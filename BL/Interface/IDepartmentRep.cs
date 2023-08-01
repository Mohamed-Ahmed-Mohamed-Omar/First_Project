using First_Project.Models;

namespace First_Project.BL.Interface
{
    public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);
        void Add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);
    }
}
