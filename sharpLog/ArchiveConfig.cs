using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace sharpLog
{
    [Serializable]

    /// <summary>
    /// This class contains the archivage settings. We will serialize it to save archivage settings.
    /// </summary>
    class ArchiveConfig
    {
        /// <summary> Name of the log file </summary>
        private String FileName;

        /// <summary>Name of the log file </summary>
        private String Path;

        /// <summary>Number of days between each archivage </summary>
        public Int32 DayInterval
        { get; set; }

        /// <summary>Date of the next archivage </summary>
        public DateTime NextArchiveDate
        { get; set; }

        /// <summary>
        /// Creates an ArchiveConfig object which represents archivage settings. 
        /// The file will be saved in the path directory if not null. If the directory
        /// does not exist, the file is created in the same directory than the program.
        /// An archivage is set with the specified number of days.
        /// </summary>
        /// <param name="fileName">Name of the configuration file</param>
        /// <param name="path">The path of the directory where the configuration file will be saved</param>
        /// <param name="dayInterval">Number of days between each archivage</param>
        public ArchiveConfig(String fileName, String path, Int32 dayInterval)
        {
            this.FileName = fileName;
            this.Path = path;
            this.DayInterval = dayInterval;
            setNextArchiveDate(this.DayInterval);
        }

        /// <summary>
        /// Determines the next archive date if needed
        /// </summary>
        /// <param name="dayInterval">Number of days between each archivage</param>
        private void setNextArchiveDate(Int32 dayInterval)
        {
            if(dayInterval > 0)
               this.NextArchiveDate = DateTime.Now.AddDays(dayInterval);
            else
                this.NextArchiveDate = new DateTime();
        }

        /// <summary>
        /// Adds the DayInterval value to the NextArchiveDate
        /// </summary>
        public void updateNextArchiveDate()
        {
            this.NextArchiveDate = this.NextArchiveDate.AddDays(this.DayInterval);
        }
    }
}


