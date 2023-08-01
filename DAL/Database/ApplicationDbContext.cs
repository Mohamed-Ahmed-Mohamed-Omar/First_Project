using First_Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using First_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace First_Project.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Department> departments { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> citys { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
