using checkers.Models;
using checkers.Services;
using checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace checkers.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameVM gvm = new GameVM(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile.txt");
            grid.ItemsSource = gvm.GameBoard;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> lines = new List<string>();
            foreach (ObservableCollection<CellVM> line in grid.Items)
            {
                foreach (CellVM item in line)
                {
                    lines.Add(item.SimpleCell.X.ToString() + " " + item.SimpleCell.Y.ToString() + " " + item.SimpleCell.Type + " " + item.SimpleCell.Image);

                }
            }
            File.WriteAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile1.txt", lines);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GameVM gvm = new GameVM(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile1.txt");
            grid.ItemsSource = gvm.GameBoard;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Baciu Andrei" + System.Environment.NewLine + "andrei.baciu@student.unitbv.ro" + System.Environment.NewLine + "10LF391" + System.Environment.NewLine + "Acesta este un joc de dame");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\checkers\checkers\Resources\TextFile2.txt");
            MessageBox.Show("Red: " + lines[0] + " Blue: " + lines[1]);
        }
    }
}
