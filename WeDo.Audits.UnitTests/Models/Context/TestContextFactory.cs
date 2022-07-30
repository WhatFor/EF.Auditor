using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WeDo.Audits.UnitTests.Models.Context;

public class TestContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    public TestDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WeDo.Audits.Tests;Integrated Security=True;");

        return new TestDbContext(optionsBuilder.Options);
    }
}