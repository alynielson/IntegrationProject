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
           
            SearchResult allBars = JsonParser.ParseYelpSearch(context);
            for (int i = 0; i < allBars.businesses.Length; i++)
            {
                Bar bar = new Bar();
                bar.YelpId = allBars.businesses[i].id;
                bar.Name = allBars.businesses[i].name;
                context.Bars.Add(bar);
               
            }
            context.SaveChanges();
          
        }


        public static Bar CreateBar(Business data, ApplicationDbContext context)
        {
            Answer answer = new Answer();
            Bar bar = new Bar()
            {
                Answer = answer,
                YelpId = data.id,
                Name = data.name,
                Image_Url = data.image_url,
                YelpRating = data.rating,
                Phone = data.phone,
                Address = data.location.address1,
                City = data.location.city,
                State = data.location.state,
                Zipcode = data.location.zip_code,
                Latitude = Convert.ToString(data.coordinates.latitude),
                Longitude = Convert.ToString(data.coordinates.longitude)
            };
            context.Answers.Add(answer);
            context.Bars.Add(bar);
            context.SaveChanges();
            return bar;
        }

    }
}
