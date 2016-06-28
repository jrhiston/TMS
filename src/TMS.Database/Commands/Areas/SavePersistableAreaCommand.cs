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
        private readonly IConverter<IPersistableArea, AreaEntity> _persistableAreaToEntityConverter;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public SavePersistableAreaCommand(IDatabaseContextFactory<AreaEntity> contextFactory, 
            IConverter<IPersistableArea, AreaEntity> persistableAreaToEntityConverter,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _contextFactory = contextFactory;
            _persistableAreaToEntityConverter = persistableAreaToEntityConverter;
            _areaKeyFactory = areaKeyFactory;
        }

        public Maybe<IAreaKey> ExecuteCommand(IPersistableArea data)
        {
            var newEntity = _persistableAreaToEntityConverter
                .Convert(data).FirstOrDefault();

            if (newEntity != null)
            {
                using (var context = _contextFactory.Create())
                {
                    var matchingEntity = context.Entities.FirstOrDefault(item => item.Id == newEntity.Id);

                    if (matchingEntity != null)
                    {
                        matchingEntity.Accept(newEntity);
                    }
                    else
                    {
                        newEntity = context.Entities.Add(newEntity).Entity;
                    }

                    context.SaveChanges();

                    return new Maybe<IAreaKey>(_areaKeyFactory.Create(new AreaKeyData
                    {
                        Identifier = newEntity.Id
                    }));
                }
            }

            return new Maybe<IAreaKey>();
        }
    }
}
