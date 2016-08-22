using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TMS.Data.Entities.People;
using TMS.ModelLayer.People;

namespace TMS.Web.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly UserManager<PersonEntity> _userManager;

        public ControllerBase(UserManager<PersonEntity> userManager)
        {
            _userManager = userManager;
        }
        
        protected Task<PersonEntity> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        protected async Task<PersonKey> GetPersonKey()
        {
            var personEntity = await GetCurrentUserAsync();

            return new PersonKey(personEntity.Id);
        }
    }
}
