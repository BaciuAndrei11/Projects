using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex
{
    class WordsVM
    {
        public ObservableCollection<Word> Words { get; set; }
        public ObservableCollection<string> Categorys { get; set; }
        public WordsVM()
        {
            Words = new ObservableCollection<Word>();
            Categorys = new ObservableCollection<string>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrei\Desktop\Projects\Dex\Dex\Text.txt");
            for (int index = 0; index < lines.Length; index += 5)
            {
                Words.Add(new Word { Name = lines[index], Description = lines[index + 1], Category = lines[index + 2], ImageLocation = lines[index + 3] });
                if (!Categorys.Contains(lines[index + 2]))
                    Categorys.Add(lines[index + 2]);
            }
        }
    }
}
