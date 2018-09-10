using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace IntegrationProject
{
    public static class JsonParser
    {
        public static List<string> ParseYelpSearch()
        {
            string url = $"https://api.yelp.com/v3/businesses/search?term=bars&latitude=43.031605&longitude=-87.909850&radius=400";
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
                    return searchResults.businesses.Select(b => b.name).ToList();
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

