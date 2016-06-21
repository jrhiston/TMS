using System.Linq;
using TMS.Database.Converters;
using TMS.Layer;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.Layer.Visitors;

namespace TMS.Database.Commands
{
    //public class SaveCommand<TData, TReturnKey> : ISaveCommand where TData : IData
    //{
    //    private readonly IDatabaseContext<TEntity> _databaseContext;

    //    public SaveCommand(IDatabaseContext<TEntity> databaseContext)
    //    {
    //        _databaseContext = databaseContext;
    //    }

    //    public Maybe<TReturnKey> ExecuteCommand(IVisited<IVisitor<TData>, TData> data)
    //    {
    //        var visitor = new Visitor<TData>();

    //        data.Accept(() => visitor);

    //        var entityConverter = new Converter<Visitor<TData>, TData, TEntity>();

    //        var entityToSave = entityConverter.Convert(visitor);

    //        if (entityToSave.Any())
    //        {
    //            _databaseContext.Entities.Add(entityToSave.FirstOrDefault());
    //            _databaseContext.SaveChanges();
    //        }

    //        return new Maybe<TReturnKey>();
    //    }
    //}
}
