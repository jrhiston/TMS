using IdentityServer4.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.Web.IdentityServer
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "tmsclient_oauth",
                    ClientName = "JavaScript OAuth 2.0 Client",
                    ClientUri = "http://identityserver.io",

                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://www.tms.local/TMS"
                    },

                    AllowedScopes = new List<string>
                    {
                        "tmsapi"
                    }
                }
            };
        }
    }
}
