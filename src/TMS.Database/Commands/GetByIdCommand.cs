using System.Linq;
using TMS.Database.Entities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.ModelObjects;
using TMS.Layer.Repositories;

namespace TMS.Database.Commands
{
    //public class GetByIdCommand<TEntity, TModelObject> : IQueryCommand<IModelKey, TModelObject>
    //    where TEntity : class, IEntityWithId
    //{
    //    private readonly IConverter<TEntity, TModelObject> _entityConverter;
    //    private readonly MainContext _mainContext;

    //    public GetByIdCommand(MainContext mainContext,
    //        IConverter<TEntity, TModelObject> entityConverter)
    //    {
    //        _mainContext = mainContext;
    //        _entityConverter = entityConverter;
    //    }

    //    public Maybe<TModelObject> ExecuteCommand(IModelKey data)
    //    {
    //        var matchingEntity = _mainContext
    //            .Set<TEntity>()
    //            .Single(item => item.Id == data.Identifier);

    //        return _entityConverter.Convert(matchingEntity);
    //    }
    //}
}
