using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class MemberBarVM
    {
        public List<BarMatch> matchedBars;
        public Member member;
    }

    public class BarMatch
    {
        public Bar bar { get; set; }
        public double score { get; set; }
    }
}
