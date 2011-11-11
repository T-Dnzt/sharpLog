using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace sharpLog
{
    public class LogManager
    {
        private FileManager fileManager;
        private DateTime archiveDate;
        private String fileName;

        public LogManager()
        {           
             this.archiveDate = new DateTime();
             this.fileName = "Default";
             this.fileManager = new FileManager(this.fileName);
        }


        public LogManager(String fileName)
        {          
            this.archiveDate = new DateTime();
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
        }


        public LogManager(String fileName, DateTime archiveDate)
        {
            this.archiveDate = archiveDate;
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
            this.archiveFile(String.Format("{0}", fileName));
        }


        public LogManager(String fileName, int daysBeforeArchivage)
        {
            this.archiveDate = DateTime.Now.AddDays(daysBeforeArchivage);
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
            this.archiveFile(String.Format("{0}", fileName));
        }


        public void logEvent(String id, String eventContent)
        {
            this.archiveFile(String.Format("{0}", fileName));
            this.fileManager.writeInFile(id, eventContent);
        }


        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager otherFile = new FileManager(fileName);
            otherFile.writeInFile(id, eventContent);
        }


        public void logException(String id, Exception ex)
        {
            this.fileManager.writeInFile(id, ex);
        }




        //ARCHIVAGE

        //Sauvegarder la date d'archivage en dur
        public void archiveFile(String fileName)
        {       
            if (File.Exists(String.Format("{0}.txt", fileName)) && this.archiveDate <= DateTime.Now)
            {
                try
                {
                    String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", fileName, DateTime.Now);
                    File.Move(String.Format("{0}.txt", fileName), archiveName);
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
            Regex fileReg = new Regex(String.Format(@"^\.\\{0}\w*\.txt$", fileName));

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
                try
                {
                    StreamReader streamR = new StreamReader(fName);
                    string line = streamR.ReadLine();

                    while (line != null)
                    {
                        logDate = DateTime.Parse(regDate.Match(line).ToString());

                        if (logDate > start && logDate < end && id == null)
                            logList.Add(line);
                        else if (logDate > start && logDate < end && !id.Equals(null))
                        {
                            if(regLine.IsMatch(line))
                                logList.Add(line);
                        }

                        line = streamR.ReadLine();
                    }
                    streamR.Close();
                
                catch (Exception ex)
                {
                    //A définir
                }

            }

            return logList;
        }

    }
}
