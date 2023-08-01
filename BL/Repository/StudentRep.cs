using AutoMapper;
using First_Project.BL.Helper;
using First_Project.BL.Interface;
using First_Project.DAL.Database;
using First_Project.DAL.Entities;
using First_Project.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.IO;

namespace First_Project.BL.Repository
{
    public class StudentRep : IStudentRep
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentRep(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(StudentVM std)
        {
            var data = _mapper.Map<Student>(std);

            data.PhotoName = UploadFileHelper.SaveFile(std.PhotoUrl, "Photos");

            data.CvName = UploadFileHelper.SaveFile(std.CvUrl, "Docs");

            _context.students.Add(data);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delData = _context.students.Find(id); 

            _context.students.Remove(delData);

            UploadFileHelper.RemoveFile("Photos/", delData.PhotoName);

            UploadFileHelper.RemoveFile("Docs/", delData.CvName);

            _context.SaveChanges();
        }

        public void Edit(StudentVM std)
        {
            var data = _mapper.Map<Student>(std);

            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }

        public IQueryable<StudentVM> Get()
        {
            IQueryable<StudentVM> data = GetAllStudent();

            return data;
        }

        private IQueryable<StudentVM> GetAllStudent()
        {
            return _context.students.Select(a => new StudentVM
            {
                Id = a.Id,
                Address = a.Address,
                Name = a.Name,
                Age = a.Age,
                DepartmentId = a.DepartmentId,
                DepartmentName = a.Department.DepartmentName,
                Email = a.Email,
                GPA = a.GPA,
                Phone = a.Phone,
                Start_Education = a.Start_Education,
                End_Education = a.End_Education,
                CvName = a.CvName,
                PhotoName = a.PhotoName
            });
        }

        public StudentVM GetById(int id)
        {
            StudentVM? data = GetStudentById(id);

            return data;
        }

        private StudentVM? GetStudentById(int id)
        {
            return _context.students.Where(a => a.Id == id)
                   .Select(a => new StudentVM
                   {
                       Id = a.Id,
                      Address = a.Address,
                      Name = a.Name,
                      Age = a.Age,
                      DepartmentId = a.DepartmentId,
                      DepartmentName = a.Department.DepartmentName,
                      Email = a.Email,
                      GPA = a.GPA,
                      Phone = a.Phone,
                      Start_Education = a.Start_Education,
                      End_Education = a.End_Education,
                      CvName = a.CvName,
                      PhotoName = a.PhotoName
                   }).FirstOrDefault();
        }
    }
}
