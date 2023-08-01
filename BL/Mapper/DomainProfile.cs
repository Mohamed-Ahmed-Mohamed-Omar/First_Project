using AutoMapper;
using First_Project.DAL.Entities;
using First_Project.Models;

namespace First_Project.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile() {

            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Student, StudentVM>();
            CreateMap<StudentVM, Student>();
        }
    }
}
