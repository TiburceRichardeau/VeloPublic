using System;
using System.Globalization;

namespace VeloPublic
{
    /// <summary>
    /// Class participant
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public class Participant
    {
        // Attributs de la classe Participant


        /// <summary>
        /// Contient l'id du cycliste (id BD)
        /// </summary>
        public long idCycliste { get; set; }

        /// <summary>
        /// Contient le nom du participant
        /// </summary>
        public string nom { get; set; }

        /// <summary>
        /// Contient le prénom du participant
        /// </summary>
        public string prenom { get; set; }

        /// <summary>
        /// Contient le poids du participant
        /// sous forme de double
        /// </summary>
        public double poids { get; set; }

        /// <summary>
        /// Contient le poids du participant
        /// sous forme de string
        /// </summary>
        public string poidsString { get; set; }

        /// <summary>
        /// Booléen qui détermine si le poids est correctement saisi
        /// <code>true</code> si le poids est correct
        /// <code>false</code> si le poids n'est pas correctement saisi
        /// </summary>
        public bool poidsCorrect { get; set; }

        /// <summary>
        /// Booléen qui détermine si le poids est renseigné ou non
        /// <code>true</code> si le poids n'est pas renseigné
        /// <code>false</code> si le poids est renseigné
        /// </summary>
        public bool poidsNonRenseigner { get; set; }

        /// <summary>
        /// Booléen qui permet de savoir si le nom du participant (nom+prénom) est correctement saisi
        /// <code>true</code> si le nom est bien renseigné
        /// <code>false</code> si le nom n'est pas correctement renseigné
        /// </summary>
        public bool nomRenseigner { get; set; }

        /// <summary>
        /// Contient l'id de la couse a laquelle le cycliste participe
        /// </summary>
        public long idCourse { get; set; }

        /// <summary>
        /// Contient la vitesse du cycliste
        /// </summary>
        public double vitesse { get; set; }

        /// <summary>
        /// Contient la distance parcourus par le cycliste
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// Contient le niveau de difficulté choisi par le cycliste sur le vélo
        /// </summary>
        public int niveau { get; set; }

        /// <summary>
        /// Contient la vitesse moyenne du cycliste
        /// </summary>
        public double vitesseMoyenne { get; set; }

        /// <summary>
        /// Contient les calories brulée par le cycliste (le poids doit être renseigné)
        /// </summary>
        public double calories { get; set; }

        /// <summary>
        /// Contient l'énergie produite par le cycliste
        /// </summary>
        public double production { get; set; }

        /// <summary>
        /// Contient le niveau choisi par le cycliste sous forme de string (facile, moyen, difficile)
        /// </summary>
        public string niveauStr { get; set; }

        public double PuissanceInstannee { get; set; }

        /// <summary>
        /// Constructeur de la classe participant
        /// </summary>
        /// <param name="prenom">contient le prénom du participant</param>
        /// <param name="nom">contient le nom du participant</param>
        /// <param name="poidsString">contient le poids du participant</param>
        /// <param name="idCourse">contient l'id de la course au quel le cycliste participe</param>
        public Participant(string prenom, string nom, string poidsString, long idCourse)
        {
            Log l = new Log(Log.Type.Infos, "Création d'un participant");
            this.distance = 0;
            this.production = 0;
            this.PuissanceInstannee = 0;
            //poidsString = string.Empty;
            poidsCorrect = false;
            poidsNonRenseigner = true;
            this.calories = 0;
            this.nom = nom;
            this.prenom = prenom;
            this.idCourse = idCourse;
            this.poidsString = poidsString;
            if (VerifPoids() && poidsNonRenseigner == false)
            {
                poids = double.Parse(poidsString, NumberStyles.Number, CultureInfo.InvariantCulture);
                poidsString = poids.ToString();
            }
            else poidsCorrect = false;
            if (VerifNP())
                nomRenseigner = true;
            else nomRenseigner = false;

            if(VerifNP() && VerifPoids())
            {
                l = new Log(Log.Type.Infos, "Ajout du participant a la base de données");
                // Ajouter participant dans la base de donnée
                string requete = "INSERT INTO `cycliste`(`idCycliste`, `nom`, `prenom`, `poids`, `course_id`) VALUES" 
                    + " (NULL,'" + nom + "','" + prenom + "','" + this.poidsString + "','" + idCourse + "' );";
                SQLCo conn = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
                conn.Connexion(); // Ouverture de la connexion à la base de donnée
                idCycliste = conn.Insert(requete); // Permet d'enregistrer le participant dans la base de donnée
                conn.Deconnexion(); // Fermeture de la connexion sql
            }
            this.f = getNiveau();
            genererVitesseMax();

            Random randNum = new Random(); // Initialisation d'un nombre aléatoire
            this.niveau = randNum.Next(1, 3); // Choix d'un niveau de difficulté aléatoire

            switch (this.niveau) // En fonction du nombre générer précédement, on enregistre le niveau de difficulté
            {
                case 1:
                    this.niveauStr = "Facile";
                    break;
                case 2:
                    this.niveauStr = "Moyen";
                    break;
                case 3:
                    this.niveauStr = "Difficile";
                    break;
            }


            l = new Log(Log.Type.Infos, "Participant créé");
        }

        /// <summary>
        /// Méthode qui permet de vérifier le nom et le prénom du participant ont bien été saisis
        /// </summary>
        /// <returns><code>true</code> si les infos sont correctement saisies <code>false</code> sinon</returns>
        public bool VerifNP() 
        {
            Log l = new Log(Log.Type.Infos, "Vérification du nom du participant");
            if (nom != string.Empty || prenom != string.Empty) // L'utilisateur a saisi au moins soit le nom soit le prénom
            {
                if (nom == "Nom" && prenom == "Prénom") // Il y a des placeholders dans les champs de saisi, 
                    return false;                       // on vérifie donc que les nom et prénom reseigné ne sont pas les placeholders
                else if (nom == "Nom" && prenom != "Prénom") // si seul le prénom est reseigné on efface le placeholder du nom
                    nom = string.Empty;
                else if (nom != "Nom" && prenom == "Prénom") // si seul le nom est renseigné on efface le placeholder du prénom
                    prenom = string.Empty;

                if (nom.Length <= 25 && prenom.Length <= 25) // Vérification de la taille des nom et prénom, 
                {
                    l = new Log(Log.Type.Infos, "Nom correctement renseigné");
                    return true;
                }
                else
                {
                    l = new Log(Log.Type.Infos, "Nom trop long (25 caractètes max)");
                    return false;

                }
            }
            else {
                l = new Log(Log.Type.Infos, "Nom mal saisi : " + nom + " " + prenom);
                return false;
            }
        }


        /// <summary>
        /// Permet de vérifier si le poids du participant a bien été saisi et est correct
        /// </summary>
        /// <returns><code>true</code>si le poids est correctement saisi<code>false</code>sinon</returns>
        public bool VerifPoids()
        {
            Log l = new Log(Log.Type.Infos, "Vérification du poids");
            double test; // Permet d'utiliser le tryparse

            if (poids == 1)
            {
                poidsCorrect = false;
                poidsNonRenseigner = true;
            }

            if (poidsString == "Poids")
            {
                poidsCorrect = true;
                poidsNonRenseigner = true;
                this.poids = 1;
                this.poidsString = "1";
                return true;
            }

            if (double.TryParse(poidsString, NumberStyles.Number, CultureInfo.InvariantCulture, out test))
            {
                poids = double.Parse(poidsString, NumberStyles.Number, CultureInfo.InvariantCulture);
                if (poids >= 1)
                {
                    l = new Log(Log.Type.Infos, "Poids correctement saisi : " + poidsString);
                    poidsCorrect = true;
                    poidsNonRenseigner = false;
                    return true;
                }else
                {
                    l = new Log(Log.Type.Infos, "Le poids saisi est négatif ou nul");
                    poidsCorrect = false;
                    poidsNonRenseigner = false;
                    return false;
                }
                
            }
            else if (poidsString == string.Empty)
            {
                l = new Log(Log.Type.Infos, "Poids Non saisi");
                poidsCorrect = true;
                poidsNonRenseigner = true;
                this.poids = 1;
                this.poidsString = "1";
                return true;
            }
            else {
                l = new Log(Log.Type.Infos, "Poids mal saisi : " + poidsString);
                poidsCorrect = false;
                return false;
            }
        }



        /// <summary>
        /// Permet de calculer le nombre de calorie brulée par le cycliste par seconde
        /// Methode a éxécuter toutes 'tempsActualisation' secondes pendant la course
        /// </summary>
        /// <param name="tempsActualisation">contient le temps écoulé entre deux mesures (en secondes)</param>
        /// <returns><code>double</code>les calories brulées par le cycliste</returns>
        public double CalorieBrule(double tempsActualisation)
        {
            /*
            (MET * 3,5 * Poids en kilos)/ 200;
            Vélo Effort léger MET = 4
            Vélo Effort moyen MET = 7
            Vélo Effort intense (22-30km/h) MET = 10
            Vélo Effort très intense (> à 30km/h) MET = 14
            http://www.regivia.com/index.php/comment-maigrir-conseils-solutions-trucs-et-astuces/calcul-des-depenses-energetiques-en-calories-par-sports-et-activites/depenses-caloriques-consommees-pour-le-velo-bicyclette-et-cyclisme/#met-velo
            */
            if (this.poidsCorrect == true && this.poidsNonRenseigner == false)
            {
                double MET = 4;
                if (vitesse >= 15)
                    MET = 7;
                if (vitesse >= 22 && vitesse <= 30)
                    MET = 10;
                if (vitesse < 30)
                    MET = 14;

                double calories = ((MET * 3.5 * this.poids) / 200) / 60; // Nombre de calorie brulée par seconde
                calories = calories * tempsActualisation; // en seconde
                this.calories = this.calories + calories;

                this.calories = Double.Parse(String.Format("{0:0.00}", this.calories));
            }

            return this.calories;
        }

        /// <summary>
        /// Permet d'enregistrer dans la base de données le relevé du cycliste
        /// </summary>
        public void EnregristrerReleve()
        {
            SQLCo sql = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
            sql.Connexion();
            sql.Insert("INSERT INTO `releve`"
                + "(`idReleve`, `Vitesse`, `VitesseMoyenne`, `NiveauDifficulte`, `Distance`, `Calories`, `ProductionEnergie`, `cycliste_id`, `Temps`, `puissanceInstantanee`)"
                + " VALUES (NULL, '" 
                + this.vitesse + "', '" 
                + this.vitesseMoyenne.ToString().Replace(',', '.') 
                + "', '" + this.niveau 
                + "', '" + this.distance + "', '" 
                + this.calories + "', '" + this.production + "', '" 
                + this.idCycliste + "', '" 
                + Properties.Settings.Default.tempsChronosec + "', '"
                + PuissanceInstannee + "');");
            sql.Deconnexion();
        }


        // Variables utilisées pour la génération de relevés de test
        public static double nbPrecedant = 0;
        public static int nbSecondesTot = 30;
        public double maxVit;
        public double last_vit = 0;
        public static int secondes = 0;
        double tempsActualisationdTimerTester = 2;

        public force f;


        static force getNiveau()
        {
            Random rnd = new Random();
            int u = rnd.Next(1, 101);

            if (u <= 30)
            {
                return force.BON;
            }
            else if (u <= 50)
            {
                return force.TRES_BON;
            }
            else
            {
                return force.MOYEN;
            }
        }

        public enum force
        {
            MOYEN = 5, BON = 7, TRES_BON = 10
        }

        public double genererVitesse()
        {
            Random rnd = new Random();
            if (last_vit <= maxVit)
            {
                last_vit += rnd.Next(1, (int)f);
            }
            else
            {
                last_vit -= rnd.Next(1, (int)f - 1);
            }
            return last_vit;
        }


        public void genererVitesseMax()
        {
            Random rnd = new Random();

            switch (f)
            {
                case force.BON:
                    maxVit = rnd.Next(22, 30);
                    break;
                case force.MOYEN:
                    maxVit = rnd.Next(13, 21);
                    break;
                case force.TRES_BON:
                    maxVit = rnd.Next(31, 40);
                    break;
            }
        }

        /// <summary>
        /// Permet de générer un relevé de test avec des valeurs aléatoires
        /// </summary>
        public void GenererTestReleve()
        {
            this.production = calculEnergieProduite(); // La production d'énegie du cycliste augmente d'un nombre compris entre 0 et 10
            this.vitesse = this.genererVitesse(); // Génération d'une vitesse aléatoire
            this.PuissanceInstannee = calculPuissanceInstannee();


            // switch de test pour la methode de calcul de vitesse
            /*
            switch (f)
            {
                case force.BON:
                    this.niveauStr = "Bon";
                    break;
                case force.MOYEN:
                    this.niveauStr = "Moyen";
                    break;
                case force.TRES_BON:
                    this.niveauStr = "très bon";
                    break;
            }*/

            //this.distance = this.distance + randNum.Next(10); // La distance parcourus augmente d'un nombre compris entre 0 et 10
            this.distance += calculDistanceTest();
            this.vitesseMoyenne = (this.vitesseMoyenne + this.vitesse) / 2; // On calcul la vitesse moyenne
            this.vitesseMoyenne = double.Parse(string.Format("{0:0.00}", this.vitesseMoyenne)); // Peremt d'arrondir a 2 chiifres après la virgule la vitesse moyenne
            this.CalorieBrule(tempsActualisationdTimerTester); // Calcul des calories brulés
        }

        /// <summary>
        /// Permet de calculer la distance parcourue
        /// </summary>
        /// <returns><code>int</code> Distance en mètres</int></returns>
        private int calculDistanceTest()
        {
            double distanceDouble = vitesse / (3600/tempsActualisationdTimerTester); // Distance en km
            distanceDouble = distanceDouble * 1000; // Distnace en mètres
            int distance = (int)distanceDouble;
            return distance;
        }

        private double calculPuissanceInstannee()
        {
            // La puissance instannée est calculée grâce au calcul suivant :
            // Volt * Ampères
            Random rnd = new Random();
            int maxVolt = 20; // Maximum 20V
            int maxAmperes = 25; // Maximum 25 ampere
            double amperes;
            double volt;
            if (vitesse >= 0 && vitesse <= 10)
            {
                volt = rnd.Next(0, 6);
                amperes = rnd.Next(0, 5);
            }else if (vitesse>10 && vitesse<=20) {
                volt = rnd.Next(6, 12);
                amperes = rnd.Next(5, 10);
            }else if (vitesse > 20 && vitesse <= 30)
            {
                volt = rnd.Next(12, 18);
                amperes = rnd.Next(10, 15);
            }else // > 30
            {
                volt = rnd.Next(18, maxVolt);
                amperes = rnd.Next(15, maxAmperes);
            }
            return volt * amperes; // Puissance instannée en Watt
        }

        private double calculEnergieProduite()
        {
            // Puissance * temps (en h)
            // 2s en heure = 0,000277778
            double tempsActualisationHeure = 0.000555556; //2s en heures
            production += (PuissanceInstannee * tempsActualisationHeure);
            production = Double.Parse(String.Format("{0:0.000}", production));
            return production;
        }
    }
}
