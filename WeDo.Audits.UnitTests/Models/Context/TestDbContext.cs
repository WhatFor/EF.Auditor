using Microsoft.EntityFrameworkCore;
using WeDo.Audits.Context;

namespace WeDo.Audits.UnitTests.Models.Context;

public class TestDbContext : AuditedDbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> opts) : base(opts)
    {
    }
    
    public DbSet<Person> People { get; set; }
}