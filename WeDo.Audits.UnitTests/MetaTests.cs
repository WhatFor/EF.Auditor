using Microsoft.Extensions.DependencyInjection;
using WeDo.Audits.UnitTests.Fixtures;
using WeDo.Audits.UnitTests.Models.Context;

namespace WeDo.Audits.UnitTests;

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