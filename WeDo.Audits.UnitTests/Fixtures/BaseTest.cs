using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Respawn;
using Respawn.Graph;
using WeDo.Audits.Extensions;
using WeDo.Audits.UnitTests.Models.Context;

namespace WeDo.Audits.UnitTests.Fixtures;

public abstract class BaseTest
{
    private readonly IServiceScopeFactory? _scopeFactory;
    private readonly ConfigurationManager? _configuration;

    protected readonly IServiceProvider Services;

    public BaseTest()
    {
        if (_configuration is null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            
            var configuration = builder.Build();
            
            _configuration = new ConfigurationManager();
            _configuration.AddConfiguration(configuration);
            
            if (_scopeFactory is null)
            {
                var services = new ServiceCollection();

                services.AddDbContext<TestDbContext>(o =>
                    o.UseSqlServer(_configuration.GetConnectionString("Default")));

                // Use WeDo.Audits
                services.AddLogging();
                services.UseAuditing();
            
                _scopeFactory = services
                    .BuildServiceProvider()
                    .GetRequiredService<IServiceScopeFactory>();
            
                using var migrationScope = _scopeFactory.CreateScope();
                var logger = migrationScope.ServiceProvider.GetRequiredService<ILogger<BaseTest>>();
                var dbContext = migrationScope.ServiceProvider.GetRequiredService<TestDbContext>();
            
                logger.LogWarning(
                    "Attempting to migrate {DbContext}, using ConnectionString: '{ConnectionString}'.",
                    nameof(TestDbContext),
                    dbContext.Database.GetConnectionString());
            
                dbContext.Database.Migrate();

                Services = services.BuildServiceProvider();
            }
        }
        
        var checkpoint = new Checkpoint
        {
            TablesToIgnore = new Table[]
            {
                "__EFMigrationsHistory",
            }
        };
        
        checkpoint
            .Reset(_configuration.GetConnectionString("Default"))
            .GetAwaiter()
            .GetResult();
    }
}