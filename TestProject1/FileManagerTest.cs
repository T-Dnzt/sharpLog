﻿using sharpLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///Classe de test pour FileManagerTest, destinée à contenir tous
    ///les tests unitaires FileManagerTest
    ///</summary>
    [TestClass()]
    public class FileManagerTest
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
        ///Test pour writeInFile
        ///</summary>
        [TestMethod()]
        public void writeInFileTest()
        {
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            Exception ex = null; // TODO: initialisez à une valeur appropriée
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            FileManager.writeInFile(id, ex, fileName);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour writeInFile
        ///</summary>
        [TestMethod()]
        public void writeInFileTest1()
        {
            string id = string.Empty; // TODO: initialisez à une valeur appropriée
            string content = string.Empty; // TODO: initialisez à une valeur appropriée
            string fileName = string.Empty; // TODO: initialisez à une valeur appropriée
            FileManager.writeInFile(id, content, fileName);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }
    }
}
