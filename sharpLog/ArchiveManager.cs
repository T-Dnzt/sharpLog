using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace sharpLog
{
    /// <summary>
    /// This class manages access to the archive configuration file and update its content if needed
    /// </summary>
    class ArchiveManager
    {
        /// <summary>Name of the log file</summary>
        private String FileName;

        /// <summary>The path to access the log file</summary>
        private String Path;

        /// <summary>Instance of the class ArchiveConfig used to save archivage settings</summary>
        private ArchiveConfig ArchiveConfig;

        /// <summary>
        /// Creates an ArchiveManager object. This class manages access to archivage settings.
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="path">The path of the directory where the log file is saved</param>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public ArchiveManager(String fileName, String path, Int32 dayInterval)
        {
            this.FileName = fileName;
            this.Path = path;
            setArchiveConfig(dayInterval);
            saveArchiveConfig();
        } 

        //Public Methods
        /// <summary>
        /// Changes the number of days between each archivage
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public void changeDayInterval(Int32 dayInterval)
        {
            this.ArchiveConfig.DayInterval = dayInterval;
            saveArchiveConfig();
        }

        /// <summary>
        /// Create an archive of the current log file and update the next archive date
        /// </summary>
        public void archiveFile()
        {

            if (File.Exists(String.Format("{0}{1}.txt", this.Path, this.FileName)) && this.ArchiveConfig.NextArchiveDate <= DateTime.Now)
            {
                try
                {
                    String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", this.FileName, DateTime.Now);
                    File.Move(String.Format("{0}{1}.txt", this.Path, this.FileName), String.Format("{0}{1}.txt", this.Path, archiveName));
                    this.ArchiveConfig.updateNextArchiveDate();
                }
                catch (Exception ex)
                { }
            }
        }


        //Private Methods
        /// <summary>
        /// Checks if there is already a configuration file for this log file or not.
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        private void setArchiveConfig(Int32 dayInterval)
        {
            if (File.Exists(String.Format("{0}{1}.conf", this.Path, this.FileName)))
            {
                this.ArchiveConfig = getArchiveConfig();
                archiveFile();
            }
            else
            {
                this.ArchiveConfig = new ArchiveConfig(this.FileName, this.Path, dayInterval);
                saveArchiveConfig();
            }
        }

        /// <summary>
        /// Saves the archivage configuration
        /// </summary>
        private void saveArchiveConfig()
        {
            Serializer.SerializeArchiveConfig(String.Format("{0}{1}", this.Path, this.FileName), this.ArchiveConfig);
        }

        /// <summary>
        /// Loads the archivage configuration
        /// </summary>
        private ArchiveConfig getArchiveConfig()
        {
            return Serializer.DeSerializeArchiveConfig(String.Format("{0}{1}", this.Path, this.FileName));
        }   
    }
}
