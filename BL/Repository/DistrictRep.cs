using First_Project.BL.Interface;
using First_Project.DAL.Database;
using First_Project.Models;

namespace First_Project.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly ApplicationDbContext _context;

        public DistrictRep(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistrict();
            return data;
        }


        public DistrictVM GetById(int id)
        {
            DistrictVM data = GetDistrictByID(id);
            return data;
        }



        // Refactor
        private DistrictVM GetDistrictByID(int id)
        {
            return _context.districts.Where(a => a.Id == id)
                                    .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId })
                                    .FirstOrDefault();
        }

        private IQueryable<DistrictVM> GetAllDistrict()
        {
            return _context.districts
                       .Select(a => new DistrictVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId });
        }
    }
}
