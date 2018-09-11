using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject
{
    public static class Survey
    {
        public static Dictionary<string, bool> PEOPLE { get; } = new Dictionary<string, bool>()
        {
            {"Yes", true },
            {"No", false }
        };
        public static Dictionary<string, bool> SITDOWN { get; } = new Dictionary<string, bool>()
        {
            {"Yes", true },
            {"No", false }
        };
        public static List<SelectListItem> PRICE { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="1", Text="Very Cheap" },
            new SelectListItem{Value = "2", Text="Cheap"},
            new SelectListItem{Value = "3", Text="Moderate"},
            new SelectListItem{Value = "4", Text="Expensive"}
        };
        public static List<SelectListItem> ACTIVITIES { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Sports" },
            new SelectListItem{Value = "1", Text="Dancing"},
            new SelectListItem{Value = "2", Text="Bar Games"},
            new SelectListItem{Value = "3", Text="Themed Bars"},
            new SelectListItem{Value = "4", Text="Patio"},
             new SelectListItem{Value = "5", Text="Lounge"}
        };
        public static List<SelectListItem> DRINKS { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Cocktails" },
            new SelectListItem{Value = "1", Text="Craft Beers"},
            new SelectListItem{Value = "2", Text="Wine"},
            new SelectListItem{Value = "3", Text="Anything to get Drunk"},
            new SelectListItem{Value = "4", Text="Anything Cheap"}
        };
        public static List<SelectListItem> FOODS { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Full Meals" },
            new SelectListItem{Value = "1", Text="Appetizers"}
        };
        public static List<SelectListItem> TIMEOFDAY { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Day" },
            new SelectListItem{Value = "1", Text="Night"},
            new SelectListItem{Value = "2", Text="Both"}
        };
        public static List<SelectListItem> MUSIC { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Country" },
            new SelectListItem{Value = "1", Text="Rock"},
            new SelectListItem{Value = "2", Text="Hip-Hop"},
            new SelectListItem{Value = "3", Text="Jukebox"},
            new SelectListItem{Value = "4", Text="Top 20"},
            new SelectListItem{Value = "5", Text="Intellectual"}
        };
        public static List<SelectListItem> DRESSCODE { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="No Dress Code" },
            new SelectListItem{Value = "1", Text="Casual"},
            new SelectListItem{Value = "2", Text="Moderate"},
            new SelectListItem{Value = "3", Text="Semi-Formal"},
            new SelectListItem{Value = "4", Text="Formal"}
        };
        public static List<SelectListItem> AGE { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="21-25" },
            new SelectListItem{Value = "1", Text="26-30"},
            new SelectListItem{Value = "2", Text="31-35"},
            new SelectListItem{Value = "2", Text="35+"},
        };
        public static List<SelectListItem> MASTER { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="0", Text="Crowdedness" },
            new SelectListItem{Value = "1", Text="Prices"},
            new SelectListItem{Value = "2", Text="Activities"},
            new SelectListItem{Value = "3", Text="Drink Options"},
            new SelectListItem{Value = "4", Text="Food Options"},
            new SelectListItem{Value = "5", Text="Sitdown Areas"},
            new SelectListItem{Value = "6", Text="Time of Day"},
            new SelectListItem{Value = "7", Text="Music"},
            new SelectListItem{Value = "8", Text="DressCode"},
            new SelectListItem{Value = "9", Text="Age Groups"}
        };
    }
}
