using App1.Model;
using App1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1.ViewModel
{
   public class MainVM : INotifyPropertyChanged
    {

        public LoginCommand loginCommand { get; set; }
        public RegisterNavigationCommand registerNavigationCommand { get; set; }


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
                    Password = this.Password
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
                    Password = this.Password
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM ()
        {
            User = new User();
            loginCommand = new LoginCommand(this);
            registerNavigationCommand = new RegisterNavigationCommand(this);

        } 




        public async void Login()
        {
            bool canLogin = User.login(User.EmailAddress, User.Password);

            if (canLogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());

            }
            else
            {
                  await App.Current.MainPage.DisplayAlert("Error", "User or  password  is incorrect", "OK");

            }
        }
        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());

        }
    }
}
