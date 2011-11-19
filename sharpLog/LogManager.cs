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
        private String fileName;
        private String path;
        private ArchiveManager archiveManager;


        //CONSTRUCTEURS
        public LogManager(String fileName)
        {         
            this.fileName = fileName;
            this.path = null;
            this.fileManager = new FileManager(this.fileName);
            this.archiveManager = null;
            this.path = null;     
        }

        public LogManager(String fileName, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = null;
            this.fileManager = new FileManager(this.fileName);
            this.archiveManager = new ArchiveManager(this.fileName, dayInterval);
            
        }

        public LogManager(String fileName, String path)
        {
            this.fileName = fileName;
            this.path = path;
            this.fileManager = new FileManager(this.fileName, this.path);
            this.archiveManager = null;
         
        }

        public LogManager(String fileName, Int32 dayInterval, String path)
        {
            this.fileName = fileName;
            this.path = path;
            this.fileManager = new FileManager(this.fileName, this.path);
            this.archiveManager = new ArchiveManager(this.fileName, this.path, dayInterval);
        }



        //METHODES D ECRITURE
        public void logEvent(String id, String eventContent)
        {
            this.fileManager.writeInFile(id, eventContent);
        }

        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager otherFile = new FileManager(fileName);
            otherFile.writeInFile(id, eventContent);
        }

        public void logEvent(String id, String eventContent, String fileName, Boolean samePath)
        {

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
            this.fileManager.writeInFile(id, ex);
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
