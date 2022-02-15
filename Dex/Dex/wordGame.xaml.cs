using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Dex
{
    /// <summary>
    /// Interaction logic for wordGame.xaml
    /// </summary>
    public partial class wordGame : Page
    {
        private int index;
        private int score;
        public wordGame()
        {
            InitializeComponent();

            Random random = new Random();
            int randomNumber = random.Next(2);
            if (randomNumber == 0 && (DataContext as RandomWords).fiveWords[0].ImageLocation != @"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\noimage.png")
            {
                image.Visibility = System.Windows.Visibility.Visible;
                wordDescription.Visibility = System.Windows.Visibility.Hidden;
                image.Source = new BitmapImage(new Uri((DataContext as RandomWords).fiveWords[0].ImageLocation));
            }
            else
            {
                wordDescription.Visibility = System.Windows.Visibility.Visible;
                image.Visibility = System.Windows.Visibility.Hidden;
                wordDescription.Text = (DataContext as RandomWords).fiveWords[0].Description;
            }

            index = 0;
            score = 0;
            next.Visibility = System.Windows.Visibility.Visible;
            finish.Visibility = System.Windows.Visibility.Hidden;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (index < 5)
            {
                if (answer.Text == (DataContext as RandomWords).fiveWords[index].Name)
                {
                    score++;
                    MessageBox.Show("Corect");
                }
                else
                {
                    MessageBox.Show("Gresit " + (DataContext as RandomWords).fiveWords[index].Name);
                }

                answer.Text = "";
                index++;
                if (index < 5)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(2);
                    if (randomNumber == 0 && (DataContext as RandomWords).fiveWords[index].ImageLocation != @"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\noimage.png")
                    {
                        image.Visibility = System.Windows.Visibility.Visible;
                        wordDescription.Visibility = System.Windows.Visibility.Hidden;
                        image.Source = new BitmapImage(new Uri((DataContext as RandomWords).fiveWords[index].ImageLocation));
                    }
                    else
                    {
                        wordDescription.Visibility = System.Windows.Visibility.Visible;
                        image.Visibility = System.Windows.Visibility.Hidden;
                        wordDescription.Text = (DataContext as RandomWords).fiveWords[index].Description;
                    }
                }
            }

            if (index == 5)
            {
                next.Visibility = System.Windows.Visibility.Hidden;
                finish.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void finsh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(score.ToString());
            wordDescription.Text = (DataContext as RandomWords).fiveWords[0].Description;
            index = 0;
            score = 0;
            next.Visibility = System.Windows.Visibility.Visible;
            finish.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
