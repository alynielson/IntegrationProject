using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationProject.Models
{
    public class ImgurResponseViewModel
    {
        public ImgurImageDataViewModel Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; }
    }

    public class ImgurImageDataViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Datetime { get; set; }
        public string Type { get; set; }
        public bool Animated { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
        public int Views { get; set; }
        public int Bandwidth { get; set; }
        public string Ddeletehash { get; set; }
        public string Section { get; set; }
        public string Link { get; set; }
        public string Account_url { get; set; }
        public int Aaccount_id { get; set; }
    }
}
