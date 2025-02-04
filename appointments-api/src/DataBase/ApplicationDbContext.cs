using Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataBase;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;


    public ApplicationDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionString");
    }

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DoctorsTimetablesDateEntity> DoctorsTimetablesDates { get; set; }
    public DbSet<DoctorsTimetablesTimesEntity> DoctorsTimetablesTimes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


}
