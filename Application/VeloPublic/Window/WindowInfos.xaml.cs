using System.Windows;
using System.Windows.Input;

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour WindowInfos.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class WindowInfos
    {
        /// <summary>
        /// Constructeur de la fenetre WindowInfos (A propos)
        /// </summary>
        public WindowInfos()
        {
            InitializeComponent();
            imageValider.Focus();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre d'infos sur l'application");
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // Permet de centrer la fenetre au centre de l'écran
            textBlockInfos.TextAlignment = TextAlignment.Center; // Permet de centrer le texte
            // Texte a afficher dans la fenetre
            textBlockInfos.Text = "Application developped by Tiburce Richardeau" + '\n' + '\n'
                + "Icon made by Freepik from flaticon.com is licensed under CC BY 3.0"
                + '\n' + "Icon also made by Nick Roach from iconfinder.com"
                + '\n' + "Theme MahApp.Metro under Ms-PL License"
                + '\n' + "ChartistJS Chart, Copyright (c) 2013 Gion Kunz gion.kunz@gmail.com"
                + '\n' + "Version 0.9.20160603";
        }

        /// <summary>
        /// Action lors de l'appui sur le bouton imageValider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Evenement lors du clic sur le bouton</param>
        private void imageValider_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            imageValider.Height -= 10;
            imageValider.Width -= 10;
            imageValider.Margin = new Thickness(108, 0, 108, 10);
        }


        /// <summary>
        /// Permet de gérer le survol du bouton valider quand la souris entre dans la zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            imageValider.Height += 10;
            imageValider.Width += 10;
            imageValider.Margin = new Thickness(103, 0, 103, 10);
        }

        /// <summary>
        /// Permet de gérer le clic sur le bouton imageValiderf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Fermeture de la fenetre d'infos");
            Close(); // Ferme la fenetre
        }

        /// <summary>
        /// Permet de fermer la fenetre avec un appui sur bouton entrer ou espace
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
