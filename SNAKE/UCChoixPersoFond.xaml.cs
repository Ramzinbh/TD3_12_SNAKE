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


        private void rbVert_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = "Vert";
        }

        private void rbRouge_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = "Rouge";
        }

        private void rbNoiretBlanc_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = "Noiretblanc";
        }

        private void rbBleu_Click(object sender, RoutedEventArgs e)
        {
            butJouer.IsEnabled = true;
            UCJeu.CouleurSerpent = "Bleu";
        }
    }
}
