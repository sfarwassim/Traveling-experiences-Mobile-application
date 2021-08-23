using App1.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        HistoryVM historyModelView;
        public HistoryPage()
        {
            InitializeComponent();
            historyModelView = new HistoryVM();
            BindingContext = historyModelView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            historyModelView.UpdatePost();
           
        }

       
        // if i will work with the observable
                private void menuItem_Clicked(object sender, EventArgs e)
                {
                    var post = (Post)((MenuItem)sender).CommandParameter;
                    historyModelView.DeletePost(post);
                    historyModelView.UpdatePost();




                }

        private  async void postListView_Refreshing(object sender, EventArgs e)
        {
           await  historyModelView.UpdatePost();
            postListView.IsRefreshing = false;

        }
    }
}