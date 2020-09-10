using eMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.MovileVM
{
    public class MobilesVM
    {
        public string Message { get; set; }
        public List<MobileInformtion> Mobiles { get; set; } = new List<MobileInformtion>();

    }
    public class MobileInformtion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }

    }

}
