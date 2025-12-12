using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SNAKE
{
    /// <summary>
    /// Logique d'interaction pour UCChoixPersoFond.xaml
    /// </summary>
    public partial class UCChoixPersoFond : UserControl
    {
        public UCChoixPersoFond()
        {
            InitializeComponent();
        }

        private void rbBleu_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = Color.FromArgb(255, 0, 0, 255);
        }

        private void rbJaune_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = Color.FromArgb(255, 250, 250, 0);
        }

        private void rbRouge_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = Color.FromArgb(255, 255, 0, 0);
        }

        private void rbVert_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = Color.FromArgb(255, 0, 255, 0);
        }
    }
}
