using checkers.Commands;
using checkers.Models;
using checkers.Services;
using Microsoft.Owin.Security.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace checkers.ViewModels
{
    class CellVM : BaseNotification
    {
        GameBusinessLogic bl;
        public CellVM(int x, int y, string type, string image , GameBusinessLogic bl)
        {
            SimpleCell = new Cell(x, y, type, image);
            this.bl = bl;
        }

        public CellVM(ref Cell cell, ref GameBusinessLogic bl)
        {
            simpleCell = cell;
            this.bl = bl;
        }

        private Cell simpleCell;
        public Cell SimpleCell
        {
            get { return simpleCell; }
            set
            {
                simpleCell = value;
                NotifyPropertyChanged("SimpleCell");
            }
        }
       
        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                {
                    clickCommand = new RelayCommand<Cell>(bl.ClickAction);
                }
                return clickCommand;
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
