using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sharpLog;
using System.Threading;
using System.IO;

namespace application_test
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager lm = new LogManager("fu", DateTime.Now);
            // LogManager f = new LogManager("fu");
            lm.logEvent("Programme principal", "Erreur 1553");
            

           // lm.logEvent("Programme secondaire", "Erreur 7", "Test2");
          // ThreadTest tt = new ThreadTest(lm);

            /*try
            {
                StreamReader sr = System.IO.File.OpenText("test");         
            }
            catch (Exception err)
            {
                lm.logException("Programme principal", err);
            }*/

        }

      
    }
}
