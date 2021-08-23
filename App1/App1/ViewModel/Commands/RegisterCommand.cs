using App1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModel.Commands
{
   public class RegisterCommand : ICommand
    {

        public RegisterVM registerViewModel { get; set; }

        public RegisterCommand(RegisterVM registerVM)
        {
            registerViewModel = registerVM;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter; //hetha eli bech yjiii mel layout 

            if (user != null)
            {
                if(user.Password == user.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(user.EmailAddress) || string.IsNullOrEmpty(user.Password))
                        return false;
                    return true;
                }
                return false;

            }
            return false;



        }

        public void Execute(object parameter)
        {
            User user = (User)parameter;
            registerViewModel.Register(user);
        }
    }
}
