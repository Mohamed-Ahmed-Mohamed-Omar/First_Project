using First_Project.Models;

namespace First_Project.BL.Interface
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}
