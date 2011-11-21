using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace sharpLog
{
    [Serializable]

    class ArchiveConfig
    {
        String fileName;
        String path;
        Int32 dInterval;
        DateTime nArchiveDate;

        public ArchiveConfig(String fileName)
        {
            this.fileName = fileName;
            this.path = null;
            this.dInterval = 0;
            this.nArchiveDate = new DateTime();
        }

        public ArchiveConfig(String fileName, String path)
        {
            this.fileName = fileName;
            this.path = path;
            this.dInterval = 0;
            this.nArchiveDate = new DateTime();
        }

        public ArchiveConfig(String fileName, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = null;
            this.dInterval = dayInterval;
            this.nArchiveDate = DateTime.Now.AddDays(dayInterval);
        }

        public ArchiveConfig(String fileName, String path, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = path;
            this.dInterval = dayInterval;
            this.nArchiveDate = DateTime.Now.AddDays(dayInterval);
        }

        public void updateNextArchiveDate()
        {
            this.nArchiveDate = this.nArchiveDate.AddDays(this.dInterval);
        }

        public Int32 dayInterval
        {
            get { return this.dInterval; }
            set { this.dInterval = value; }
        }

        public DateTime nextArchiveDate
        {
            get { return this.nArchiveDate; }
        }
    }
}
