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
using System.Windows.Threading;

namespace SNAKE
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    
    public partial class UCJeu : UserControl
    {
        private static DispatcherTimer minuterie;
        private static BitmapImage[] persos = new BitmapImage[2];
        public static string CouleurSerpent { get; set; }
        public UCJeu()
        {
            InitializeComponent();
            InitializeImages();
            InitializeTimer();
        }
        private void InitializeImages()
        {
            for (int i = 0; i < persos.Length; i++)
                persos[i] = new BitmapImage(new Uri($"pack://application:,,,/images/serpent{CouleurSerpent}Jeu_{i}.png"));
        }

        private void InitializeTimer()
        {
           minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            minuterie.Start();
        }

        private int nb = 0;

        private void Jeu(object? sender, EventArgs e)
        {
            Canvas.SetTop(imgFond1, Canvas.GetTop(imgFond1) - 2);
            if (Canvas.GetTop(imgFond1) + imgFond1.Height <= 0)
                Canvas.SetTop(imgFond1, 800);
            Canvas.SetTop(imgFond2, Canvas.GetTop(imgFond2) - 2);
            if (Canvas.GetTop(imgFond2) + imgFond1.Height <= 0)
                Canvas.SetTop(imgFond2, 800);
            nb++;
            if (nb == 2)
            {
                nb = 0;
            }
            serpent.Source = persos[nb];
        }
    }
}

