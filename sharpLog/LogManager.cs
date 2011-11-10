using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            this.archiveFile(String.Format("{0}.txt", fileName));
        }

        public LogManager(String fileName, int daysBeforeArchivage)
        {
            this.archiveDate = DateTime.Now.AddDays(daysBeforeArchivage);
            this.fileName = fileName;
            this.fileManager = new FileManager(this.fileName);
            this.archiveFile(String.Format("{0}.txt", fileName));
        }

        public void logEvent(String id, String eventContent)
        {
            this.archiveFile(String.Format("{0}.txt", fileName));
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

        public void archiveFile(String fileName)
        {
            String archiveName = "fu_archive_MAIS_FUCK.txt";
            if (this.archiveDate <= DateTime.Now)
                File.Move(fileName, archiveName);
        }
    }
}
