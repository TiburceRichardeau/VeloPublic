using System;

namespace VeloPublic
{
    /// <summary>
    /// Class Evenement
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public class Evenement
    {
        /// <summary>
        /// Contient l'id de l'évenement, utile pour la base de donnée
        /// </summary>
        public long idLong { get; set; }
        
        /// <summary>
        /// contient le nom de l'évenement
        /// </summary>
        public string nom { get; set; }

        /// <summary>
        /// Contient la date de l'évenement
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Contient la date de l'événement en chaine de caractères
        /// </summary>
        public string dateString { get; set; }

        /// <summary>
        /// Contient le lieu de l'évenement
        /// </summary>
        public string lieu { get; set; }


        /// <summary>
        /// Constructeur d'évement
        /// </summary>
        /// <param name="nom">contient le nom de l'évenement</param>
        /// <param name="date">Contient la date de l'évenement</param>
        /// <param name="lieu">Contient le lieu de l'évenement</param>
        public Evenement(string nom, DateTime date, string lieu)
        {
            Log l = new Log(Log.Type.Infos, "Création d'un évenement");
            this.nom = nom; // Récuparation du nom de l'évenement
            this.date = date; // Récuparation de la date de l'évenement
            string dateStr = date.ToString("yyyy-MM-dd HH:mm:ss"); // Enregistrement de la date au format yyyy-MM-dd HH:mm:ss
            MySql.Data.Types.MySqlDateTime dateSQL = new MySql.Data.Types.MySqlDateTime(date.ToString()); // Enregistrement de la date au format MySQL
            this.lieu = lieu; // Récuparation du lieu de l'évenement
            if (VerifierNomEv() && VerifierLieuEv())
            {
                try // Essaye d'enregistrer l'évenement dans la base de donnée
                {
                    l = new Log(Log.Type.Infos, "Enregistrement de l'évenement dans la base de données");
                    Properties.Settings.Default.erreurSQL = false;
                    Properties.Settings.Default.Save();
                    SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
                    co.Connexion();
                    this.idLong = co.Insert("INSERT INTO `evenement`(`idEvenement`, `nom`, `date`, `lieu`) VALUES (NULL, '" + nom + "', '" + dateStr + "', '" + lieu + "');"); // Insertion dans la DB et récuparation de l'id de l'évenement
                    Properties.Settings.Default.idEv = this.idLong;
                    Properties.Settings.Default.Save(); // Sauvegarde de l'id
                }
                catch (Exception e) // Si une exeption est levée on l'enregistre pour l'afficher plus tard
                {
                    l = new Log(Log.Type.Erreur, "Erreur lors de l'enregistrement de l'évenement dans la BD : " + e.Message);
                    Properties.Settings.Default.ErreurSQLSTR = e.Message;
                    Properties.Settings.Default.erreurSQL = true;
                    Properties.Settings.Default.Save();
                }
            }
        }





        /// <summary>
        /// Constructeur d'evenement utilisé pour remplir la datagrid des événements existants
        /// </summary>
        /// <param name="nom"><code>string</code>Nom de l'événement récupéré de la base de données</param>
        /// <param name="dateString"><code>string</code>Date récupérée de la base de données</param>
        /// <param name="lieu"><code>string</code> Lieu de l'événement récupérer de la base de données</param>
        /// <param name="idLong"><code>long</code>id de l'événement choisi</param>
        public Evenement(string nom, string dateString, string lieu, long idLong)
        {
            Log l = new Log(Log.Type.Infos, "Création d'un évenement pour l'ajout dans  la datagrid des evenements existants");
            this.nom = nom; // Récuparation du nom de l'évenement
            this.dateString = dateString; // Récuparation de la date de l'évenement
            this.lieu = lieu; // Récuparation du lieu de l'évenement
            this.idLong = idLong;
        }



        /// <summary>
        /// Permet de vérifier si le nom de l'évenement saisi n'est pas trop long pour la base de donnée
        /// </summary>
        /// <returns><code>true</code> si le nom n'est pas trop long <code>false</code> sinon</returns>
        public bool VerifierNomEv()
        {
            if (this.nom.Length <= 50 && this.nom.Length > 0 && this.nom != "Nom de l'événement")
                return true;
            else
                return false;
        }

        /// <summary>
        /// Permet de vérifier si le lieu saisi n'est pas trop long pour la base de données
        /// </summary>
        /// <returns><code>true</code> si le nom du lieu n'est pas trop long <code>false</code> sinon</returns>
        public bool VerifierLieuEv()
        {
            if (this.lieu.Length <= 50 && this.lieu.Length > 0 && this.lieu != "Lieu")
                return true;
            else
                return false;
        }
    }
}
