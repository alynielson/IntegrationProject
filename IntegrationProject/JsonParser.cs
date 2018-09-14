using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using IntegrationProject.Data;


namespace IntegrationProject
{
    public static class JsonParser
    {
        public static SearchResult ParseYelpSearch(ApplicationDbContext context)
        {
            string radiusForSearch;
            var radius = context.Values.SingleOrDefault(v => v.Name == "radius");
            if (radius == null)
            {
                radiusForSearch = "400";
            }
            else
            {
                radiusForSearch = radius.Item;
            }
            string url = $"https://api.yelp.com/v3/businesses/search?term=bars&latitude=43.031605&longitude=-87.909850&radius={radiusForSearch}";
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = Credentials.yelpApiKey;
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string responseString = null;
                    Stream stream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(stream);
                    responseString = streamReader.ReadToEnd();
                    SearchResult searchResults = JsonConvert.DeserializeObject<SearchResult>(responseString);
                    return searchResults;
                }
                else
                {
                    throw new Exception("Unable to get response");
                }

            }
            catch
            {
                throw new Exception("Request url not valid");
            }
        }

        public static Business ParseYelpSearchBar(string id)
        {
            string url = $"https://api.yelp.com/v3/businesses/" + id;
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = Credentials.yelpApiKey;
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string responseString = null;
                    Stream stream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(stream);
                    responseString = streamReader.ReadToEnd();
                    Business businessResult = JsonConvert.DeserializeObject<Business>(responseString);
                    return businessResult;
                }
                else
                {
                    throw new Exception("Unable to get response");
                }

            }
            catch
            {
                throw new Exception("Request url not valid");
            }
        }

        public static YelpReviews ParseYelpReviews(string id)
        {
            string url = $"https://api.yelp.com/v3/businesses/{id}/reviews";
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Authorization"] = Credentials.yelpApiKey;
                request.Method = "GET";
                response = request.GetResponse();
                if (response != null)
                {
                    string responseString = null;
                    Stream stream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(stream);
                    responseString = streamReader.ReadToEnd();
                    YelpReviews yelpReviews = JsonConvert.DeserializeObject<YelpReviews>(responseString);
                    return yelpReviews;
                }
                else
                {
                    throw new Exception("Unable to get response");
                }

            }
            catch
            {
                throw new Exception("Request url not valid");
            }
        }
    }
}

