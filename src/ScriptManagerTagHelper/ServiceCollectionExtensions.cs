using ScriptManagerTagHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSegmentManager(this IServiceCollection services)
        {
            services.AddScoped(typeof(SegmentCollector));
            return services;
        }
    }
}
