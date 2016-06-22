using System.Linq;
using TMS.Database.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.Database.Commands.People
{
    public class GetPersonCommand : IQueryCommand<IPersonKey, IPersistablePerson>
    {
        private readonly IDatabaseContext<PersonEntity> _personContext;
        private readonly IConverter<PersonEntity, IPersistablePerson> _personConverter;

        public GetPersonCommand(IDatabaseContext<PersonEntity> personContext, IConverter<PersonEntity, IPersistablePerson> personConverter)
        {
            _personContext = personContext;
            _personConverter = personConverter;
        }

        public Maybe<IPersistablePerson> ExecuteCommand(IPersonKey data)
        {
            var matchingEntity = _personContext.Entities.FirstOrDefault(item => item.Id == data.Identifier);

            return _personConverter.Convert(matchingEntity);
        }
    }
}
