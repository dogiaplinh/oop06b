using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace oop06b.Helpers
{
    /// <summary>
    /// Class hỗ trợ việc binding command
    /// </summary>
    internal class RelayCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}