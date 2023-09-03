
using bookAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace bookAPI.Infrastructre.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EmployeeRepository>? Employees { get; set; }
        public DbSet<UserRepository>? Users { get; set; }
        public DbSet<BookRepository>? Books { get; set; }
        public DbSet<OrderRepository>? Orders { get; set; }
    }
}
