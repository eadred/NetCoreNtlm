using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebListenerTest.Auth
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        private IAuthorizationService authService;

        public AuthorizationHelper(IAuthorizationService authService)
        {
            this.authService = authService;
        }

        public Task<bool> IsFinance(ClaimsPrincipal user)
        {
            return CheckAgainstPolicy(user, Policies.FinanceOnly);
        }

        public Task<bool> IsMarketing(ClaimsPrincipal user)
        {
            return CheckAgainstPolicy(user, Policies.MarketingOnly);
        }

        public Task<bool> CheckAgainstPolicy(ClaimsPrincipal user, string policyName)
        {
            return authService.AuthorizeAsync(user, policyName);
        }
    }
}
