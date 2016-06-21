using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TMS.Database.Entities.People;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.Web.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;
        private readonly UserManager<PersonEntity> _userManager;

        public ControllerBase(UserManager<PersonEntity> userManager,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory)
        {
            _userManager = userManager;
            _personKeyFactory = personKeyFactory;
        }
        
        protected Task<PersonEntity> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        protected async Task<IPersonKey> GetPersonKey()
        {
            var personEntity = await GetCurrentUserAsync();

            var personKey = _personKeyFactory.Create(new PersonKeyData
            {
                Identifier = personEntity.Id
            });
            return personKey;
        }
    }
}
