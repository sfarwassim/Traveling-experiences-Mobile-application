using App1.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{


 
   

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string cc { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string address { get; set; }
        public string crossStreet { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string neighborhood { get; set; }
    }

   

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }

        public async static Task<List<Venue>> GetVenues(double latitude, double longtitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenereateUrl(latitude, longtitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                //deserialize our json
                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>; // class venueRoot contains class response which contain Ilist of venue
            }


            return venues;
        }

    }

    public class Response
    {
        public IList<Venue> venues { get; set; }
    }

  
    //our old class that we create / class venue /response retrived from json
    class VenueRoot
    {
        public Response response { get; set; }
        public static string GenereateUrl(double latitude , double longtitude)
        {
           return string.Format(Constants.VENUE_SEARCH, latitude, longtitude,Constants.CLIENT_ID,Constants.CLIENT_SECRET,DateTime.Now.ToString("yyyyyMMdd"));
        }
    }
}
