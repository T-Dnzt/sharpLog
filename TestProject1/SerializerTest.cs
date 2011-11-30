using sharpLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///Classe de test pour SerializerTest, destinée à contenir tous
    ///les tests unitaires SerializerTest
    ///</summary>
    [TestClass()]
    public class SerializerTest
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
        ///Test pour SerializeArchiveConfig
        ///</summary>
        [TestMethod()]
        public void SerializeArchiveConfigTest()
        {
            string filename = string.Empty; // TODO: initialisez à une valeur appropriée
            ArchiveConfig archiveConf = null; // TODO: initialisez à une valeur appropriée
            Serializer.SerializeArchiveConfig(filename, archiveConf);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour DeSerializeArchiveConfig
        ///</summary>
        [TestMethod()]
        public void DeSerializeArchiveConfigTest()
        {
            string filename = string.Empty; // TODO: initialisez à une valeur appropriée
            ArchiveConfig expected = null; // TODO: initialisez à une valeur appropriée
            ArchiveConfig actual;
            actual = Serializer.DeSerializeArchiveConfig(filename);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        }
    }
}
