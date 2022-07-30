using Microsoft.Extensions.DependencyInjection;

namespace WeDo.Audits.Extensions.Models;

public class AuditsServiceBuilder
{
    public AuditsServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}