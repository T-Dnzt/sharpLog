using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace sharpLog
{
    class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeArchiveConfig(String filename, ArchiveConfig archiveConf)
        {
            Stream stream = File.Open(String.Format("{0}.conf", filename), FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, archiveConf);
            stream.Close();
        }

        public ArchiveConfig DeSerializeArchiveConfig(string filename)
        {
            ArchiveConfig archiveConf;
            Stream stream = File.Open(String.Format("{0}.conf", filename), FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            archiveConf = (ArchiveConfig)bFormatter.Deserialize(stream);
            stream.Close();
            return archiveConf;
        }
    }
}
