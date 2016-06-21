using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Commands.Areas
{
    public class SavePersistableAreaCommand : IQueryCommand<IPersistableArea, IAreaKey>
    {
        private readonly IConverter<IPersistableArea, AreaEntity> _areaEntityToPersistableAreaConverter;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public SavePersistableAreaCommand(IDatabaseContext<AreaEntity> areasContext, 
            IConverter<IPersistableArea, AreaEntity> areaEntityToPersistableAreaConverter,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areasContext = areasContext;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
            _areaKeyFactory = areaKeyFactory;
        }

        public Maybe<IAreaKey> ExecuteCommand(IPersistableArea data)
        {
            var newEntity = _areaEntityToPersistableAreaConverter
                .Convert(data).FirstOrDefault();

            if (newEntity != null)
            {
                var matchingEntity = _areasContext.Entities.FirstOrDefault(item => item.Id == newEntity.Id);

                if (matchingEntity != null)
                {
                    matchingEntity.Accept(newEntity);
                }
                else
                {
                    newEntity = _areasContext.Entities.Add(newEntity).Entity;
                }

                _areasContext.SaveChanges();

                return new Maybe<IAreaKey>(_areaKeyFactory.Create(new AreaKeyData
                {
                    Identifier = newEntity.Id
                }));
            }

            return new Maybe<IAreaKey>();
        }
    }
}
