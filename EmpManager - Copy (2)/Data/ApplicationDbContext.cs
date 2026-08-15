using Microsoft.EntityFrameworkCore;
using EmpManager.Models;

namespace EmpManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }
    }
}