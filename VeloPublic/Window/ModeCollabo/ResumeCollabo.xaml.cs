using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing.Printing;

using MySql.Data;
using MySql.Data.MySqlClient;

// Auteur Claire Pubert
namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour ResumeCollabo.xaml
    /// </summary>
    public partial class ResumeCollabo
    {
        public string cycliste_id { get; set; }
        public int ProductionEnergie { get; set; }
        public int Distance { get; set; }
        public int VitesseMoyenne { get; set; }

        protected MySql.Data.MySqlClient.MySqlConnection conn;


        /// <summary>
        /// Constructeur de ResumeCollabo qui contient les informations des participants
        /// </summary>
        public ResumeCollabo()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            GestionMySQLDataBase mysql = new GestionMySQLDataBase();

            CefHistoCollabo.Address = "http://localhost/Test_graphiques/test_2.html";

            // Affiche les infos du/des participant(s) sélectionné(s) en fonction du nombre de participants choisis
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;

                    // Récupère les informations et les enregistre dans la base de données
                    //valeurResume val11 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                    GestionMySQLDataBase conn = new GestionMySQLDataBase();
                    conn.connection_bdd();

                    // textBoxEnergieProduite1.Text = val11._energieProduite.ToString();
                    // textBoxCalorie1.Text = val11._calories.ToString();
                    // textBoxDistanceParcourue1.Text = val11._distance.ToString();


                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Hidden;

                    labelCouleur2.Visibility = Visibility.Hidden;
                    labelCalorie2.Visibility = Visibility.Hidden;
                    labelEnergieProduite2.Visibility = Visibility.Hidden;
                    labelDistanceParcourue2.Visibility = Visibility.Hidden;
                    textBoxCalorie2.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue2.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite2.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;



                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Hidden;

                    labelCouleur3.Visibility = Visibility.Hidden;
                    labelCalorie3.Visibility = Visibility.Hidden;
                    labelEnergieProduite3.Visibility = Visibility.Hidden;
                    labelDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxCalorie3.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite3.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 2:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;

                    /*        valeurResume val21 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                            textBoxEnergieProduite1.Text = val21._energieProduite.ToString();
                            textBoxCalorie1.Text = val21._calories.ToString();
                            textBoxDistanceParcourue1.Text = val21._distance.ToString();*/



                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelCalorie2.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;

                    /*       valeurResume val22 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP2, Properties.Settings.Default.PrenomP2));
                           textBoxEnergieProduite2.Text = val22._energieProduite.ToString();
                           textBoxCalorie2.Text = val22._calories.ToString();
                           textBoxDistanceParcourue2.Text = val22._distance.ToString();*/



                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Hidden;

                    labelCouleur3.Visibility = Visibility.Hidden;
                    labelCalorie3.Visibility = Visibility.Hidden;
                    labelEnergieProduite3.Visibility = Visibility.Hidden;
                    labelDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxCalorie3.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite3.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 3:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;

                    /*   valeurResume val31 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                       textBoxEnergieProduite1.Text = val31._energieProduite.ToString();
                       textBoxCalorie1.Text = val31._calories.ToString();
                       textBoxDistanceParcourue1.Text = val31._distance.ToString();*/



                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;

                    /*       valeurResume val32 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP2, Properties.Settings.Default.PrenomP2));
                           textBoxEnergieProduite2.Text = val32._energieProduite.ToString();
                           textBoxCalorie2.Text = val32._calories.ToString();
                           textBoxDistanceParcourue2.Text = val32._distance.ToString();*/



                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Visible;

                    labelCouleur3.Visibility = Visibility.Visible;
                    labelCalorie3.Visibility = Visibility.Visible;
                    labelEnergieProduite3.Visibility = Visibility.Visible;
                    labelDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxCalorie3.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxEnergieProduite3.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Visible;

                    /*        valeurResume val33 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP3, Properties.Settings.Default.PrenomP3));
                            textBoxEnergieProduite3.Text = val33._energieProduite.ToString();
                            textBoxCalorie3.Text = val33._calories.ToString();
                            textBoxDistanceParcourue3.Text = val33._distance.ToString();*/



                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 4:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;

                    /*        valeurResume val41 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                            textBoxEnergieProduite1.Text = val41._energieProduite.ToString();
                            textBoxCalorie1.Text = val41._calories.ToString();
                            textBoxDistanceParcourue1.Text = val41._distance.ToString();*/



                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelCalorie2.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;

                    /*      valeurResume val42 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                          textBoxEnergieProduite1.Text = val42._energieProduite.ToString();
                          textBoxCalorie1.Text = val42._calories.ToString();
                          textBoxDistanceParcourue1.Text = val42._distance.ToString();*/



                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Visible;

                    labelCouleur3.Visibility = Visibility.Visible;
                    labelCalorie3.Visibility = Visibility.Visible;
                    labelEnergieProduite3.Visibility = Visibility.Visible;
                    labelDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxCalorie3.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxEnergieProduite3.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Visible;

                    /*     valeurResume val43 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1));
                         textBoxEnergieProduite1.Text = val43._energieProduite.ToString();
                         textBoxCalorie1.Text = val43._calories.ToString();
                         textBoxDistanceParcourue1.Text = val43._distance.ToString();*/



                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Visible;

                    labelCouleur4.Visibility = Visibility.Visible;
                    labelCalorie4.Visibility = Visibility.Visible;
                    labelEnergieProduite4.Visibility = Visibility.Visible;
                    labelDistanceParcourue4.Visibility = Visibility.Visible;
                    textBoxCalorie4.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue4.Visibility = Visibility.Visible;
                    textBoxEnergieProduite4.Visibility = Visibility.Visible;
                    rec4.Visibility = Visibility.Visible;

                    /*     valeurResume val44 = mysql.recuperer_donnees(mysql.recupIdCycliste(Properties.Settings.Default.NomP4, Properties.Settings.Default.PrenomP4));
                         textBoxEnergieProduite4.Text = val44._energieProduite.ToString();
                         textBoxCalorie4.Text = val44._calories.ToString();
                         textBoxDistanceParcourue4.Text = val44._distance.ToString();*/

                    break;

            }
        }
        //-------------------------------------------
        /// <summary>
        /// // Imprime un rapport une fois la collaboration terminée (via un bouton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImprimer_Click(object sender, RoutedEventArgs e)
        {
            // Création de l'évènement pour sélectionner une imprimante
            PrintDialog impResume = new PrintDialog();
            this.WindowState = WindowState.Maximized;    // On agrandit la taille du formulaire

            bool? dialogResult = impResume.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value)
            {
                buttonImprimer.Visibility = Visibility.Hidden;                                         // On rend le bouton d'impression invisible pour ne pas le faire apparaitre sur l'impression
                impResume.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;     // Orientation de la page en paysage ou portrait
                impResume.PrintVisual(ResuColla, "Impression du Résumé de la Collaboration");
                buttonImprimer.Visibility = Visibility.Visible;
            }
        }
        //--------------------------------------------
        /// <summary>
        /// Affiche l'histogramme à partir des données dans la base de données
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        /*    public List<ResumeCollabo> getHistogramme(List<string> pData) 
            {
                List<ResumeCollabo> p = new List<ResumeCollabo>();

                using (MySqlConnection cn = new MySqlConnection(Convert.ToInt32(conn).ToString()))
                {
                    string myQuery = "SELECT cycliste_id, ProductionEnergie, Distance, VitesseMoyenne FROM releve";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = myQuery;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ResumeCollabo cpData = new ResumeCollabo();
                            cpData.ProductionEnergie = Convert.ToInt32(dr["ProductioEnergie"].ToString());
                            cpData.Distance = Convert.ToInt32(dr["Distance"].ToString());
                            cpData.VitesseMoyenne = Convert.ToInt32(dr["VitesseMoyenne"].ToString());
                            p.Add(cpData);
                        }
                    }
                }
                return p;
            }*/


    }
}
