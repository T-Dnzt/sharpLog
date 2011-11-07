using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sharpLog;

namespace application_test
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager lm = new LogManager("fu");
            lm.logEvent("Programme principal", "Erreur 1553");
            lm.logEvent("Programme secondaire", "Erreur 7", "Test2");


        }
    }
}
