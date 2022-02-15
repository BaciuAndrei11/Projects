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
using System.IO;
using Microsoft.Win32;

namespace Dex
{
    /// <summary>
    /// Interaction logic for addWord.xaml
    /// </summary>
    public partial class addWord : Page
    {
        public addWord()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                if (string.IsNullOrEmpty(word.Text) || string.IsNullOrEmpty(description.Text) || string.IsNullOrEmpty(category.Text))
                {
                    MessageBox.Show("You must complete all fields");
                }
                else
                {
                    if (string.IsNullOrEmpty(imageLocation.Text))
                    {
                        imageLocation.Text = @"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\noimage.png";
                    }
                    (DataContext as WordsVM).Words.Add(new Word { Name = word.Text, Description = description.Text, Category = category.Text, ImageLocation = imageLocation.Text });
                    File.AppendAllText(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", Environment.NewLine + word.Text);
                    File.AppendAllText(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", Environment.NewLine + description.Text);
                    File.AppendAllText(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", Environment.NewLine + category.Text);
                    File.AppendAllText(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", Environment.NewLine + imageLocation.Text);
                    File.AppendAllText(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", Environment.NewLine);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a word from list");
            }
            else
            {
                List<string> lines = File.ReadAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt").ToList();
                lines.RemoveAt(listBox.SelectedIndex * 5);
                lines.RemoveAt(listBox.SelectedIndex * 5);
                lines.RemoveAt(listBox.SelectedIndex * 5);
                lines.RemoveAt(listBox.SelectedIndex * 5);
                lines.RemoveAt(listBox.SelectedIndex * 5);
                File.WriteAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", lines);

                (DataContext as WordsVM).Words.RemoveAt(listBox.SelectedIndex);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a word from list");
            }
            else if (string.IsNullOrEmpty(word.Text) || string.IsNullOrEmpty(description.Text) || string.IsNullOrEmpty(category.Text))
            {
                MessageBox.Show("You must complete all fields");
            }
            else
            {
                List<string> lines = File.ReadAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt").ToList();
                lines[listBox.SelectedIndex * 5] = word.Text;
                lines[listBox.SelectedIndex * 5 + 1] = description.Text;
                lines[listBox.SelectedIndex * 5 + 2] = category.Text;
                lines[listBox.SelectedIndex * 5 + 3] = imageLocation.Text;
                File.WriteAllLines(@"C:\Users\Andrei\Desktop\MediiVizualeDeProgramare\Dex\Dex\Text.txt", lines);

                (DataContext as WordsVM).Words[listBox.SelectedIndex] = new Word { Name = word.Text, Description = description.Text, Category = category.Text, ImageLocation = imageLocation.Text };
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                imageLocation.Text = openFileDialog.FileName;
        }
    }
}
