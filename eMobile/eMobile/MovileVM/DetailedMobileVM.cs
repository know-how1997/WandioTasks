using eMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.MovileVM
{
    public class DetailedMobileVM
    {
        public string Message { get; set; }
        public Mobile Mobile { get; set; } = new Mobile();

        public DetailedMobileVM(Mobile mobile)
        {
            Mobile.Id = mobile.Id;
            Mobile.Name = mobile.Name;
            Mobile.Manufacturer = mobile.Manufacturer;
            Mobile.Size = mobile.Size;
            Mobile.Weight = mobile.Weight;
            Mobile.ScreenSize = mobile.ScreenSize;
            Mobile.ScreenResolution = mobile.ScreenResolution;
            Mobile.Processor = mobile.Processor;
            Mobile.Memory = mobile.Memory;
            Mobile.OperatingSystem = mobile.OperatingSystem;
            Mobile.Price = mobile.Price;
            Mobile.Camera = mobile.Camera;

        }
        public DetailedMobileVM()
        {

        }

    }
}
