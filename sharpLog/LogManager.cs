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
        /// <summary>
        /// The fileManager manages the writting part of the log.
        /// </summary>
        private FileManager fileManager;

        /// <summary>
        /// The fileName is the name of the log file.
        /// </summary>
        private String fileName;

        /// <summary>
        /// The path of the directory where the log file is saved.
        /// </summary>
        private String path;

        /// <summary>
        /// The archiveManager manages settings and access to the archive files.
        /// </summary>
        private ArchiveManager archiveManager;


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
        /// Constructor with fileName and dayInterval. The file is created in the specified directory.
        /// No archivage is set.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        public LogManager(String fileName, String path) : this(fileName, path, 0) { }

        /// <summary>
        /// Constructor with fileName and dayInterval. The file is created in the specified directory, if the directory
        /// does not exist, the file is created in the same directory than the program.
        /// An archivage is set with the specified number of days.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public LogManager(String fileName, String path, Int32 dayInterval)
        {
            this.fileName = fileName;
            setPath(path);
            this.fileManager = new FileManager(this.fileName, this.path);
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
                this.archiveManager = new ArchiveManager(this.fileName, this.path, dayInterval);
            else
                this.archiveManager = null;

        }

        /// <summary>
        /// Checks if the path exists, if not, the path is set to null and the file will be created in the same directory than the program.
        /// </summary>
        /// <param name="path">The path of the directory where the log file will be saved</param>
        private void setPath(String path)
        {
            if (Directory.Exists(path))
                this.path = path;
            else
                this.path = null;
        }

        /// <summary>
        /// Allows to define the archivage in the current LogManager. 
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public void setArchivage(Int32 dayInterval)
        {
            if(!this.archiveManager.Equals(null))
                this.archiveManager.setArchivage(dayInterval);
        }

        /// <summary>
        /// Allows to change the number of days between each archivage.
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public void changeDayInterval(Int32 dayInterval)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.changeDayInterval(dayInterval);
        }




        //Log Methods
        /// <summary>
        /// Logs an event.
        /// </summary>
        /// <param name="id">The id of the element where the event occured</param>
        /// <param name="eventContent">Text of the event</param>
        public void logEvent(String id, String eventContent)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.archiveFile();
            this.fileManager.writeInFile(id, eventContent);
        }

        /// <summary>
        /// Logs an event in a different file.
        /// </summary>
        /// <param name="id">The id of the element where the event occured</param>
        /// <param name="eventContent">Text of the event</param>
        /// /// <param name="fileName">The name of the file. Have to contains the path if needed</param>
        public void logEvent(String id, String eventContent, String fileName)
        {
            FileManager otherFile = new FileManager(fileName);
            otherFile.writeInFile(id, eventContent);
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="id">The id of the element where the event occured</param>
        /// <param name="ex">The exception</param>
        public void logException(String id, Exception ex)
        {
            if (!this.archiveManager.Equals(null))
                this.archiveManager.archiveFile();
            this.fileManager.writeInFile(id, ex);
        }    

        


        //Search methods
        /// <summary>
        /// Gets all files, including archive, which match the param fileName.
        /// </summary>
        /// <param name="fileName">Name of the files to look for</param>
        public List<String> getFilesAndArchives(String fileName)
        {
            List<String> fileList = new List<String>();
            //Regex to get log files AND archive files (which also contain a date)
            Regex fileReg = new Regex(String.Format(@"{0}\w*\.txt$", fileName));

            //We look for all the files in the path or in the program directory
            if (!String.IsNullOrEmpty(this.path))
            {  
                foreach (string sFileName in System.IO.Directory.GetFiles(this.path))
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
            List<String> fileList = getFilesAndArchives(this.fileName);
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
                        logDate = DateTime.Parse(regDate.Match(line).ToString());
                
                        if (logDate >= start && logDate <= end && id.Equals(null))
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

            //Display to check errors
            foreach (String s in logList)
                Console.WriteLine(s);
            return logList;
        }

    }
}
