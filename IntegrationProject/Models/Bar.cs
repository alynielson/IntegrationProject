using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }
        public string YelpId { get; set; }

        public string Name { get; set; }
        public double YelpRating { get; set; }
        public string Image_Url { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        
        public List<Comment> Comments { get; set; }
        [ForeignKey("Admin")]
        public int? AdminId { get; set; }
        public Admin Admin { get; set; }
        [ForeignKey("Answer")]
        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
    }

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string userComment { get; set; }
        [ForeignKey("Bar")]
        public int BarId { get; set; }
        public Bar bar { get; set; }
    }
}
