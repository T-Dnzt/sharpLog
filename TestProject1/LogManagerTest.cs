using sharpLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///Classe de test pour LogManagerTest, destinée à contenir tous
    ///les tests unitaires LogManagerTest
    ///</summary>
    [TestClass()]
    public class LogManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test pour setPath
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void setPathTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            LogManager_Accessor target = new LogManager_Accessor(param0); // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            target.setPath(path);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour setArchiveManager
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void setArchiveManagerTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            LogManager_Accessor target = new LogManager_Accessor(param0); // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            target.setArchiveManager(dayInterval);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour setArchivage
        ///</summary>
        [TestMethod()]
        public void setArchivageTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            target.setArchivage(dayInterval);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour logException
        ///</summary>
        [TestMethod()]
        public void logExceptionTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            Exception ex = null; // TODO: initialisez à une valeur appropriée
            target.logException(id, ex);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour logEvent
        ///</summary>
        [TestMethod()]
        public void logEventTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            string eventContent = string.Empty; // TODO: initialisez à une valeur appropriée
            target.logEvent(id, eventContent);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour logEvent
        ///</summary>
        [TestMethod()]
        public void logEventTest1()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            string eventContent = string.Empty; // TODO: initialisez à une valeur appropriée
            string fileName1 = string.Empty; // TODO: initialisez à une valeur appropriée
            target.logEvent(id, eventContent, fileName1);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour getLogs
        ///</summary>
        [TestMethod()]
        public void getLogsTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            DateTime start = new DateTime(); // TODO: initialisez à une valeur appropriée
            DateTime end = new DateTime(); // TODO: initialisez à une valeur appropriée
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            List<string> expected = null; // TODO: initialisez à une valeur appropriée
            List<string> actual;
            actual = target.getLogs(start, end, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour getFilesAndArchives
        ///</summary>
        [TestMethod()]
        public void getFilesAndArchivesTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            string fileName1 = string.Empty; // TODO: initialisez à une valeur appropriée
            List<string> expected = null; // TODO: initialisez à une valeur appropriée
            List<string> actual;
            actual = target.getFilesAndArchives(fileName1);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour changeDayInterval
        ///</summary>
        [TestMethod()]
        public void changeDayIntervalTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName); // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            target.changeDayInterval(dayInterval);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour Constructeur LogManager
        ///</summary>
        [TestMethod()]
        public void LogManagerConstructorTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName, dayInterval);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour Constructeur LogManager
        ///</summary>
        [TestMethod()]
        public void LogManagerConstructorTest1()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour Constructeur LogManager
        ///</summary>
        [TestMethod()]
        public void LogManagerConstructorTest2()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName, path);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour Constructeur LogManager
        ///</summary>
        [TestMethod()]
        public void LogManagerConstructorTest3()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            LogManager target = new LogManager(fileName, path, dayInterval);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }
    }
}
