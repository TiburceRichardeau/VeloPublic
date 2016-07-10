using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace VeloPublic.Window
{
    /// <summary>
    /// Logique d'interaction pour ModifierEv.xaml
    /// </summary>
    public partial class ModifierEv
    {
        /// <summary>
        /// Contient l'id de l'événement a modifier
        /// </summary>
        string idSelectedEv;

        /// <summary>
        /// Constructeur de la fenetre qui permet de modifier un événement
        /// </summary>
        public ModifierEv()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Properties.Settings.Default.erreurSQL = false;
            Properties.Settings.Default.Save();
            // Connexion 
            string myConnectionString = "server=" + "localhost" + ";" + "uid=" + "userVeloPublic" + ";" + "pwd=" + "userVeloPublic" + ";" + "database=" + "veloinfospublic" + ";" + "Charset=" + "utf8" + ";";
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open(); // Si la conexion marche ou l'ouvre

            // Select
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `evenement` WHERE idEvenement=" + Properties.Settings.Default.idEv, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string id = string.Empty;
            string nom = string.Empty;
            string date = string.Empty;
            string lieu = string.Empty;

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Log l = new Log(Log.Type.Infos, "Evenement(s) trouvés dans la base de donnée");
                    id = rdr[0].ToString();
                    nom = rdr[1].ToString();
                    date = rdr[2].ToString().Substring(0, 10);
                    lieu = rdr[3].ToString();

                }

                textBoxLieu.Text = lieu;
                textBoxNomEv.Text = nom;
                DPEv.SelectedDate = DateTime.Parse(date);
                idSelectedEv = id;
            }
            else
            {
                Log l = new Log(Log.Type.Infos, "Il n'y a pas d'évenement dans la base de données");
            }
        }

        /// <summary>
        /// Permet de gérer le focus avec les placeholders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNomEv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxNomEv.Text == "Nom de l'événement")
            {
                textBoxNomEv.Text = "";
                textBoxNomEv.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus avec les placeholders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNomEv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNomEv.Text))
            {
                textBoxNomEv.Text = "Nom de l'événement";
                textBoxNomEv.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus avec les placeholders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelLieu_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLieu.Text == "Lieu")
            {
                textBoxLieu.Text = "";
                textBoxLieu.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus avec les placeholders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelLieu_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxLieu.Text))
            {
                textBoxLieu.Text = "Lieu";
                textBoxLieu.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de limiter la saisi dans le champ de saisi du lieu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNLieu_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            bool isCapsOn = Keyboard.IsKeyToggled(Key.CapsLock);
            bool isLeftShiftDown = Keyboard.IsKeyDown(Key.LeftShift);
            bool isRightShiftDown = Keyboard.IsKeyDown(Key.RightShift);
            bool isD4Down = Keyboard.IsKeyDown(Key.D4);


            if (!isCapsOn && isD4Down && !isRightShiftDown && !isLeftShiftDown)
            {
                e.Handled = true;
                Erreur er = new Erreur("' est un caractère interdit");
                er.ShowDialog();
            }
            if (isCapsOn && isD4Down && isRightShiftDown && !isLeftShiftDown)
            {
                e.Handled = true;
                Erreur er = new Erreur("' est un caractère interdit");
                er.ShowDialog();
            }
            if (isCapsOn && isD4Down && !isRightShiftDown && isLeftShiftDown)
            {
                e.Handled = true;
                Erreur er = new Erreur("' est un caractère interdit");
                er.ShowDialog();
            }
        }

        /// <summary>
        /// Méthode exécutée lors de la fermeture de la fentre.
        /// Quand la fenetre se ferme on réouvre la fenetre qui permet de choisir un événement dans une liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NewEvenement ev = new NewEvenement(true);
            ev.Show();
        }

        /// <summary>
        /// Méthode qui permet de gérer le clic sur l'image qui permet de valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Parse(DPEv.SelectedDate.ToString());
                string datestr = date.ToString("yyyy-MM-dd HH:mm:ss");
                SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8"); // Création de l'objet SQLCo qui permet d'accéder a la base de donnée
                co.Connexion();
                co.Update("UPDATE `evenement` SET `nom`='" + textBoxNomEv.Text + "',`date`='" + datestr + "',`lieu`='" + textBoxLieu.Text + "' WHERE `idEvenement`='" + idSelectedEv + "';");
                co.Deconnexion();
                this.Close();
            }
            catch
            {
                Erreur er = new Erreur("Erreur lors de la modification de l'événement");
                er.ShowDialog();
            }
            
        }

        /// <summary>
        /// Permet de gérer le passage de la souris sur le bouton valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            imageValider.Height += 10;
            imageValider.Width += 10;
            imageValider.Margin = new Thickness(103, 5, 103, 5);
        }

        /// <summary>
        /// Permet de gérer le passage de la souris sur le bouton valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageValider_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            imageValider.Height -= 10;
            imageValider.Width -= 10;
            imageValider.Margin = new Thickness(108, 0, 108, 10);
        }

        /// <summary>
        /// Permet de gérer le clic sur le bouton retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectRetour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Permet de gérer le passage de la souris sur le bouton retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectRetour_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            RectRetour.Margin = new Thickness(2, 2, 0, 0);
            imageRetour.Margin = new Thickness(13, 13, 0, 0);
            RectRetour.Width += 6;
            RectRetour.Height += 6;
            imageRetour.Width += 6;
            imageRetour.Height += 6;
        }

        /// <summary>
        /// Permet de gérer le passage de souris sur le bouton retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectRetour_MouseLeave(object sender, MouseEventArgs e)
        {
            RectRetour.Margin = new Thickness(5, 5, 0, 0);
            imageRetour.Margin = new Thickness(15, 15, 0, 0);
            RectRetour.Width -= 6;
            RectRetour.Height -= 6;
            imageRetour.Width -= 6;
            imageRetour.Height -= 6;
            Cursor = Cursors.Arrow;
        }
    }
}
