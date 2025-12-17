using System.Diagnostics.Eventing.Reader;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SNAKE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double vitesse;
        public static double difficulte;
        public static int score = 0;
        public static int chances = 3;
        private static MediaPlayer musique;
        public static SoundPlayer sonPommeMange = new SoundPlayer();
        public static int PasPomme { get; set; } = 5;
        public static int PasAigle { get; set; } = 7;
        public static int PasFond { get; set; } = 2;
        public static int PasSerpent { get; set; } = 10;
        public MainWindow()
        {
            InitializeComponent();
            AfficheRegleJeu();
            InitMusique();
            InitSon();
        }
        private void AfficheRegleJeu()
        {
            UCReglesJeu uc = new UCReglesJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butDemarrer.Click += AfficheChoixPerso;
            uc.butRegleJeu.Click += AfficheButJeu;
        }
        private void AfficheRegleJeu(object sender, RoutedEventArgs e)
        {
            UCReglesJeu uc = new UCReglesJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butDemarrer.Click += AfficheChoixPerso;
            uc.butRegleJeu.Click += AfficheButJeu;
        }

        private void AfficheButJeu(object sender, RoutedEventArgs e)
        {
            UCButJeu uc = new UCButJeu();
            ZoneJeu.Content = uc;
            uc.butRetour.Click += AfficheRegleJeu;
        }

        private void AfficheChoixPerso(object sender, RoutedEventArgs e)
        {
            UCChoixPersoFond uc = new UCChoixPersoFond();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butJouer.Click += AfficheJeu;
        }
        private void InitMusique()
        {
            musique = new MediaPlayer();
            musique.Open(new Uri(AppDomain.CurrentDomain.BaseDirectory + "sons_musiques/musiqueUCJeu.mp3"));
            musique.MediaEnded += RelanceMusique;
            musique.Volume = 15;
            musique.Play();
        }
        private void RelanceMusique(object? sender, EventArgs e)
        {
            musique.Position = TimeSpan.Zero;
            musique.Play();
        }
        private void InitSon()
        {
            sonPommeMange = new SoundPlayer(Application.GetResourceStream(new Uri("pack://application:,,,/sons_musiques/sonPomme.wav")).Stream);
        }
        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.GameOverEvent += AfficheGameOver;
        }
        private void AfficheGameOver(object sender, EventArgs e)
        {
            UCGameOver uc = new UCGameOver();
            ZoneJeu.Content = uc;
            uc.butRejouer.Click += Rejouer;
            uc.butQuitter.Click += Stop;
        }
        private void Rejouer(object sender, RoutedEventArgs e)
        {
            score = 0;
            chances = 3;
            AfficheJeu(null, null);
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}