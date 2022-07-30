using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EF.Auditor.UnitTests.Models.Context;

public class TestContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    public TestDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EF.Auditor.Tests;Integrated Security=True;TrustServerCertificate=True;");

        return new TestDbContext(optionsBuilder.Options);
    }
}