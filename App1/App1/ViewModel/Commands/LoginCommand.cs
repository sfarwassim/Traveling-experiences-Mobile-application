using App1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainVM MainViewModel { get; set; }

        public LoginCommand(MainVM mainVM)
        {
            MainViewModel = mainVM;
        }




        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
                return false;

            if (string.IsNullOrEmpty(user.EmailAddress) || string.IsNullOrEmpty(user.Password))
                return false;
            
                return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Login();
        }
    }
}
