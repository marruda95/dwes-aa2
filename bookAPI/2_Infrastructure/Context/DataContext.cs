
using bookAPI._2_Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace bookAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EmployeeRepository>? Employees { get; set; }
        public DbSet<UserRepository>? Users { get; set; }
        public DbSet<BookRepository>? Books { get; set; }
    }
}
