using qlkho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace qlkho.Viewmodels
{
    public class vmmain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public vmmain() {
            cmdNewuser = new relayCommand(excuteNew);
            cmdEdit = new relayCommand(executeEdit);
        }

       
        private void OnPropertyChanged(string name)
        {
              PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        private ICommand _command;
        public ICommand cmdNewuser
        {
            get { return _command; }
            set { _command = value;
            OnPropertyChanged(nameof(cmdNewuser));}
        }

        private void excuteNew(object obj)
        {
            if(obj != null) {
                //var o=obj as modelUser;
                MessageBox.Show(obj.ToString());
            }
        }

        private ICommand _cmdEdit;
        public ICommand cmdEdit
        {
            get { return _cmdEdit; }
            set { _cmdEdit = value; OnPropertyChanged(nameof(cmdEdit)); }
        }
        private void executeEdit(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

    }
}
