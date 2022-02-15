using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex
{
    class RandomWords
    {
        public ObservableCollection<Word> fiveWords { get; set; }
        public RandomWords()
        {
            fiveWords = new ObservableCollection<Word>();
            WordsVM aux = new WordsVM();
            Random random = new Random();
            for( int index =0; index < 5; index ++)
            {
                int pozition = random.Next(0, aux.Words.Count);
                fiveWords.Add(aux.Words[pozition]);
                aux.Words.RemoveAt(pozition);
            }
        }
    }
}
