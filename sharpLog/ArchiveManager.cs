using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace sharpLog
{
    class ArchiveManager
    {
        private String fileName;
        private String path;
        private ArchiveConfig archiveConfig;


        //Constructeurs
        public ArchiveManager(String fileName)
        {
            this.fileName = fileName;
            this.path = null;
            checkArchiveConfig();
        }

        public ArchiveManager(String fileName, String path)
        {
            this.fileName = fileName;
            this.path = path;
            checkArchiveConfig();
        }

        public ArchiveManager(String fileName, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = null;
            checkArchiveConfig(dayInterval);
            saveArchiveConfig();
        }

        public ArchiveManager(String fileName,  String path, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = path;
            checkArchiveConfig(dayInterval);
            saveArchiveConfig();
        }
       

        //Méthodes
        public void checkArchiveConfig()
        {
            if (File.Exists(String.Format("{0}{1}.conf", this.path, this.fileName)))
                this.archiveConfig = getArchiveConfig();
            else
                this.archiveConfig = new ArchiveConfig(this.fileName);
        }

        public void checkArchiveConfig(Int32 dayInterval)
        {
            if (File.Exists(String.Format("{0}{1}.conf", this.path, this.fileName)))
                this.archiveConfig = getArchiveConfig();
            else
            {
                this.archiveConfig = new ArchiveConfig(this.fileName);
                setArchivage(dayInterval);
            }
        }

        public void setArchivage(Int32 dayInterval)
        {
            if (String.IsNullOrEmpty(this.path))
                this.archiveConfig = new ArchiveConfig(this.fileName, dayInterval);
            else
                this.archiveConfig = new ArchiveConfig(this.fileName, this.path, dayInterval);
        }

        public void changeDayInterval(Int32 dayInterval)
        {
            this.archiveConfig.dayInterval = dayInterval;
        }

        private void saveArchiveConfig()
        {
            Serializer serializer = new Serializer();
            serializer.SerializeArchiveConfig(this.fileName, this.archiveConfig);
        }

        private ArchiveConfig getArchiveConfig()
        {
            Serializer serializer = new Serializer();
            return serializer.DeSerializeArchiveConfig(this.fileName);
        }


        public void archiveFile()
        {
            if (File.Exists(String.Format("{0}{1}.txt", this.path, this.fileName)) && this.archiveConfig.nextArchiveDate >= DateTime.Now)
            {
                try
                {
                    String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", this.fileName, DateTime.Now);
                    File.Move(String.Format("{0}{1}.txt", this.path, this.fileName), String.Format("{0}{1}.txt", this.path, archiveName));
                    this.archiveConfig.updateNextArchiveDate();
                }
                catch (Exception ex)
                {
                    //si le fichier d'archive existe déjà
                }

            }
        }
    }
}
