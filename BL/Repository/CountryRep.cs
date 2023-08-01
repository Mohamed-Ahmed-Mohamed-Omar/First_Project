using First_Project.BL.Interface;
using First_Project.DAL.Database;
using First_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace First_Project.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly ApplicationDbContext _context;

        public CountryRep(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;
        }


        public CountryVM GetById(int id)
        {
            CountryVM data = GetCountryByID(id);
            return data;
        }



        // Refactor
        private CountryVM GetCountryByID(int id)
        {
            return _context.countries.Where(a => a.Id == id)
                                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName })
                                    .FirstOrDefault();
        }

        private IQueryable<CountryVM> GetAllCountries()
        {
            return _context.countries
                       .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
        }
    }
}
