using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Console.WriteLine("lol");
        }

        public LogManager(String fileName, DateTime archiveDate)
        {
            this.archiveDate = archiveDate;
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
        }

        public LogManager(String fileName, int daysBeforeArchivage)
        {
            this.archiveDate = DateTime.Now.AddDays(daysBeforeArchivage);
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
        }

        public void logEvent(String id, String eventContent)
        {
            
        }

        public void logEvent(String id, String eventContent, String fileName)
        {

        }
    }
}
