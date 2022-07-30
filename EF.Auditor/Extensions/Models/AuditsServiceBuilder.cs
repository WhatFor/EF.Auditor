using Microsoft.Extensions.DependencyInjection;

namespace EF.Auditor.Extensions.Models;

public class AuditsServiceBuilder
{
    public AuditsServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}