using Microsoft.Extensions.DependencyInjection;
using WeDo.Audits.Extensions.Models;

namespace WeDo.Audits.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static AuditsServiceBuilder UseAuditing(this IServiceCollection services)
    {
        return new AuditsServiceBuilder(services);
    }
}