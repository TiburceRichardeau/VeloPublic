using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

using MySql.Data;
using MySql.Data.MySqlClient;

// Auteur Claire Pubert

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour WindowCollaboEnCours.xaml
    /// </summary>
    public partial class WindowCollaboEnCours
    {
        private int time = 300;
        private DispatcherTimer Timer;

        private ResumeCollabo res_col;

        /// <summary>
        /// Constructeur de WindowCollaboEnCours, avec affichage des informations des participants
        /// </summary>
        /// <param name="nb_particip"></param>
        public WindowCollaboEnCours(int nb_particip)
        {
            InitializeComponent();

            res_col = null;

            this.WindowState = WindowState.Maximized;

            // Création et initialisation du Timer
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;


            //-------------------------------------
            // Affiche le(s) participant(s) sélectionné(s) avec leur infos
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    vitesse1.Visibility = Visibility.Visible;
                    labelVitesseMoyenne1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    textBoxVitesse1.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;


                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Hidden;

                    labelCouleur2.Visibility = Visibility.Hidden;
                    labelVitesse2.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne2.Visibility = Visibility.Hidden;
                    labelEnergieProduite2.Visibility = Visibility.Hidden;
                    labelDistanceParcourue2.Visibility = Visibility.Hidden;
                    labelCalorie2.Visibility = Visibility.Hidden;
                    textBoxVitesse2.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne2.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue2.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite2.Visibility = Visibility.Hidden;
                    textBoxCalorie2.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;



                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Hidden;

                    labelCouleur3.Visibility = Visibility.Hidden;
                    labelVitesse3.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne3.Visibility = Visibility.Hidden;
                    labelEnergieProduite3.Visibility = Visibility.Hidden;
                    labelDistanceParcourue3.Visibility = Visibility.Hidden;
                    labelCalorie3.Visibility = Visibility.Hidden;
                    textBoxVitesse3.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne3.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite3.Visibility = Visibility.Hidden;
                    textBoxCalorie3.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelVitesse4.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    textBoxVitesse4.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 2:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    vitesse1.Visibility = Visibility.Visible;
                    labelVitesseMoyenne1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    textBoxVitesse1.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;


                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelVitesse2.Visibility = Visibility.Visible;
                    labelVitesseMoyenne2.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    labelCalorie2.Visibility = Visibility.Visible;
                    textBoxVitesse2.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;


                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Hidden;

                    labelCouleur3.Visibility = Visibility.Hidden;
                    labelVitesse3.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne3.Visibility = Visibility.Hidden;
                    labelEnergieProduite3.Visibility = Visibility.Hidden;
                    labelDistanceParcourue3.Visibility = Visibility.Hidden;
                    labelCalorie3.Visibility = Visibility.Hidden;
                    textBoxVitesse3.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne3.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue3.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite3.Visibility = Visibility.Hidden;
                    textBoxCalorie3.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelVitesse4.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    textBoxVitesse4.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 3:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    vitesse1.Visibility = Visibility.Visible;
                    labelVitesseMoyenne1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    textBoxVitesse1.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;


                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelVitesse2.Visibility = Visibility.Visible;
                    labelVitesseMoyenne2.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    labelCalorie2.Visibility = Visibility.Visible;
                    textBoxVitesse2.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;


                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Visible;

                    labelCouleur3.Visibility = Visibility.Visible;
                    labelVitesse3.Visibility = Visibility.Visible;
                    labelVitesseMoyenne3.Visibility = Visibility.Visible;
                    labelEnergieProduite3.Visibility = Visibility.Visible;
                    labelDistanceParcourue3.Visibility = Visibility.Visible;
                    labelCalorie3.Visibility = Visibility.Visible;
                    textBoxVitesse3.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne3.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxEnergieProduite3.Visibility = Visibility.Visible;
                    textBoxCalorie3.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Visible;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Hidden;

                    labelCouleur4.Visibility = Visibility.Hidden;
                    labelVitesse4.Visibility = Visibility.Hidden;
                    labelVitesseMoyenne4.Visibility = Visibility.Hidden;
                    labelEnergieProduite4.Visibility = Visibility.Hidden;
                    labelDistanceParcourue4.Visibility = Visibility.Hidden;
                    labelCalorie4.Visibility = Visibility.Hidden;
                    textBoxVitesse4.Visibility = Visibility.Hidden;
                    textBoxVitesseMoyenne4.Visibility = Visibility.Hidden;
                    textBoxDistanceParcourue4.Visibility = Visibility.Hidden;
                    textBoxEnergieProduite4.Visibility = Visibility.Hidden;
                    textBoxCalorie4.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    break;


                case 4:
                    labelNomP5.Content = Properties.Settings.Default.PrenomP1 + " " + Properties.Settings.Default.NomP1;
                    labelNomP5.Visibility = Visibility.Visible;

                    labelCouleur1.Visibility = Visibility.Visible;
                    vitesse1.Visibility = Visibility.Visible;
                    labelVitesseMoyenne1.Visibility = Visibility.Visible;
                    labelEnergieProduite1.Visibility = Visibility.Visible;
                    labelDistanceParcourue1.Visibility = Visibility.Visible;
                    labelCalorie1.Visibility = Visibility.Visible;
                    textBoxVitesse1.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne1.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue1.Visibility = Visibility.Visible;
                    textBoxEnergieProduite1.Visibility = Visibility.Visible;
                    textBoxCalorie1.Visibility = Visibility.Visible;


                    labelNomP6.Content = Properties.Settings.Default.PrenomP2 + " " + Properties.Settings.Default.NomP2;
                    labelNomP6.Visibility = Visibility.Visible;

                    labelCouleur2.Visibility = Visibility.Visible;
                    labelVitesse2.Visibility = Visibility.Visible;
                    labelVitesseMoyenne2.Visibility = Visibility.Visible;
                    labelEnergieProduite2.Visibility = Visibility.Visible;
                    labelDistanceParcourue2.Visibility = Visibility.Visible;
                    labelCalorie2.Visibility = Visibility.Visible;
                    textBoxVitesse2.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne2.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue2.Visibility = Visibility.Visible;
                    textBoxEnergieProduite2.Visibility = Visibility.Visible;
                    textBoxCalorie2.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Visible;


                    labelNomP7.Content = Properties.Settings.Default.PrenomP3 + " " + Properties.Settings.Default.NomP3;
                    labelNomP7.Visibility = Visibility.Visible;

                    labelCouleur3.Visibility = Visibility.Visible;
                    labelVitesse3.Visibility = Visibility.Visible;
                    labelVitesseMoyenne3.Visibility = Visibility.Visible;
                    labelEnergieProduite3.Visibility = Visibility.Visible;
                    labelDistanceParcourue3.Visibility = Visibility.Visible;
                    labelCalorie3.Visibility = Visibility.Visible;
                    textBoxVitesse3.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne3.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue3.Visibility = Visibility.Visible;
                    textBoxEnergieProduite3.Visibility = Visibility.Visible;
                    textBoxCalorie3.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Visible;


                    labelNomP8.Content = Properties.Settings.Default.PrenomP4 + " " + Properties.Settings.Default.NomP4;
                    labelNomP8.Visibility = Visibility.Visible;

                    labelCouleur4.Visibility = Visibility.Visible;
                    labelVitesse4.Visibility = Visibility.Visible;
                    labelVitesseMoyenne4.Visibility = Visibility.Visible;
                    labelEnergieProduite4.Visibility = Visibility.Visible;
                    labelDistanceParcourue4.Visibility = Visibility.Visible;
                    labelCalorie4.Visibility = Visibility.Visible;
                    textBoxVitesse4.Visibility = Visibility.Visible;
                    textBoxVitesseMoyenne4.Visibility = Visibility.Visible;
                    textBoxDistanceParcourue4.Visibility = Visibility.Visible;
                    textBoxEnergieProduite4.Visibility = Visibility.Visible;
                    textBoxCalorie4.Visibility = Visibility.Visible;
                    rec4.Visibility = Visibility.Visible;
                    break;

            }


        }

        /// <summary>
        /// Création du Timer et des actions possibles en fonction du temps restant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            labelTimer.Content = DateTime.Now.ToString("mm:ss");

            if (time > 0)
            {
                time--;
                labelTimer.Content = string.Format("{0}:{1}", time / 60, time % 60);  //
            }
            else
            {
                Timer.Stop();
                labelTimer.Content = string.Format("00:00");          //Format d'affichage du timer
                System.Windows.MessageBox.Show("TEMPS ECOULE !!");    //Message qui s'affiche à la fin du décompte

            }

        }

        /// <summary>
        /// Fenêtre de fermeture de la collaboration en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (res_col != null)
            {

                res_col.Show();
            }
            else
            {
                if (time > 0)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Vous allez quitter la collaboration et revenir à l'accueil. Etes-vous sûr de vouloir continuer ?", "EnergieCycle", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        Timer.Stop();
                    }
                }
                else
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Vous allez revenir au menu et vos données seront perdues. Continuer ?", "EnergieCycle", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// Bouton Go : démarre la collaboration et le décompte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            buttonGo.Visibility = Visibility.Hidden;              //Disparition du bouton 'Go'
            buttonResume.Visibility = Visibility.Visible;         //Apparition du bouton 'Resume'
            Timer.Start();                                        //Lancement du Timer

            CefGraphCollabo1.Address = "http://localhost/Test_graphiques/test.html";
            CefGraphCollabo2.Address = "http://localhost/Test_graphiques/test_3.html";
        }

        /// <summary>
        /// Bouton 'Resume' : définit l'action à faire si l'on appuie sur le bouton 'Resume' en fonction du temps restant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResume_Click(object sender, RoutedEventArgs e)
        {
            if (time > 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Vous allez interrompre la collaboration en cours. Afficher le résumé ?", "EnergieCycle", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Timer.Stop();
                    res_col = new ResumeCollabo();
                    res_col.Show();
                    this.Close();
                }
            }
        }
    }
}