using AutoMapper;
using First_Project.BL.Interface;
using First_Project.DAL.Database;
using First_Project.DAL.Entities;
using First_Project.Models;

namespace First_Project.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRep(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(DepartmentVM departmentVM)
        {
            //Mapping

            var data = _mapper.Map<Department>(departmentVM);

            _context.departments.Add(data);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeleteObject = _context.departments.Find(id);

            _context.departments.Remove(DeleteObject);
            _context.SaveChanges();
        }

        public void Edit(DepartmentVM departmentVM)
        {
            var data = _mapper.Map<Department>(departmentVM);

            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepartments();

            return data;
        }

        private IQueryable<DepartmentVM> GetAllDepartments()
        {
            return _context.departments
                .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

        public DepartmentVM GetById(int id)
        {
            DepartmentVM? data = GetDepartmentById(id);

            return data;
        }

        private DepartmentVM? GetDepartmentById(int id)
        {
            return _context.departments.Where(a => a.Id == id)
                                           .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                           .FirstOrDefault();
        }
    }
}
