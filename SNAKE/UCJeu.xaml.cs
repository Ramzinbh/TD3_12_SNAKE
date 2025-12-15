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
        private static Random rand = new Random();
        private static DispatcherTimer minuterie;
        private static BitmapImage[] persos = new BitmapImage[2];

        public event Action GameOverEvent;
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
            Deplace(imgFond1, MainWindow.PasFond);
            Deplace(imgFond2, MainWindow.PasFond);
            nb++;
            if (nb == 16)
            {
                nb = 0;
            }
            if (nb < 8)
            {
                serpent.Source = persos[0];
            }
            else
            {
                serpent.Source = persos[1];
            }
            Tombe(imgAigle1, MainWindow.PasAigle);
            Tombe(imgAigle2, MainWindow.PasAigle);
            Tombe(imgPomme, MainWindow.PasPomme);
            if (Collision(imgAigle1,serpent) == true)
            {
                GameOverEvent?.Invoke();
            }
            //Console.WriteLine("Position Top du cadeau :" + Canvas.GetTop(imgAigle1));
        }
        public static bool Collision(Image img1, Image img2)
        {
            if (Canvas.GetTop(img1) + img1.ActualHeight == Canvas.GetTop(img2))
                return true;
            if (Canvas.GetLeft(img1) + img1.ActualWidth == Canvas.GetLeft(img2))
                return true;
            if (Canvas.GetRight(img1) + img1.ActualWidth == Canvas.GetRight(img2))
                return true;
            if (Canvas.GetBottom(img1) + img1.ActualHeight == Canvas.GetBottom(img2))
                return true;
            return false;

        }
        public void Tombe(Image objet, int pas)
        {
            if (Canvas.GetTop(objet) < canvasJeu.ActualHeight)
                Canvas.SetTop(objet, Canvas.GetTop(objet) + pas);
            else
            {
                Canvas.SetTop(objet, -objet.ActualHeight);
                Canvas.SetLeft(objet, rand.Next(0, (int)canvasJeu.ActualWidth - (int)objet.ActualWidth));
            }
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
            if (Keyboard.IsKeyDown(Key.Right))
            {
                if ((Canvas.GetLeft(serpent) + MainWindow.PasSerpent) <= (canvasJeu.ActualWidth - serpent.ActualWidth))
                {
                    Canvas.SetLeft(serpent, Canvas.GetLeft(serpent) + MainWindow.PasSerpent);
                }
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if ((Canvas.GetLeft(serpent) - MainWindow.PasSerpent) >= 0)
                {
                    Canvas.SetLeft(serpent, Canvas.GetLeft(serpent) - MainWindow.PasSerpent);
                }
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if ((Canvas.GetTop(serpent) - MainWindow.PasSerpent) >= this.menuJeu.ActualHeight)
                {
                    Canvas.SetTop(serpent, Canvas.GetTop(serpent) - MainWindow.PasSerpent);
                }
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                if ((Canvas.GetTop(serpent) + MainWindow.PasSerpent) <= (canvasJeu.ActualHeight - serpent.ActualHeight))
                {
                    Canvas.SetTop(serpent, Canvas.GetTop(serpent) + MainWindow.PasSerpent);
                }
            }
            if (e.Key == Key.P)
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
            Console.WriteLine("Position Left serpent :" + Canvas.GetLeft(serpent));
#endif
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            ParametreWindow parametreWindow = new ParametreWindow();
            bool? rep = parametreWindow.ShowDialog();
            if (rep == true)
            {
                minuterie.Start();
                MainWindow.vitesse = parametreWindow.slidVitesse.Value;

                // ATTENTION : LES PAS DOIVENT ETRE DES MULTIPLES
                // DE LA TAILLE DE L’IMAGE A DEPLACER
                if (MainWindow.vitesse == 2)
                {
                    MainWindow.PasSerpent = 10;
                }
                else if (MainWindow.vitesse == 1)
                {
                    MainWindow.PasSerpent = 5;
                }
                else if (MainWindow.vitesse == 3)
                {
                    MainWindow.PasSerpent = 15;
                }
            }
        }
    }
}

