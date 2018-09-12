using IntegrationProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationProject.Models;

namespace IntegrationProject
{
    public static class BarCreator
    {
        public static void CreateBars(ApplicationDbContext context)
        {
           
            SearchResult allBars = JsonParser.ParseYelpSearch();
            for (int i = 0; i < allBars.businesses.Length; i++)
            {
                Bar bar = new Bar();
                bar.YelpId = allBars.businesses[i].id;
                bar.Name = allBars.businesses[i].name;
                context.Bars.Add(bar);
               
            }
            context.SaveChanges();
          
        }
    }
}
