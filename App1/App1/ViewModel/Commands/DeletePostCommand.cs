using App1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App1.ViewModel.Commands
{
    //i am not using this page
    public class DeletePostCommand :ICommand
    {
        HistoryVM historyViewModel;

        public DeletePostCommand(HistoryVM historyVM)
        {
            historyViewModel = historyVM;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if (post != null)
                return true;
            return false;
           
        }

        public void Execute(object parameter)
        {
            Post post = (Post)parameter;
            historyViewModel.DeletePost(post);
        }
    }
}
