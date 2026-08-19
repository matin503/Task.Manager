using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Persistence.Context;

public class DataProviderContext : DbContext
{
    DbSet<TaskModel> Tasks { get; set; }


    public DataProviderContext(DbContextOptions<DataProviderContext> options) : base(options)
    {}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        try
        {
            var assembly = AppDomain.CurrentDomain.Load("Sanpad.Domain.Model");
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
        catch (Exception ex) { }
    }
}
