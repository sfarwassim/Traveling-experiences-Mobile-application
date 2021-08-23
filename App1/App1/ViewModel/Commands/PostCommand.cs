using App1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModel.Commands
{
    public class PostCommand : ICommand
    {

        public NewTravelVM newTravelViewModel;

        public PostCommand(NewTravelVM newTravelVm)
        {
            newTravelViewModel = newTravelVm;

        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;

                if (post.Venue != null)
                    return true;

                return false;
            }
            return false;

        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            newTravelViewModel.PublishPost(post);
        }
    }
}
