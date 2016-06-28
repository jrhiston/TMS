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
        private readonly IDatabaseContextFactory<PersonEntity> _contextFactory;
        private readonly IConverter<PersonEntity, IPersistablePerson> _personConverter;

        public GetPersonCommand(IDatabaseContextFactory<PersonEntity> contextFactory, IConverter<PersonEntity, IPersistablePerson> personConverter)
        {
            _contextFactory = contextFactory;
            _personConverter = personConverter;
        }

        public Maybe<IPersistablePerson> ExecuteCommand(IPersonKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var matchingEntity = context.Entities.FirstOrDefault(item => item.Id == data.Identifier);

                return _personConverter.Convert(matchingEntity);
            }
        }
    }
}
