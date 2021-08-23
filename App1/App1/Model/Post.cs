using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;

namespace App1.Model
{
   public class Post : INotifyPropertyChanged
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set { experience = value;
                  OnPropertyChanged("Experience");
                }
        }


        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set { venueName = value;
                OnPropertyChanged("VenueName");
            }
        }


        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }


        private double lat;

        public double Lat
        {
            get { return lat; }
            set { lat = value;
                OnPropertyChanged("Lat");
            }
        }

        private double lng;

        public double Lng
        {
            get { return lng; }
            set { lng = value;
                OnPropertyChanged("Lng");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value;
                OnPropertyChanged("Address");
            }
        }

        private Venue venue;

        [Ignore]
        [JsonIgnore] //because venue is object , this for the serialization
        public Venue Venue
        {
            get { return venue; }
            set {
                venue = value;

                OnPropertyChanged("Venue");


                if (Venue.categories!=null)
                {
                    var firstCategory = Venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;

                    }
                    
                }
                if (Venue.location !=null)
                {
                    Address = Venue.location.address;
                    Distance = Venue.location.distance;
                    Lat = Venue.location.lat;
                    Lng = Venue.location.lng;

                }
               
                VenueName = Venue.name;
            }
        }


        private DateTimeOffset createdat;

        public DateTimeOffset CREATEDAT
        {
            get { return createdat; }
            set { createdat = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged !=null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public static bool InsertPost(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int row = conn.Insert(post);
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

        public static bool DeletePost(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Post>();
                    conn.Delete(post);
                    return true;

                }
                catch (Exception)
                {

                    return false;
                }
               
               
                
            }
        }

        public static List<Post> ReadAllPost()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
              
                    conn.CreateTable<Post>();
                    var posts = conn.Table<Post>().ToList();
                    return posts;

                
              
            }
        }

        public static Dictionary<string,int> PostCategories(List<Post> postTable)
        {
            var categories = (from p in postTable
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();
            // we are using linq
            //returing all category  dinstint
            //counting how much category name is maaawda
            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {

                var count = (from post in postTable
                             where post.CategoryName == category
                             select post).ToList().Count;
                categoriesCount.Add(category, count);
             }
            return categoriesCount;
        }
    }
}
