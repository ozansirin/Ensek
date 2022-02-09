using Ensek.Core.Model;

using Microsoft.EntityFrameworkCore;

namespace Ensek.Core;
public class EnsekDbContext : DbContext
{
    public EnsekDbContext(DbContextOptions<EnsekDbContext> options) : base(options)
    {
        AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
    }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<MeterReading> MeterReadings { get; set; }
}
