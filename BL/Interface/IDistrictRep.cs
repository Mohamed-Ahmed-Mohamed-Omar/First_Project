using First_Project.Models;

namespace First_Project.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        DistrictVM GetById(int id);
    }
}
