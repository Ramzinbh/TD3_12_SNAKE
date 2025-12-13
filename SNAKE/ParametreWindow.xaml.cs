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
using System.Windows.Shapes;

namespace SNAKE
{
    /// <summary>
    /// Logique d'interaction pour ParametreWindow.xaml
    /// </summary>
    public partial class ParametreWindow : Window
    {
        public ParametreWindow()
        {
            InitializeComponent();
            this.slidVitesse.Value = MainWindow.vitesse;
            this.slidDifficulte.Value = MainWindow.difficulte;
            if (this.slidVitesse.Value == 1 && this.slidDifficulte.Value == 3)
                this.butTriche.IsEnabled = true;
        }
        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
