using EF.Auditor.Extensions.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Auditor.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static AuditsServiceBuilder UseAuditing(this IServiceCollection services)
    {
        return new AuditsServiceBuilder(services);
    }
}