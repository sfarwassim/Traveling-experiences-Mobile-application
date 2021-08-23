using App1.Model;
using App1.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public PostCommand postCommand { get; set; }


        private Post post;
        public Post Post
        {
            get { return post; }
            set { post = value;
                OnPropertyChanged("Post");
            }
        }



        public NewTravelVM()
        {
            Post = new Post();
            Venue = new Venue();
            postCommand = new PostCommand(this);

        }

        private string experience;
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
                Post = new Post()
                {
                    Experience = this.Experience,
                    Venue = this.venue


                };
            }
        }

         private Venue venue;

        public Venue Venue
        {
            get { return venue; }
            set { venue = value;
                 OnPropertyChanged("Venue");
                 Post= new Post()
                 {
                    Experience = this.Experience,
                    Venue=this.venue


                 };
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void PublishPost(Post post)
        {
            try
            {
                Post.InsertPost(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience succesfully inserter", "Ok");
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }



        }
    }
}
