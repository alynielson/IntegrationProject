﻿using System;
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
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }

        public string Details { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Waypoint> Waypoints { get; set; }
       
        [ForeignKey("Destination")]
        public int DestinationId {get; set;}
        public Destination Destination { get; set; }
        [ForeignKey("Origin")]
        public int OriginId { get; set; }
        public Origin Origin { get; set; }
        [NotMapped]
        public int NumberOfStops { get; set; }
        public int NumberOfGuests { get; set; }
    }

    public class Waypoint
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }

    public class Origin
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
    }

    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Name { get; set; }
    }
}
