using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class AdminBarVM
    {
        public Admin admin { get; set; }

        public List<BarVM> bars { get; set; }

       
    }

    public class BarVM
    {
        public Bar bar { get; set; }
        public string adminName { get; set; }

        public bool CompletedSurvey { get; set; }
    }
}
