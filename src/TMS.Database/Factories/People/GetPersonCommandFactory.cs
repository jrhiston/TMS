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
        private readonly IDatabaseContext<PersonEntity> _personContext;
        private readonly IConverter<PersonEntity, IPersistablePerson> _personConverter;

        public GetPersonCommandFactory(IDatabaseContext<PersonEntity> personContext, IConverter<PersonEntity, IPersistablePerson> personConverter)
        {
            _personContext = personContext;
            _personConverter = personConverter;
        }

        public IQueryCommand<IPersonKey, IPersistablePerson> Create() => new GetPersonCommand(_personContext, _personConverter);
    }
}
