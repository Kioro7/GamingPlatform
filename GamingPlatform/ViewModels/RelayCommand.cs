using System;
using System.Windows.Input;

namespace GamingPlatform.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        //вызывается при изменении условий, указывающих, может ли команда выполняться
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        //определяет, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        //выполняет логику команды
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
