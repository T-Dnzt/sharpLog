using sharpLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///Classe de test pour ArchiveConfigTest, destinée à contenir tous
    ///les tests unitaires ArchiveConfigTest
    ///</summary>
    [TestClass()]
    public class ArchiveConfigTest
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
        ///Test pour setNextArchiveDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("sharpLog.dll")]
        public void setNextArchiveDateTest()
        {
            PrivateObject param0 = null; // TODO: initialisez à une valeur appropriée
            ArchiveConfig_Accessor target = new ArchiveConfig_Accessor(param0); // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            target.setNextArchiveDate(dayInterval);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour Constructeur ArchiveConfig
        ///</summary>
        [TestMethod()]
        public void ArchiveConfigConstructorTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveConfig target = new ArchiveConfig(fileName, path, dayInterval);
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour updateNextArchiveDate
        ///</summary>
        [TestMethod()]
        public void updateNextArchiveDateTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveConfig target = new ArchiveConfig(fileName, path, dayInterval); // TODO: initialisez à une valeur appropriée
            target.updateNextArchiveDate();
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour DayInterval
        ///</summary>
        [TestMethod()]
        public void DayIntervalTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveConfig target = new ArchiveConfig(fileName, path, dayInterval); // TODO: initialisez à une valeur appropriée
            int expected = 0; // TODO: initialisez à une valeur appropriée
            int actual;
            target.DayInterval = expected;
            actual = target.DayInterval;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }

        /// <summary>
        ///Test pour NextArchiveDate
        ///</summary>
        [TestMethod()]
        public void NextArchiveDateTest()
        {
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            string path = string.Empty; // TODO: initialisez à une valeur appropriée
            int dayInterval = 0; // TODO: initialisez à une valeur appropriée
            ArchiveConfig target = new ArchiveConfig(fileName, path, dayInterval); // TODO: initialisez à une valeur appropriée
            DateTime expected = new DateTime(); // TODO: initialisez à une valeur appropriée
            DateTime actual;
            target.NextArchiveDate = expected;
            actual = target.NextArchiveDate;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
