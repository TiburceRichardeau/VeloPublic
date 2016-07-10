using System.Windows;
using System.Windows.Media;
using System;
using System.Windows.Input;

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour Erreur.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class Erreur
    {
        /// <summary>
        /// Constructeur de la fenetre Erreur
        /// </summary>
        /// <param name="message">Contient le message d'erreur a afficher</param>
        public Erreur(string message)
        {
            InitializeComponent();
            imageValider.Focus();
            //MediaPlayer mp = new MediaPlayer();
            //mp.Open(new Uri(Environment.GetEnvironmentVariable("windir") + "\\Media\\" + "Windows Error.wav"));
            //mp.Play();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            labelErreur.Content = message;
            // Permet de voir le message en entier
            this.Width = (message.ToString().Length) * 10;
            labelErreur.Width = (message.ToString().Length) * 10;

            // Permet de diminuer la taille du message sur les écran qui ont une petite résolution d'écran
            if (SystemParameters.PrimaryScreenWidth < this.Width)
            {
                Width = SystemParameters.PrimaryScreenWidth; // Redimentionne la largeur de la fenetre au max de la définition de l'écran
                labelErreur.Width = SystemParameters.PrimaryScreenWidth;
            }
            // Permet de centrer le bouton au centre de la fenetre
            imageValider.Margin = new Thickness(((Width - imageValider.Width) / 2), 0, ((Width - imageValider.Width) / 2), 10);
            image.Margin = new Thickness(((Width - image.Width) / 2), 4, 0,0); // Permet de centrer l'image

            Log l = new Log(Log.Type.Erreur, message);
            VerifierTailleMin(message);
        }

        public Erreur()
        {
            InitializeComponent();
            imageValider.Focus();
            string message = "Les fichiers de logs sont en lecture seule";
            //MediaPlayer mp = new MediaPlayer();
            //mp.Open(new Uri(Environment.GetEnvironmentVariable("windir") + "\\Media\\" + "Windows Error.wav"));
            //mp.Play();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            labelErreur.Content = message;
            // Permet de voir le message en entier
            this.Width = (message.ToString().Length) * 10;
            labelErreur.Width = (message.ToString().Length) * 10;

            // Permet de diminuer la taille du message sur les écran qui ont une petite résolution d'écran
            if (SystemParameters.PrimaryScreenWidth < this.Width)
            {
                Width = SystemParameters.PrimaryScreenWidth; // Redimentionne la largeur de la fenetre au max de la définition de l'écran
                labelErreur.Width = SystemParameters.PrimaryScreenWidth;
            }
            // Permet de centrer le bouton au centre de la fenetre
            imageValider.Margin = new Thickness(((Width - imageValider.Width) / 2), 0, ((Width - imageValider.Width) / 2), 10);
            image.Margin = new Thickness(((Width - image.Width) / 2), 4, 0, 0); // Permet de centrer l'image

            VerifierTailleMin(message);
        }


        /// <summary>
        /// Permet de vérifier si la fenetre est assez grande pour afficher le message
        /// La fenetre est redimmentionnée si ce n'est pas le cas
        /// </summary>
        /// <param name="message"></param>
        private void VerifierTailleMin(string message)
        {
            if (this.Width < 200)
            {
                this.Width = 200;
                imageValider.Focus();
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                // Permet de voir le message en entier
                labelErreur.Width = (message.ToString().Length) * 10;

                // Permet de diminuer la taille du message sur les écran qui ont une petite résolution d'écran
                if (SystemParameters.PrimaryScreenWidth < this.Width)
                {
                    Width = SystemParameters.PrimaryScreenWidth; // Redimentionne la largeur de la fenetre au max de la définition de l'écran
                    labelErreur.Width = SystemParameters.PrimaryScreenWidth;
                }
                // Permet de centrer le bouton au centre de la fenetre
                imageValider.Margin = new Thickness(((Width - imageValider.Width) / 2), 0, ((Width - imageValider.Width) / 2), 10);
                image.Margin = new Thickness(((Width - image.Width) / 2), 4, 0, 0); // Permet de centrer l'image
            }
        }

        /// <summary>
        /// Permet de gérer le survol de la souris sur le bouton valider quand la souris sort dans la zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            imageValider.Height -= 10;
            imageValider.Width -= 10;
            imageValider.Margin = new Thickness(((Width - imageValider.Width) / 2), 0, ((Width - imageValider.Width) / 2), 10);
        }

        /// <summary>
        /// Permet de gérer le survol de la souris sur le bouton valider quand la souris entre dans la zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            imageValider.Height += 10;
            imageValider.Width += 10;
            imageValider.Margin = new Thickness(((Width - imageValider.Width) / 2), 0, ((Width - imageValider.Width) / 2), 5);
        }

        /// <summary>
        /// Permet de gérer le clic sur le bouton imageValider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close(); // Ferme la fenetre
        }

        /// <summary>
        /// Permet de fermer la fenetre avec un appui sur la touche entrer ou espace du clavier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Return) || Keyboard.IsKeyDown(Key.Space))
            {
                Close();
            }
        }
    }
}
