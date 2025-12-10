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
        public static string CouleurSerpent { get; set; }
        
        private BitmapImage serpent = new BitmapImage();
        public MainWindow()
        {
            InitializeComponent();
            AfficheRegleJeu();
            InitializeImages();
            
        }

        private void InitializeImages()
        {
            throw new NotImplementedException();
        }

        private void AfficheRegleJeu()
        {
            UCReglesJeu uc = new UCReglesJeu();
            // associe l'écran au conteneur
            ZoneJeu.Content = uc;
            uc.butDemarrer.Click += AfficheChoixPerso;
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