using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using VeloPublic.Window;

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour NewEvenement.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class NewEvenement
    {
        bool ShowListOnOpen = false;
        bool listeEvExistantVide = false;
        bool ouvrirChoixMode = true;
        bool creationEv; // Variable qui permet de choisir le mode (evenement existant ou non)
        double imgBot, imgTop, RecTop, RecBot;

        enum Ouverture { OuvirChoixMode, OuvrirNewEv, OuvrirListeEv, OuvrirChoixParticipants, OuvrirModifierEv, OuvrirSupprimerEv }
        Ouverture Opening;

        /// <summary>
        /// Constructeur par défaut de la fenetre NewEvenement
        /// </summary>
        public NewEvenement()
        {
            InitializeComponent();
            Opening = Ouverture.OuvirChoixMode;
            ShowListOnOpen = false;
            Log l = new Log(Log.Type.Infos, "Ouverture de la fenetre de création//Selection d'évenement");
            this.Title = Properties.Settings.Default.Mode + " - événement";
            labelNewEv.Visibility = Visibility.Hidden;
            verifierExistanceEv();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Selection de la date auto
            DPEv.SelectedDate = DateTime.Now;
        }

        public NewEvenement(bool afficher_liste)
        {
            InitializeComponent();
            Opening = Ouverture.OuvrirNewEv;
            Log l = new Log(Log.Type.Infos, "Ouverture de la fenetre de création//Selection d'évenement");
            this.Title = Properties.Settings.Default.Mode + " - événement";
            labelNewEv.Visibility = Visibility.Hidden;
            verifierExistanceEv();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Selection de la date auto
            DPEv.SelectedDate = DateTime.Now;
            if (!verifierExistanceEv())
            {
                remplirListEv();
            }
            else
            {
                l = new Log(Log.Type.Infos, "Selection d'un evenement depuis la liste des évenements existants");
                // L'évenement existe déjà
                creationEv = false;
                labelNewEv.Visibility = Visibility.Hidden;

                RectEvExistant.Visibility = Visibility.Hidden;
                RectNouvelEv.Visibility = Visibility.Hidden;
                imageEvExistant.Visibility = Visibility.Hidden;
                imageNouvelEv.Visibility = Visibility.Hidden;
                labelEvExistant.Visibility = Visibility.Hidden;
                labelNouvelEv.Visibility = Visibility.Hidden;

                imageValider.Visibility = Visibility.Visible;
                //listViewEv.Visibility = Visibility.Visible;
                dataGridListEv.Visibility = Visibility.Visible;
                remplirListEv();
                // Récupération de l'id de l'évenement 
                // Enregistrer les données de l'évenement dans les paramètres d'application

                imageRetour.Visibility = Visibility.Visible;
                RectRetour.Visibility = Visibility.Visible;
            }
            labelNewEv.Visibility = Visibility.Hidden;
            ShowListOnOpen = afficher_liste;
        }

        /// <summary>
        /// Méthode qui permet de vérifier si il y a déjà des evenements existants dans la base de données pour afficher ou non le bouton Evenements existants
        /// </summary>
        private bool verifierExistanceEv()
        {
            string myConnectionString = "server=" + "localhost" + ";" + "uid=" + "userVeloPublic" + ";" + "pwd=" + "userVeloPublic" + ";" + "database=" + "veloinfospublic" + ";" + "Charset=" + "utf8" + ";";
            MySqlConnection conn;
            // Connexion a la base de donnée
            try
            {
                Log l;
                //On essaye de se connecter
                conn = new MySqlConnection(myConnectionString);
                conn.Open(); // Si la conexion marche ou l'ouvre
                Properties.Settings.Default.erreurSQL = false;
                Properties.Settings.Default.Save();

                //listViewEv.Items.Clear(); // On vide la liste
                dataGridListEv.Items.Clear();

                // Select
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `evenement` ORDER BY date DESC", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    l = new Log(Log.Type.Infos, "Il n'y a pas d'évenement dans la base de données");
                    //buttonValider.Visibility = Visibility.Hidden;
                    imageValider.Visibility = Visibility.Hidden;
                    //listViewEv.Visibility = Visibility.Hidden;
                    dataGridListEv.Visibility = Visibility.Hidden;
                    RectEvExistant.Visibility = Visibility.Hidden;
                    imageEvExistant.Visibility = Visibility.Hidden;
                    labelEvExistant.Visibility = Visibility.Hidden;

                    listeEvExistantVide = true;

                    RectNouvelEv.Margin = new Thickness((this.Width - (RectNouvelEv.Width)) / 2, RectNouvelEv.Margin.Top, ((this.Width) - (RectNouvelEv.Width)) / 2, RectNouvelEv.Margin.Bottom);
                    RectNouvelEv.Visibility = Visibility.Visible;


                    imageNouvelEv.Margin = new Thickness(((this.Width) - (imageNouvelEv.Width)) / 2, imageNouvelEv.Margin.Top, (this.Width - (imageNouvelEv.Width)) / 2, imageNouvelEv.Margin.Bottom);
                    imageNouvelEv.Visibility = Visibility.Visible;

                    labelNouvelEv.Margin = new Thickness(((this.Width) - (labelNouvelEv.Width)) / 2, labelNouvelEv.Margin.Top, (this.Width - (labelNouvelEv.Width)) / 2, labelNouvelEv.Margin.Bottom);
                    labelNouvelEv.Visibility = Visibility.Visible;

                    imgBot = imageNouvelEv.Margin.Bottom;
                    imgTop = imageNouvelEv.Margin.Top;
                    RecBot = RectNouvelEv.Margin.Bottom;
                    RecTop = RectNouvelEv.Margin.Top;
                    rdr.Close(); // Fermeture du reader une fois le select parcourus
                    conn.Close(); // Fermeture de la connexion
                    return false;
                }
                else
                {
                    return true;
                }


            }
            catch
            {
                return true;
            }
        }

        // TODO trier la liste lors de l'appui sur les colonnes

        /// <summary>
        /// Replissage de la liste des évenements existant en cas de choix de choix d'évenement précédement créer
        /// </summary>
        private void remplirListEv()
        {
            Log l = new Log(Log.Type.Infos, "Remplissage de la liste des évenenemnt existant");
            string myConnectionString = "server=" + "localhost" + ";" + "uid=" + "userVeloPublic" + ";" + "pwd=" + "userVeloPublic" + ";" + "database=" + "veloinfospublic" + ";" + "Charset=" + "utf8" + ";";
            MySqlConnection conn;
            // Connexion a la base de donnée
            try
            {
                //On essaye de se connecter
                conn = new MySqlConnection(myConnectionString);
                conn.Open(); // Si la conexion marche ou l'ouvre
                Properties.Settings.Default.erreurSQL = false;
                Properties.Settings.Default.Save();

                //listViewEv.Items.Clear(); // On vide la liste
                dataGridListEv.Items.Clear();

                // Select
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `evenement` ORDER BY date DESC", conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                long test;

                if (rdr.HasRows)
                {
                    this.Width = 400;
                    this.Height = 350;
                    recentrerFenetre();
                    try
                    {
                        while (rdr.Read())
                        {
                            l = new Log(Log.Type.Infos, "Evenement(s) trouvés dans la base de donnée");
                            string nom = rdr[1].ToString();
                            //string date = rdr[2].ToString().Substring(0, 10);
                            string lieu = rdr[3].ToString();
                            string id = rdr[0].ToString();
                            DateTime dateT = DateTime.Parse(rdr[2].ToString());
                            string date = dateT.ToString().Substring(0, 10);
                            //MessageBox.Show(date + " et " + dateT.ToString());
                            if (long.TryParse(id, out test))
                            {
                                Evenement ev = new Evenement(nom, date, lieu, long.Parse(id));
                                dataGridListEv.Items.Add(ev);
                            }
                            //listViewEv.Items.Add(new { Nom = nom, Lieu = lieu, Date = date, id }); // Remplissage de la liste
                        }
                    }
                    catch
                    {
                        Erreur er = new Erreur("Erreur lors du remplissage de la liste d'événement");
                        er.ShowDialog();
                    }

                }
                else
                {
                    l = new Log(Log.Type.Infos, "Il n'y a pas d'évenement dans la base de données");
                    imageValider.Visibility = Visibility.Hidden;
                    //listViewEv.Visibility = Visibility.Hidden;
                    dataGridListEv.Visibility = Visibility.Hidden;
                    labelNewEv.Content = "Il n'y a aucun évenement";
                    labelNewEv.Visibility = Visibility.Visible;

                    listeEvExistantVide = true;

                    RectNouvelEv.Margin = new Thickness((this.Width - (RectNouvelEv.Width)) / 2, RectNouvelEv.Margin.Top, ((this.Width) - (RectNouvelEv.Width)) / 2, RectNouvelEv.Margin.Bottom);
                    RectNouvelEv.Visibility = Visibility.Visible;


                    imageNouvelEv.Margin = new Thickness(((this.Width) - (imageNouvelEv.Width)) / 2, imageNouvelEv.Margin.Top, (this.Width - (imageNouvelEv.Width)) / 2, imageNouvelEv.Margin.Bottom);
                    imageNouvelEv.Visibility = Visibility.Visible;

                    labelNouvelEv.Margin = new Thickness(((this.Width) - (labelNouvelEv.Width)) / 2, labelNouvelEv.Margin.Top, (this.Width - (labelNouvelEv.Width)) / 2, labelNouvelEv.Margin.Bottom);
                    labelNouvelEv.Visibility = Visibility.Visible;

                    imgBot = imageNouvelEv.Margin.Bottom;
                    imgTop = imageNouvelEv.Margin.Top;
                    RecBot = RectNouvelEv.Margin.Bottom;
                    RecTop = RectNouvelEv.Margin.Top;
                }

                rdr.Close(); // Fermeture du reader une fois le select parcourus
                conn.Close(); // Fermeture de la connexion
            }
            catch (MySqlException ex) // Sinon on affiche l'erreur
            {
                Close();
                Erreur er = new Erreur("Impossible de récupérer la liste des événements");
                Log SQLlog = new Log(Log.Type.Erreur, ex.Message);
                er.ShowDialog();
                Properties.Settings.Default.erreurSQL = true;
                Properties.Settings.Default.Save();
            }
        }

      
        private void textBoxNLieu_KeyDown(object sender, KeyEventArgs e)
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
        /// Permet de réouvrir la fentre de choix de mode a la fermeture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            switch (Opening)
            {
                case Ouverture.OuvirChoixMode:
                    MainWindow win = new MainWindow();
                    win.Show();
                    break;
                case Ouverture.OuvrirNewEv:
                    NewEvenement ev = new NewEvenement();
                    ev.Show();
                    break;
                case Ouverture.OuvrirListeEv:
                    NewEvenement ListeEv = new NewEvenement(true);
                    break;
                case Ouverture.OuvrirChoixParticipants:
                    break;
                case Ouverture.OuvrirSupprimerEv:
                    break;
                case Ouverture.OuvrirModifierEv:
                    break;
                default:
                    break;
            }
        }

        private void buttonCréerEv_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonCréerEv_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void imageNouvelEv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Création d'un nouvel evenement dans la fenetre newEvenement");
            labelNewEv.Visibility = Visibility.Visible;
            labelNewEv.Content = "Nouvel Evenement";
            creationEv = true;
            Opening = Ouverture.OuvrirNewEv;
            this.Height = 300;

            labelNewEv.Visibility = Visibility.Hidden;

            //buttonNon.Visibility = Visibility.Hidden;
            //buttonOui.Visibility = Visibility.Hidden;
            RectEvExistant.Visibility = Visibility.Hidden;
            RectNouvelEv.Visibility = Visibility.Hidden;
            imageEvExistant.Visibility = Visibility.Hidden;
            imageNouvelEv.Visibility = Visibility.Hidden;
            labelNouvelEv.Visibility = Visibility.Hidden;
            labelEvExistant.Visibility = Visibility.Hidden;


            //buttonValider.Visibility = Visibility.Visible;
            imageValider.Visibility = Visibility.Visible;
            //labelNom.Visibility = Visibility.Visible;
            textBoxNomEv.Visibility = Visibility.Visible;
            //labelLieu.Visibility = Visibility.Visible;
            textBoxLieu.Visibility = Visibility.Visible;
            DPEv.Visibility = Visibility.Visible;

            imageRetour.Visibility = Visibility.Visible;
            RectRetour.Visibility = Visibility.Visible;
        }

        private void imageEvExistant_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Selection d'un evenement depuis la liste des évenements existants");
            // L'évenement existe déjà
            Opening = Ouverture.OuvrirNewEv;
            creationEv = false;
            labelNewEv.Visibility = Visibility.Hidden;

            //buttonNon.Visibility = Visibility.Hidden;
            //buttonOui.Visibility = Visibility.Hidden;
            RectEvExistant.Visibility = Visibility.Hidden;
            RectNouvelEv.Visibility = Visibility.Hidden;
            imageEvExistant.Visibility = Visibility.Hidden;
            imageNouvelEv.Visibility = Visibility.Hidden;
            labelEvExistant.Visibility = Visibility.Hidden;
            labelNouvelEv.Visibility = Visibility.Hidden;

            //buttonValider.Visibility = Visibility.Visible;
            imageValider.Visibility = Visibility.Visible;
            //listViewEv.Visibility = Visibility.Visible;
            dataGridListEv.Visibility = Visibility.Visible;
            remplirListEv();
            // Récupération de l'id de l'évenement 
            // Enregistrer les données de l'évenement dans les paramètres d'application

            imageRetour.Visibility = Visibility.Visible;
            RectRetour.Visibility = Visibility.Visible;
        }

        private void RectNouvelEv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            imageNouvelEv_MouseLeftButtonUp(sender, e);
        }

        private void RectNouvelEv_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            labelNouvelEv.FontWeight = FontWeights.Normal;

            RectNouvelEv.Width -= 10;
            RectNouvelEv.Height -= 10;
            imageNouvelEv.Width -= 10;
            imageNouvelEv.Height -= 10;

            if (listeEvExistantVide == false)
            {
                RectNouvelEv.Margin = new Thickness(18, 61, 0, 0);
                imageNouvelEv.Margin = new Thickness(38, 81, 0, 0);
            }
            else
            {
                RectNouvelEv.Margin = new Thickness((this.Width - (RectNouvelEv.Width)) / 2, RecTop, ((this.Width) - (RectNouvelEv.Width)) / 2, RecBot);
                imageNouvelEv.Margin = new Thickness(((this.Width) - (imageNouvelEv.Width)) / 2, imgTop, (this.Width - (imageNouvelEv.Width)) / 2, imgBot);
            }

        }

        private bool verifNomLieu()
        {
            // Vérification des données saisi par l'utilisateur
            bool nomOk, LieuOk;

            if (textBoxNomEv.Text != string.Empty && textBoxNomEv.Text != "Nom de l'événement")
                nomOk = true;
            else
                nomOk = false;

            if (textBoxLieu.Text != string.Empty && textBoxLieu.Text != "Lieu")
                LieuOk = true;
            else
                LieuOk = false;

            return LieuOk && nomOk;

        }

        private void imageValider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Validation du choix de l'évenement");
            switch (Properties.Settings.Default.Mode)
            {
                case "Défi":
                    if (verifEvenementComplet())
                    {
                        ModeDefiChoixParticipants win = new ModeDefiChoixParticipants();
                        win.Show();
                        Opening = Ouverture.OuvrirChoixParticipants;
                        this.Close();
                    }
                    break;
                case "Collaboration":
                    if (verifEvenementComplet())
                    {
                        ModeCollaboChoixParticipantsTrue win = new ModeCollaboChoixParticipantsTrue();
                        win.Show();
                        Opening = Ouverture.OuvrirChoixParticipants;
                        this.Close();
                    }
                    break;
            }
        }

        private bool verifEvenementComplet()
        {
            bool resultat = false;
            if (creationEv)
            {
                if (verifNomLieu())
                {
                    Properties.Settings.Default.NomEv = textBoxNomEv.Text;
                    Properties.Settings.Default.LieuEv = textBoxLieu.Text;
                    try
                    {
                        // Creation de l'évenement
                        Evenement Ev = new Evenement(textBoxNomEv.Text, (DateTime)DPEv.SelectedDate, textBoxLieu.Text);
                        resultat = true;
                    }
                    catch (MySqlException ex)
                    {
                        Close();
                        Log SQLLog = new Log(Log.Type.Erreur, ex.Message);
                        Erreur er = new Erreur("Erreur lors de la création de l'événement");
                        er.ShowDialog();
                        resultat = false;
                    }
                    if (Properties.Settings.Default.erreurSQL)
                    {
                        Erreur er = new Erreur("Erreur lors de l'enregistrement de l'événement");
                        er.Show();
                        resultat = false;
                    }
                    else
                    {
                        ouvrirChoixMode = false;
                        // Ouverture de la fenetre de saisi des participants
                        resultat = true;
                    }
                }
                else
                {
                    Erreur er = new Erreur("Merci de remplir correctement les champs.");
                    er.ShowDialog();
                    resultat = false;
                }
            }
            else if (creationEv == false)
            {
                // On vérifie si l'utilisateur a bien selectionné un évenement avant de valider
                //if (listViewEv.SelectedIndex > -1) // utilisé pour la listView
                if (dataGridListEv.SelectedIndex >-1) // Utilisé pour la datagrid
                {
                    ouvrirChoixMode = false;
                    return true;
                }
                else
                {
                    Erreur er = new Erreur("Merci de selectionner un événement dans la liste");
                    er.ShowDialog();
                    return false;
                }
            }
            return resultat;
        }

        private void imageValider_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            imageValider.Height += 10;
            imageValider.Width += 10;
            imageValider.Margin = new Thickness(103, 5, 103, 5);
        }

        private void imageValider_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            imageValider.Height -= 10;
            imageValider.Width -= 10;
            imageValider.Margin = new Thickness(108, 0, 108, 10);
        }

        private void labelNouvelEv_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            labelNouvelEv.FontWeight = FontWeights.Bold;
        }

        private void labelNouvelEv_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            labelNouvelEv.FontWeight = FontWeights.Normal;
        }

        private void labelEvExistant_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            labelEvExistant.FontWeight = FontWeights.Bold;
        }

        private void labelEvExistant_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            labelEvExistant.FontWeight = FontWeights.Normal;
        }

        private void textBoxNomEv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxNomEv.Text == "Nom de l'événement")
            {
                textBoxNomEv.Text = "";
                textBoxNomEv.Foreground = Brushes.Black; // Noir
            }
        }

        private void textBoxNomEv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNomEv.Text))
            {
                textBoxNomEv.Text = "Nom de l'événement";
                textBoxNomEv.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        private void labelLieu_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLieu.Text == "Lieu")
            {
                textBoxLieu.Text = "";
                textBoxLieu.Foreground = Brushes.Black; // Noir
            }
        }

        private void labelLieu_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxLieu.Text))
            {
                textBoxLieu.Text = "Lieu";
                textBoxLieu.Foreground = Brushes.Gray; // Couleur gris
            }
        }


        private void RectRetour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

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


        private void ConnectionMenuItemClickedEdit(object sender, RoutedEventArgs e)
        {
            // TODO fenetre qui permet de modifier un événement
            ouvrirChoixMode = false;
            Opening = Ouverture.OuvrirModifierEv;
            ModifierEv win = new ModifierEv();
            win.Show();
            this.Close();
        }

        private void ConnectionMenuItemClickedDelete(object sender, RoutedEventArgs e)
        {
            ouvrirChoixMode = false;
            Opening = Ouverture.OuvrirSupprimerEv;
            SupprimerEv win = new SupprimerEv();
            win.Show();
            this.Close();
        }

        private void RectNouvelEv_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            labelNouvelEv.FontWeight = FontWeights.Bold;

            RectNouvelEv.Width += 10;
            RectNouvelEv.Height += 10;
            imageNouvelEv.Width += 10;
            imageNouvelEv.Height += 10;

            if (listeEvExistantVide == false)
            {
                RectNouvelEv.Margin = new Thickness(13, 56, 0, 0);
                imageNouvelEv.Margin = new Thickness(33, 76, 0, 0);
            }
            else
            {
                RectNouvelEv.Margin = new Thickness((this.Width - (RectNouvelEv.Width)) / 2, RecTop - 5, ((this.Width) - (RectNouvelEv.Width)) / 2, RecBot - 5);
                imageNouvelEv.Margin = new Thickness(((this.Width) - (imageNouvelEv.Width)) / 2, imgTop - 5, (this.Width - (imageNouvelEv.Width)) / 2, imgBot - 5);
            }

        }

        /// <summary>
        /// Permet de gérer la selection dans la datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridListEv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO datagridSelectionChange
            if (dataGridListEv.SelectedIndex > -1)
            {
                //MessageBox.Show(dataGridListEv.);
                Evenement ev = (Evenement)dataGridListEv.SelectedItem;
                Properties.Settings.Default.idEv = ev.idLong;
                Properties.Settings.Default.Save();
                Log l = new Log(Log.Type.Infos, "Choix de l'évenement : " + Properties.Settings.Default.idEv + " depuis la liste des evenement existant : " + ev.nom + ", " + ev.lieu + ", " + ev.date);
            }
        }


        /// <summary>
        /// Permet de gérer le clic droit sur la datagrid qui lite les événements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridListEv_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            ContextMenu theMenu = new ContextMenu();

            MenuItem mib = new MenuItem();
            mib.Header = "Modifier";
            theMenu.Items.Add(mib);

            MenuItem mia = new MenuItem();
            mia.Header = "Supprimer";
            theMenu.Items.Add(mia);

            if (dataGridListEv.SelectedIndex != -1)
                theMenu.IsOpen = true;

            mia.Click += ConnectionMenuItemClickedDelete;
            mib.Click += ConnectionMenuItemClickedEdit;
        }

        private void dataGridListEv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridListEv.SelectedIndex != -1) // Vérification qu'un evenement est bien selectionné dans la liste
                imageValider_MouseLeftButtonUp(sender, e);
        }

        private void dataGridListEv_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void dataGridListEv_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }





        /// <summary>
        /// Methode qui diminue la taille de l'image Evexistant lors que la souris ne survol plus l'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectEvExistant_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            labelEvExistant.FontWeight = FontWeights.Normal;

            RectEvExistant.Width -= 10;
            RectEvExistant.Height -= 10;
            imageEvExistant.Width -= 10;
            imageEvExistant.Height -= 10;

            RectEvExistant.Margin = new Thickness(0, 61, 18, 0);
            imageEvExistant.Margin = new Thickness(0, 81, 38, 0);
        }

        /// <summary>
        /// Methode qui agrendit la taille de l'image Evexistant lors du survol par la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectEvExistant_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            labelEvExistant.FontWeight = FontWeights.Bold;


            RectEvExistant.Width += 10;
            RectEvExistant.Height += 10;
            imageEvExistant.Width += 10;
            imageEvExistant.Height += 10;

            RectEvExistant.Margin = new Thickness(0, 56, 13, 0);
            imageEvExistant.Margin = new Thickness(0, 76, 33, 0);
        }

        /// <summary>
        /// Méthode qui permet de rencentrer la fenetre quand elle change de taille
        /// </summary>
        private void recentrerFenetre()
        {
            // Permet de recentrer la fentre après avoir changé sa taille
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
