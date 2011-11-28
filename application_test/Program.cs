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
            LogManager lm = new LogManager("f", @"C:\Users\Thibault\Documents\Logs\", 3);
          
            

            //LogManager lm2 = new LogManager("log");
            // LogManager f = new LogManager("fu");
            /*lm.logEvent("Programme principal", "Erreur 7");
            lm.logEvent("Programme secondaire", "Erreur 0");
            lm.logEvent("Programme principal", "Nlkd,qds");
            lm.logEvent("Programme principal", "kdjzalmk");
            lm.logEvent("Programme principal", "Rhaaaa");*/

            //Test de la recherche
            
            DateTime now = new DateTime(2011,11,27,16,36,45);
            DateTime end = now.AddMinutes(10);
            lm.getLogs(now, end);
            
            //lm.getLogs(now, end, "Programme secondaire");
            

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
