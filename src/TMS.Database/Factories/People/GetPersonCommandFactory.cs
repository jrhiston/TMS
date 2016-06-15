using TMS.Database.Commands.People;
using TMS.Database.Entities.People;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.People;

namespace TMS.Database.Factories.People
{
    public class GetPersonCommandFactory : IQueryFactory<IQueryCommand<IPersonKey, IPerson>>
    {
        private readonly IDatabaseContext<PersonEntity> _personContext;
        private readonly IConverter<PersonEntity, IPerson> _personConverter;

        public GetPersonCommandFactory(IDatabaseContext<PersonEntity> personContext, IConverter<PersonEntity, IPerson> personConverter)
        {
            _personContext = personContext;
            _personConverter = personConverter;
        }

        public IQueryCommand<IPersonKey, IPerson> Create() => new GetPersonCommand(_personContext, _personConverter);
    }
}
