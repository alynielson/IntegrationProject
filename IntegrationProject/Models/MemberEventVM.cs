using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class MemberEventVM
    {
        public Member member { get; set; }
        public List<Event> @events { get; set; }
       
    }

   
}
