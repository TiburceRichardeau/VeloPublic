using System;

namespace VeloPublic
{
    /// <summary>
    /// Classe course qui peremet de créer une course et de l'enregistrer dans la base de donnée
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public class Course
    {
        /// <summary>
        /// Contient l'id de la course, utile pour la base de donnée
        /// </summary>
        public long idCourse { get; set; } // Attribus qui contient l'id de la course 

        /// <summary>
        /// Contient l'id de l'évenement dont fait parti la course
        /// </summary>
        public long idEvenement { get; set; } // Attribus qui contient l'id de l'évenement dont la course fait partie

        /// <summary>
        /// Booléen qui permet de savoir si la course un est un défi ou une collaboration
        /// <code>true</code> si la course est un défi
        /// <code>false</code> si la course est une collaboration
        /// </summary>
        public bool estUnDefi { get; set; }

        /// <summary>
        /// Contient la durée de la couse en secondes
        /// </summary>
        public int dureeCourse { get; set; }

        /// <summary>
        /// Constructeur de course 
        /// </summary>
        /// <param name="idEvenement">Contient l'id de l'évenement auquel est ratachée la course</param>
        /// <param name="estUnDefi">Permet de savoir si la course est un défi ou une collaboration <code>true</code> c'est un défi <code>false</code> c'est une collaboration</param>
        public Course(long idEvenement, bool estUnDefi)
        {
            this.estUnDefi = estUnDefi;
            Log l = new Log(Log.Type.Infos, "Création d'une course");
            this.idEvenement = idEvenement; // enregistrement de l'id de l'évenement assoiciée a la course
            try
            {
                l = new Log(Log.Type.Infos, "Enregistrement de la course dans la base de donnée");
                Properties.Settings.Default.erreurSQL = false;
                Properties.Settings.Default.Save();
                SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8"); // Création de l'objet SQLCo qui permet d'accéder a la base de donnée
                co.Connexion(); // Connexion a la base de donnée
                // Enregistrement de la course dans la BD et récupération de l'id de course
                int tempsS = (Properties.Settings.Default.minutes) * 60 + Properties.Settings.Default.secondes;
                idCourse = co.Insert("INSERT INTO `course`(`idCourse`, `evenement_id`, `estUnDefi`, `duree`) VALUES (NULL," + idEvenement + ", " + estUnDefi + ", '"+ tempsS + "');");
                co.Deconnexion(); // fermeture de la connexion SQL
            }
            catch (Exception e) // Il y a eu une erreur, une exeption est levée
            {
                l = new Log(Log.Type.Infos, "Erreur lors de l'enregistrement de la course dans la base de données : " + e.Message);
                Properties.Settings.Default.ErreurSQLSTR = e.Message; // Enregistement du message d'érreur
                Properties.Settings.Default.erreurSQL = true; // ErreurSQL passe a vrai
                Properties.Settings.Default.Save(); // Sauvegarde de l'erreur dans les paramètres de l'application pour l'afficher a l'utilisateur plus tard
            }
        }
    }
}
