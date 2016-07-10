using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;

// Using pour la création automatique de PDF
/*
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Windows.Markup;
using System.IO;
using System.IO.Packaging;
using System.Windows.Xps;
using PdfSharp.Pdf;
*/

namespace VeloPublic
{
    /// <summary>
    /// Logique d'interaction pour WindowDefiEnCours.xaml
    /// </summary>
    /// <author>Tiburce Richardeau</author>
    public partial class WindowRapportDefi
    {   
        string dateFileName = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
        string date = DateTime.Now.ToString().ToString();
        DispatcherTimer TimerGraphV, TimerGraphE;
        Participant p1, p2, p3, p4;

        /// <summary>
        /// Constructeur de la fenetre de rapport de défi, j'usqu'a 4 participants
        /// </summary>
        /// <param name="p1">Permier Participant au défi</param>
        /// <param name="p2">Deuxième Participant au défi</param>
        /// <param name="p3">Troisème Participant au défi</param>
        /// <param name="p4">Quatrième Participant au défi</param>
        public WindowRapportDefi(Participant p1, Participant p2, Participant p3, Participant p4)
        {
            InitializeComponent();
            imagePrint.IsEnabled = false;
            Log l = new Log(Log.Type.Infos, "Ouverture de la fenetre Rapport Défi");
            this.WindowState = WindowState.Maximized;
            //TextBlockModeRapport.Text = "Rapport du " + Properties.Settings.Default.Mode;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            labelDate.Content = date;
            RemplirDureeDefi();

            afficherStats();

            if (Properties.Settings.Default.EstUnTest)
            {
                ImageModeTest.Visibility = Visibility.Visible;
            }
            else
            {
                ImageModeTest.Visibility = Visibility.Hidden;
            }

            TimerGraphE = new DispatcherTimer();
            TimerGraphE.Tick += new EventHandler(dispatcherTimer_Tick_Energie);
            TimerGraphE.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphE.Start();

            TimerGraphV = new DispatcherTimer();
            TimerGraphV.Tick += new EventHandler(dispatcherTimer_Tick_Vitesse);
            TimerGraphV.Interval = new TimeSpan(0, 0, 1); // Met a jour teoute les secondes 
            TimerGraphV.Start();

            //Test
            // Affiche a chaque fois 
            // Adresse dans le switch afficage aléatoire
            //CefGraphVitesse.Address = "http://localhost/chartservice/graphPuissance.php?id_cycliste1=196&staticGraph=1";
            //CefGraphEnergie.Address= "http://localhost/chartservice/graphEnergie.php?id_cycliste1=196&staticGraph=1";


            PlacerCalories();
            SavePDF();
        }

        /// <summary>
        /// Méthode qui permet d'afficher les statistiques des participants (vitesse moyenne, distance, energie produite).
        /// Texte Uniquement (les graphiques ne sont pas gérés ici
        /// </summary>
        private void afficherStats()
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    AfficherRP1(p1);
                    break;
                case 2:
                    AfficherRP1(p1);
                    AfficherRP2(p2);
                    break;
                case 3:
                    AfficherRP1(p1);
                    AfficherRP2(p2);
                    AfficherRP3(p3);
                    break;
                case 4:
                    AfficherRP1(p1);
                    AfficherRP2(p2);
                    AfficherRP3(p3);
                    AfficherRP4(p4);
                    break;
            }
        }

        /// <summary>
        /// Permet de remplir le champ qui contient la durée du défi dans le rapport
        /// </summary>
        private void RemplirDureeDefi()
        {
            Log l = new Log(Log.Type.Infos, "Récupération de la durée du défi");
            int heure = Properties.Settings.Default.tempsChronosec / 3600;
            int min = Properties.Settings.Default.tempsChronosec % 3600 / 60;
            int sec = (Properties.Settings.Default.tempsChronosec % 3600) % 60;
            string heureString = heure.ToString();
            string minString = min.ToString();
            string secString = sec.ToString();

            if (heure < 10)
                heureString = "0" + heure;

            if (sec < 10)
                secString = "0" + sec;

            if (min < 10)
                minString = "0" + min;

            if (heure>0)
            {
                labelTempsDefi.Content = heureString + " : " + minString + " : " + secString;
            }
            else
            {
                labelTempsDefi.Content = minString + " : " + secString;
            }

            
            labelTempsDefi.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les statistiques du premier participant
        /// </summary>
        /// <param name="p"><code>Participant</code>Participant a afficher</param>
        private void AfficherRP1(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage du rapport du participant 1");
            labelRapportNomP1.Content = p.prenom + " " + p.nom;
            labelRapportNomP1.Visibility = Visibility.Visible;
            labelRapportDistanceP1.Content = p.distance.ToString() + " m";
            labelRapportDistanceP1.Visibility = Visibility.Visible;
            labelRapportVitesseMoyenneP1.Content = p.vitesseMoyenne.ToString() + " km/h";
            labelRapportVitesseMoyenneP1.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelRapportCalorieP1.Content = p.calories.ToString() + " kcal";
                labelRapportCalorieP1.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelRapportProductionP1.Content = p.production + " Wh";
            labelRapportProductionP1.Visibility = Visibility.Visible;
            //RecRapportEnergieP1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les statistiques du dexième participant
        /// </summary>
        /// <param name="p"><code>Participant</code>Participant a afficher</param>
        private void AfficherRP2(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage du rapport du participant 2");
            labelRapportNomP2.Content = p.prenom + " " + p.nom;
            labelRapportNomP2.Visibility = Visibility.Visible;
            labelRapportDistanceP2.Content = p.distance.ToString() + " m";
            labelRapportDistanceP2.Visibility = Visibility.Visible;
            labelRapportVitesseMoyenneP2.Content = p.vitesseMoyenne.ToString() + " km/h";
            labelRapportVitesseMoyenneP2.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelRapportCalorieP2.Content = p.calories.ToString() + " kcal";
                labelRapportCalorieP2.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelRapportProductionP2.Content = p.production + " Wh";
            labelRapportProductionP2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les statistiques du troisième participant
        /// </summary>
        /// <param name="p"><code>Participant</code>Participant a afficher</param>
        private void AfficherRP3(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage du rapport du participant 3");
            labelRapportNomP3.Content = p.prenom + " " + p.nom;
            labelRapportNomP3.Visibility = Visibility.Visible;
            labelRapportDistanceP3.Content = p.distance.ToString() + " m";
            labelRapportDistanceP3.Visibility = Visibility.Visible;
            labelRapportVitesseMoyenneP3.Content = p.vitesseMoyenne.ToString() + " km/h";
            labelRapportVitesseMoyenneP3.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelRapportCalorieP3.Content = p.calories.ToString() + " kcal";
                labelRapportCalorieP3.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelRapportProductionP3.Content = p.production + " Wh";
            labelRapportProductionP3.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Méthode qui permet d'afficher les statistiques du quatrième participant
        /// </summary>
        /// <param name="p"><code>Participant</code>Participant a afficher</param>
        private void AfficherRP4(Participant p)
        {
            Log l = new Log(Log.Type.Infos, "Affichage du rapport du participant 4");
            labelRapportNomP4.Content = p.prenom + " " + p.nom;
            labelRapportNomP4.Visibility = Visibility.Visible;
            labelRapportDistanceP4.Content = p.distance.ToString() + " m";
            labelRapportDistanceP4.Visibility = Visibility.Visible;
            labelRapportVitesseMoyenneP4.Content = p.vitesseMoyenne.ToString() + " km/h";
            labelRapportVitesseMoyenneP4.Visibility = Visibility.Visible;
            if (p.poids >= 0 && p.poidsString != "1" && p.poidsNonRenseigner == false)
            {
                labelRapportCalorieP4.Content = p.calories.ToString() + " kcal";
                labelRapportCalorieP4.Visibility = Visibility.Visible;
                ImageCalorie1.Visibility = Visibility.Visible;
            }
            labelRapportProductionP4.Content = p.production + " Wh";
            labelRapportProductionP4.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Permet de génerer un PDF de chaque rapport de défi
        /// TODO savePDF, methode non foncitonnelle
        /// </summary>
        private void SavePDF()
        {
            Log l = new Log(Log.Type.Infos, "Enrgistrement du rapport en PDF");
            /*MemoryStream lMemoryStream = new MemoryStream();
            Package package = Package.Open(lMemoryStream, FileMode.Create);
            XpsDocument doc = new XpsDocument(package);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);


            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();

            FixedPage.SetLeft(rapport, 0);
            FixedPage.SetTop(rapport, 0);

            double pageWidth = 960 * 80.5;
            double pageHeight = 960 * 110;

            fixedPage.Width = pageWidth;
            fixedPage.Height = pageHeight;

            fixedPage.Children.Add(rapport);

            Size sz = new Size(8.5 * 96, 11 * 96);
            fixedPage.Measure(sz);
            fixedPage.Arrange(new Rect(new Point(), sz));
            fixedPage.UpdateLayout();

            ((IAddChild)pageContent).AddChild(fixedPage);

            writer.Write(fixedPage);
            doc.Close();
            package.Close();
            var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(lMemoryStream);
            PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, "E:\\" + dateFileName + ".pdf", 0);
            */
        }

        /// <summary>
        /// Méthode qui permet de gérer le clic sur bouton imprimé présent sur le rapport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imagePrint_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Log l = new Log(Log.Type.Infos, "Demande impression du rapport par l'utilisateur");
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // On masque les éléments qu'il ne faut pas imprimer
                imagePrint.Visibility = Visibility.Hidden;
                ImageHome.Visibility = Visibility.Hidden;
                ImageReloadEnergie.Visibility = Visibility.Hidden;
                ImageReloadVitesse.Visibility = Visibility.Hidden;
                // On imprime
                printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                printDialog.PrintVisual(rapport, "Rapport Défi");
                // On réaffiche les éléements caché précédement 
                imagePrint.Visibility = Visibility.Visible;
                ImageReloadEnergie.Visibility = Visibility.Visible;
                ImageReloadVitesse.Visibility = Visibility.Visible;
                ImageHome.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Méthode éxécuter lors de la fermture de la fenetre du rapport.
        /// Ouverture de la fenetre de selection du mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void ImageReloadVitesse_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageReloadVitesse.Width += 10;
            ImageReloadVitesse.Height += 10;
            Cursor = Cursors.Hand;
        }

        private void ImageReloadVitesse_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageReloadVitesse.Width -= 10;
            ImageReloadVitesse.Height -= 10;
            Cursor = Cursors.Arrow;
        }

        private void ImageReloadVitesse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    if (p1 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 2:
                    if (p1 != null && p2 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 3:
                    if (p1 != null && p2 != null && p3 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 4:
                    if (p1 != null && p2 != null && p4 != null && p4 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste + "&staticGraph=1";
                    }
                    break;
                default:
                    Log l = new Log(Log.Type.Erreur, "dispatcherTimer_Tick_Vitesse valeur non compris entre 1 et 4");
                    break;

            }
        }

        private void ImageReloadEnergie_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageReloadEnergie.Width += 10;
            ImageReloadEnergie.Height += 10;
            Cursor = Cursors.Hand;
        }

        private void ImageReloadEnergie_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageReloadEnergie.Width -= 10;
            ImageReloadEnergie.Height -= 10;
            Cursor = Cursors.Arrow;
        }

        private void ImageReloadEnergie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                default:
                    Log l = new Log(Log.Type.Erreur, "dispatcherTimer_Tick_Energie valeur non compris entre 1 et 4");
                    break;
            }
        }

        private void Home_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ImageHome_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageHome.Height += 10;
            ImageHome.Width += 10;
                Cursor = Cursors.Hand;
        }

        private void ImageHome_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageHome.Height -= 10;
            ImageHome.Width -= 10;
            Cursor = Cursors.Arrow;
        }

        private void imagePrint_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            imagePrint.Height -= 10;
            imagePrint.Width -= 10;
            //imagePrint.Margin = new Thickness(0, 0, 43, 35);
        }

        private void imagePrint_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
            imagePrint.Height += 10;
            imagePrint.Width += 10;
            //imagePrint.Margin = new Thickness(0, 0, 38, 30);
        }

        /// <summary>
        /// fonction executée par le dispatcherTimer pour afficher le graphique Energie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick_Energie(object sender, EventArgs e)
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
                default:
                    Log l = new Log(Log.Type.Erreur, "dispatcherTimer_Tick_Energie valeur non compris entre 1 et 4");
                    break;
            }
            CefGraphEnergie.Visibility = Visibility.Visible;
            imagePrint.IsEnabled = true;
            TimerGraphE.Stop(); // Permet de n'éxécuter le dispatchTimer qu'une seule fois
        }

        private void dispatcherTimer_Tick_Vitesse(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.nbParticipants)
            {
                case 1:
                    if (p1 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 2:
                    if (p1 != null && p2 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 3:
                    if (p1 != null && p2 != null && p3 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&staticGraph=1";
                    }
                    break;
                case 4:
                    if (p1 != null && p2 != null && p4 != null && p4 != null)
                    {
                        CefGraphVitesse.Address = "http://localhost/chartService/graphPuissance.php?id_cycliste1="
                        + p1.idCycliste + "&id_cycliste2=" + p2.idCycliste + "&id_cycliste3=" + p3.idCycliste + "&id_cycliste4=" + p4.idCycliste + "&staticGraph=1";
                    }
                    break;
                default:
                    Log l = new Log(Log.Type.Erreur, "dispatcherTimer_Tick_Vitesse valeur non compris entre 1 et 4");
                    break;

            }

            CefGraphVitesse.Visibility = Visibility.Visible;
            imagePrint.IsEnabled = true;
            TimerGraphE.Stop(); // Permet de n'éxécuter lfdse dispatchTimer qu'une seule fois
        }

        /// <summary>
        /// Permet de placer correctement différent élément de l'interface 
        /// Permet de cacher la colonne des calories brulés si aucun poids n'est renseigné
        /// </summary>
        private void PlacerCalories()
        {
            if (ImageCalorie1.Visibility == Visibility.Hidden)
            {
                ColCalorie.Width = new GridLength(0);
            }
        }
    }
}