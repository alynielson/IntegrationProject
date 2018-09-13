using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public class YelpReviews
    {
        public Review[] reviews { get; set; }
        public int total { get; set; }
        public Language[] possible_languages { get; set; }
    }

    public class Review
    {
        public string id { get; set; }
        public string url { get; set; }
        public string text { get; set; }
        public int rating { get; set; }
        public string time_created { get; set; }
        public User user { get; set; }
    }

    public class Language
    {
        public string language { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string profile_url { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
    }
}
