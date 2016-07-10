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
using MahApps.Metro.Controls;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

// Claire Pubert
namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour ModeCollaboChoixParticipantsTrue.xaml
    /// </summary>
    public partial class ModeCollaboChoixParticipantsTrue
    {
        public ModeCollaboChoixParticipantsTrue()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Properties.Settings.Default.nbParticipants = 0;
            Properties.Settings.Default.Save();
            TextBlockMode.Text = "Mode " + Properties.Settings.Default.Mode;

            GestionMySQLDataBase conn = new GestionMySQLDataBase();
            conn.connection_bdd();
        }

        /// <summary>
        /// Fenêtre de fermeture lorsque l'on clique sur la croix rouge
        /// </summary>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Vous allez revenir au menu de l'application. Continuer ?", "EnergieCycle", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Affichage des informations à compléter en fonction du nombre de participants choisi
        /// </summary>
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 1;
                Properties.Settings.Default.Save();

                labelCycliste1.Visibility = Visibility.Visible;
                //   labelCouleur1.Visibility = Visibility.Visible;
                labelPrenom1.Visibility = Visibility.Visible;
                labelNom1.Visibility = Visibility.Visible;
                labelPoids1.Visibility = Visibility.Visible;
                textBoxNom1.Visibility = Visibility.Visible;
                textBoxPrenom1.Visibility = Visibility.Visible;
                textBoxPoids1.Visibility = Visibility.Visible;

                labelCycliste2.Visibility = Visibility.Hidden;
                //      labelCouleur2.Visibility = Visibility.Hidden;
                labelPrenom2.Visibility = Visibility.Hidden;
                labelNom2.Visibility = Visibility.Hidden;
                labelPoids2.Visibility = Visibility.Hidden;
                textBoxNom2.Visibility = Visibility.Hidden;
                textBoxPrenom2.Visibility = Visibility.Hidden;
                textBoxPoids2.Visibility = Visibility.Hidden;

                labelCycliste3.Visibility = Visibility.Hidden;
                //      labelCouleur3.Visibility = Visibility.Hidden;
                labelPrenom3.Visibility = Visibility.Hidden;
                labelNom3.Visibility = Visibility.Hidden;
                labelPoids3.Visibility = Visibility.Hidden;
                textBoxNom3.Visibility = Visibility.Hidden;
                textBoxPrenom3.Visibility = Visibility.Hidden;
                textBoxPoids3.Visibility = Visibility.Hidden;

                labelCycliste4.Visibility = Visibility.Hidden;
                //       labelCouleur4.Visibility = Visibility.Hidden;
                labelPrenom4.Visibility = Visibility.Hidden;
                labelNom4.Visibility = Visibility.Hidden;
                labelPoids4.Visibility = Visibility.Hidden;
                textBoxNom4.Visibility = Visibility.Hidden;
                textBoxPrenom4.Visibility = Visibility.Hidden;
                textBoxPoids4.Visibility = Visibility.Hidden;

                buttonValider.Visibility = Visibility.Visible;
            }
            else if (radioButton2.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 2;
                Properties.Settings.Default.Save();

                labelCycliste1.Visibility = Visibility.Visible;
                // labelCouleur1.Visibility = Visibility.Visible;
                labelPrenom1.Visibility = Visibility.Visible;
                labelNom1.Visibility = Visibility.Visible;
                labelPoids1.Visibility = Visibility.Visible;
                textBoxNom1.Visibility = Visibility.Visible;
                textBoxPrenom1.Visibility = Visibility.Visible;
                textBoxPoids1.Visibility = Visibility.Visible;

                labelCycliste2.Visibility = Visibility.Visible;
                // labelCouleur2.Visibility = Visibility.Visible;
                labelPrenom2.Visibility = Visibility.Visible;
                labelNom2.Visibility = Visibility.Visible;
                labelPoids2.Visibility = Visibility.Visible;
                textBoxNom2.Visibility = Visibility.Visible;
                textBoxPrenom2.Visibility = Visibility.Visible;
                textBoxPoids2.Visibility = Visibility.Visible;

                labelCycliste3.Visibility = Visibility.Hidden;
                //    labelCouleur3.Visibility = Visibility.Hidden;
                labelPrenom3.Visibility = Visibility.Hidden;
                labelNom3.Visibility = Visibility.Hidden;
                labelPoids3.Visibility = Visibility.Hidden;
                textBoxNom3.Visibility = Visibility.Hidden;
                textBoxPrenom3.Visibility = Visibility.Hidden;
                textBoxPoids3.Visibility = Visibility.Hidden;

                labelCycliste4.Visibility = Visibility.Hidden;
                //      labelCouleur4.Visibility = Visibility.Hidden;
                labelPrenom4.Visibility = Visibility.Hidden;
                labelNom4.Visibility = Visibility.Hidden;
                labelPoids4.Visibility = Visibility.Hidden;
                textBoxNom4.Visibility = Visibility.Hidden;
                textBoxPrenom4.Visibility = Visibility.Hidden;
                textBoxPoids4.Visibility = Visibility.Hidden;

                buttonValider.Visibility = Visibility.Visible;
            }
            else if (radioButton3.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 3;
                Properties.Settings.Default.Save();

                labelCycliste1.Visibility = Visibility.Visible;
                //       labelCouleur1.Visibility = Visibility.Visible;
                labelPrenom1.Visibility = Visibility.Visible;
                labelNom1.Visibility = Visibility.Visible;
                labelPoids1.Visibility = Visibility.Visible;
                textBoxNom1.Visibility = Visibility.Visible;
                textBoxPrenom1.Visibility = Visibility.Visible;
                textBoxPoids1.Visibility = Visibility.Visible;

                labelCycliste2.Visibility = Visibility.Visible;
                //       labelCouleur2.Visibility = Visibility.Visible;
                labelPrenom2.Visibility = Visibility.Visible;
                labelNom2.Visibility = Visibility.Visible;
                labelPoids2.Visibility = Visibility.Visible;
                textBoxNom2.Visibility = Visibility.Visible;
                textBoxPrenom2.Visibility = Visibility.Visible;
                textBoxPoids2.Visibility = Visibility.Visible;

                labelCycliste3.Visibility = Visibility.Visible;
                //        labelCouleur3.Visibility = Visibility.Visible;
                labelPrenom3.Visibility = Visibility.Visible;
                labelNom3.Visibility = Visibility.Visible;
                labelPoids3.Visibility = Visibility.Visible;
                textBoxNom3.Visibility = Visibility.Visible;
                textBoxPrenom3.Visibility = Visibility.Visible;
                textBoxPoids3.Visibility = Visibility.Visible;

                labelCycliste4.Visibility = Visibility.Hidden;
                //      labelCouleur4.Visibility = Visibility.Hidden;
                labelPrenom4.Visibility = Visibility.Hidden;
                labelNom4.Visibility = Visibility.Hidden;
                labelPoids4.Visibility = Visibility.Hidden;
                textBoxNom4.Visibility = Visibility.Hidden;
                textBoxPrenom4.Visibility = Visibility.Hidden;
                textBoxPoids4.Visibility = Visibility.Hidden;

                buttonValider.Visibility = Visibility.Visible;
            }
            else if (radioButton4.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 4;
                Properties.Settings.Default.Save();

                labelCycliste1.Visibility = Visibility.Visible;
                //    labelCouleur1.Visibility = Visibility.Visible;
                labelPrenom1.Visibility = Visibility.Visible;
                labelNom1.Visibility = Visibility.Visible;
                labelPoids1.Visibility = Visibility.Visible;
                textBoxNom1.Visibility = Visibility.Visible;
                textBoxPrenom1.Visibility = Visibility.Visible;
                textBoxPoids1.Visibility = Visibility.Visible;

                labelCycliste2.Visibility = Visibility.Visible;
                //     labelCouleur2.Visibility = Visibility.Visible;
                labelPrenom2.Visibility = Visibility.Visible;
                labelNom2.Visibility = Visibility.Visible;
                labelPoids2.Visibility = Visibility.Visible;
                textBoxNom2.Visibility = Visibility.Visible;
                textBoxPrenom2.Visibility = Visibility.Visible;
                textBoxPoids2.Visibility = Visibility.Visible;

                labelCycliste3.Visibility = Visibility.Visible;
                //     labelCouleur3.Visibility = Visibility.Visible;
                labelPrenom3.Visibility = Visibility.Visible;
                labelNom3.Visibility = Visibility.Visible;
                labelPoids3.Visibility = Visibility.Visible;
                textBoxNom3.Visibility = Visibility.Visible;
                textBoxPrenom3.Visibility = Visibility.Visible;
                textBoxPoids3.Visibility = Visibility.Visible;

                labelCycliste4.Visibility = Visibility.Visible;
                //    labelCouleur4.Visibility = Visibility.Visible;
                labelPrenom4.Visibility = Visibility.Visible;
                labelNom4.Visibility = Visibility.Visible;
                labelPoids4.Visibility = Visibility.Visible;
                textBoxNom4.Visibility = Visibility.Visible;
                textBoxPrenom4.Visibility = Visibility.Visible;
                textBoxPoids4.Visibility = Visibility.Visible;

                buttonValider.Visibility = Visibility.Visible;
            }
            this.Height = 480;

        }
        // Création d'un évènement pour la base de données
        GestionMySQLDataBase gest = new GestionMySQLDataBase();

        int i = 0;


        /// <summary>
        /// Actions du bouton Valider
        /// </summary>
        private void buttonValider_Click(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                // Pour un participant sélectionné
                case 1:
                    // Traduit les informations en texte
                    Properties.Settings.Default.NomP1 = textBoxNom1.Text.ToString();
                    Properties.Settings.Default.PrenomP1 = textBoxPrenom1.Text.ToString();
                    //  Properties.Settings.Default.PoidsP1 = Int32.Parse(textBoxPoids1.Text.ToString());
                    Properties.Settings.Default.idP1 = int.Parse(Properties.Settings.Default.idP1.ToString());

                    // Enregistre les informations rentrées dans la base de données lorsque l'on clique sur le bouton valider
                    gest.inserer_donnees(Properties.Settings.Default.NomP1, Properties.Settings.Default.PrenomP1, int.Parse(Properties.Settings.Default.PoidsP1.ToString()), int.Parse(Properties.Settings.Default.idP1.ToString()));

                    // Sauvegarde
                    Properties.Settings.Default.Save();
                    i = 1;
                    break;

                // Pour deux participants sélectionnés
                case 2:
                    // On répète les mêmes opérations que pour un participant
                    Properties.Settings.Default.NomP1 = textBoxNom1.Text.ToString();
                    Properties.Settings.Default.PrenomP1 = textBoxPrenom1.Text.ToString();
                    Properties.Settings.Default.PoidsP1 = int.Parse(textBoxPoids1.Text.ToString());

                    //     gest.inserer_donnees(textBoxNom1.Text.ToString(), textBoxPrenom1.Text.ToString(), Int32.Parse(textBoxPoids1.Text.ToString()));


                    Properties.Settings.Default.NomP2 = textBoxNom2.Text.ToString();
                    Properties.Settings.Default.PrenomP2 = textBoxPrenom2.Text.ToString();
                    Properties.Settings.Default.PoidsP2 = int.Parse(textBoxPoids2.Text.ToString());


                    Properties.Settings.Default.Save();
                    i = 2;
                    break;

                // Pour trois participants sélectionnés
                case 3:
                    // On répète les mêmes opérations que pour un participant
                    Properties.Settings.Default.NomP1 = textBoxNom1.Text.ToString();
                    Properties.Settings.Default.PrenomP1 = textBoxPrenom1.Text.ToString();
                    Properties.Settings.Default.PoidsP1 = int.Parse(textBoxPoids1.Text.ToString());



                    Properties.Settings.Default.NomP2 = textBoxNom2.Text.ToString();
                    Properties.Settings.Default.PrenomP2 = textBoxPrenom2.Text.ToString();
                    Properties.Settings.Default.PoidsP2 = int.Parse(textBoxPoids2.Text.ToString());



                    Properties.Settings.Default.NomP3 = textBoxNom3.Text.ToString();
                    Properties.Settings.Default.PrenomP3 = textBoxPrenom3.Text.ToString();
                    Properties.Settings.Default.PoidsP3 = int.Parse(textBoxPoids3.Text.ToString());



                    Properties.Settings.Default.Save();
                    i = 3;
                    break;

                // Pour quatre participants sélectionnés
                case 4:
                    // On répète les mêmes opérations que pour un participant
                    Properties.Settings.Default.NomP1 = textBoxNom1.Text.ToString();
                    Properties.Settings.Default.PrenomP1 = textBoxPrenom1.Text.ToString();
                    //    Properties.Settings.Default.PoidsP1 = int.Parse(textBoxPoids1.Text.ToString());



                    Properties.Settings.Default.NomP2 = textBoxNom2.Text.ToString();
                    Properties.Settings.Default.PrenomP2 = textBoxPrenom2.Text.ToString();
                    //   Properties.Settings.Default.PoidsP2 = int.Parse(textBoxPoids2.Text.ToString());



                    Properties.Settings.Default.NomP3 = textBoxNom3.Text.ToString();
                    Properties.Settings.Default.PrenomP3 = textBoxPrenom3.Text.ToString();
                    //     Properties.Settings.Default.PoidsP3 = int.Parse(textBoxPoids3.Text.ToString());



                    Properties.Settings.Default.NomP4 = textBoxNom4.Text.ToString();
                    Properties.Settings.Default.PrenomP4 = textBoxPrenom4.Text.ToString();
                    //    Properties.Settings.Default.PoidsP4 = int.Parse(textBoxPoids4.Text.ToString());



                    Properties.Settings.Default.Save();
                    i = 4;
                    break;
            }

            //Création d'un nouvel évènement 'col_en_cours' pour ouvrir la page 'WindowCollaboEnCours'
            WindowCollaboEnCours col_en_cours = new WindowCollaboEnCours(i);
            col_en_cours.ShowDialog();
            this.Close();

        }

    }
}

