using Microsoft.EntityFrameworkCore;
using EF.Auditor.Context;

namespace EF.Auditor.UnitTests.Models.Context;

public class TestDbContext : AuditedDbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> opts) : base(opts)
    {
    }
    
    public DbSet<Person> People { get; set; }
}