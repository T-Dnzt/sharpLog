using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;


namespace sharpLog
{
    /// <summary>
    ///  The LogManager class is used to access the log library. Thanks to this class, you can manage your logs, 
    ///  the number of days between archivage, and search for data inside your log files.
    /// </summary>
    public class LogManager
    {

        private FileManager fileManager;
        private String fileName;
        private String path;
        private ArchiveManager archiveManager;



        /// <summary>
        /// Constructor with fileName. The file is created in the same directory
        /// than the program. No archivage is set since the day between archivage is not set.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        public LogManager(String fileName) : this(fileName, null, 0) { }

        /// <summary>
        /// Constructor with fileName and dayInterval. The file is created in the same directory
        /// than the program. An archivage is set with the specified number of days.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="dayInterval">Number of days between archivage</param>
        public LogManager(String fileName, Int32 dayInterval) : this(fileName, null, dayInterval) { }


        /// <summary>
        /// Constructor with fileName and dayInterval. The file is created in the specified directory.
        /// No archivage is set.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where you want to save the log file</param>
        public LogManager(String fileName, String path) : this(fileName, path, 0) { }

        /// <summary>
        /// Constructor with fileName and dayInterval. The file is created in the specified directory, if the directory
        /// does not exist, the file is created in the same directory than the program.
        /// An archivage is set with the specified number of days.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where you want to save the log file</param>
        /// <param name="dayInterval">Number of days between archivage</param>
        public LogManager(String fileName, String path, Int32 dayInterval)
        {
            this.fileName = fileName;
            setPath(path);
            this.fileManager = new FileManager(this.fileName, this.path);
            setArchiveManager(dayInterval);
        }






        private void setArchiveManager(Int32 dayInterval)
        {
            if (dayInterval > 0)
                this.archiveManager = new ArchiveManager(this.fileName, this.path, dayInterval);
            else
                this.archiveManager = null;

        }

        private void setPath(String path)
        {
            if (Directory.Exists(path))
                this.path = path;
            else
                this.path = null;
        }

        public void setArchivage(Int32 dayInterval)
        {
            if(!this.archiveManager.Equals(null))
                this.archiveManager.setArchivage(dayInterval);
        }

        public void changeDayInterval(Int32 dayInterval)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.changeDayInterval(dayInterval);
        }

        //METHODES D ECRITURE
        public void logEvent(String id, String eventContent)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.archiveFile();
            this.fileManager.writeInFile(id, eventContent);
        }

        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager otherFile = new FileManager(fileName);
            otherFile.writeInFile(id, eventContent);
        }

        public void logException(String id, Exception ex)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.archiveFile();
            this.fileManager.writeInFile(id, ex);
        }    

        //RECHERCHE DANS LES LOGS
        public List<String> getFilesAndArchives(String fileName)
        {
            List<String> fileList = new List<String>();
            Regex fileReg = new Regex(String.Format(@"{0}\w*\.txt$", fileName));

            
     
            if (!String.IsNullOrEmpty(this.path))
            {
                
                foreach (string sFileName in System.IO.Directory.GetFiles(this.path))
                {
                    Console.WriteLine(sFileName);
                    Console.WriteLine(fileReg.IsMatch(sFileName));
                    if (fileReg.IsMatch(sFileName))
                    {
                        Console.WriteLine(sFileName);
                        fileList.Add(sFileName);
                    }
                }
            }
            else
            {
                foreach (string sFileName in System.IO.Directory.GetFiles("."))
                {
                    if (fileReg.IsMatch(sFileName))
                    {
                        fileList.Add(sFileName);
                    }
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
                Console.WriteLine(fName);
                using(StreamReader streamR = new StreamReader(fName))
                {
                    string line = streamR.ReadLine();
                    while (line != null)
                    {
                        logDate = DateTime.Parse(regDate.Match(line).ToString());
                        Console.WriteLine(line);
                        if (logDate >= start && logDate <= end && id == null)
                            logList.Add(line);
                        else if (logDate >= start && logDate <= end && !id.Equals(null))
                        {
                            if (regLine.IsMatch(line))
                                logList.Add(line);
                        }
                        line = streamR.ReadLine();
                    }
                    streamR.Close();
                }

            }

            Console.WriteLine("fu");
            foreach (String s in logList)
                Console.WriteLine(s);
            return logList;
        }

    }
}




//CONSTRUCTEURS
/*
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
      checkPath(path);
      this.fileManager = new FileManager(this.fileName, this.path);
      this.archiveManager = null;
         
  }

  public LogManager(String fileName, String path, Int32 dayInterval)
  {
      this.fileName = fileName;
      checkPath(path);
      this.fileManager = new FileManager(this.fileName, this.path);
      this.archiveManager = new ArchiveManager(this.fileName, this.path, dayInterval);
  }

  */