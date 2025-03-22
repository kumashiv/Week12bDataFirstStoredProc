using Microsoft.EntityFrameworkCore;
using Week12bDataFirstStoredProc.Models;

namespace Week12bDataFirstStoredProc.AppDbContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }  // Table Name
    }
}
