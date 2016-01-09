﻿using ScriptManagerTagHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScriptManager(this IServiceCollection services)
        {
            services.AddScoped(typeof(ScriptCollector));
            return services;
        }
    }
}
