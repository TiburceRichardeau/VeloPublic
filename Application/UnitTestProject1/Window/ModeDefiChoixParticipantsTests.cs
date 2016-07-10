using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VeloPublic.Tests
{
    [TestClass()]
    public class ModeDefiChoixParticipantsTests
    {
        /// <summary>
        /// <author>Tiburce Richardeau</author>
        /// Test unitaire pour vérifier le temps saisi par l'utilisateur
        /// </summary>
        [TestMethod()]
        public void verifierTempsTest()
        {
            ModeDefiChoixParticipants win = new ModeDefiChoixParticipants();

            // Test avec un temps nul
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("0"); // L'utilisateur saisi 0 minutes
            win.set_TextBoxSec("0"); // L'utilisateur saisi 0 secondes
            bool resultat = win.VerifierTemps(); // Vérification du temps
            bool attendu = false; // la méthode précédente doit retourer faux
            Assert.AreEqual(resultat, attendu); // on vérifie si c'est le cas

            // Simulation de la saisi utilisateur
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10"); // L'utilisateur saisi 10 minutes
            win.set_TextBoxSec("50"); // L'utilisateur saisi 50 secondes
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);


            // test avec 1 minute et 0 seconde
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("1");
            win.set_TextBoxSec("0");
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);

            // Test avec 0 minutes et 1 seconde
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("0");
            win.set_TextBoxSec("1");
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);

            // Test avec un temps négatif
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("-10");
            win.set_TextBoxSec("-20");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes négatives
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("-10");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes négatives
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("-10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec du texte dans les secondes et les minutes
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("test");
            win.set_TextBoxSec("test");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec du texte dans les secondes
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("test");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec texte dans les minutes
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("test");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes et minutes a virgule
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10.1");
            win.set_TextBoxSec("10.1");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes a virgule
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("10.1");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10.1");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10,1");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("10,0");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);


            //////////////////////////////////////////////////////
            // Test unitaire sur l'heure rajouté le 03/06       //
            // Test unitaire non répertorié dans les tableaux   //
            //////////////////////////////////////////////////////

            // Simulation de la saisi utilisateur
            win.set_heuresDefi("10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10"); // L'utilisateur saisi 10 minutes
            win.set_TextBoxSec("50"); // L'utilisateur saisi 50 secondes
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);


            // test avec 1 minute et 0 seconde
            win.set_heuresDefi("1"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("1");
            win.set_TextBoxSec("0");
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);

            // Test avec 0 minutes et 1 seconde
            win.set_heuresDefi("0"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("0");
            win.set_TextBoxSec("1");
            resultat = win.VerifierTemps();
            attendu = true;
            Assert.AreEqual(resultat, attendu);

            // Test avec un temps négatif
            win.set_heuresDefi("-10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("-10");
            win.set_TextBoxSec("-20");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes négatives
            win.set_heuresDefi("-10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("-10");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes négatives
            win.set_heuresDefi("10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("-10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec du texte dans les secondes et les minutes
            win.set_heuresDefi("test"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("test");
            win.set_TextBoxSec("test");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec du texte dans les secondes
            win.set_heuresDefi("10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("test");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec texte dans les minutes
            win.set_heuresDefi("test"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("test");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes et minutes a virgule
            win.set_heuresDefi("10.1"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10.1");
            win.set_TextBoxSec("10.1");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec secondes a virgule
            win.set_heuresDefi("10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("10.1");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("10.1"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10.1");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("10,1"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10,1");
            win.set_TextBoxSec("10");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);

            // Test avec minutes a virgule
            win.set_heuresDefi("10"); // L'utilisateur saisi 0 heures
            win.set_TextBoxMin("10");
            win.set_TextBoxSec("10,0");
            resultat = win.VerifierTemps();
            attendu = false;
            Assert.AreEqual(resultat, attendu);
        }
    }
}