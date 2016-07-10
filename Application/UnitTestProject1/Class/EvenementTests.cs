using Microsoft.VisualStudio.TestTools.UnitTesting;
using VeloPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloPublic.Tests
{
    [TestClass()]
    public class EvenementTests
    {
        /// <summary>
        /// <author>Tiburce Richardeau</author>
        /// Test unitaire pour la vérification du lieu de l'événement
        /// </summary>
        [TestMethod()]
        public void verifierLieuEvTest()
        {
            // test avec un nom de lieu inferieur a 50 caractères (limite base de données)
            Evenement ev = new Evenement("EvTest1", DateTime.Now, "LieuTest");
            bool attendu = true;
            bool obtenu = ev.VerifierLieuEv();
            Assert.AreEqual(attendu, obtenu);

            // test avec un nom de lieu superieur a 50 caractères
            string lieu = string.Empty;
            for (int i=0; i < 6; i++) // 6 * 10 caractères, soit 60 caractères
            {
                lieu = lieu + "0123456789";
            }
            ev = new Evenement("EvTest1", DateTime.Now, lieu);
            attendu = false;
            obtenu = ev.VerifierLieuEv();
            Assert.AreEqual(attendu, obtenu);

            // Test avec un nom de lieu vide
            ev = new Evenement("EvTest1", DateTime.Now, string.Empty);
            attendu = false;
            obtenu = ev.VerifierLieuEv();
            Assert.AreEqual(attendu, obtenu);
        }

        /// <summary>
        /// <author>Tiburce Richardeau</author>
        /// Test unitaire pour vérifier le nom de l'événement
        /// </summary>
        [TestMethod()]
        public void verifierNomEvTest()
        {
            // test avec un nom d'évenement inferieur a 50 caractères (limite de la base de données)
            Evenement ev = new Evenement("EvTest1", DateTime.Now, "LieuTest");
            bool attendu = true;
            bool obtenu = ev.VerifierNomEv();
            Assert.AreEqual(attendu, obtenu);

            // test avec un nom d'évenement superieur a 50 caractères
            string nomEv = string.Empty;
            for (int i = 0; i < 6; i++) // 6 * 10 caractères, soit 60 caractères
            {
                nomEv = nomEv + "0123456789";
            }
            ev = new Evenement(nomEv, DateTime.Now, "Nantes");
            attendu = false;
            obtenu = ev.VerifierNomEv();
            Assert.AreEqual(attendu, obtenu);

            // Test avec le nom de l'évenement non rempli
            ev = new Evenement(string.Empty, DateTime.Now, "Nantes");
            attendu = false;
            obtenu = ev.VerifierNomEv();
            Assert.AreEqual(attendu, obtenu);
        }
    }
}