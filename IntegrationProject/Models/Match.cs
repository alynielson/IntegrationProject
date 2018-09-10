using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        public double Score { get; set; }
        [ForeignKey("Bar")]
        public int BarId { get; set; }
        public Bar Bar { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        
    }
}
