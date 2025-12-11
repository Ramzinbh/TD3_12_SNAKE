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
        public static readonly int pixel = 23;
        private DispatcherTimer minuterie;
        public static SolidColorBrush CouleurSerpent { get; set; }
        public UCJeu()
        {
            InitializeComponent();
            InitializeMap();
            InitializeSerpent();
            //InitializeImages();
            InitializeTimer();
        }
        int[,] map = new int[22, 22];
        Rectangle[,] mapRect = new Rectangle[22, 22];
        private void InitializeMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 0;
                }
        }

        List<int[]> listSerpent = new List<int[]>();
        private void InitializeSerpent()
        {
            listSerpent.Add(new int[] { map.GetLength(0) / 2, (map.GetLength(1) / 2) - 2 });
            listSerpent.Add(new int[] { map.GetLength(0) / 2, (map.GetLength(1) / 2) - 1 });
            listSerpent.Add(new int[] { map.GetLength(0) / 2, map.GetLength(1) / 2});
            for (int i = 0; i < listSerpent.Count; i++)
            {
                map[listSerpent[i][0], listSerpent[i][1]] = 1;
            }
        }

        //private void InitializeImages()
        //{
        //    string nomFichierCouleur = $"pack://application:,,,/image/{CouleurSerpent}.jpg";
        //    BitmapImage caseSerpent = new BitmapImage(new Uri(nomFichierCouleur));
        //}

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
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        mapRect[i, j] = new Rectangle();
                        mapRect[i, j].Width = pixel;
                        mapRect[i, j].Height = pixel;
                        mapRect[i, j].Fill = CouleurSerpent;
                        Canvas.SetLeft(mapRect[i, j], (j + 1) * pixel);
                        Canvas.SetTop(mapRect[i, j], (i + 1) * pixel);


                        //Image image = new Image();

                        //// Chargement de l'image à partir du chemin ou d'une ressource
                        //BitmapImage bitmap = new BitmapImage();
                        //bitmap.BeginInit();
                        //bitmap.UriSource = new Uri($"pack://application:,,,/image/{CouleurSerpent}.jpg", UriKind.RelativeOrAbsolute); // Remplacez par le chemin de votre image
                        //bitmap.EndInit();

                        //// Assignation de l'image au contrôle Image
                        //image.Source = bitmap;

                        //// Définition de la position de l'image sur le Canvas (par exemple, X=100, Y=100)
                        //Canvas.SetLeft(image, (j + 1) * pixel);
                        //Canvas.SetTop(image, (i + 1) * pixel);
                        //image.Width = pixel;
                        //image.Height = pixel;
                        //image.Stretch = Stretch.Fill;
                        

                        //// Ajout de l'image au Canvas
                        //canvasJeu.Children.Add(image);
                    }

                }
            }
            
        }

        //private void OrientationDroite(int pos)
        //{
        //    Canvas.SetLeft(caseSerpent, (pos + 1) * pixel);
        //}

        //private void OrientationGauche(int pos)
        //{
        //    Canvas.SetRight(caseSerpent, (pos + 1) * pixel);
        //}

        //private void OrientationHaut(int pos)
        //{
        //    Canvas.SetBottom(caseSerpent, (pos + 1) * pixel);
        //}

        //private void OrientationBas(int pos)
        //{
        //    Canvas.SetTop(caseSerpent, (pos + 1) * pixel);
        //}
    }
}
