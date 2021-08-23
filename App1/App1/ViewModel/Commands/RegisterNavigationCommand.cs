using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModel.Commands
{
    public class RegisterNavigationCommand : ICommand
    {
        public MainVM MainViewModel { get; set; }

        public RegisterNavigationCommand( MainVM mainViewModel)
        {
            MainViewModel = mainViewModel;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Navigate();
        }
    }
}
