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
    }
}
