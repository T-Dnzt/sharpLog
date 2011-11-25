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

        public ArchiveManager(String fileName) : this(fileName, null, 0) { }

        public ArchiveManager(String fileName, String path) : this(fileName, path, 0) { }

        public ArchiveManager(String fileName, Int32 dayInterval) : this(fileName, null, dayInterval) { }
     
        public ArchiveManager(String fileName, String path, Int32 dayInterval)
        {
            this.fileName = fileName;
            this.path = path;
            checkArchiveConfig(dayInterval);
            saveArchiveConfig();
        } 

        //Méthodes
        //A CHECK
        public void checkArchiveConfig(Int32 dayInterval)
        {
            if (dayInterval <= 0)
            {
                if (File.Exists(String.Format("{0}{1}.conf", this.path, this.fileName)))
                {
                    this.archiveConfig = getArchiveConfig();
                    archiveFile();
                }
                else
                    this.archiveConfig = new ArchiveConfig(this.fileName);
            }
            else
            {
                if (File.Exists(String.Format("{0}{1}.conf", this.path, this.fileName)))
                {
                    this.archiveConfig = getArchiveConfig();
                    archiveFile();
                }
                else
                {
                    if (String.IsNullOrEmpty(this.path))
                        this.archiveConfig = new ArchiveConfig(this.fileName);
                    else
                        this.archiveConfig = new ArchiveConfig(this.fileName, this.path);
                    setArchivage(dayInterval);
                }
                saveArchiveConfig();
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
            serializer.SerializeArchiveConfig(String.Format("{0}{1}", this.path, this.fileName), this.archiveConfig);
        }

        private ArchiveConfig getArchiveConfig()
        {
            Serializer serializer = new Serializer();
            return serializer.DeSerializeArchiveConfig(String.Format("{0}{1}", this.path, this.fileName));
        }


        public void archiveFile()
        {
            Console.WriteLine("Prochaine date : " + this.archiveConfig.nextArchiveDate);
            Console.WriteLine("Date actuelle : " + DateTime.Now);
            Console.WriteLine(this.archiveConfig.nextArchiveDate >= DateTime.Now);
            if (File.Exists(String.Format("{0}{1}.txt", this.path, this.fileName)) && this.archiveConfig.nextArchiveDate <= DateTime.Now.AddDays(8))
            {
                try
                {
                    String archiveName = String.Format("{0}_archive_{1:yyyy_M_dd}.txt", this.fileName, DateTime.Now);
                    File.Move(String.Format("{0}{1}.txt", this.path, this.fileName), String.Format("{0}{1}.txt", this.path, archiveName));
                    this.archiveConfig.updateNextArchiveDate();
                    Console.WriteLine("Apres archivage : " + this.archiveConfig.nextArchiveDate);
                }
                catch (Exception ex)
                {
                    //Si l'archive existe déjà
                }

            }
        }
    }
}




/*
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
*/
