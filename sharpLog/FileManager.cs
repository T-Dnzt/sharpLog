using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sharpLog
{
    class FileManager
    {
        private String fileName;

        public FileManager()
        {
            this.fileName = "Default";
        }

        public FileManager(String fileName)
        {
            this.fileName = fileName;
        }

        public void writeInFile(String content)
        {
           
        }

    }
}
