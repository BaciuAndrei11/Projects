using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex
{
    class Word : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }
        private string imageLocation;

        public string ImageLocation
        {
            get
            {
                return imageLocation;
            }
            set
            {
                imageLocation = value;
                NotifyPropertyChanged("Image");
            }
        }

        public Word()
        {
        }
        public Word(string n, string d, string c, string i)
        {
            Name = n;
            Description = d;
            Category = c;
            ImageLocation = i;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
