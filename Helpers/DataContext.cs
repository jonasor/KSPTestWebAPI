namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        // options.UseInMemoryDatabase("KSPEmployeesDBTest");
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
           .HasKey(s => s.Id);

        modelBuilder.Entity<Beneficiary>()
            .HasKey(s => s.Id);
            
        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Beneficiary)
            .WithOne(b => b.Employee)
            .HasForeignKey<Beneficiary>(b => b.EmployeeRef);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Beneficiary> Beneficiaries { get; set; }
}