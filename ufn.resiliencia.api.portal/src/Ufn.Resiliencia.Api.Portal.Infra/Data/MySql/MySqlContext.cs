using Microsoft.EntityFrameworkCore;

namespace Ufn.Resiliencia.Api.Portal.Infra.Data.MySql;
public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySqlContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
