using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace sharpLog
{
    /// <summary>
    /// This static class is used to save or load the ArchiveConfig object.
    /// </summary>
    static class Serializer
    {
        /// <summary>
        /// Save the ArchiveConfig specified
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        /// <param name="archiveConf">Object to serialize</param>
        static public void SerializeArchiveConfig(String filename, ArchiveConfig archiveConf)
        {
            Stream stream = File.Open(String.Format("{0}.conf", filename), FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, archiveConf);
            stream.Close();
        }

        /// <summary>
        /// Load the ArchiveConfig object
        /// </summary>
        /// <param name="fileName">Name of the log file</param>
        static public ArchiveConfig DeSerializeArchiveConfig(string filename)
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
