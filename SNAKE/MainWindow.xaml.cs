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
        private static MediaPlayer musique;
        public static int PasPomme { get; set; } = 3;
        public static int PasAigle { get; set; } = 5;
        public static int PasFond { get; set; } = 2;
        public static int PasSerpent { get; set; } = 10;
        public MainWindow()
        {
            InitializeComponent();
            AfficheRegleJeu();
            InitMusique();
        }

        private void AfficheRegleJeu()
        {
            UCReglesJeu uc = new UCReglesJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butDemarrer.Click += AfficheChoixPerso;
        }

        private void AfficheChoixPerso(object sender, RoutedEventArgs e)
        {
            UCChoixPersoFond uc = new UCChoixPersoFond();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butJouer.Click += AfficheJeu;
        }

        public void AfficheGameOver()
        {
            ZoneJeu.Content = new UCGameOver();
        }

        public void Jeu(object sender, RoutedEventArgs e)
        {
            UCJeu jeu = new UCJeu();
            jeu.GameOverEvent += AfficheGameOver;
            ZoneJeu.Content=jeu;
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
        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
        }
    }
}