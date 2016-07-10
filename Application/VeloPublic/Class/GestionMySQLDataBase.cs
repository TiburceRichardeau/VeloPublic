using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
// Claire Pubert
namespace VeloPublic
{
    public class valeurResume
    {
        public double _distance { get; set; }
        public double _calories { get; set; }
        public double _energieProduite { get; set; }
    }

    public class GestionMySQLDataBase
    {
        /// <summary>
        /// Créer l'attribut nécessaire à la connection à la base de données
        /// </summary>
        string Connection;
        protected MySql.Data.MySqlClient.MySqlConnection conn;

        /// <summary>
        /// Constructeur de la classe GestionMyQLDataBase
        /// </summary>
        public GestionMySQLDataBase()
        {
            Connection = "server=" + "localhost" + ";" + "uid=" + "userVeloPublic" + ";" + "pwd=" + "userVeloPublic" + ";" + "database=" + "veloinfospublic" + ";" + "Charset=" + "utf8" + ";";
            conn = new MySql.Data.MySqlClient.MySqlConnection(Connection);
        }

        public void connection_bdd()
        {
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }


        public void inserer_donnees(string nom, string prenom, int poids, int id)
        {
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();

            string sql1 = "SELECT idCourse FROM course";
            int id_course = 0;

            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            MySqlDataReader rdrSql1 = cmd1.ExecuteReader();

            if (rdrSql1.HasRows)
            {
                rdrSql1.Read();

                id_course = Int32.Parse(rdrSql1[0].ToString());
            }

            string sql2 = " INSERT INTO `cycliste` (`nom`, `prenom`, `poids`, `course_id`) VALUES ( '" + nom + "', '" + prenom + "', '" + poids + "', '" + id_course + "');";
            MySqlCommand cmd = new MySqlCommand(sql2, conn);
            //    cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int recupIdCycliste(string nom, string prenom)
        {
            try
            {
                conn = null;
                conn = new MySql.Data.MySqlClient.MySqlConnection(Connection);
                conn.Open();
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }


            string sql = "SELECT id FROM cycliste WHERE nom = '" + nom + "' AND prenom = '" + prenom + "';";
            int id_cycliste = 0;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader idCycliste = cmd.ExecuteReader();

            if (idCycliste.HasRows)
            {
                id_cycliste = Int32.Parse(idCycliste[0].ToString());
            }

            return id_cycliste;
        }

        public valeurResume recuperer_donnees(int id_cycliste)
        {
            conn.Open();
            string sql = "SELECT Distance, Calories, ProductionEnergie FROM releve WHERE cycliste_id = " + id_cycliste + ";";
            double distance = 0;
            double calories = 0;
            double energieProduite = 0;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader DerniereCourse = cmd.ExecuteReader();

            if (DerniereCourse.HasRows)
            {
                distance = Convert.ToDouble(DerniereCourse[0].ToString());
                calories = Convert.ToDouble(DerniereCourse[1].ToString());
                energieProduite = Int32.Parse(DerniereCourse[2].ToString());
            }
            conn.Close();

            valeurResume val = new valeurResume() { _distance = distance, _calories = calories, _energieProduite = energieProduite };

            return val;
        }

    }


}
