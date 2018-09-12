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
        [Display(Name = "Crowdednesss")]
        public double People { get; set; }
        [Display(Name = "Priciness")]
        public double Price { get; set; }
        [Display(Name = "Activity Preferences")]
        public List<ActivityItem> Activities { get; set; }
        [Display(Name = "Drink Preferences")]
        public List<Drink> Drinks { get; set; }
        [Display(Name = "Food Preferences")]
        public List<Food> Foods { get; set; }
        [Display(Name = "Sitdown Space")]
        public double SitDown { get; set; }
        [Display(Name="Time of Day")]
        public double TimeOfDay { get; set; }
        [Display(Name = "Music Preferences")]
        public List<Music> Musics { get; set; }
        [Display(Name = "Dresscode Strictness")]
        public double DressCode { get; set; }
        [Display(Name = "Age Group")]
        public double Age { get; set; }
        [Display(Name = "Favorite Bar Aspect")]
        public int Master { get; set; }

    }

    public class Drink
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }

    public class ActivityItem
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
    public class Music
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool Checked { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
