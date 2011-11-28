using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace sharpLog
{
    /// <summary>
    /// This static class manages access and writing in log files.
    /// </summary>
    static class FileManager
    {
        /// <summary>
        /// We use a mutex to prevent two logger to access the same file at the same time
        /// </summary>
        static Mutex Mut = new Mutex();

        /// <summary>
        /// Logs the content in the file fileName with the specified id
        /// </summary>
        /// <param name="id">The id of the section where the event occured</param>
        /// <param name="content">What will be logged</param>
        /// <param name="fileName">Name of the log file</param>
        static public void writeInFile(String id, String content, String fileName)
        {
            Mut.WaitOne();    
            using (StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(String.Format("{0} - {1} : {2}", DateTime.Now, id, content));
                w.Flush();
                w.Close();
            }
            Mut.ReleaseMutex();
        }

        /// <summary>
        /// Logs the exception in the file fileName with the specified id
        /// </summary>
        /// <param name="id">The id of the section where the event occured</param>
        /// <param name="ex">Exception to log</param>
        /// <param name="fileName">Name of the log file</param>
        static public void writeInFile(String id, Exception ex, String fileName)
        {
            Mut.WaitOne();
            using (StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(String.Format("{0} - {1} : Exception - {2}", DateTime.Now, id, ex.ToString()));
                w.Flush();
                w.Close();
            }
            Mut.ReleaseMutex();
        }

    }
}
