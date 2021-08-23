using App1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    // i am just using this page for the history page
   public class HistoryVM : INotifyPropertyChanged
    {
        //public DeletePostCommand deletePostCommand { get; set; }
        public ObservableCollection<Post>  Posts { get; set; }

      
    

         public HistoryVM()
        {
           
            Posts = new ObservableCollection<Post>();
            //deletePostCommand = new DeletePostCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public async void DeletePost(Post post)
        {
            var deleted = Post.DeletePost(post);
            if (deleted)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Deleted", "OK");


            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Fail", "Not Deleted", "OK");


            }






        }
        public  async Task<bool> UpdatePost()
        {
            try
            {
                var posts = Post.ReadAllPost();
                if (posts != null)
                {
                    Posts.Clear();
                    foreach (var post in posts)
                    {
                        Posts.Add(post);
                    }
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
           

            

        }
    }
}
