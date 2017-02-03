using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebListenerTest.Auth
{
    public static class Policies
    {
        public const string MarketingOnly = "MarketingOnly";
        public const string FinanceOnly = "FinanceOnly";
    }

    public static class PoliciesExtensions
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.MarketingOnly, policy => policy.AddRequirements(new RoleRequirement("Marketing")));
                options.AddPolicy(Policies.FinanceOnly, policy => policy.AddRequirements(new RoleRequirement("Finance")));
            });

            services.AddSingleton<IAuthorizationHandler, RoleAuthHandler>();
        }
    }
}
