using eMobile.Dal;
using eMobile.Models;
using eMobile.MovileVM;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eMobile.Services
{
    public class MobileService : IMobileService
    {
        private readonly MobileDbContext _db;
        public MobileService(MobileDbContext db)
        {
            _db = db;
        }
        public MobilesVM GetAllMobiles()
        {
            _ = new MobilesVM();
            MobilesVM result = Transfer(_db.Mobiles.ToList());
            result.Message = "მოცემულია ყველა მობილური";
            return result;
        }
        public MobilesVM GetFilteredMobiles(FilterModel filter)
        {

            var result = new MobilesVM();
            result = Transfer(_db.Mobiles.ToList());
            if (filter.Name != null)
                result.Mobiles = result.Mobiles.Where(x => x.Name == filter.Name).ToList();
            if (filter.Manufacturer != null)
                result.Mobiles = result.Mobiles.Where(x => x.Manufacturer == filter.Manufacturer).ToList();
            if (filter.MinPrice != null)
                result.Mobiles = result.Mobiles.Where(x => x.Price > filter.MinPrice).ToList();
            if (filter.MaxPrice != null)
                result.Mobiles = result.Mobiles.Where(x => x.Price < filter.MaxPrice).ToList();

            if (result.Mobiles.Count == 0)
                result.Message = "მობილურები ვერ მოიძებნა";
            else
                result.Message = "მოიძებნა შემდეგი მობილურები";

            return result;

        }

        private MobilesVM Transfer(List<Mobile> mobiles)
        {
            var result = new MobilesVM();
            foreach (var mobile in mobiles)
            {
                result.Mobiles.Add(new MobileInformtion()
                { Id = mobile.Id, Name = mobile.Name, Manufacturer = mobile.Manufacturer, Price = mobile.Price });
            }
            return result;
        }

        public DetailedMobileVM GetDetailedInformtion(int id)
        {
            var mobile = _db.Mobiles.FirstOrDefault(x => x.Id == id);
            if (mobile == null)
                return new DetailedMobileVM() { Message = "მოცემული ID-ით მობილური ვერ მოიძებნა", Mobile = null };
            else
                return new DetailedMobileVM(mobile) { Message = "მოიძებნა შესაბამისი მობილური" };
        }


    }
}
