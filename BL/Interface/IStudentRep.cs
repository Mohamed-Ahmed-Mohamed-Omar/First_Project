using First_Project.Models;

namespace First_Project.BL.Interface
{
    public interface IStudentRep
    {
        IQueryable<StudentVM> Get();
        StudentVM GetById(int id);
        void Add(StudentVM std);
        void Edit(StudentVM std);
        void Delete(int id);
    }
}
