using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Answer
    {
        public int Id { get; set; }
        
        public double People { get; set; }

        public double Price { get; set; }

        public string Activities { get; set; }
        public List<Drink> Drinks { get; set; }
        public string Foods { get; set; }
        public double SitDown { get; set; }
        public double TimeOfDay { get; set; }
        public string Music { get; set; }
        public double DressCode { get; set; }
        public double Age { get; set; }
        public int Master { get; set; }

    }

    public class Drink
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        // [NotMapped]
        public bool Checked { get; set; }
    }
}
