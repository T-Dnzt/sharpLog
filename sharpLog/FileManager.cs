using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace sharpLog
{
    class FileManager
    {
        private String fileName;
        private String path;
        static Mutex mut = new Mutex();

        public FileManager()
        {
            this.fileName = "Default.txt";
        }

        public FileManager(String fileName)
        {
            this.fileName = String.Format("{0}.txt", fileName);
            this.path = null;
        }

        public FileManager(String fileName, String path)
        {
            this.fileName = String.Format("{0}.txt", fileName);
            this.path = path;
        }

        public void writeInFile(String id, String content)
        {
            mut.WaitOne();    
            using (StreamWriter w = File.AppendText(String.Format("{0}{1}", this.path, this.fileName)))
            {
                w.WriteLine(String.Format("{0} - {1} : {2}", DateTime.Now, id, content));
                w.Flush();
                w.Close();
            }
            mut.ReleaseMutex();
        }

        public void writeInFile(String id, Exception ex)
        {
            mut.WaitOne();
            using (StreamWriter w = File.AppendText(this.fileName))
            {
                w.WriteLine(String.Format("{0} - Exception in {1} : {2}", DateTime.Now, id, ex.ToString()));
                w.Flush();
                w.Close();
            }
            mut.ReleaseMutex();
        }

    }
}
