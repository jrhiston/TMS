using TMS.Database.Commands.People;
using TMS.Database.Entities.People;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.Database.Factories.People
{
    public class GetPersonCommandFactory : IQueryFactory<IQueryCommand<IPersonKey, IPersistablePerson>>
    {
        private readonly IDatabaseContextFactory<PersonEntity> _contextFactory;
        private readonly IConverter<PersonEntity, IPersistablePerson> _personConverter;

        public GetPersonCommandFactory(IDatabaseContextFactory<PersonEntity> contextFactory, IConverter<PersonEntity, IPersistablePerson> personConverter)
        {
            _contextFactory = contextFactory;
            _personConverter = personConverter;
        }

        public IQueryCommand<IPersonKey, IPersistablePerson> Create() => new GetPersonCommand(_contextFactory, _personConverter);
    }
}
