using ConfigurationManagementSystem.Repositories.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManagementSystem.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<ConfigurationEntity> Configurations { get; set; }
}
