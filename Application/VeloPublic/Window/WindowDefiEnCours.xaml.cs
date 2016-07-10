using System;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Input;

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour WindowDefiEnCours.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class WindowDefiEnCours
    {
        Participant p1, p2, p3, p4;
        DispatcherTimer dTimer, dTimerTester, TimerGraphE, TimerGraphV, TimerGraphEStatic, TimerGraphVStatic;
        bool ouvrirChoixMode = true;



        // TODO graphiques (en cours) bug toutes les courbes ne trace pas a chaque fois

        /// <summary>
        /// Constructeur a 1 participant
        /// </summary>
        /// <param name="p1">premier participant</param>
        public WindowDefiEnCours(Participant p1)
        {
            InitializeComponent();
            buttonGo.IsEnabled = false;
            RemplirDureeDefi();

            if (Properties.Settings.Default.EstUnTest)
            {
                ImageModeTest.Visibility = Visibility.Visible;
            }else
            {
                ImageModeTest.Visibility = Visibility.Hidden;
            }

            DemarrerDispatchTimerEnergie();
            DemarrerDispatchTimerVitesse();

            labelMode.Content = Properties.Settings.Default.Mode;
            Properties.Settings.Default.autorisationFermeture = true;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre Défi en cours avec 1 Participant");
            this.WindowState = WindowState.Maximized;
            
            //TextBlockMode.Text = Properties.Settings.Default.Mode;

            CefGraphEnergie.Visibility = Visibility.Hidden;
            CefGraphVitesse.Visibility = Visibility.Hidden;
            Properties.Settings.Default.tempsChronosec = 0;
            Properties.Settings.Default.Save();

            AfficherP1(p1);

            this.p1 = p1;
            PlacerCalories();
            setMaxPbDefi();
        }

        /// <summary>
        /// Constructeur a 2 participants
        /// </summary>
        /// <param name="p1">premier participant</param>
        /// <param name="p2">deuxième participant</param>
        public WindowDefiEnCours(Participant p1, Participant p2)
        {
            InitializeComponent();
            buttonGo.IsEnabled = false;
            RemplirDureeDefi();

            DemarrerDispatchTimerEnergie();
            DemarrerDispatchTimerVitesse();

            if (Properties.Settings.Default.EstUnTest)
            {
                ImageModeTest.Visibility = Visibility.Visible;
            }
            else
            {
                ImageModeTest.Visibility = Visibility.Hidden;
            }

            labelMode.Content = Properties.Settings.Default.Mode;
            Properties.Settings.Default.autorisationFermeture = true;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre Défi en cours avec 2 Participants");
            this.WindowState = WindowState.Maximized;
            
            CefGraphEnergie.Visibility = Visibility.Hidden;
            CefGraphVitesse.Visibility = Visibility.Hidden;
            Properties.Settings.Default.tempsChronosec = 0;
            Properties.Settings.Default.Save();


            AfficherP1(p1);
            AfficherP2(p2);

            this.p1 = p1;
            this.p2 = p2;

            PlacerCalories();
            setMaxPbDefi();
        }

        /// <summary>
        /// Constructeur a 3 participants
        /// </summary>
        /// <param name="p1">Premier Participant</param>
        /// <param name="p2">Deuxième Participant</param>
        /// <param name="p3">Troisième Participant</param>
        public WindowDefiEnCours(Participant p1, Participant p2, Participant p3)
        {
            InitializeComponent();
            buttonGo.IsEnabled = false;
            RemplirDureeDefi();

            if (Properties.Settings.Default.EstUnTest)
            {
                ImageModeTest.Visibility = Visibility.Visible;
            }
            else
            {
                ImageModeTest.Visibility = Visibility.Hidden;
            }

            DemarrerDispatchTimerEnergie();
            DemarrerDispatchTimerVitesse();

            labelMode.Content = Properties.Settings.Default.Mode;
            Properties.Settings.Default.autorisationFermeture = true;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre Défi en cours avec 3 Participants");
            this.WindowState = WindowState.Maximized;
            

            CefGraphEnergie.Visibility = Visibility.Hidden;
            CefGraphVitesse.Visibility = Visibility.Hidden;
            Properties.Settings.Default.tempsChronosec = 0;
            Properties.Settings.Default.Save();

            AfficherP1(p1);
            AfficherP2(p2);
            AfficherP3(p3);

            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            PlacerCalories();
            setMaxPbDefi();
        }

        /// <summary>
        /// Constructeur a 4 participants
        /// </summary>
        /// <param name="p1">Premier participant</param>
        /// <param name="p2">Deuxième Participant</param>
        /// <param name="p3">Troisième Participant</param>
        /// <param name="p4">Quatrième Participant</param>
        public WindowDefiEnCours(Participant p1, Participant p2, Participant p3, Participant p4)
        {
            InitializeComponent();
            buttonGo.IsEnabled = false;
            RemplirDureeDefi();

            if (Properties.Settings.Default.EstUnTest == true)
            {
                ImageModeTest.Visibility = Visibility.Visible;
            }
            else
            {
                ImageModeTest.Visibility = Visibility.Hidden;
            }

            DemarrerDispatchTimerEnergie();
            DemarrerDispatchTimerVitesse();

            Properties.Settings.Default.autorisationFermeture = true;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Ouverture de le fenetre Défi en cours avec 4 Participants");
            this.WindowState = WindowState.Maximized;
            

            labelMode.Content = Properties.Settings.Default.Mode;

            CefGraphEnergie.Visibility = Visibility.Hidden;
            CefGraphVitesse.Visibility = Visibility.Hidden;
            Properties.Settings.Default.tempsChronosec = 0;
            Properties.Settings.Default.Save();

            AfficherP1(p1);
            AfficherP2(p2);
            AfficherP3(p3);
            AfficherP4(p4);

            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;

            PlacerCalories();
            setMaxPbDefi();
        }

        private void setMaxPbDefi()
        {
            PbDefi.Maximum = (Properties.Settings.Default.secondes) + (Properties.Settings.Default.minutes * 60) + (Properties.Settings.Default.heures * 3600);
            PbDefi.Value = 1;
        }

        private void RemplirDureeDefi()
        {
            if (Properties.Settings.Default.heures > 0)
            {
                labelChrono.Content = Properties.Settings.Default.heures + " : ";
            }
            else
            {
                labelChrono.Content = string.Empty;
            }

            if (Properties.Settings.Default.minutes < 10 && Properties.Settings.Default.heures > 0)
            {
                labelChrono.Content = labelChrono.Content.ToString() + "0";
            }

            if (Properties.Settings.Default.minutes > 0)
            {
                labelChrono.Content = labelChrono.Content.ToString() + Properties.Settings.Default.minutes;
            }
            else
            {
                labelChrono.Content = labelChrono.Content.ToString() + "00";
            }

            if (Properties.Settings.Default.secondes > 0)
            {
                labelChrono.Content = labelChrono.Content.ToString() + " : " + Properties.Settings.Default.secondes;
            }
            else
            {
                labelChrono.Content = labelChrono.Content.ToString() + " : 00";
            }
        }

        /// <summary>
        /// Permet d'afficher les données pour le premier participant
        /// </summary>
        /// <param name="p">Participant a afficher</param>
        private void AfficherP1(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage des infos sur le participant 1");
            labelNomP1.Content = p.prenom + " " + p.nom;
            labelNomP1.Visibility = Visibility.Visible;
            labelVitesseP1.Content = p.vitesse.ToString() + " km/h";
            labelVitesseP1.Visibility = Visibility.Visible;
            labelDistanceP1.Content = p.distance.ToString() + " m";
            labelDistanceP1.Visibility = Visibility.Visible;
            //labelVitesseMoyenneP1.Content = "Vitesse Moyenne : " + p.vitesseMoyenne.ToString() + " km/h";
            //labelVitesseMoyenneP1.Visibility = Visibility.Visible;
            if (Properties.Settings.Default.EstUnTest)
            {
                switch (p.f)
                {
                    case Participant.force.MOYEN:
                        labelNiveauP1.Content = "Moyen";
                        break;
                    case Participant.force.BON:
                        labelNiveauP1.Content = "Bon";
                        break;
                    case Participant.force.TRES_BON:
                        labelNiveauP1.Content = "Très bon";
                        break;
                    default:
                        break;
                }
                labelNiveauCycliste.Content = "Niveau du cycliste simulé";
            }else
            {
                labelNiveauP1.Content = p.niveauStr;
            }
            labelNiveauP1.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelCalorieP1.Content = p.calories.ToString() + " kcal";
                labelCalorieP1.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelProductionP1.Content = p.production + " Wh";
            labelProductionP1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les données pour le deuxième participant
        /// </summary>
        /// <param name="p">Participant a afficher</param>
        private void AfficherP2(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage des infos sur le participant 2");
            labelNomP2.Content = p.prenom + " " + p.nom;
            labelNomP2.Visibility = Visibility.Visible;
            labelVitesseP2.Content = p.vitesse.ToString() + " km/h";
            labelVitesseP2.Visibility = Visibility.Visible;
            labelDistanceP2.Content = p.distance.ToString() + " m";
            labelDistanceP2.Visibility = Visibility.Visible;
            //labelVitesseMoyenneP2.Content = "Vitesse Moyenne : " + p.vitesseMoyenne.ToString() + " km/h";
            //labelVitesseMoyenneP2.Visibility = Visibility.Visible;
            if (Properties.Settings.Default.EstUnTest)
            {
                switch (p.f)
                {
                    case Participant.force.MOYEN:
                        labelNiveauP2.Content = "Moyen";
                        break;
                    case Participant.force.BON:
                        labelNiveauP2.Content = "Bon";
                        break;
                    case Participant.force.TRES_BON:
                        labelNiveauP2.Content = "Très bon";
                        break;
                    default:
                        break;
                }
                labelNiveauCycliste.Content = "Niveau du cycliste simulé";
            }
            else
            {
                labelNiveauP2.Content = p.niveauStr;
            }
            labelNiveauP2.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelCalorieP2.Content = p.calories.ToString() + " kcal";
                labelCalorieP2.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelProductionP2.Content = p.production + " Wh";
            labelProductionP2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les données pour le troisième participant
        /// </summary>
        /// <param name="p">Participant a afficher</param>
        private void AfficherP3(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage des infos sur le participant 3");
            labelNomP3.Content = p.prenom + " " + p.nom;
            labelNomP3.Visibility = Visibility.Visible;
            labelVitesseP3.Content = p.vitesse.ToString() + " km/h";
            labelVitesseP3.Visibility = Visibility.Visible;
            labelDistanceP3.Content = p.distance.ToString() + " m";
            labelDistanceP3.Visibility = Visibility.Visible;
            //labelVitesseMoyenneP3.Content = "Vitesse Moyenne : " + p.vitesseMoyenne.ToString() + " km/h";
            //labelVitesseMoyenneP3.Visibility = Visibility.Visible;
            if (Properties.Settings.Default.EstUnTest)
            {
                switch (p.f)
                {
                    case Participant.force.MOYEN:
                        labelNiveauP3.Content = "Moyen";
                        break;
                    case Participant.force.BON:
                        labelNiveauP3.Content = "Bon";
                        break;
                    case Participant.force.TRES_BON:
                        labelNiveauP3.Content = "Très bon";
                        break;
                    default:
                        break;
                }
                labelNiveauCycliste.Content = "Niveau du cycliste simulé";
            }
            else
            {
                labelNiveauP3.Content = p.niveauStr;
            }
            labelNiveauP3.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelCalorieP3.Content = p.calories.ToString() + " kcal";
                labelCalorieP3.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelProductionP3.Content = p.production + " Wh";
            labelProductionP3.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet d'afficher les données pour le quatrième participant
        /// </summary>
        /// <param name="p">Participant a afficher</param>
        private void AfficherP4(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage des infos sur le participant 4");
            labelNomP4.Content = p.prenom + " " + p.nom;
            labelNomP4.Visibility = Visibility.Visible;
            labelVitesseP4.Content = p.vitesse.ToString() + " km/h";
            labelVitesseP4.Visibility = Visibility.Visible;
            labelDistanceP4.Content = p.distance.ToString() + " m";
            labelDistanceP4.Visibility = Visibility.Visible;
            //labelVitesseMoyenneP4.Content = "Vitesse Moyenne : " + p.vitesseMoyenne.ToString() + " km/h";
            //labelVitesseMoyenneP4.Visibility = Visibility.Visible;
            if (Properties.Settings.Default.EstUnTest)
            {
                switch (p.f)
                {
                    case Participant.force.MOYEN:
                        labelNiveauP4.Content = "Moyen";
                        break;
                    case Participant.force.BON:
                        labelNiveauP4.Content = "Bon";
                        break;
                    case Participant.force.TRES_BON:
                        labelNiveauP4.Content = "Très bon";
                        break;
                    default:
                        break;
                }
                labelNiveauCycliste.Content = "Niveau du cycliste simulé";
            }
            else
            {
                labelNiveauP4.Content = p.niveauStr;
            }
            labelNiveauP4.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelCalorieP4.Content = p.calories.ToString() + " kcal";
                labelCalorieP4.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelProductionP4.Content = p.production + " Wh";
            labelProductionP4.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode éxécutée a la fermeture de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Evenement de fermeture </param>
        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            if (ouvrirChoixMode && Properties.Settings.Default.autorisationFermeture == true)
            {
                MainWindow win = new MainWindow();
                win.Show();
            }

            if (Properties.Settings.Default.autorisationFermeture == true)
                e.Cancel = false;
            else
            {
                Erreur er = new Erreur("Merci de terminer le défi");
                er.ShowDialog();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Méthode éxécutée lors de l'appui sur le bouton qui affiche le rapport du défi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAfficherRapport_Click(object sender, RoutedEventArgs e)
        {
            ouvrirChoixMode = false;
            Properties.Settings.Default.autorisationFermeture = true;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Affichage du rapport");
            WindowRapportDefi win = new WindowRapportDefi(p1, p2, p3, p4);
            win.Show();
            this.Close();
        }

        private void buttonFermerYes_Click(object sender, RoutedEventArgs e)
        {
            buttonAfficherRapport_Click(sender, e);
            SQLCo sql = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
            sql.Connexion();
            // Update durée course
            int sec = Properties.Settings.Default.tempsChronosec;
            sql.Update("UPDATE `course` SET `Duree`=" + sec + " WHERE `idCourse` = " + p1.idCourse.ToString());
            sql.Deconnexion();
        }

        private void buttonFermerNo_Click(object sender, RoutedEventArgs e)
        {
            // Permet de relancer l'actualisation des graphiques
            DemarrerDispatchTimerEnergie();
            DemarrerDispatchTimerVitesse();

            buttonFermerNo.Visibility = Visibility.Hidden;
            buttonFermerYes.Visibility = Visibility.Hidden;
            buttonTerminerDéfi.Visibility = Visibility.Visible;
            dTimer.Start();
            if (Properties.Settings.Default.EstUnTest == true)
                dTimerTester.Start();
        }

        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {
            ouvrirChoixMode = false;
            CefGraphEnergie.Visibility = Visibility.Visible;
            CefGraphVitesse.Visibility = Visibility.Visible;

            Properties.Settings.Default.autorisationFermeture = false;
            Properties.Settings.Default.Save();
            Log l = new Log(Log.Type.Infos, "Démarrage du défi");
            buttonGo.Visibility = Visibility.Hidden;
            labelChrono.Visibility = Visibility.Visible;
            buttonTerminerDéfi.Visibility = Visibility.Visible;

            // Thread pour affichage des données
            dTimer = new DispatcherTimer();
            dTimer.Tick += new EventHandler(dispatcherTimer_Tick_Affichage);
            dTimer.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            dTimer.Start();

            if (Properties.Settings.Default.EstUnTest == true)
            {
                // Thread pour test
                dTimerTester = new DispatcherTimer();
                dTimerTester.Tick += new EventHandler(dispatcherTimer_Tick_Test);
                dTimerTester.Interval = new TimeSpan(0, 0, 2); // Met a jour teoute les 2 secondes 
                dispatcherTimer_Tick_Test(sender, e);
                dTimerTester.Start();
            }


            PbDefi.Visibility = Visibility.Visible;
            borderMinuteur.Visibility = Visibility.Visible;
            labelMinuteurDefi.Visibility = Visibility.Visible;
            PbDefi.Maximum = (Properties.Settings.Default.heures*3600) + (Properties.Settings.Default.minutes * 60) + (Properties.Settings.Default.secondes) + 1;
        }

        bool defiTermine = false;

        /// <summary>
        /// Methode exécuter dans le thread (toutes les secondes, pour afficher mettre a jour le chronomètre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Affichage(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.heures >= 0 && Properties.Settings.Default.minutes >= 0 && Properties.Settings.Default.secondes > 0)
            {
                Properties.Settings.Default.secondes--;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.heures >= 0 && Properties.Settings.Default.minutes > 0 && Properties.Settings.Default.secondes == 0)
            {
                Properties.Settings.Default.minutes--;
                Properties.Settings.Default.secondes = 59;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.heures > 0 && Properties.Settings.Default.minutes == 0 && Properties.Settings.Default.secondes == 0)
            {
                Properties.Settings.Default.heures--;
                Properties.Settings.Default.minutes = 59;
                Properties.Settings.Default.secondes = 59;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.heures == 0 && Properties.Settings.Default.minutes == 0 && Properties.Settings.Default.secondes == 0)
            {
                labelChrono.Content = "Défi Terminé";
                dTimer.Stop();
                buttonAfficherRapport.Visibility = Visibility.Visible;
                buttonTerminerDéfi.Visibility = Visibility.Hidden;
            }
            else
            {
                string heureStr = Properties.Settings.Default.heures.ToString();
                string minuteStr = Properties.Settings.Default.minutes.ToString();
                string secondeStr = Properties.Settings.Default.secondes.ToString();

                if (Properties.Settings.Default.minutes < 10 && Properties.Settings.Default.heures > 0)
                    minuteStr = "0" + minuteStr;

                if (Properties.Settings.Default.secondes < 10)
                    secondeStr = "0" + secondeStr;

                if (Properties.Settings.Default.heures == 0)
                    labelChrono.Content = minuteStr + " : " + secondeStr;
                else
                    labelChrono.Content = heureStr + " : " + minuteStr + " : " + secondeStr;
            }

            Properties.Settings.Default.tempsChronosec++;
            Properties.Settings.Default.Save();
            PbDefi.Value++;
        }

        /// <summary>
        /// Méthode éxécuter lors de l'appui sur le bouton qui termine le défi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTerminerDéfi_Click(object sender, RoutedEventArgs e)
        {
            ouvrirChoixMode = false;
            Log l = new Log(Log.Type.Infos, "L'utilisateur demande l'arret du défi avant la fin");

            // Met en pause l'actualisation es graphiques
            DemarrerDispatchTimerEnergieStatic();
            DemarrerDispatchTimerVitesseStatic();

            dTimer.Stop(); // Le temps que le message apparait on arret le chrono
            if (Properties.Settings.Default.EstUnTest == true)
            {
                dTimerTester.Stop();
            }
                
            buttonTerminerDéfi.Visibility = Visibility.Hidden;
            buttonFermerYes.Visibility = Visibility.Visible;
            buttonFermerNo.Visibility = Visibility.Visible;
            //labelConfirmFermer.Visibility = Visibility.Visible;
            /*MessageBoxResult result = MessageBox.Show("Voulez vous arretez le défi avant la fin ?", "EnergieCycle", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK) // Si l'arret du défi est confirmé on affiche "défi terminer" et on affiche le bouton pour accéder au rapport du défi
            {
                Log l2 = new Log(Log.Type.Infos, "Arret du défi avant la fin confirmé");
                labelChrono.Content = "Défi terminé";
                buttonAfficherRapport.Visibility = Visibility.Visible;
                buttonTerminerDéfi.Visibility = Visibility.Hidden;
            }
            if (result == MessageBoxResult.Cancel) // Sinon le chrono redemarre et le défi continu
            {
                Log l3 = new Log(Log.Type.Infos, "Arret avant la fin annulé");
                dTimer.Start(); // On relance le thread pour actualiser le chrono
                dTimerTester.Sart();
            }*/
        }

        private void buttonGo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonGo_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void buttonAfficherRapport_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonAfficherRapport_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void buttonTerminerDéfi_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonTerminerDéfi_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void buttonFermerYes_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void buttonFermerYes_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonFermerNo_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void buttonFermerNo_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Permet de généré des valeurs aléatoires pour le cycliste 1
        /// Permet de faire des test sans vélo
        /// Chaque test est enregistrer dans la base de donnée (table relevé)
        /// </summary>
        private void testParticipant(Participant p)
        {
            p.GenererTestReleve();
            p.EnregristrerReleve();
        }

        /// <summary>
        /// fonction executée par le dispatcherTimer de test (dTimerTester)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Test(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    testParticipant(p1);
                    AfficherP1(p1);
                    break;
                case 2:
                    testParticipant(p1);
                    testParticipant(p2);
                    AfficherP1(p1);
                    AfficherP2(p2);
                    break;
                case 3:
                    testParticipant(p1);
                    testParticipant(p2);
                    testParticipant(p3);
                    AfficherP1(p1);
                    AfficherP2(p2);
                    AfficherP3(p3);
                    break;
                case 4:
                    testParticipant(p1);
                    testParticipant(p2);
                    testParticipant(p3);
                    testParticipant(p4);
                    AfficherP1(p1);
                    AfficherP2(p2);
                    AfficherP3(p3);
                    AfficherP4(p4);
                    break;
                default:
                    Log l = new Log(Log.Type.Erreur, "Nombre de participant incorrect pour le test : " + Properties.Settings.Default.nbParticipants);
                    break;
            }
        }

        /// <summary>
        /// DispatchTimer pour affichage graphique Energie (s'éxécute une seule fois
        /// Actualisation des graph en temps réel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Energie(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste;
                    break;
                case 2:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste;
                    break;
                case 3:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste;
                    break;
                case 4:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste;
                    break;
            }
            CefGraphEnergie.Visibility = Visibility.Visible;
            buttonGo.IsEnabled = true;
            TimerGraphE.Stop(); // Permet de n'éxécuter le dispatchTimer qu'une seule fois
        }

        /// <summary>
        /// DispatchTimer pour afficher graphique Vitesse (s'éxétue une seule fois
        /// Actualisation des graph en temps réel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Vitesse(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste;
                    break;
                case 2:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste;
                    break;
                case 3:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste;
                    break;
                case 4:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste;
                    break;
            }
            CefGraphVitesse.Visibility = Visibility.Visible;
            buttonGo.IsEnabled = true; // Permet d'attendre que le graphique soit chargé pour lancer le défi
            TimerGraphV.Stop(); // Permet de n'éxécuter lfdse dispatchTimer qu'une seule fois
        }


        /// <summary>
        /// DispatchTimer pour afficher graphique Energie (s'éxétue une seule fois
        /// Actualisation des graph désactivée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Energie_Static(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&staticGraph=1";
                    break;
                case 2:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&staticGraph=1";
                    break;
                case 3:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&staticGraph=1";
                    break;
                case 4:
                    CefGraphEnergie.Address = "http://localhost/chartService/graphEnergie.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste + "&staticGraph=1";
                    break;
            }
            CefGraphEnergie.Visibility = Visibility.Visible;
            TimerGraphEStatic.Stop(); // Permet de n'éxécuter le dispatchTimer qu'une seule fois
        }

        /// <summary>
        /// DispatchTimer pour afficher graphique Vitesse (s'éxétue une seule fois
        /// Actualisation des graph désactivée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Vitesse_Static(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&staticGraph=1";
                    break;
                case 2:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&staticGraph=1";
                    break;
                case 3:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&staticGraph=1";
                    break;
                case 4:
                    CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste + "&staticGraph=1";
                    break;
            }

            CefGraphVitesse.Visibility = Visibility.Visible;
            TimerGraphVStatic.Stop(); // Permet de n'éxécuter lfdse dispatchTimer qu'une seule fois
        }

        // Méthodes pour démarrer les threads des graphs (début)

        /// <summary>
        /// Permet de démarrer le dispatchTimer qui trace le graphique Energie en temps réel
        /// </summary>
        private void DemarrerDispatchTimerEnergie()
        {
            TimerGraphE = new DispatcherTimer();
            TimerGraphE.Tick += new EventHandler(dispatcherTimer_Tick_Energie);
            TimerGraphE.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphE.Start();
        }


        /// <summary>
        /// Permet de démarrer le dispatchTimer qui trace le graphique Vitesse en temps réel
        /// </summary>
        private void DemarrerDispatchTimerVitesse()
        {
            TimerGraphV = new DispatcherTimer();
            TimerGraphV.Tick += new EventHandler(dispatcherTimer_Tick_Vitesse);
            TimerGraphV.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphV.Start();
        }

        /// <summary>
        /// Permet de démarrer le dispatchTimer qui met en pause l'actualisation du graph Energie
        /// </summary>
        private void DemarrerDispatchTimerEnergieStatic()
        {
            TimerGraphEStatic = new DispatcherTimer();
            TimerGraphEStatic.Tick += new EventHandler(dispatcherTimer_Tick_Energie_Static);
            TimerGraphEStatic.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphEStatic.Start();
        }


        /// <summary>
        /// Permet de démarrer le dispatchTimer qui met en pause l'actualisation du graph Vitesse
        /// </summary>
        private void DemarrerDispatchTimerVitesseStatic()
        {
            TimerGraphVStatic = new DispatcherTimer();
            TimerGraphVStatic.Tick += new EventHandler(dispatcherTimer_Tick_Vitesse_Static);
            TimerGraphVStatic.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphVStatic.Start();
        }

        /// <summary>
        /// Permet de placer correctement différent élément de l'interface 
        /// Permet de cacher la colone des calories brulés si aucun poids n'est renseigné
        /// </summary>
        private void PlacerCalories()
        {
            if (ImageCalorie1.Visibility == Visibility.Hidden)
            {
                ColCalorie.Width = new GridLength(0);
            }else
            {
                ColCalorie.Width = new GridLength(200);
            }
        }
    }
}
