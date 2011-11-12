using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;


namespace sharpLog
{
    public class LogManager
    {
        private FileManager fileManager;
        private Int32 dayInterval;
        private DateTime archiveDate;
        private String fileName;
        private String path;


        //CONSTRUCTEURS
        public LogManager()
        {           
             this.archiveDate = new DateTime();
             this.fileName = "Default";
             this.fileManager = new FileManager(this.fileName);
        }

        public LogManager(String fileName)
        {
            this.archiveDate = new DateTime();
            this.dayInterval = 0;
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
            this.path = null;
          
        }

        public LogManager(String fileName, Int32 dayInterval)
        {
            this.dayInterval = dayInterval;
            this.archiveDate = DateTime.Now.AddDays(dayInterval);
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
            this.archiveFile();
            this.path = null;
            this.setSettings();
        }

        public LogManager(String fileName, String path)
        {
            this.archiveDate = new DateTime();
            this.dayInterval = 0;
            this.fileName = fileName;
            this.path = path;
            this.fileManager = new FileManager(this.fileName, this.path);
            
        }

        public LogManager(String fileName, Int32 dayInterval, String path)
        {
            this.dayInterval = dayInterval;
            this.archiveDate = DateTime.Now.AddDays(dayInterval);
            this.fileName = fileName;
            this.path = path;
            this.fileManager = new FileManager(this.fileName, this.path);
            this.setSettings();
        }




        //METHODES
        public void logEvent(String id, String eventContent)
        {
            this.archiveFile();
            this.fileManager.writeInFile(id, eventContent);
        }

        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager otherFile = new FileManager(fileName);
            otherFile.writeInFile(id, eventContent);
        }

        public void logEvent(String id, String eventContent, String fileName, Boolean samePath)
        {
            this.archiveFile();
            if (samePath)
            {
                FileManager otherFile = new FileManager(fileName, this.path);
                otherFile.writeInFile(id, eventContent);
            }
            else
            {
                FileManager otherFile = new FileManager(fileName);
                otherFile.writeInFile(id, eventContent);
            }
        }

        public void logException(String id, Exception ex)
        {
            this.archiveFile();
            this.fileManager.writeInFile(id, ex);
        }

        //A check...
        public void setSettings()
        {
            if (log.Default.file.Equals(this.fileName))
            {
                this.archiveDate = log.Default.archiveDate;
                this.path = log.Default.path;
                this.dayInterval = log.Default.interval;
            }
            else
            {
                log.Default.file = this.fileName;
                if (this.path != null)
                    log.Default.path = this.path;
                log.Default.interval = this.dayInterval;
                log.Default.archiveDate = this.archiveDate;
                log.Default.Save();
            }
        }


        //ARCHIVAGE

        //Sauvegarder la date d'archivage en dur
        public void archiveFile()
        {       
            if (File.Exists(String.Format("{0}.txt", this.fileName)) && this.archiveDate <= DateTime.Now)
            {
                try
                {
                    if (this.path == null)
                    {
                        String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", this.fileName, DateTime.Now);
                        File.Move(String.Format("{0}.txt", this.fileName), archiveName);
                    }
                    else
                    {
                        String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", this.fileName, DateTime.Now);
                        File.Move(String.Format("{0}{1}.txt", this.path, this.fileName), String.Format("{0}{1}.txt", this.path, archiveName));
                    }

                    this.archiveDate = DateTime.Now.AddDays(this.dayInterval);
                }
                catch (Exception ex)
                {
                   //Faire quelque chose si le fichier d'archive existe déjà
                }

            }
        }

        //RECHERCHE DANS LES LOGS
        public List<String> getFilesAndArchives(String fileName)
        {
            List<String> fileList = new List<String>();
            Regex fileReg = new Regex(String.Format(@"\\{0}\w*\.txt$", fileName));

            //Peut-être changer le répertoire ? en laissant la possibilité à l'utilisateur de le spécifier
            foreach (string sFileName in System.IO.Directory.GetFiles("."))
            {
                if (fileReg.IsMatch(sFileName))
                {
                    fileList.Add(sFileName);
                }
            }
            return fileList;
        }

        public List<String> getLogs(DateTime start, DateTime end, String id = null)
        {
            List<String> logList = new List<String>();
            List<String> fileList = getFilesAndArchives(this.fileName);
            DateTime logDate = new DateTime();
            Regex regDate = new Regex(@"^\d{2}\/\d{2}\/\d{4}\s\d{2}:\d{2}:\d{2}");
            Regex regLine = new Regex(@"^\d{2}\/\d{2}\/\d{4}\s\d{2}:\d{2}:\d{2}\s\-\s"+id);
                

            //Récupère les logs entre deux dates
            foreach (String fName in fileList)
            {
                using(StreamReader streamR = new StreamReader(fName))
                {
                    string line = streamR.ReadLine();
                    while (line != null)
                    {
                        logDate = DateTime.Parse(regDate.Match(line).ToString());

                        if (logDate > start && logDate < end && id == null)
                            logList.Add(line);
                        else if (logDate > start && logDate < end && !id.Equals(null))
                        {
                            if (regLine.IsMatch(line))
                                logList.Add(line);
                        }
                        line = streamR.ReadLine();
                    }
                    streamR.Close();
                }

            }

            foreach (String s in logList)
                Console.WriteLine(s);
            return logList;
        }

    }
}
