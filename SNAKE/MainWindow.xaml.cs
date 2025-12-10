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
        public static string Perso { get; set; }
        private DispatcherTimer minuterie;
        public MainWindow()
        {
            InitializeComponent();
            AfficheRegleJeu();
            InitializeTimer();

        }

        private void AfficheRegleJeu()
        {
            UCReglesJeu uc = new UCReglesJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butDemarrer.Click += AfficheChoixPerso;
        }

        int[,] map = new int[20, 20];

        private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            // configure l'intervalle du Timer :62 images par s
            minuterie.Interval = TimeSpan.FromMilliseconds(6);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            // lancement du timer
            minuterie.Start();
        }


        private void Jeu(object? sender, EventArgs e)
        {

        }

        private void AfficheChoixPerso(object sender, RoutedEventArgs e)
        {
            UCChoixPersoFond uc = new UCChoixPersoFond();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butJouer.Click += AfficheJeu;
        }

        private void AfficheJeu(object sender, RoutedEventArgs e)
        {
            UCJeu uc = new UCJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
        }
    }
}