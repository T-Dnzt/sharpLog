using System;
using System.Collections.Generic;
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
        /// <summary>
        /// The name of the file associated to this instance of LogManager
        /// </summary>
        private String FileName;
        /// <summary>
        /// The path to access the log file
        /// </summary>
        private String Path;
        /// <summary>
        /// An instance of the ArchiveManager to manages archivage settings.
        /// </summary>
        private ArchiveManager ArchiveManager;

        //Constructors
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
        /// <param name="dayInterval">Number of days between each archivage</param>
        public LogManager(String fileName, Int32 dayInterval) : this(fileName, null, dayInterval) { }

        /// <summary>
        /// Constructor with fileName and path. The file is created in the specified directory.
        /// No archivage is set.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        public LogManager(String fileName, String path) : this(fileName, path, 0) { }

        /// <summary>
        /// Constructor with fileName, path and dayInterval. The file is created in the specified directory, if the directory
        /// does not exist, the file is created in the same directory than the program.
        /// An archivage is set with the specified number of days.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        /// <param name="dayInterval">Number of days etween each archivage</param>
        public LogManager(String fileName, String path, Int32 dayInterval)
        {
            this.FileName = fileName;
            setPath(path);
           // this.fileManager = new FileManager(this.fileName, this.path);
            setArchiveManager(dayInterval);
        }




        //Methods
        /// <summary>
        /// Creates a new ArchiveManager or not, based on the dayInterval parameter.
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        private void setArchiveManager(Int32 dayInterval)
        {
            if (dayInterval > 0)
                this.ArchiveManager = new ArchiveManager(this.FileName, this.Path, dayInterval);
            else
                this.ArchiveManager = null;

        }

        /// <summary>
        /// Checks if the path exists, if not, the path is set to null and the file will be created in the same directory than the program.
        /// </summary>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        private void setPath(String path)
        {
            if (Directory.Exists(path))
                this.Path = path;
            else
                this.Path = null;
        }

        /// <summary>
        /// Allows to define the archivage in the current LogManager. 
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public void setArchivage(Int32 dayInterval)
        {
            if(this.ArchiveManager == null)
                this.ArchiveManager = new ArchiveManager(this.FileName, this.Path, dayInterval);
        }

        /// <summary>
        /// Allows to change the number of days between each archivage.
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public void changeDayInterval(Int32 dayInterval)
        {
            if (!this.ArchiveManager.Equals(null))
                this.ArchiveManager.changeDayInterval(dayInterval);
        }




        //Log Methods
        /// <summary>
        /// Logs an event.
        /// </summary>
        /// <param name="id">The id of the section where the event occured</param>
        /// <param name="eventContent">Text of the event</param>
        public void logEvent(String id, String eventContent)
        {
            if (!this.ArchiveManager.Equals(null))
                this.ArchiveManager.archiveFile();
            FileManager.writeInFile(id, eventContent, String.Format("{0}{1}.txt", this.Path, this.FileName));
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="id">The id of the section where the event occured</param>
        /// <param name="ex">The exception</param>
        public void logException(String id, Exception ex)
        {
            if (!this.ArchiveManager.Equals(null))
                this.ArchiveManager.archiveFile();
            FileManager.writeInFile(id, ex, String.Format("{0}{1}.txt", this.Path, this.FileName));
        }

        /// <summary>
        /// Logs an event in a different file.
        /// </summary>
        /// <param name="id">The id of the section where the event occured</param>
        /// <param name="eventContent">Text of the event</param>
        /// /// <param name="fileName">The name of the file. Have to contains the path if needed</param>
        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager.writeInFile(id, eventContent, String.Format("{0}{1}.txt", fileName));
        }



        //Search methods
        /// <summary>
        /// Gets all files, including archive, which match the param fileName.
        /// </summary>
        /// <param name="fileName">Name of the files to look for</param>
        private List<String> getFilesAndArchives(String fileName)
        {
            List<String> fileList = new List<String>();
            //Regex to get log files AND archive files (which also contain a date)
            Regex fileReg = new Regex(String.Format(@"{0}\w*\.txt$", fileName));

            //We look for all the files in the path or in the program directory
            if (!String.IsNullOrEmpty(this.Path))
            {  
                foreach (string sFileName in System.IO.Directory.GetFiles(this.Path))
                {
                    //If we have a match, we add the file name in our list
                    if (fileReg.IsMatch(sFileName))
                    {
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

        /// <summary>
        /// Gets all logs between the dates parameters.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="id">ID to look for between the two dates</param>
        public List<String> getLogs(DateTime start, DateTime end, String id = null)
        {
            List<String> logList = new List<String>();
            List<String> fileList = getFilesAndArchives(this.FileName);
            DateTime logDate = new DateTime();

            //Regex to match the dates and the id
            Regex regDate = new Regex(@"^\d{2}\/\d{2}\/\d{4}\s\d{2}:\d{2}:\d{2}");
            Regex regLine = new Regex(@"^\d{2}\/\d{2}\/\d{4}\s\d{2}:\d{2}:\d{2}\s\-\s"+id);

            foreach (String fName in fileList)
            {
                using(StreamReader streamR = new StreamReader(fName))
                {
                    string line = streamR.ReadLine();
 
                    while (line != null)
                    {
                        //We add the ligne if it matches the regex
                        try
                        {
                            logDate = DateTime.Parse(regDate.Match(line).ToString());

                            if (logDate >= start && logDate <= end && id == null)
                                logList.Add(line);
                            else if (logDate >= start && logDate <= end && !(id == null))
                            {
                                if (regLine.IsMatch(line))
                                    logList.Add(line);
                            }
                        }
                        catch (Exception ex)
                        {                        
                        }
                        finally
                        {
                            line = streamR.ReadLine();
                        }
                    }
                    streamR.Close();
                }

            }

            //Display to check the return
          /*  foreach (String s in logList)
                Console.WriteLine(s);*/
            return logList;
        }

    }
}
