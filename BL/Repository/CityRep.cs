using First_Project.BL.Interface;
using First_Project.DAL.Database;
using First_Project.Models;
using System.Security.AccessControl;

namespace First_Project.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly ApplicationDbContext _context;

        public CityRep(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCities();

            return data;
        }


        public CityVM GetById(int id)
        {
            CityVM data = GetCityByID(id);

            return data;
        }



        // Refactor
        private CityVM GetCityByID(int id)
        {
            return _context.citys.Where(a => a.Id == id)
                                    .Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId })
                                    .FirstOrDefault();
        }

        private IQueryable<CityVM> GetAllCities()
        {
            return _context.citys
                       .Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId });
        }
    }
}
