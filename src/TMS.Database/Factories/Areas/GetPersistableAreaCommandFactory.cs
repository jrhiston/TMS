﻿using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Factories.Areas
{
    public class GetPersistableAreaCommandFactory : IQueryFactory<IQueryCommand<IAreaKey, IPersistableArea>>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public GetPersistableAreaCommandFactory(IDatabaseContext<AreaEntity> areasContext, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _areasContext = areasContext;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public IQueryCommand<IAreaKey, IPersistableArea> Create()
        {
            return new GetPersistableAreaCommand(_areasContext, _areaEntityToPersistableAreaConverter);
        }
    }
}