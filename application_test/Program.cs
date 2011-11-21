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
            LogManager lm = new LogManager("Testdefifou", @"C:\C:\Users\Thibault\Documents\Logs\", 3);
            

            //LogManager lm2 = new LogManager("log");
            // LogManager f = new LogManager("fu");
            lm.logEvent("Programme principal", "Erreur 7");
            lm.logEvent("Programme secondaire", "Erreur 0");


            //Test de la recherche
            /*
            DateTime now = new DateTime(2011,11,11,16,51,5);
            DateTime end = now.AddMinutes(3);
            lm.getLogs(now, end);
            Console.WriteLine();
            lm.getLogs(now, end, "Programme secondaire");
            */

            // lm.logEvent("Programme secondaire", "Erreur 7", "Test2");
          //ThreadTest tt = new ThreadTest(lm);

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
