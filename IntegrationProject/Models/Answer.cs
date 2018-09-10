using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Answer
    {
        public int Id { get; set; }
        
        public double People { get; set; }

        public double Price { get; set; }

        public List<int> Activities { get; set; }
        public List<int> Drinks { get; set; }
        public List<int> Foods { get; set; }
        public double SitDown { get; set; }
        public double TimeOfDay { get; set; }
        public List<int> Music { get; set; }
        public double DressCode { get; set; }
        public double Age { get; set; }
        public int Master { get; set; }

    }
}
