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

namespace VeloPublic.Window
{
    /// <summary>
    /// Logique d'interaction pour SupprimerEv.xaml
    /// </summary>
    public partial class SupprimerEv
    {
        /// <summary>
        /// Constructeur par défaut de la fenetre de suppression d'événement
        /// </summary>
        public SupprimerEv()
        {
            InitializeComponent();
            //this.Topmost = true;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Action lors de l'appui sur le bouton "Supprimer" (l'événement est supprimer de la base de données)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SQLCo conn = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
            conn.Connexion(); // Ouverture de la connexion à la base de donnée
            //"select foreach idcourse in course delete from cycliste where cycliste = "
            conn.Insert("DELETE FROM `evenement` WHERE idEvenement=" + Properties.Settings.Default.idEv + ";");
            conn.Deconnexion();
            this.Close();
        }

        /// <summary>
        /// Action lors de l'appui sur le bouton annulé (la fenetre se ferme)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Méthode éxécuté lors de la fermeture de la fentre (on ouvre la fenetre qui affiche la liste des événements existants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NewEvenement win = new NewEvenement(true);
            win.Show();
        }
    }
}
