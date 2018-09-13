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

        public static Dictionary<string, int> RATING { get; } = new Dictionary<string, int>()
        {
            {"Terrible", 1 },
            {"Bad", 2 },
            {"Ok", 3 },
            {"Good", 4 },
            {"Great", 5 }
        };
        public static List<Drink> GetDrinks(List<Drink> memberDrinks)
        {
            for (int i = 0; i < Survey.DRINKS.Count; i++)
            {
                memberDrinks[i].Type = Survey.DRINKS[i].Type;
            }
            var filteredDrinks = memberDrinks.Where(drink => drink.Checked == true).ToList();
            return filteredDrinks;
        }
        public static List<Food> GetFoods(List<Food> memberFoods)
        {
            for (int i = 0; i < Survey.FOODS.Count; i++)
            {
                memberFoods[i].Type = Survey.FOODS[i].Type;
            }
            var filteredFoods = memberFoods.Where(food => food.Checked == true).ToList();
            return filteredFoods;
        }
        public static List<ActivityItem> GetActivities(List<ActivityItem> memberActivities)
        {
            for (int i = 0; i < Survey.ACTIVITIES.Count; i++)
            {
                memberActivities[i].Type = Survey.ACTIVITIES[i].Type;
            }
            var filteredActivities = memberActivities.Where(activity => activity.Checked == true).ToList();
            return filteredActivities;
        }
        public static List<Music> GetMusics(List<Music> memberMusics)
        {
            for (int i = 0; i < Survey.MUSICS.Count; i++)
            {
                memberMusics[i].Type = Survey.MUSICS[i].Type;
            }
            var filteredMusics = memberMusics.Where(music => music.Checked == true).ToList();
            return filteredMusics;
        }
        public static Answer GetCheckLists(Answer answer)
        {
            answer.Drinks = GetDrinks(answer.Drinks);
            answer.Foods = GetFoods(answer.Foods);
            answer.Activities = GetActivities(answer.Activities);
            answer.Musics = GetMusics(answer.Musics);
            return answer;
        }
    }
}
