using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebListenerTest.Auth
{
    public class RoleAuthHandler : AuthorizationHandler<RoleRequirement>
    {
        private IConfiguration configuration;

        public RoleAuthHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var roleName = configuration.GetSection("Roles").GetValue<string>(requirement.RoleAlias);

            if (context.User.Identity.IsAuthenticated && context.User.IsInRole(roleName))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
