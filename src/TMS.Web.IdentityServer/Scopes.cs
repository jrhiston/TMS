using System;
using System.Collections.Generic;
using IdentityServer4.Core.Models;

namespace TMS.Web.IdentityServer
{
    internal class Scopes
    {
        internal static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.ProfileAlwaysInclude,
                StandardScopes.EmailAlwaysInclude,
                StandardScopes.OfflineAccess,
                StandardScopes.RolesAlwaysInclude,

                new Scope
                {
                    Name = "tmsapi",
                    DisplayName = "TMS API",
                    Description = "TMS API features and data",
                    Type = ScopeType.Resource,

                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                }
            };
        }
    }
}