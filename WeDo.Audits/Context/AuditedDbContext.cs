using Microsoft.EntityFrameworkCore;
using WeDo.Audits.Models;

// Justification: Not needed.
#pragma warning disable CS8618

namespace WeDo.Audits.Context;

public abstract class AuditedDbContext : DbContext
{
    public AuditedDbContext(DbContextOptions opts) : base(opts) { }
    
    public DbSet<Audit> Audits { get; set; }
}