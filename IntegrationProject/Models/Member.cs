using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        
    }
}
