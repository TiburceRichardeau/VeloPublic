using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VeloPublic.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        /// <summary>
        /// Test unitaire qui vérifie si le nom et le prénom est bien saisi lors de la création du participant
        /// <author>Tiburce Richardeau</author>
        /// </summary>
        [TestMethod()]
        public void verifNPTest()
        {
            // Test avec le nom et prénom renseigné
            Participant p = new Participant("Tiburce", "Richardeau", "250", 1);
            bool attendu = true;
            bool obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test avec le prénom non renseigné et le nom renseigné
            p = new Participant(string.Empty, "Richardeau", "250", 1);
            attendu = true;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test avec le prénom reseigné et pas le nom
            p = new Participant("Tiburce", string.Empty, "250", 1);
            attendu = true;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test avec le prénom et le nom pas renseigné
            p = new Participant(string.Empty, string.Empty, "250", 1);
            attendu = false;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test si le prénom saisi est inferieur a 25 (limite dans la BD)

            string prenom = string.Empty;
            for (int i = 0; i < 4; i++) // 12 *10 caractères, soit 120 caractères
            {
                prenom = prenom + "Tiburce"; // 4*7=28 caractères
            }
            p = new Participant(prenom, string.Empty, "250", 1);
            attendu = false;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test si le nom saisi est inferieur a 25 (limite dans la BD)
            string nom = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                nom = nom + "Richardeau"; // 10*3=30 caractères
            }
            p = new Participant(string.Empty, nom, "250", 1);
            attendu = false;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);

            // Test si le nom et le prénom saisi sont superieur a 25 (limite dans la BD)
            prenom = string.Empty;
            nom = string.Empty;
            for (int i = 0; i < 4; i++) // 12 *10 caractères, soit 120 caractères
            {
                prenom = prenom + "Tiburce"; // 4*7=28 caractères
            }
            for (int i = 0; i < 3; i++)
            {
                nom = nom + "Richardeau"; // 10*3=30 caractères
            }
            p = new Participant(prenom, nom, "250", 1);
            attendu = false;
            obtenu = p.VerifNP();
            Assert.AreEqual(attendu, obtenu);
        }

        /// <summary>
        /// Test unitaire qui vérifie si le poids est bien saisi lors de la création du participant
        /// <author>Tiburce Richardeau</author>
        /// </summary>
        [TestMethod()]
        public void verifPoidsTest()
        {
            // l'utilisateur a saisi son poids
            Participant p = new Participant("Tiburce", "Richardeau", "250", 1);
            bool attendu = true;
            bool obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);

            // l'utilisateur n'a pas saisi son poids
            p = new Participant("Tiburce", "Richardeau", string.Empty, 1);
            attendu = true;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);

            // l'utilisateur n'a pas saisi un nombre dans le champs de saisi du poids
            p = new Participant("Tiburce", "Richardeau", "test", 1);
            attendu = false;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);


            // l'utilisateur a saisi un nombre négatif
            p = new Participant("Tiburce", "Richardeau", "-10", 1);
            attendu = false;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);


            // l'utilisateur a saisi un nombre décimal
            p = new Participant("Tiburce", "Richardeau", "10,1", 1);
            attendu = true;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);

            // l'utilisateur a saisi un nombre a virgule avec un point a la place de la virgule
            p = new Participant("Tiburce", "Richardeau", "10.1", 1);
            attendu = true;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);

            // l'utilisateur saisi un poids qui est superieur a la limite des double
            double poids = double.MaxValue + 1;
            p = new Participant("Tiburce", "Richardeau", poids.ToString(), 1);
            attendu = false;
            obtenu = p.VerifPoids();
            Assert.AreEqual(attendu, obtenu);

            // l'utilisateur saisi un nombre a vigule, la virgule est remplacer par un point
            ModeDefiChoixParticipants win = new ModeDefiChoixParticipants(); // Création de la fentre de saisie des participants
            win.Select1Participant(); // L'utilisateur selectionne 1 participant
            win.radioButton1_Checked(new object(), new System.Windows.RoutedEventArgs()); // il coche le radiobutton 1
            win.set_TextBoxPoidsCycliste1("10,1"); // il saisi un poids de 10,1
            win.RemplacerVirgulePointCycliste1(); // la méthode remplace les , par des .
            p = new Participant("Tiburce", "Richardeau", win.get_PoidsCyclite1(), 1); // Le participant est créer
            attendu = true; // Ce test unitaire doit revoyer vrai
            if (p.poidsString == "10.1") // on vérifie le poids du participant
                obtenu = true; // si le poids contient un point le test est réussi
            else obtenu = false; // Sinon le test n'a pas fonctionner
            Assert.AreEqual(attendu, obtenu); // on compare les deux booléans, si ils sont égaux le test est passé
        }
    }
}