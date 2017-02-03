using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebListenerTest.Auth
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string RoleAlias { get; private set; }

        public RoleRequirement(string roleAlias)
        {
            RoleAlias = roleAlias;
        }
    }
}
