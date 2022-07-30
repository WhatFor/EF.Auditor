using EF.Auditor.UnitTests.Fixtures;
using EF.Auditor.UnitTests.Models.Context;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Auditor.UnitTests;

public class MetaTests : BaseTest
{
    [Fact]
    public void EnsureDatabaseIsAccessible()
    {
        var context = Services.GetRequiredService<TestDbContext>();
        
        var r = FluentActions.Invoking(() => context.Audits.Any());

        r.Should().NotThrow();
    }
}