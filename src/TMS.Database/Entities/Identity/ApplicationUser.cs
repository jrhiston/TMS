using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenIddict;

namespace TMS.Database.Entities.Identity
{
    public class ApplicationUser : OpenIddictUser
    {
        public string GivenName { get; set; }
    }
}
