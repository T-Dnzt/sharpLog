using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using sharpLog;

namespace application_test
{
    class ThreadTest
    {
        private LogManager lm;
        private Thread thread1;
        private Thread thread2;


         public ThreadTest(LogManager lm)
         {
             this.lm = lm;

             this.thread1 = new Thread(testThread1);
             this.thread2 = new Thread(testThread2);

             this.thread1.Start();
             this.thread2.Start();
         }


        private void testThread1()
        {
            LogManager lfdsf = new LogManager("fu");
            lfdsf.logEvent("Programme principal", "1");
        }

        private void testThread2()
        {
            this.lm.logEvent("Programme secondaire", "2");
        }
    }

   
}
