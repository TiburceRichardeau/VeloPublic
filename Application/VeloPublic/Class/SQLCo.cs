using MySql.Data.MySqlClient;

namespace VeloPublic
{
    /// <summary>
    /// Class SQLCo qui permet de se connecter a la base de donnée
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public class SQLCo
    {
        /// <summary>
        /// Contient l'adresse du server de base de données
        /// </summary>
        public string server { get; set; }

        /// <summary>
        /// Contient le nom d'utilisateur de la base de données
        /// </summary>
        public string uid { get; set; }

        /// <summary>
        /// Contient le mot de passe asssocié au nom d'utilisateur
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Contient le nom de la base de données a utiliser
        /// </summary>
        public string db { get; set; }

        /// <summary>
        /// Contient le codage de caractère a utiliser
        /// </summary>
        public string charset { get; set; }

        /// <summary>
        /// Objet de connexion MySQL
        /// Permet de se connecter a base de données MySQL
        /// </summary>
        protected MySqlConnection conn;

        /// <summary>
        /// Constructeur de la classe SQLCO
        /// </summary>
        /// <param name="server">Contient l'adresse du serveur</param>
        /// <param name="uid">contient id de connexion a la base de données</param>
        /// <param name="password">contient le mot de passe</param>
        /// <param name="db">contient le nom de la bd a utiliser</param>
        /// <param name="charset">contient le type d'encodage de caractère a utiliser</param>
        public SQLCo(string server, string uid, string password, string db, string charset)
        {
            Log l = new Log(Log.Type.Infos, "Création d'un objet de connexion SQL via la classe SQLCo.cs");
            this.server = server;
            this.uid = uid;
            this.password = password;
            this.db = db;
            this.charset = charset;
        }


        /// <summary>
        /// Permet de se connecter a la base de données
        /// </summary>
        /// <returns><code>true</code> si la connexion est établie <code>false</code> sinon</returns>
        public bool Connexion()
        {
            Log l = new Log(Log.Type.Infos, "Connexion a la base de donnée via la class SQLCO.cs");
            string myConnectionString = "server=" + server + ";" + "uid=" + uid + ";" + "pwd=" + password + ";" + "database=" + db + ";" + "Charset=" + charset + ";";
            try
            {
                //On essaye de se connecter
                conn = new MySqlConnection(myConnectionString);
                conn.Open(); // Si la conexion marche ou l'ouvre
                Properties.Settings.Default.erreurSQL = false;
                Properties.Settings.Default.Save();
                return true;
            }
            catch (MySqlException ex) // Sinon on affiche l'erreur
            {
                l = new Log(Log.Type.Erreur, "Erreur de connexion : " + ex.Message);
                Erreur win = new Erreur("Merci de démarrer wamp, la base de données est inaccessible");
                win.ShowDialog();
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.Save();
                return false;
            }
        }

        /// <summary>
        /// Permet de fermer la connexion a la base de données
        /// </summary>
        /// <returns><code>true</code> si la déconexion s'est bien passée <code>false</code> sinon</returns>
        public bool Deconnexion()
        {
            try
            {
                Log l = new Log(Log.Type.Infos, "Fermeture de la connexion sql via SQLCo.cs");
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de la fermeture de la connexion sql via SQLCo.cs : " + ex.Message);
                return false;
            }
            
        }

        /// <summary>
        /// Permet d'insérer des données dans la base
        /// RequeteNonQuery
        /// </summary>
        /// <param name="requete">contient la requete a éxécuter</param>
        /// <returns><code>long</code>l'id (clé primaire) de la ligne insérée</returns>
        public long Insert(string requete)
        {
            try
            {
                Log l = new Log(Log.Type.Infos, "Insertion dans la base de données : " + requete);
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de l'insertion dans la base de données, requete : " + requete);
                l = new Log(Log.Type.Erreur, "erreur sql : " + ex.Message);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
                return -1;
            }
            
        }

        /// <summary>
        /// Permet de mettre a jour une table
        /// </summary>
        /// <param name="requete">contient la requete de mise a jour a éxécuter</param>
        public void Update(string requete)
        {
            try
            {
                Log l = new Log(Log.Type.Infos, "Mise a jour de la base de donnée");
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de la mise a jour de la base de donnée, requete : " + requete);
                l = new Log(Log.Type.Erreur, "erreur sql : " + ex.Message);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
            }
        }

        // TODO methode non fonctionelle
        /*
        /// <summary>
        /// Permet de faire un "select"
        /// </summary>
        /// <param name="requete">contient la requete select a éxecuter</param>
        /// <returns>retourne le resultat du select</returns>
        public MySqlDataReader select(string requete)
        {

            string myConnectionString = "server=" + server + ";" + "uid=" + uid + ";" + "pwd=" + password + ";" + "database=" + db + ";" + "Charset=" + charset + ";";
            Log l = new Log(Log.Type.Infos, "Exécution d'un select avec la classe SQLCo.cs");
            try
            {
                //On essaye de se connecter
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open(); // Si la conexion marche ou l'ouvre
                Properties.Settings.Default.erreurSQL = false;
                Properties.Settings.Default.Save();
            }
            catch (MySqlException ex) // Sinon on affiche l'erreur
            {
                Log SQLlog = new Log(Log.Type.Erreur, ex.Message);
                Erreur win = new Erreur("Erreur lors de la selection");
                win.ShowDialog();
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.Save();
            }


            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdrDernierEvenement = cmd.ExecuteReader();

            Log l1 = new Log(Log.Type.Infos, "Fermeture de la connexion en fin de select");
            conn.Close();

            return rdrDernierEvenement;
        }*/

        /*
        // TODO Methode paramètrée pour les inserts
        // https://social.msdn.microsoft.com/Forums/fr-FR/b3247e46-92da-4743-a4fc-05d45a3506d0/requte-insert-avec-base-de-donnes-mysql?forum=visualcsharpfr
        public long insertEvenement(long id, string nom, MySql.Data.Types.MySqlDateTime Date, string lieu)
        {
            string requete = "TODO";
            try
            {
                Log l = new Log(Log.Type.Infos, "Insertion dans la base de donnée");
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long idInsert = cmd.LastInsertedId;
                return idInsert;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de l'insertion dans la base de donnée, requete : " + requete);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
                return -1;
            }

        }

        public long insertCycliste(long id, string nom, string prenom, string poids, long id_course)
        {
            string requete = "TODO";
            try
            {
                Log l = new Log(Log.Type.Infos, "Insertion dans la base de donnée");
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long idInsert = cmd.LastInsertedId;
                return idInsert;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de l'insertion dans la base de donnée, requete : " + requete);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
                return -1;
            }

        }

        public long insertCourse(long idCourse, long idEvenement, bool estUnDefi)
        {
            string requete = "TODO";
            try
            {
                Log l = new Log(Log.Type.Infos, "Insertion dans la base de donnée");
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long idInsert = cmd.LastInsertedId;
                return idInsert;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de l'insertion dans la base de donnée, requete : " + requete);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
                return -1;
            }

        }

        public long insertReleve(long idReleve, double Vitesse, double VitesseMoyenne, int NiveauDifficulte, double Distance, double Calories, double ProductionEnergie, long cycliste_id, long cycliste_evenement_id)
        {
            string requete = "TODO";
            try
            { 
                Log l = new Log(Log.Type.Infos, "Insertion dans la base de donnée");
                MySqlCommand cmd = new MySqlCommand(requete, conn);
                cmd.ExecuteNonQuery();
                long idInsert = cmd.LastInsertedId;
                return idInsert;
            }
            catch (MySqlException ex)
            {
                Log l = new Log(Log.Type.Erreur, "Erreur lors de l'insertion dans la base de donnée, requete : " + requete);
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.ErreurSQLSTR = ex.Message;
                Properties.Settings.Default.Save();
                return -1;
            }

        }*/
    }
}

