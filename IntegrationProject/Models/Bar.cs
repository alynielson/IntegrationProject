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
        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
