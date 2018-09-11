using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    class BusinessInfo
    {
        string Name { get; set; }
        double Rating { get; set; }
        string Img_Url { get; set; }
        int Review_Count { get; set; }
        string Display_Phone { get; set; }
        string[] Display_Address { get; set; }
    }
    public class AnonViewModel
    {
        List<BusinessInfo> Card { get; set; }
    }
}
