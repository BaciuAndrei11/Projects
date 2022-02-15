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

namespace Dex
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listBox.Items.Clear();
            listBox.Visibility = System.Windows.Visibility.Visible;
            if (string.IsNullOrEmpty(textBox.Text) == false)
            {
                foreach (Word word in (DataContext as WordsVM).Words)
                {
                    if (word.Name.StartsWith(textBox.Text))
                    {
                        if (word.Category == category.Text || string.IsNullOrEmpty(category.Text))
                        {
                            listBox.Items.Add(word);
                        }
                    }
                }
            }
            else
            {
                listBox.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
