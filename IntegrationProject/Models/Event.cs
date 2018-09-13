using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfEvent { get; set; }
        public string TimeOfEvent { get; set; }
        public string EventDetails { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }

}
