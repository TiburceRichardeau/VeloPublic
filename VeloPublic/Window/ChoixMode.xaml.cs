using System.Windows;
using System.Windows.Input;
using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace VeloPublic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Constructeur de la fenetre qui permet de choisir le mode (MainWindow)
        /// Fentre de démarrage de l'application
        /// </summary>
        /// <author>Tiburce Richardeau</author>
        public MainWindow()
        {
            /*
            // Permet de lancer wamp si il n'est lancé
            if (Properties.Settings.Default.wampPath != string.Empty)
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.wampPath);
            }else
            {
                System.Windows.Forms.OpenFileDialog openfile = new System.Windows.Forms.OpenFileDialog();
                openfile.Filter = "wamp.exe|*.exe";
                openfile.Title = "Ouvrir wamp";
                openfile.ShowDialog();
                Properties.Settings.Default.wampPath = openfile.FileName;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.wampPath != string.Empty)
                    System.Diagnostics.Process.Start(Properties.Settings.Default.wampPath);
                this.Topmost = true; // Permet de réafficher la fentre
            }
            */
            InitializeComponent();

            modeCollaboImage.Width -= 20;
            modeCollaboImage.Height -= 20;

            modeDefiImage.Width -= 20;
            modeDefiImage.Height -= 20;
            SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8"); // Création de l'objet SQLCo qui permet d'accéder a la base de donnée
            if (!co.Connexion())
            {
                Close();
            }

            Log l = new Log(Log.Type.Infos, "Démarrage de la fenetre de choix du mode");
            Properties.Settings.Default.erreurSQL = false; // Définition de la viariable qui vérifi les erreurs SQL a false (on a pas encore éxécuter de requete SQL)
            Properties.Settings.Default.Save(); // Sauvegarde dans les paramètres d'application
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Placement de la fenetre au centre de l'écran
            VerifierResolution(); // Vérification de la résolution de l'écran pour savoir si l'application peut s'afficher correctement
        }

       

        /// <summary>
        /// Permet de vérifier si la résolution de l'écran est suffisante pour afficher la fentre
        /// Resolution minimale recommandée : 900*450
        /// </summary>
        /// <returns><code>true</code>si la résolution est suffisante <code>false</code> sinon</returns>
        private bool VerifierResolution()
        {
            Log l = new Log(Log.Type.Infos, "Vérification de la résolution");
            if (SystemParameters.PrimaryScreenWidth < this.Width) // Si la lageur de l'écran est inferieur a la largeur de l'application
            {
                this.Width = SystemParameters.PrimaryScreenWidth;
                Erreur win = new Erreur("Vous utilisez l'application avec une résolution non optimale");
                win.ShowDialog(); // affichage d'un message de pour prévenir l'utilisateur
                return false; // La résolution n'est pas optimale
            }else
            {
                return true; // La résolution est optimale
            }    
        }

        // Gestion actions utilisateur mode défi

        /// <summary>
        /// Permet de mettre en gras et d'agrandir l'image du mode défi lorsce que l'utilisateur passe la souris dessus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefi_MouseEnter(object sender, MouseEventArgs e)
        {
            labelDefi.FontWeight = FontWeights.Bold; // Lors du passage de la souris sur le label collaboration le texte passe en gras
            Cursor = Cursors.Hand;
            modeDefiImage_MouseEnter(sender, e);
        }


        /// <summary>
        /// Permet de diminué la taila de l'image du mode défi et de remettre la police en normal (non gras)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefi_MouseLeave(object sender, MouseEventArgs e)
        {
            labelDefi.FontWeight = FontWeights.Normal; // Puis repasse en normal quand la souris n'est plus dessus
            Cursor = Cursors.Arrow;
            modeDefiImage_MouseLeave(sender, e);
        }

        /// <summary>
        /// Permet de gérer le clic sur l'image du mode défi (ouverture du mode défi...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeDefiImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
            Log l = new Log(Log.Type.Infos, "Mode défi choisi");
            Properties.Settings.Default.Mode = "Défi"; // On définit le mode sur défi
            Properties.Settings.Default.Save(); // Sauvegarde de la modification
            NewEvenement ev = new NewEvenement(); // Création de la fentre de l'évenement
            ev.Show(); // Affichage de la fentre crée
            this.Close();
        }



        /// <summary>
        /// Permet de gérer le clic sur le label du mode défi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefi_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
            Log l = new Log(Log.Type.Infos, "clic sur le label de défi");
            modeDefiImage_MouseLeftButtonUp(sender, e);// Rappel de la fonction button défi pour rendre le label cliquable
        }


        /// <summary>
        /// Permet de gérer le survol par la souris de l'image du mode collaboration (lorsce que la souris entre dans la zone)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeDefiImage_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            modeDefiImage.Width += 20;
            modeDefiImage.Height += 20;
            modeDefiImage.Margin = new Thickness(0, 0, 0, 0);
            labelDefi.FontWeight = FontWeights.Bold; // Puis repasse en normal quand la souris n'est plus dessus
        }

        /// <summary>
        /// Permet de gérer le survol par la souris de l'image du mode defi (lorsce que la souris sort dans la zone)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeDefiImage_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            modeDefiImage.Width -= 20;
            modeDefiImage.Height -= 20;
            modeDefiImage.Margin = new Thickness(10, 10, 10, 10);
            labelDefi.FontWeight = FontWeights.Normal; // Puis repasse en normal quand la souris n'est plus dessus
        }

        // Gestion des actions utilisateurs mode collaboration


        /// <summary>
        /// Permet de gerer le survol du label du mode collaboration (mise en gras du texte) lors du survol par la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCollabo_MouseEnter(object sender, MouseEventArgs e)
        {
            labelCollabo.FontWeight = FontWeights.Bold; // Lors du passage de la souris sur le label defi le texte passe en gras
            Cursor = Cursors.Hand;
            modeCollaboImage_MouseEnter(sender, e);
        }

        /// <summary>
        /// Permet de remettre en normal la police utilisée pour le label du mode collaboration lors que la souris n'est plus sur le label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCollabo_MouseLeave(object sender, MouseEventArgs e)
        {
            labelCollabo.FontWeight = FontWeights.Normal; // Puis repasse en normal quand la souris n'est plus dessus
            Cursor = Cursors.Arrow;
            modeCollaboImage_MouseLeave(sender, e);
        }



        /// <summary>
        /// Permet de gérer le clic sur le label du mode collaboration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCollabo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
            Log l = new Log(Log.Type.Infos, "Mode collaboration choisi (via label)");
            this.Topmost = false;
            Properties.Settings.Default.Mode = "Collaboration"; // Enregistrement du mode choisi
            Properties.Settings.Default.Save(); // Sauvegarde
            NewEvenement ev = new NewEvenement(); // Création de la fentre de l'évenement
            ev.Show(); // Affichage de la fentre créée
            this.Close();
        }

        /// <summary>
        /// Permet de gérer le clic sur l'image du mode collaboration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeCollaboImage_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            modeCollaboImage.Margin = new Thickness(0, 0, 0, 0);
            modeCollaboImage.Width += 20;
            modeCollaboImage.Height += 20;
            labelCollabo.FontWeight = FontWeights.Bold; // on passe le label en gras au survol

        }

        /// <summary>
        /// Permet de gérer le survol par la souris de l'image du mode collaboration (lorsce que la souris sort dans la zone)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeCollaboImage_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            modeCollaboImage.Width -= 20;
            modeCollaboImage.Height -= 20;
            modeCollaboImage.Margin = new Thickness(10, 10, 10, 10);
            labelCollabo.FontWeight = FontWeights.Normal; // Puis repasse en normal quand la souris n'est plus dessus
        }



        /// <summary>
        /// Permet de gérer le clic sur l'image du mode collaboration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeCollaboImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.Mode = "Collaboration";
            Properties.Settings.Default.Save();
            NewEvenement ev = new NewEvenement(); // Création de la fentre de l'évenement
            ev.Show(); // Affichage de la fentre crée
            this.Close();
        }


        // Gestion actions utilisateur bouton A Propos

        /// <summary>
        /// Permet de gérer le clic sur le bouton qui ouvre la fenetre "A propos" (voir WindowInfos.xaml)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParamEvenementImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
            Log l = new Log(Log.Type.Infos, "appui sur le bouton A propos");
            WindowInfos win = new WindowInfos(); // Action lors du clic sur le boutton A Propos
            win.ShowDialog(); // Affichage de la fenetre
        }

        /// <summary>
        /// Permet de gérer le survol par la souris de l'image du bouton a propos (lorsce que la souris sort dans la zone)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParamEvenementImage_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            ParamEvenementImage.Height -= 10;
            ParamEvenementImage.Width -= 10;
            ParamEvenementImage.Margin = new Thickness(0, 0, 41, 36);
        }

        /// <summary>
        /// Permet de gérer le survol par la souris de l'image du bouton a propos (lorsce que la souris entre dans la zone)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParamEvenementImage_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            ParamEvenementImage.Height += 10;
            ParamEvenementImage.Width += 10;
            ParamEvenementImage.Margin = new Thickness(0, 0, 36, 32);
        }

        private void ButtonInfos_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
            Log l = new Log(Log.Type.Infos, "appui sur le bouton A propos");
            WindowInfos win = new WindowInfos(); // Action lors du clic sur le boutton A Propos
            win.ShowDialog(); // Affichage de la fenetre
        }

        private void ButtonInfos_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void ButtonInfos_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
