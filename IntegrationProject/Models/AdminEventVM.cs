using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class AdminEventVM
    {
        public Admin admin { get; set; }
        public List<Event> @events { get; set; }

    }
}
