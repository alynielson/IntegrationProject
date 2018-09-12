using IntegrationProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class Survey
    {
        public static Dictionary<string, double> PEOPLE { get; } = new Dictionary<string, double>()
        {
            {"Yes", 1},
            {"No", 0 }
        };
        public static Dictionary<string, double> SITDOWN { get; } = new Dictionary<string, double>()
        {
            {"Yes", 1 },
            {"No", 0 }
        };
        public static Dictionary<string, double> PRICE { get; } = new Dictionary<string, double>()
        {
            {"Very Cheap", 1 },
            {"Cheap", 2 },
            {"Moderate", 3 },
            {"Expensive", 4 }
        };
        public static List<ActivityItem> ACTIVITIES { get; } = new List<ActivityItem>()
        {
            new ActivityItem(){Type = "Sports"},
            new ActivityItem(){Type = "Dancing"},
            new ActivityItem(){Type = "Themed Bars"},
            new ActivityItem(){Type = "Patio"},
            new ActivityItem(){Type = "Lounge"}
        };
        public static List<Drink> DRINKS { get; } = new List<Drink>()
        {
            new Drink(){Type = "Cocktails" },
            new Drink(){Type = "Craft Beers" },
            new Drink(){Type = "Wine" },
            new Drink(){Type = "Anything to get Drunk" },
            new Drink(){Type = "Anything Cheap" }
        };
        public static List<Food> FOODS { get; } = new List<Food>()
        {
            new Food(){Type = "Full Meals"},
            new Food(){Type = "Appetizers"},
            new Food(){Type = "Brunch"},
        };
        public static Dictionary<string, double> TIMEOFDAY { get; } = new Dictionary<string, double>()
        {
            {"Day", 1 },
            {"Night", 2 },
            {"Both", 3 }
        };
        public static List<Music> MUSICS { get; } = new List<Music>()
        {
            new Music(){Type= "Country"},
            new Music(){Type= "Rock"},
            new Music(){Type= "Hip-Hop"},
            new Music(){Type= "Jukebox"},
            new Music(){Type= "Top 20"},
            new Music(){Type= "Intellectual"}
        };
        public static Dictionary<string, double> DRESSCODE { get; } = new Dictionary<string, double>()
        {
            {"No Dress Code", 1 },
            {"Casual", 2 },
            {"Moderate", 3 },
            {"Semi-Formal", 4 },
            {"Formal", 5 }
        };
        public static Dictionary<string, double> AGE { get; } = new Dictionary<string, double>()
        {
            {"21-25", 1 },
            {"26-30", 2 },
            {"31-34", 3 },
            {"35+", 4 }
        };
        public static Dictionary<string, int> MASTER { get; } = new Dictionary<string, int>()
        {
            {"Crowdedness", 1 },
            {"Prices", 2 },
            {"Activities", 3 },
            {"Drink Options", 4 },
            {"Food Options", 5 },
            {"Sitdown Areas", 6 },
            {"Time of Day", 7 },
            {"Music", 8 },
            {"Dresscode", 9 },
            {"Age Groups", 10 }
        };
    }
}
