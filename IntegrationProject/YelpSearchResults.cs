using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public class SearchResult
    {
        public int total { get; set; }
        public Region region { get; set; }

        public Business[] businesses { get; set; }
    }

    public class ViewModel
    {
        public List<string> barNames { get; set; }
    }

    public class Business
    {
        public string id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public string url { get; set; }
        public int review_count { get; set; }
        public Categories[] categories { get; set; }
        public double rating { get; set; }
        public Coordinates coordinates { get; set; }
        public string[] transactions { get; set; }
        public Location location { get; set; }
        public string phone { get; set; }
        public string display_phone { get; set; }
        public decimal distance { get; set; }

    }

    public class Location
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string[] display_address { get; set; }
    }
    public class Region
    {
        public Coordinates center { get; set; }
    }

    public class Coordinates
    {
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
    }

    public class Categories
    {
        public string alias { get; set; }
        public string title { get; set; }
    }


}
