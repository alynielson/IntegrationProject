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
        public static Dictionary<string, double> ACTIVITIES { get; } = new Dictionary<string, double>()
        {
            {"Sports", 1 },
            {"Dancing", 2 },
            {"Bar Games", 3 },
            {"Themed Bars", 4 },
            {"Patio", 5 },
            {"Lounge", 6 }
        };
        public static Dictionary<string, double> DRINKS { get; } = new Dictionary<string, double>()
        {
            {"Cocktails", 1 },
            {"Craft Beers", 2 },
            {"Wine", 3 },
            {"Anything to get Drunk", 4 },
            {"Anything Cheap", 5 }
        };
        public static Dictionary<string, double> FOODS { get; } = new Dictionary<string, double>()
        {
            {"Full Meals", 1 },
            {"Appetizers", 2 }
        };
        public static Dictionary<string, double> TIMEOFDAY { get; } = new Dictionary<string, double>()
        {
            {"Day", 1 },
            {"Night", 2 },
            {"Both", 3 }
        };
        public static Dictionary<string, double> MUSIC { get; } = new Dictionary<string, double>()
        {
            {"Country", 1 },
            {"Rock", 2 },
            {"Hip-Hop", 3 },
            {"Jukebox", 1 },
            {"Top 20", 2 },
            {"Intellectual", 3 }
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
