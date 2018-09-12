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
        [Key]
        public int Id { get; set; }
        public double People { get; set; }
        public double Price { get; set; }
        public List<ActivityItem> Activities { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Food> Foods { get; set; }
        public double SitDown { get; set; }
        public double TimeOfDay { get; set; }
        public List<Music> Musics { get; set; }
        public double DressCode { get; set; }
        public double Age { get; set; }
        public int Master { get; set; }

    }

    public class Drink
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
    }
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
    }

    public class ActivityItem
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
    }
    public class Music
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
    }
}
