using First_Project.BL.Interface;
using First_Project.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.BL.Services.EmployeeServices
{
    public class EmployeeServicesController : Controller
    {
        private readonly ICityRep _cityRep;
        private readonly IDistrictRep _districtRep;

        public EmployeeServicesController(ICityRep cityRep, IDistrictRep districtRep)
        {
            _cityRep = cityRep;
            _districtRep = districtRep;
        }

        [HttpPost]
        [Route("/EmployeeServices/GetCityDataByCountryId")]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = _cityRep.Get().Where(a => a.CountryId == CntryID);

            return Json(data);
        }


        [HttpPost]
        [Route("/EmployeeServices/GetDistrictDataByCityId")]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = _districtRep.Get().Where(a => a.CityId == cityId);

            return Json(data);
        }
    }
}
