using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace qlkho.Viewmodels
{
    public class relayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object,bool> _canExecute;
        public relayCommand(Action<object> excute,Func<object,bool> canexcute=null) {
        _execute = excute;
            _canExecute = canexcute;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter)??true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

        
    }
}
