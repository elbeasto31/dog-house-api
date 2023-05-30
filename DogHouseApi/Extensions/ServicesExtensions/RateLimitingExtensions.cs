using System.Collections.Generic;
using AspNetCoreRateLimit;
using DogHouseApi.Constants;
using DogHouseApi.Models.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogHouseApi.Extensions.ServicesExtensions
{
    public static class RateLimitingExtensions
    {
        public static void AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IpRateLimitOptions>(options =>
            {
                var rateLimitingRule = configuration
                    .GetSection(ConfigSections.RateLimitingRule)
                    .Get<RateLimitingRule>();
                
                options.GeneralRules = new List<RateLimitRule>
                {
                    new()
                    {
                        Endpoint = rateLimitingRule.Endpoint,
                        Limit = rateLimitingRule.Limit,
                        Period = rateLimitingRule.Period
                    }
                };
            });

            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
    }
}