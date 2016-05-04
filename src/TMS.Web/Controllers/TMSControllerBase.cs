using System.Security.Claims;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using System.Web.Http;
using System.Linq;
using TMS.Layer.Factories;
using TMS.Layer.Readers;

namespace TMS.Web.Controllers
{
    public abstract class TMSControllerBase : ApiController
    {
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;
        private readonly IReader<IPersonKey, IPerson> _personReader;

        protected TMSControllerBase(IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IReader<IPersonKey, IPerson> personReader)
        {
            _personKeyFactory = personKeyFactory;
            _personReader = personReader;
        }

        protected IPersonKey GetPersonKey()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    long id = 0;

                    if (long.TryParse(userIdValue, out id))
                        return _personKeyFactory.Create(new PersonKeyData { Identifier = id });
                }
            }

            return null;
        }

        protected IPerson GetPerson()
        {
            var personKey = GetPersonKey();

            return _personReader.Read(personKey);
        }
    }
}