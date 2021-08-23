using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace App1.Model
{
    public class User 
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string emailAddress;

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value;
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                 }
        }
        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
            }
        }

      


        public static bool RegisterUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                int row = conn.Insert(user);
                if (row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        } 


        public static bool login(string email ,string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);
            if (isEmailEmpty || isPasswordEmpty)
            {
                return false;

            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<User>();
                    var users = conn.Table<User>().ToList();
                    var user = (from u in users
                                where u.EmailAddress == email
                                select u).ToList().FirstOrDefault();



                    if (user.EmailAddress == email && user.Password == password)
                    {
                        return true;

                    }

                    else
                    {
                        return false;

                    }

                }
            }

        }
    }
}
