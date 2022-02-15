using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkers.Models 
{
    class Cell : INotifyPropertyChanged
    {
        public Cell()
        {
            this.X = -1;
            this.Y = -1;
            this.Type = "yuggyugyj";
            this.Image = "dsdvsv";
        }
        public Cell(int x, int y, string type, string image)
        {
            this.X = x;
            this.Y = y;
            this.Type = type;
            this.Image = image;
        }

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
