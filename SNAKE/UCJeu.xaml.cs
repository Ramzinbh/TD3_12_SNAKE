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
        public static Color CouleurSerpent { get; set; }
        public UCJeu()
        {
            InitializeComponent();
            InitializeMap();
            InitializeSerpent();
            InitializeTimer();
        }

        int pixel = 23;
        int[,] map = new int[22, 22];
        
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

        private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            // configure l'intervalle du Timer :62 images par s
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            // lancement du timer
            minuterie.Start();
        }

        string orientation = "droite";

        private void Jeu(object? sender, EventArgs e)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 1)
                    {
                        CaseSerpend(i, j);
                        for (int k = 0; k < listSerpent.Count -1; k++)
                        {
                            listSerpent[k] = listSerpent[k + 1];
                        }
                        listSerpent[listSerpent.Count -1 ][1] += 1;
                    }
                }
            }
        }

        private void CaseSerpend(int i, int j)
        {

            var cases = new Rectangle
            {
                Width = pixel,
                Height = pixel,
                Fill = new SolidColorBrush(Colors.Blue)
            };

            Canvas.SetLeft(cases, j * pixel); // X
            Canvas.SetTop(cases, i * pixel);  // Y
            canvasJeu.Children.Add(cases);
        }            
    }
}
