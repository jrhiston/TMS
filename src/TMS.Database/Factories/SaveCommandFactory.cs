using System;
using System.Collections.Generic;
using TMS.Database.Commands;
using TMS.Database.Entities.Areas;
using TMS.Layer.Data;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.Database.Factories
{
    //public class SaveCommandFactory<TData, TReturnKey> : IQueryFactory<ISaveCommand>
    //    where TData : IData
    //{
    //    private readonly IDatabaseContextFactory<TEntity> _databaseContext;

    //    private static readonly Dictionary<Type, Type> s_EntityMappings = new Dictionary<Type, Type>
    //    {
    //        {
    //            typeof(AreaData),
    //            typeof(AreaEntity)
    //        }
    //    };

    //    public SaveCommandFactory(IDatabaseContextFactory<TEntity> databaseContext)
    //    {
    //        _databaseContext = databaseContext;
    //    }
        
    //    public ISaveCommand Create()
    //    {
    //        return new SaveCommand<TData, TReturnKey>(_databaseContext);
    //    }
    //}
}
