﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
