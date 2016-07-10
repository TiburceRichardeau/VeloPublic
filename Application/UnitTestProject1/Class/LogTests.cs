using Microsoft.VisualStudio.TestTools.UnitTesting;
using VeloPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VeloPublic.Tests
{
    [TestClass()]
    public class LogTests
    {
        /// <summary>
        /// <author>Tiburce Richardeau</author>
        /// Test unitaire pour les fichiers de log
        /// </summary>
        [TestMethod()]
        public void enregistrerLogTest()
        {
            // Le log est de type infos
            Log l = new Log(Log.Type.Infos, "Infos Test");
            string obtenu = l.EnregistrerLog();
            string attendu = l.date + "\t" + "[Info]" + "\t" + "\t" + "Infos Test" + "\n";
            Assert.AreEqual(attendu, obtenu);


            // Le log est de type Erreur
            l = new Log(Log.Type.Erreur, "Erreur Test");
            obtenu = l.EnregistrerLog();
            attendu = l.date + "\t" + "[Erreur]" + "\t" + "Erreur Test" + "\n";
            Assert.AreEqual(attendu, obtenu);

            // Le log est de type Erreur
            l = new Log(Log.Type.Autre, "Log Test");
            obtenu = l.EnregistrerLog();
            attendu = l.date + "\t" + "[Autre]" + "\t" + "Log Test" + "\n";
            Assert.AreEqual(attendu, obtenu);


            // TODO Test Unitaire qui va lire dans le fichier pour vérifier que le log a bien été écrit dans le fichier
        }
    }
}