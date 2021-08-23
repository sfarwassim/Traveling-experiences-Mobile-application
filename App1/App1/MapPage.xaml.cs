using App1.Model;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected  async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var locator = CrossGeolocator.Current;
                //Event handler when location changed
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.FromSeconds(2), 100); //dima yasma3


                //create a span map to move to it
                var position = await locator.GetPositionAsync();
                var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
                var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
                LocationMap.MoveToRegion(span);

                var posts = Post.ReadAllPost();
                DisplayInMap(posts);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           

          
        }
        protected  async override void OnDisappearing()
        {
            base.OnDisappearing();

            //we need to  stop listening to start listening again and this is the solutuion
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();




        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {

                    var position = new Xamarin.Forms.Maps.Position(post.Lat, post.Lng);

                    var pin = new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };
                    LocationMap.Pins.Add(pin);

                }
                catch (NullReferenceException nre)
                {

                }
                catch (Exception)
                {

                   
                }

            }

        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            LocationMap.MoveToRegion(span);
        }
    }
 }
