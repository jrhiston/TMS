using IdentityServer4.Core.Services.InMemory;
using System.Linq;
using System.Collections.Generic;

namespace TMS.Web.IdentityServer.UI.Login
{
    public class LoginService
    {
        private readonly List<InMemoryUser> _users = new List<InMemoryUser>();

        public LoginService()
        {
        }

        public bool ValidateCredentials(string username, string password)
        {
            return true;
            var user = FindByUsername(username);
            if (user != null)
            {
                return user.Password.Equals(password);
            }
            return false;
        }

        public InMemoryUser FindByUsername(string username)
        {
            return new InMemoryUser();

            return _users.FirstOrDefault(x=>x.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
