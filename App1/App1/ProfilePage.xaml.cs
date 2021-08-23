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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();


            
                var postTable = Post.ReadAllPost();



                categoriesList.ItemsSource = Post.PostCategories(postTable); ;

                postCountLabel.Text = postTable.Count().ToString();
            
        }
    }
}