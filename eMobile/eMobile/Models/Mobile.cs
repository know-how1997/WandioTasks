using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace eMobile.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public double ScreenSize { get; set; }
        public string ScreenResolution { get; set; }
        public double Processor { get; set; }
        public double Memory { get; set; }
        public double OperatingSystem { get; set; }
        public double Price { get; set; }
        public double Camera { get; set; }
    }
}
