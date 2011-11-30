using sharpLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///Classe de test pour ArchiveManagerTest, destinée à contenir tous
    ///les tests unitaires ArchiveManagerTest
    ///</summary>
    [TestClass()]
    public class ArchiveManagerTest
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
        ///Test pour Constructeur ArchiveManager
        ///</summary>
        [TestMethod()]
        public void ArchiveManagerConstructorTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveManager target = new ArchiveManager(fileName, path, dayInterval);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour archiveFile
        ///</summary>
        [TestMethod()]
        public void archiveFileTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveManager target = new ArchiveManager(fileName, path, dayInterval); // TODO: initialisez à une valeur appropriée
            target.archiveFile();
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour saveArchiveConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void saveArchiveConfigTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            ArchiveManager_Accessor target = new ArchiveManager_Accessor(param0); // TODO: initialisez à une valeur appropriée
            target.saveArchiveConfig();
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour setArchiveConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void setArchiveConfigTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            ArchiveManager_Accessor target = new ArchiveManager_Accessor(param0); // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            target.setArchiveConfig(dayInterval);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour getArchiveConfig
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void getArchiveConfigTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            ArchiveManager_Accessor target = new ArchiveManager_Accessor(param0); // TODO: initialisez à une valeur appropriée
            ArchiveConfig_Accessor expected = null; // TODO: initialisez à une valeur appropriée
            ArchiveConfig_Accessor actual;
            actual = target.getArchiveConfig();
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
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveManager target = new ArchiveManager(fileName, path, dayInterval); // TODO: initialisez à une valeur appropriée
            int dayInterval1 = 0; // TODO: initialisez à une valeur appropriée
            target.changeDayInterval(dayInterval1);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }
    }
}
