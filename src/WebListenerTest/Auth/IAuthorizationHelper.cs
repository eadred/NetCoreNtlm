using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebListenerTest.Auth
{
    public interface IAuthorizationHelper
    {
        Task<bool> IsMarketing(ClaimsPrincipal user);

        Task<bool> IsFinance(ClaimsPrincipal user);
    }
}
