using App1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModel
{
   public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }

        

    }
}
