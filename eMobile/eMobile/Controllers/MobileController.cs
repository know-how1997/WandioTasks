using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMobile.Models;
using eMobile.MovileVM;
using eMobile.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileService _mobile;
        public MobileController(IMobileService mobile)
        {
            _mobile = mobile;
        }


        [SwaggerOperation(Description = "მოცემულ ურლზე ტანის გარეშე რექუესთის გაგზავნის შემთხვევაში დაგიბრუნდებათ ყველა მობილური," +
            " პარამეტრების შევსების შემთხვევაში დაგიბრუნდებათ გაფილტრული ტელეფონების მასივი.")]
        [HttpGet("mobile/filtered/name={{name}}/manufacturer={{company}}/minprice={{minprice}}/maxprice{{maxprice}}")]
        public ActionResult<MobilesVM> FilteredMobiles(string name, string company, double? minprice, double? maxprice)
        {
            FilterModel search = new FilterModel() { Name = name, Manufacturer = company, MinPrice = minprice, MaxPrice = maxprice };
            if (search.Name == null && search.Manufacturer == null && search.MinPrice == null && search.MaxPrice == null)
                return _mobile.GetAllMobiles();
            else
                return _mobile.GetFilteredMobiles(search);
        }


        [SwaggerOperation(Description = "მოცემულ ურლში მობილურის ID-ის ჩამატებით დაგიბრუნდებათ მობილურის დეტალური ინფორმაცია")]
        [HttpGet("mobile/details={{id}}")]
        public ActionResult<DetailedMobileVM> GetDetails(int id)
        {
            return _mobile.GetDetailedInformtion(id);
        }
    }
}
