using System.Linq;
using TMS.Database.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.People;

namespace TMS.Database.Commands.People
{
    public class GetPersonCommand : IQueryCommand<IPersonKey, IPerson>
    {
        private readonly IDatabaseContext<PersonEntity> _personContext;
        private readonly IConverter<PersonEntity, IPerson> _personConverter;

        public GetPersonCommand(IDatabaseContext<PersonEntity> personContext, IConverter<PersonEntity, IPerson> personConverter)
        {
            _personContext = personContext;
            _personConverter = personConverter;
        }

        public Maybe<IPerson> ExecuteCommand(IPersonKey data)
        {
            var matchingEntity = _personContext.Entities.FirstOrDefault(item => item.Id == data.Identifier);

            return _personConverter.Convert(matchingEntity);
        }
    }
}
