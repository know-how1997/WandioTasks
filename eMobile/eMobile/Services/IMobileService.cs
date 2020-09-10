using eMobile.Models;
using eMobile.MovileVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Services
{
    public interface IMobileService
    {
        public DetailedMobileVM GetDetailedInformtion(int id);
        public MobilesVM GetFilteredMobiles(FilterModel filter);
        public MobilesVM GetAllMobiles();
    }
}
