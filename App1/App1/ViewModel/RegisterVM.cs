using App1.Model;
using App1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1.ViewModel
{
   public class RegisterVM : INotifyPropertyChanged
    {

        public RegisterCommand registerCommand { get; set; }

        private User user;

        public User User
        {
            get { return user; }
            set { user = value;
                OnPropertyChanged("User");


            }
        }



        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
                User = new User()
                {
                    EmailAddress = this.EmailAddress,
                    Password = this.Password,
                    ConfirmPassword=this.ConfirmPassword
                    
                };
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
                User = new User()
                {
                    EmailAddress = this.EmailAddress,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword


                };
            }
        }
        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
                User = new User()
                {
                    EmailAddress = this.EmailAddress,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword

                };
            }
        }

     

        public event PropertyChangedEventHandler PropertyChanged;


        // should get used to write this methode
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }





        public RegisterVM()
        {
            User = new User();
            registerCommand = new RegisterCommand(this);
        }




        public void Register(User user)
        {

            bool inserted= User.RegisterUser(user);
            if (inserted)
            {
                App.Current.MainPage.DisplayAlert("Success", "User added", "Ok");

            }


        }
    }
}
