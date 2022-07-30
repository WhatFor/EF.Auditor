using Microsoft.EntityFrameworkCore;
using EF.Auditor.Models;

// Justification: Not needed.
#pragma warning disable CS8618

namespace EF.Auditor.Context;

public abstract class AuditedDbContext : DbContext
{
    public AuditedDbContext(DbContextOptions opts) : base(opts) { }
    
    public DbSet<Audit> Audits { get; set; }
}