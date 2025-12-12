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
        private static int pasFond = 2;
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
            Deplace(imgFond1, pasFond);
            Deplace(imgFond2, pasFond);
            nb++;
            if (nb == 2)
            {
                nb = 0;
            }
            serpent.Source = persos[nb];
        }
        

        public void Deplace(Image image, int pas)
        {
            Canvas.SetBottom(image, Canvas.GetBottom(image) - pas);

            if (Canvas.GetBottom(image) + image.Height < 0)
                Canvas.SetBottom(image, canvasJeu.ActualHeight);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.KeyDown += canvasJeu_KeyDown;
            //    Application.Current.MainWindow.KeyUp += canvasJeu_KeyUp;
        }

        private void canvasJeu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if ((Canvas.GetLeft(serpent) + MainWindow.PasSerpent) <= (canvasJeu.ActualWidth - serpent.ActualWidth))
                    Canvas.SetLeft(serpent, Canvas.GetLeft(serpent) + MainWindow.PasSerpent);
            }
            else if (e.Key == Key.Left)
            {
                if ((Canvas.GetLeft(serpent) - MainWindow.PasSerpent) >= 0)
                    Canvas.SetLeft(serpent, Canvas.GetLeft(serpent) - MainWindow.PasSerpent);
            }
            else if (e.Key == Key.Up)
            {
                //faire mouvement serpent haut
            }
            else if (e.Key == Key.Down)
            {
                //faire mouvement serpent bas
            }
            else if (e.Key == Key.Space)
            {
                if (minuterie.IsEnabled)
                {
                    minuterie.Stop();

                }

                else
                {
                    minuterie.Start();
                }

            }
#if DEBUG
            Console.WriteLine("Position Left pere noel :" + Canvas.GetLeft(serpent));
#endif
        }
    }
}

