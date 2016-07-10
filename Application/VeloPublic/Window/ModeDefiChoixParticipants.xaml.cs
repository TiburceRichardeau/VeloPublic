using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour ModeDefiChoixParticipants.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class ModeDefiChoixParticipants
    {
        /// <summary>
        /// <code>bool</code> permet de savoir si lors de la fermeture de la fentre on doit réouvrir la fenetre qui permet de choisir le mode
        /// </summary>
        bool ouvrirChoixMode = true;

        // TODO faire les tests unitaires pour la partie qui concerne le nombre d'heure du défi

        /// <summary>
        /// Permet de remplir le textbox qui contient le nombre d'heures du défi
        /// </summary>
        /// <param name="heures"><code>string</code>nombre d'heures</param>
        public void set_heuresDefi(string heures) { textBoxPoids1.Text = heures; }

        /// <summary>
        /// Permet de récupérer le nombre d'heures saisi pas l'utilisateur
        /// </summary>
        /// <returns></returns>
        public string get_heuresDefi() { return textBoxTempsHeureDefi.Text; }

        /// <summary>
        /// Permet de simuler le choix de l'utilisateur pour un défi a un participant (pour les tests unitaires)
        /// </summary>
        public void Select1Participant() { radioButton1.IsChecked = true; }

        /// <summary>
        /// Permet de récupérer le poids saisi par l'utilisateur
        /// </summary>
        /// <returns><code>string</code>poids saisi par l'utilisateur</returns>
        public string get_PoidsCyclite1() { return textBoxPoids1.Text; }

        /// <summary>
        /// Permet de remplir le textbox qui contient le poids du premier cycliste
        /// </summary>
        /// <param name="poids">poids du cycliste en string</param>
        public void set_TextBoxPoidsCycliste1(string poids) { textBoxPoids1.Text = poids; }

        /// <summary>
        /// Permet de recupérer le nombre de minutes du défi saisi par l'utilisateur
        /// </summary>
        /// <returns>nombre de minutes en string</returns>
        public string get_TextBoxMin() { return textBoxTempsMinDefi.Text; }

        /// <summary>
        /// Permet de définir le nombre de minutes saisi par l'utilisateur dans les tests unitaires
        /// </summary>
        /// <param name="min">contient le nombre de minutes en string</param>
        public void set_TextBoxMin(string min) { textBoxTempsMinDefi.Text = min; }

        /// <summary>
        /// Permet de récuperer le nombre de secondes saisi par l'utilisateur
        /// </summary>
        /// <returns>Le nombre de seconde en string</returns>
        public string get_TextBoxSec() { return textBoxTempsSecDefi.Text; }

        /// <summary>
        /// Permet de définir le nombre de secondes saisi par l'utilisateur dans les tests unitaires 
        /// </summary>
        /// <param name="sec">contient le nombde de secondes en string</param>
        public void set_TextBoxSec(string sec) { textBoxTempsSecDefi.Text = sec; }


        /// <summary>
        /// Constructeur par défaut de la fenetre ModeDefiChoixParticipants
        /// Cette fenetre permet a l'utilisateur de replir les données des différents cyclistes qui participe a la course
        /// </summary>
        public ModeDefiChoixParticipants()
        {
            InitializeComponent();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre de choix de particiapant pour le mode " + Properties.Settings.Default.Mode);
            RemplirPlaceHolder();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen; // Affichage de la fenetre au centre de l'écran
            Properties.Settings.Default.nbParticipants = 0; // Lors de l'ouverture de la fenetre au défini le nombre de participants a 0
            Properties.Settings.Default.Save();
            labelMode.Content = Properties.Settings.Default.Mode; // On affiche le nom du mode choisi en haut de la fenetre
            // Définition du temps du défi (par défaut 5 minutes)
            Properties.Settings.Default.heures = 0;
            Properties.Settings.Default.minutes = 5; 
            Properties.Settings.Default.secondes = 0;
            Properties.Settings.Default.Save();

            // Remplissage de des champs de temps de défi avec les paramètres par défaut (5 munutes)
            textBoxTempsMinDefi.Text = Properties.Settings.Default.minutes.ToString();
            textBoxTempsSecDefi.Text = Properties.Settings.Default.secondes.ToString();
        }

        /// <summary>
        /// Permet de gérer l'affichage des champs de saisi en fonction du nombre de participants (de 1 à 4)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            ImageValider.Visibility = Visibility.Visible; // Affichage du bouton valider
            checkBoxTest.Visibility = Visibility.Visible;
            //buttonValider.Visibility = Visibility.Visible; // Affichage du bouton valider
            // Enregistrement dans un paramètre de l'application du nombre de participants
            if (radioButton1.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 1;
                Properties.Settings.Default.Save();
            }
            else if(radioButton2.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 2;
                Properties.Settings.Default.Save();
            }
            else if (radioButton3.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 3;
                Properties.Settings.Default.Save();

            }
            else if (radioButton4.IsChecked == true)
            {
                Properties.Settings.Default.nbParticipants = 4;
                Properties.Settings.Default.Save();
            }

            this.Height = 500; // agrandit la fenetre

            // Permet de recentrer la fentre après avoir changé sa taille
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            ImageValider.Margin = new Thickness(Width / 2, ImageValider.Margin.Top, ImageValider.Margin.Right, ImageValider.Margin.Bottom);
            checkBoxTest.Margin = new Thickness(Width / 2, checkBoxTest.Margin.Top, checkBoxTest.Margin.Right, checkBoxTest.Margin.Bottom);

            // Affichage des champs de saisi nécéssaire en fonction du nombre de participants
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    Affichertempsdefi();
                    //ImageP1.Margin = new Thickness((this.Width / 2) + ImageP1.Width/2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom1.Margin = new Thickness(this.Width / 2, textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom1.Margin = new Thickness(this.Width / 2, textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids1.Margin = new Thickness(this.Width / 2, textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);
                    AfficherP1();
                    CacherP2();
                    CacherP3();
                    CacherP4();
                    break;
                case 2:
                    Affichertempsdefi();
                    //ImageP1.Margin = new Thickness((this.Width / 4) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom1.Margin = new Thickness(this.Width / 4, textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom1.Margin = new Thickness(this.Width / 4, textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids1.Margin = new Thickness(this.Width / 4, textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP2.Margin = new Thickness(3*(this.Width / 2) + ImageP1.Width / 2, ImageP2.Margin.Top, ImageP2.Margin.Right, ImageP2.Margin.Bottom);
                    //textBoxNom2.Margin = new Thickness(3*(this.Width / 4), textBoxNom2.Margin.Top, textBoxNom2.Margin.Right, textBoxNom2.Margin.Bottom);
                    //textBoxPrenom2.Margin = new Thickness(3*(this.Width / 4), textBoxPrenom2.Margin.Top, textBoxPrenom2.Margin.Right, textBoxPrenom2.Margin.Bottom);
                    //textBoxPoids2.Margin = new Thickness(3*(this.Width / 4), textBoxPoids2.Margin.Top, textBoxPoids2.Margin.Right, textBoxPoids2.Margin.Bottom);
                    AfficherP1();
                    AfficherP2();
                    CacherP3();
                    CacherP4();
                    break;
                case 3:
                    Affichertempsdefi();
                    //ImageP1.Margin = new Thickness((this.Width / 6) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom1.Margin = new Thickness(this.Width / 6, textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom1.Margin = new Thickness(this.Width / 6, textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids1.Margin = new Thickness(this.Width / 6, textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP2.Margin = new Thickness(3 * (this.Width / 6) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom2.Margin = new Thickness(3 * (this.Width / 6), textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom2.Margin = new Thickness(3 * (this.Width / 6), textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids2.Margin = new Thickness(3 * (this.Width / 6), textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP3.Margin = new Thickness(5 * (this.Width / 6) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom3.Margin = new Thickness(5 * (this.Width / 6), textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom3.Margin = new Thickness(5 * (this.Width / 6), textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids3.Margin = new Thickness(5 * (this.Width / 6), textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);
                    AfficherP1();
                    AfficherP2();
                    AfficherP3();
                    CacherP4();
                    break;
                case 4:
                    Affichertempsdefi();
                    //ImageP1.Margin = new Thickness((this.Width / 8) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom1.Margin = new Thickness(this.Width / 8, textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom1.Margin = new Thickness(this.Width / 8, textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids1.Margin = new Thickness(this.Width / 8, textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP2.Margin = new Thickness(3 * (this.Width / 8) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom2.Margin = new Thickness(3 * (this.Width / 8), textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom2.Margin = new Thickness(3 * (this.Width / 8), textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids2.Margin = new Thickness(3 * (this.Width / 8), textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP3.Margin = new Thickness(5 * (this.Width / 8) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom3.Margin = new Thickness(5 * (this.Width / 8), textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom3.Margin = new Thickness(5 * (this.Width / 8), textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids3.Margin = new Thickness(5 * (this.Width / 8), textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);

                    //ImageP3.Margin = new Thickness(7 * (this.Width / 8) + ImageP1.Width / 2, ImageP1.Margin.Top, ImageP1.Margin.Right, ImageP1.Margin.Bottom);
                    //textBoxNom3.Margin = new Thickness(7 * (this.Width / 8), textBoxNom1.Margin.Top, textBoxNom1.Margin.Right, textBoxNom1.Margin.Bottom);
                    //textBoxPrenom3.Margin = new Thickness(7 * (this.Width / 8), textBoxPrenom1.Margin.Top, textBoxPrenom1.Margin.Right, textBoxPrenom1.Margin.Bottom);
                    //textBoxPoids3.Margin = new Thickness(7 * (this.Width / 8), textBoxPoids1.Margin.Top, textBoxPoids1.Margin.Right, textBoxPoids1.Margin.Bottom);
                    AfficherP1();
                    AfficherP2();
                    AfficherP3();
                    AfficherP4();
                    break;
            }
        }

        /// <summary>
        /// Permet de vérifier si le temps de défi saisi par l'utilisateur est correctement saisi.
        /// </summary>
        /// <returns><code>true</code> si le temps est correctement saisi <code>false</code> sinon</returns>
        public bool VerifierTemps()
        {
            Log l = new Log(Log.Type.Infos, "Vérification du temps de défi saisi");
            int test; // Variable utile pour les tryParse
            if (textBoxTempsHeureDefi.Text == string.Empty)
                textBoxTempsHeureDefi.Text = "0";

            if (textBoxTempsMinDefi.Text == string.Empty)
                textBoxTempsMinDefi.Text = "0";

            if (textBoxTempsSecDefi.Text == string.Empty)
                textBoxTempsSecDefi.Text = "0";

            if (int.TryParse(textBoxTempsMinDefi.Text, out test) && int.TryParse(textBoxTempsSecDefi.Text, out test) && int.TryParse(textBoxTempsHeureDefi.Text, out test))
            {
                if (int.Parse(textBoxTempsHeureDefi.Text) == 0 && int.Parse(textBoxTempsMinDefi.Text) == 0 && int.Parse(textBoxTempsSecDefi.Text) == 0)
                    return false;
                else if (int.Parse(textBoxTempsSecDefi.Text) >= 60 || int.Parse(textBoxTempsSecDefi.Text) < 0 || int.Parse(textBoxTempsMinDefi.Text) >= 60 || int.Parse(textBoxTempsMinDefi.Text) < 0 || int.Parse(textBoxTempsHeureDefi.Text) < 0)
                    return false;
                if (int.Parse(textBoxTempsMinDefi.Text) > 0 && int.Parse(textBoxTempsSecDefi.Text) > 0 && int.Parse(textBoxTempsHeureDefi.Text) > 0)
                    return true;
                else if (int.Parse(textBoxTempsMinDefi.Text) > 0 && int.Parse(textBoxTempsSecDefi.Text) == 0)
                    return true;
                else if (int.Parse(textBoxTempsMinDefi.Text) == 0 && int.Parse(textBoxTempsSecDefi.Text) > 0)
                    return true;
                else if (int.Parse(textBoxTempsSecDefi.Text) < 59 && int.Parse(textBoxTempsSecDefi.Text) >= 0 && int.Parse(textBoxTempsMinDefi.Text) < 59 && int.Parse(textBoxTempsMinDefi.Text) >= 0 && int.Parse(textBoxTempsHeureDefi.Text) >= 0)
                    return true;
                else
                    return false;
            }
            else
                return false;   
        }

        /// <summary>
        /// Permet de remplacer les , par des . pour le cycliste 1 (car les variables de type double s'écrivent avec un . entre la partie entière et la partie décimale
        /// </summary>
        public void RemplacerVirgulePointCycliste1()
        {
            textBoxPoids1.Text = textBoxPoids1.Text.Replace(',', '.');
        }

        /// <summary>
        /// Permet de remplacer les , par des . pour le cycliste 2 (car les variables de type double s'écrivent avec un . entre la partie entière et la partie décimale
        /// </summary>
        public void RemplacerVirgulePointCycliste2()
        {
            textBoxPoids2.Text = textBoxPoids2.Text.Replace(',', '.');
        }

        /// <summary>
        /// Permet de remplacer les , par des . pour le cycliste 3 (car les variables de type double s'écrivent avec un . entre la partie entière et la partie décimale
        /// </summary>
        public void RemplacerVirgulePointCycliste3()
        {
            textBoxPoids3.Text = textBoxPoids3.Text.Replace(',', '.');
        }

        /// <summary>
        /// Permet de remplacer les , par des . pour le cycliste 3 (car les variables de type double s'écrivent avec un . entre la partie entière et la partie décimale
        /// </summary>
        public void RemplacerVirgulePointCycliste4()
        {
            textBoxPoids4.Text = textBoxPoids4.Text.Replace(',', '.');
        }

        // Affichage participants

        /// <summary>
        /// Permet d'afficher sur le fentre les champs de saisi du temps du défi
        /// </summary>
        private void Affichertempsdefi()
        {
            Log l = new Log(Log.Type.Infos, "Affichage du temps du défi");


            labelTempsMinDefi.Visibility = Visibility.Visible;
            labelTempsSecDefi.Visibility = Visibility.Visible;
            textBoxTempsSecDefi.Visibility = Visibility.Visible;
            textBoxTempsMinDefi.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les champs de saisi pour enregistrer le premier cycliste
        /// </summary>
        private void AfficherP1()
        {
            Log l = new Log(Log.Type.Infos, "Affichage des champs d'enregistrement de P1");
            //labelCycliste1.Visibility = Visibility.Visible;
            //labelPrenom1.Visibility = Visibility.Visible;
            //labelNom1.Visibility = Visibility.Visible;
            //labelPoids1.Visibility = Visibility.Visible;
            textBoxNom1.Visibility = Visibility.Visible;
            textBoxPrenom1.Visibility = Visibility.Visible;
            textBoxPoids1.Visibility = Visibility.Visible;
            ImageP1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les champs de saisi pour enregistrer le deuxième cycliste
        /// </summary>
        private void AfficherP2()
        {
            Log l = new Log(Log.Type.Infos, "Affichage des champs d'enregistrement de P2");
            //labelCycliste2.Visibility = Visibility.Visible;
            ImageP2.Visibility = Visibility.Visible;
            //labelPrenom2.Visibility = Visibility.Visible;
            //labelNom2.Visibility = Visibility.Visible;
            //labelPoids2.Visibility = Visibility.Visible;
            textBoxNom2.Visibility = Visibility.Visible;
            textBoxPrenom2.Visibility = Visibility.Visible;
            textBoxPoids2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les champs de saisi pour enregistrer le troixième cycliste
        /// </summary>
        private void AfficherP3()
        {
            Log l = new Log(Log.Type.Infos, "Affichage des champs d'enregistrement de P3");
            //labelCycliste3.Visibility = Visibility.Visible;
            ImageP3.Visibility = Visibility.Visible;
            //labelPrenom3.Visibility = Visibility.Visible;
            //labelNom3.Visibility = Visibility.Visible;
            //labelPoids3.Visibility = Visibility.Visible;
            textBoxNom3.Visibility = Visibility.Visible;
            textBoxPrenom3.Visibility = Visibility.Visible;
            textBoxPoids3.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les champs de saisi pour enregistrer le quatrième cycliste
        /// </summary>
        private void AfficherP4()
        {
            Log l = new Log(Log.Type.Infos, "Affichage des champs d'enregistrement de P4");
            //labelCycliste4.Visibility = Visibility.Visible;
            //labelPrenom4.Visibility = Visibility.Visible;
            //labelNom4.Visibility = Visibility.Visible;
            //labelPoids4.Visibility = Visibility.Visible;
            ImageP4.Visibility = Visibility.Visible;
            textBoxNom4.Visibility = Visibility.Visible;
            textBoxPrenom4.Visibility = Visibility.Visible;
            textBoxPoids4.Visibility = Visibility.Visible;
        }

        
        // cacher participants

        /// <summary>
        /// Permet de cacher les champs de saisi pour le deuxième participant
        /// </summary>
        private void CacherP2()
        {
            Log l = new Log(Log.Type.Infos, "Les champs d'enregistrement de P2 ont été masqués");
            //labelCycliste2.Visibility = Visibility.Hidden;
            ImageP2.Visibility = Visibility.Hidden;
            //labelPrenom2.Visibility = Visibility.Hidden;
            //labelNom2.Visibility = Visibility.Hidden;
            //labelPoids2.Visibility = Visibility.Hidden;
            textBoxNom2.Visibility = Visibility.Hidden;
            textBoxPrenom2.Visibility = Visibility.Hidden;
            textBoxPoids2.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Permet de cacher les champs de saisi pour le troixième participant
        /// </summary>
        private void CacherP3()
        {
            Log l = new Log(Log.Type.Infos, "Les champs d'enregistrement de P3 ont été masqués");
            //labelCycliste3.Visibility = Visibility.Hidden;
            ImageP3.Visibility = Visibility.Hidden;
            //labelPrenom3.Visibility = Visibility.Hidden;
            //labelNom3.Visibility = Visibility.Hidden;
            //labelPoids3.Visibility = Visibility.Hidden;
            textBoxNom3.Visibility = Visibility.Hidden;
            textBoxPrenom3.Visibility = Visibility.Hidden;
            textBoxPoids3.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Permet de cacher les champs de saisi pour le quatrième participant
        /// </summary>
        private void CacherP4()
        {
            Log l = new Log(Log.Type.Infos, "Les champs d'enregistrement de P4 ont été masqués");
            //labelCycliste4.Visibility = Visibility.Hidden;
            //labelPrenom4.Visibility = Visibility.Hidden;
            //labelNom4.Visibility = Visibility.Hidden;
            //labelPoids4.Visibility = Visibility.Hidden;
            ImageP4.Visibility = Visibility.Hidden;
            textBoxNom4.Visibility = Visibility.Hidden;
            textBoxPrenom4.Visibility = Visibility.Hidden;
            textBoxPoids4.Visibility = Visibility.Hidden;
        }
        
        /// <summary>
        /// Méthode éxécuter lors de l'appui sur une touche dans les champs de saisi de nom et de prénom
        /// Permet d'interdir d'écrire des ' pour éviter les injections et les erreurs SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNomPrenom_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            bool isCapsOn = Keyboard.IsKeyToggled(Key.CapsLock);
            bool isLeftShiftDown = Keyboard.IsKeyDown(Key.LeftShift);
            bool isRightShiftDown = Keyboard.IsKeyDown(Key.RightShift);
            bool isD4Down = Keyboard.IsKeyDown(Key.D4);
            

            if(!isCapsOn && isD4Down && !isRightShiftDown && !isLeftShiftDown)
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
        /// Permet de n'autoriser la saisi que de nombre dans le champs de saisi du poids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids_KeyDown(object sender, KeyEventArgs e)
        {
            bool isCapsOn = Keyboard.IsKeyToggled(Key.CapsLock);
            bool isLeftShiftDown = Keyboard.IsKeyDown(Key.LeftShift);
            bool isRightShiftDown = Keyboard.IsKeyDown(Key.RightShift);
            bool isNumLock = Keyboard.IsKeyToggled(Key.NumLock);
            bool isVirguleDown = Keyboard.IsKeyDown(Key.OemComma);

            if (isCapsOn && !isLeftShiftDown && !isRightShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if ((isRightShiftDown && isVirguleDown) || (isLeftShiftDown && isVirguleDown))
                e.Handled = true;
            else if (!isCapsOn && isRightShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if (!isCapsOn && isLeftShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if (isNumLock && (Keyboard.IsKeyDown(Key.NumPad0) || Keyboard.IsKeyDown(Key.NumPad1) || Keyboard.IsKeyDown(Key.NumPad2) || Keyboard.IsKeyDown(Key.NumPad3) || Keyboard.IsKeyDown(Key.NumPad4) || Keyboard.IsKeyDown(Key.NumPad5) || Keyboard.IsKeyDown(Key.NumPad6) || Keyboard.IsKeyDown(Key.NumPad7) || Keyboard.IsKeyDown(Key.NumPad8) || Keyboard.IsKeyDown(Key.NumPad9)))
                e.Handled = false;
            else if (!isCapsOn && !isLeftShiftDown && isVirguleDown)
                e.Handled = false;
            else if (!isCapsOn && !isRightShiftDown && isVirguleDown)
                e.Handled = false;
            else if (isCapsOn && isRightShiftDown && isVirguleDown)
                e.Handled = false;
            else if (isCapsOn && isLeftShiftDown && isVirguleDown)
                e.Handled = false;
            else if (isNumLock && Keyboard.IsKeyDown(Key.Decimal))
                e.Handled = false;
            else
                e.Handled = true;

            // Si e.Handled = true la touche n'est pas prise en compte si e.Handled = false la touche est prise en compte
            //MessageBox.Show(e.Key.ToString());
        }

        /// <summary>
        /// Permet de n'autoriser que la saisi des chiffres dans les champs de saisi du temps de défi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTempsDefi_KeyDown(object sender, KeyEventArgs e)
        {
            
            bool isCapsOn = Keyboard.IsKeyToggled(Key.CapsLock);
            bool isLeftShiftDown = Keyboard.IsKeyDown(Key.LeftShift);
            bool isRightShiftDown = Keyboard.IsKeyDown(Key.RightShift);
            bool isNumLock = Keyboard.IsKeyToggled(Key.NumLock);

            if (isCapsOn && !isLeftShiftDown && !isRightShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if (!isCapsOn && isRightShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if (!isCapsOn && isLeftShiftDown && (Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3) || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8) || Keyboard.IsKeyDown(Key.D9) || Keyboard.IsKeyDown(Key.D0)))
                e.Handled = false;
            else if (isNumLock && (Keyboard.IsKeyDown(Key.NumPad0) || Keyboard.IsKeyDown(Key.NumPad1) || Keyboard.IsKeyDown(Key.NumPad2) || Keyboard.IsKeyDown(Key.NumPad3) || Keyboard.IsKeyDown(Key.NumPad4) || Keyboard.IsKeyDown(Key.NumPad5) || Keyboard.IsKeyDown(Key.NumPad6) || Keyboard.IsKeyDown(Key.NumPad7) || Keyboard.IsKeyDown(Key.NumPad8) || Keyboard.IsKeyDown(Key.NumPad9)))
                e.Handled = false;
            else
                e.Handled = true;
        }


        /// <summary>
        /// Méthode éxécutée lors de la fermeture de la fenetre
        /// Si le booléan ouvrirChoixMode est a vrai alors on ouvre la fentre de choix des mode sinon on ferme juste la fentre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ouvrirChoixMode == true)
            {
                MainWindow win = new MainWindow();
                win.Show();
            }
        }

        /// <summary>
        /// Permet de changer le curseur de la souris au survol des radiobutton qui permettent de choisir le nombre de participants (la souris survole le bouton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Permet de changer le curseur de la souris au survol des radiobutton qui permettent de choisir le nombre de participants (la souris ne survole plus le bouton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Permet de changer le curseur de la souris au survol du checkbox test (la souris survole le bouton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTest_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        /// <summary>
        ///  Permet de changer le curseur de la souris au survol du checkbox de test (la souris ne survole plus le bouton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTest_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        //==========================PlaceHolders==========================\\
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        //\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/

        /// <summary>
        /// Permet de remplir les placeHolder dans les champs de saisi
        /// </summary>
        private void RemplirPlaceHolder()
        {
            textBoxNom1.Text = "Nom";
            textBoxNom2.Text = "Nom";
            textBoxNom3.Text = "Nom";
            textBoxNom4.Text = "Nom";

            textBoxPrenom1.Text = "Prénom";
            textBoxPrenom2.Text = "Prénom";
            textBoxPrenom3.Text = "Prénom";
            textBoxPrenom4.Text = "Prénom";

            textBoxPoids1.Text = "Poids";
            textBoxPoids2.Text = "Poids";
            textBoxPoids3.Text = "Poids";
            textBoxPoids4.Text = "Poids";
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom1_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBoxNom1.Text=="Nom")
            {
                textBoxNom1.Text = "";
                textBoxNom1.Foreground = Brushes.Black; // Noir
            }
                
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNom1.Text))
            {
                textBoxNom1.Text = "Nom";
                textBoxNom1.Foreground = Brushes.Gray; // Couleur gris
            }
                
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxNom2.Text == "Nom")
            {
                textBoxNom2.Text = "";
                textBoxNom2.Foreground = Brushes.Black; // Noir
            }
                
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNom2.Text))
            {
                textBoxNom2.Text = "Nom";
                textBoxNom2.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxNom3.Text == "Nom")
            {
                textBoxNom3.Text = "";
                textBoxNom3.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNom3.Text))
            {
                textBoxNom3.Text = "Nom";
                textBoxNom3.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxNom4.Text == "Nom")
            {
                textBoxNom4.Text = "";
                textBoxNom4.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le nom du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxNom4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxNom4.Text))
            {
                textBoxNom4.Text = "Nom";
                textBoxNom4.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPrenom1.Text == "Prénom")
            {
                textBoxPrenom1.Text = "";
                textBoxPrenom1.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPrenom1.Text))
            {
                textBoxPrenom1.Text = "Prénom";
                textBoxPrenom1.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPrenom2.Text == "Prénom")
            {
                textBoxPrenom2.Text = "";
                textBoxPrenom2.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPrenom2.Text))
            {
                textBoxPrenom2.Text = "Prénom";
                textBoxPrenom2.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPrenom3.Text == "Prénom")
            {
                textBoxPrenom3.Text = "";
                textBoxPrenom3.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPrenom3.Text))
            {
                textBoxPrenom3.Text = "Prénom";
                textBoxPrenom3.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPrenom4.Text == "Prénom")
            {
                textBoxPrenom4.Text = "";
                textBoxPrenom4.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le prenom du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPrenom4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPrenom4.Text))
            {
                textBoxPrenom4.Text = "Prénom";
                textBoxPrenom4.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoids1.Text == "Poids")
            {
                textBoxPoids1.Text = "";
                textBoxPoids1.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 1er participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPoids1.Text))
            {
                textBoxPoids1.Text = "Poids";
                textBoxPoids1.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoids2.Text == "Poids")
            {
                textBoxPoids2.Text = "";
                textBoxPoids2.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 2eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPoids2.Text))
            {
                textBoxPoids2.Text = "Poids";
                textBoxPoids2.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoids3.Text == "Poids")
            {
                textBoxPoids3.Text = "";
                textBoxPoids3.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 3eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPoids3.Text))
            {
                textBoxPoids3.Text = "Poids";
                textBoxPoids3.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPoids4.Text == "Poids")
            {
                textBoxPoids4.Text = "";
                textBoxPoids4.Foreground = Brushes.Black; // Noir
            }
        }

        /// <summary>
        /// Permet de gérer le focus et placeholder sur la textbox qui contient le poids du 4eme participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPoids4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxPoids4.Text))
            {
                textBoxPoids4.Text = "Poids";
                textBoxPoids4.Foreground = Brushes.Gray; // Couleur gris
            }
        }

        ///\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        //==========================PlaceHolders==========================\\

        /// <summary>
        /// Permet de gérer le clic sur l'image qui permet de valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageValider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Validation des infos cyclistes");
            textBoxNom1.Text.Replace("'", string.Empty);
            textBoxNom2.Text.Replace("'", string.Empty);
            textBoxNom3.Text.Replace("'", string.Empty);
            textBoxNom4.Text.Replace("'", string.Empty);
            textBoxPrenom1.Text.Replace("'", string.Empty);
            textBoxPrenom2.Text.Replace("'", string.Empty);
            textBoxPrenom3.Text.Replace("'", string.Empty);
            textBoxPrenom4.Text.Replace("'", string.Empty);

            // Temps (durée défi)
            if (textBoxTempsHeureDefi.Text == string.Empty)
                textBoxTempsHeureDefi.Text = "0";

            if (textBoxTempsMinDefi.Text == string.Empty)
                textBoxTempsMinDefi.Text = "0";

            if (textBoxTempsSecDefi.Text == string.Empty)
                textBoxTempsSecDefi.Text = "0";

            // Nom
            if (textBoxNom1.Text == "Nom")
            {
                textBoxNom1.Text = string.Empty;
            }
            if (textBoxNom2.Text == "Nom")
            {
                textBoxNom2.Text = string.Empty;
            }
            if (textBoxNom3.Text == "Nom")
            {
                textBoxNom3.Text = string.Empty;
            }
            if (textBoxNom4.Text == "Nom")
            {
                textBoxNom4.Text = string.Empty;
            }

            // Prénom
            if (textBoxPrenom1.Text == "Prénom")
            {
                textBoxPrenom1.Text = string.Empty;
            }
            if (textBoxPrenom2.Text == "Prénom")
            {
                textBoxPrenom2.Text = string.Empty;

            }
            if (textBoxPrenom3.Text == "Prénom")
            {
                textBoxPrenom3.Text = string.Empty;
            }
            if (textBoxPrenom4.Text == "Prénom")
            {
                textBoxPrenom4.Text = string.Empty;
            }

            // Poids
            if (textBoxPoids1.Text == "Poids")
            {
                textBoxPoids1.Text = string.Empty;
            }
            if (textBoxPoids2.Text == "Poids")
            {
                textBoxPoids2.Text = string.Empty;
            }
            if (textBoxPoids3.Text == "Poids")
            {
                textBoxPoids3.Text = string.Empty;
            }
            if (textBoxPoids4.Text == "Poids")
            {
                textBoxPoids4.Text = string.Empty;
            }

            int test;
            Participant p1, p2, p3, p4;
            Course c = new Course(Properties.Settings.Default.idEv, true);
            if (Properties.Settings.Default.erreurSQL == true)
            {
                Log SQLl = new Log(Log.Type.Erreur, Properties.Settings.Default.ErreurSQLSTR + ' ' + Properties.Settings.Default.MessageErreur);
                Erreur er = new Erreur("Erreur avec la base de données lors de la création de la course");
                er.ShowDialog();
            }


            if (VerifierTemps())
            {
                l = new Log(Log.Type.Infos, "Le temps a été correctement saisi");
                if (int.TryParse(textBoxTempsMinDefi.Text, out test) && int.TryParse(textBoxTempsSecDefi.Text, out test))
                {
                    Properties.Settings.Default.minutes = int.Parse(textBoxTempsMinDefi.Text);
                    Properties.Settings.Default.secondes = int.Parse(textBoxTempsSecDefi.Text);
                    Properties.Settings.Default.heures = int.Parse(textBoxTempsHeureDefi.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Erreur er = new Erreur("Erreur lors de la saisi du temps du défi");
                    er.ShowDialog();
                }

                if (checkBoxTest.IsChecked == true)
                {
                    Properties.Settings.Default.EstUnTest = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.EstUnTest = false;
                    Properties.Settings.Default.Save();
                }

                switch (Properties.Settings.Default.nbParticipants)
                {
                    case 1:
                        RemplacerVirgulePointCycliste1();
                        if (textBoxPoids1.Text == "1")
                        {
                            Erreur er = new Erreur("Le poids doit être superieur a 1 kg");
                            er.ShowDialog();
                            break;
                        }
                        p1 = new Participant(textBoxPrenom1.Text, textBoxNom1.Text, textBoxPoids1.Text, c.idCourse);
                        if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors du participant 1");
                            er.ShowDialog();
                        }
                        WindowDefiEnCours win1P = new WindowDefiEnCours(p1);
                        if (p1.VerifPoids() && p1.VerifNP() && Properties.Settings.Default.erreurSQL == false)
                        {
                            ouvrirChoixMode = false;
                            win1P.Show();
                            this.Close();
                        }
                        else if (p1.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 1 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p1.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 1 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors de la création du participant");
                            er.ShowDialog();
                        }
                        else
                        {
                            Erreur er = new Erreur("Erreur");
                            er.ShowDialog();
                        }
                        break;
                    case 2:
                        RemplacerVirgulePointCycliste1();
                        RemplacerVirgulePointCycliste2();
                        if (textBoxPoids1.Text == "1" || textBoxPoids2.Text == "1")
                        {
                            Erreur er = new Erreur("Le poids doit être superieur a 1 kg");
                            er.ShowDialog();
                            break;
                        }
                        p1 = new Participant(textBoxPrenom1.Text, textBoxNom1.Text, textBoxPoids1.Text, c.idCourse);
                        p2 = new Participant(textBoxPrenom2.Text, textBoxNom2.Text, textBoxPoids2.Text, c.idCourse);
                        if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors du participant 2");
                            er.ShowDialog();
                        }
                        WindowDefiEnCours win2P = new WindowDefiEnCours(p1, p2);
                        if (p1.VerifPoids() && p2.VerifPoids() && p1.VerifNP() && p2.VerifNP() && Properties.Settings.Default.erreurSQL == false)
                        {
                            ouvrirChoixMode = false;
                            win2P.Show();
                            this.Close();
                        }
                        else if (p1.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 1 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p1.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 1 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 2 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 2 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors de la création des participants");
                            er.ShowDialog();
                        }
                        else
                        {
                            Erreur er = new Erreur("Erreur");
                            er.ShowDialog();
                        }
                        break;
                    case 3:
                        RemplacerVirgulePointCycliste1();
                        RemplacerVirgulePointCycliste2();
                        RemplacerVirgulePointCycliste3();
                        if (textBoxPoids1.Text == "1" || textBoxPoids2.Text == "1" || textBoxPoids3.Text == "1")
                        {
                            Erreur er = new Erreur("Le poids doit être superieur a 1 kg");
                            er.ShowDialog();
                            break;
                        }
                        p1 = new Participant(textBoxPrenom1.Text, textBoxNom1.Text, textBoxPoids1.Text, c.idCourse);
                        p2 = new Participant(textBoxPrenom2.Text, textBoxNom2.Text, textBoxPoids2.Text, c.idCourse);
                        p3 = new Participant(textBoxPrenom3.Text, textBoxNom3.Text, textBoxPoids3.Text, c.idCourse);
                        if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors du participant 3");
                            er.ShowDialog();
                        }
                        WindowDefiEnCours win3P = new WindowDefiEnCours(p1, p2, p3);
                        if (p1.VerifPoids() && p2.VerifPoids() && p3.VerifPoids() && p1.VerifNP() && p2.VerifNP() && p3.VerifNP() && Properties.Settings.Default.erreurSQL == false)
                        {
                            ouvrirChoixMode = false;
                            win3P.Show();
                            this.Close();
                        }
                        else if (p1.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 1 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p1.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 1 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 2 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 2 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p3.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 3 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p3.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 3 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors de la création des participants");
                            er.ShowDialog();
                        }
                        else
                        {
                            Erreur er = new Erreur("Erreur");
                            er.ShowDialog();
                        }
                        break;
                    case 4:
                        RemplacerVirgulePointCycliste1();
                        RemplacerVirgulePointCycliste2();
                        RemplacerVirgulePointCycliste3();
                        RemplacerVirgulePointCycliste4();
                        if (textBoxPoids1.Text == "1" || textBoxPoids2.Text == "1" || textBoxPoids3.Text == "1" || textBoxPoids4.Text == "1")
                        {
                            Erreur er = new Erreur("Le poids doit être superieur a 1 kg");
                            er.ShowDialog();
                            break;
                        }
                        p1 = new Participant(textBoxPrenom1.Text, textBoxNom1.Text, textBoxPoids1.Text, c.idCourse);
                        p2 = new Participant(textBoxPrenom2.Text, textBoxNom2.Text, textBoxPoids2.Text, c.idCourse);
                        p3 = new Participant(textBoxPrenom3.Text, textBoxNom3.Text, textBoxPoids3.Text, c.idCourse);
                        p4 = new Participant(textBoxPrenom4.Text, textBoxNom4.Text, textBoxPoids4.Text, c.idCourse);
                        if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors du participant 4");
                            er.ShowDialog();
                        }
                        WindowDefiEnCours win4P = new WindowDefiEnCours(p1, p2, p3, p4);
                        if (p1.VerifPoids() && p2.VerifPoids() && p3.VerifPoids() && p4.VerifPoids() && p1.VerifNP() && p2.VerifNP() && p3.VerifNP() && p4.VerifNP() && Properties.Settings.Default.erreurSQL == false)
                        {
                            ouvrirChoixMode = false;
                            win4P.Show();
                            this.Close();
                        }
                        else if (p1.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 1 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p1.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 1 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 2 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p2.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 2 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p3.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 3 à été mal saisi");
                            er.ShowDialog();
                        }

                        else if (p3.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 3 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p4.VerifNP() == false)
                        {
                            Erreur er = new Erreur("Le nom du participant 4 à été mal saisi");
                            er.ShowDialog();
                        }
                        else if (p4.VerifPoids() == false)
                        {
                            Erreur er = new Erreur("Le poids du participant 4 a été mal saisi");
                            er.ShowDialog();
                        }
                        else if (Properties.Settings.Default.erreurSQL == true)
                        {
                            Erreur er = new Erreur("Erreur SQL lors de la création des participants");
                            er.ShowDialog();
                        }
                        else
                        {
                            Erreur er = new Erreur("Erreur");
                            er.ShowDialog();
                        }
                        break;
                }
            }
            else if (!VerifierTemps())
            {
                Erreur er = new Erreur("La durée du défi a été mal sasi");
                er.ShowDialog();
            }
            else
            {
                Erreur er = new Erreur("Erreur");
                er.ShowDialog();
            }
        }

        /// <summary>
        /// Permet de gérer le survol de la souris sur l'imageValider ce qui permet d'agrandir l'image lors de ce que la souris est dans la zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageValider_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            ImageValider.Height += 10;
            ImageValider.Width += 10;
            ImageValider.Margin = new Thickness(ImageValider.Margin.Left-5, ImageValider.Margin.Top - 5, 0, 0);
        }

        /// <summary>
        /// Permet de gérer le survol de la souris sur l'imageValider ce qui permet de diminuer l'image lors de ce que la souris n'est dans la zone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageValider_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            ImageValider.Height -= 10;
            ImageValider.Width -= 10;
            ImageValider.Margin = new Thickness(ImageValider.Margin.Left + 5, ImageValider.Margin.Top + 5, 0, 0);
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

        private void RectRetour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ouvrirChoixMode = false;
            NewEvenement ev = new NewEvenement(true);
            ev.Show();
            this.Close();
        }

        private void checkBoxTest_Checked(object sender, RoutedEventArgs e)
        {
            ImageModeTest.Visibility = Visibility.Visible;
        }

        private void checkBoxTest_Unchecked(object sender, RoutedEventArgs e)
        {
            ImageModeTest.Visibility = Visibility.Hidden;
        }
    }
}