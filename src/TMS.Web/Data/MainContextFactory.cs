using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TMS.Web.Options;
using TMS.Layer.Factories;
using TMS.Data.Entities.Tags;
using TMS.Data.Entities.People;
using TMS.Data.Entities.Activities;
using TMS.Data.Entities.Activities.Comments;
using TMS.Layer.Data;
using TMS.Data.Entities.Areas;

namespace TMS.Web.Data
{
    public class MainContextFactory : IDataContextFactory<AreaEntity>,
        IDataContextFactory<ActivityEntity>,
        IDataContextFactory<PersonEntity>,
        IDataContextFactory<TagEntity>,
        IDataContextFactory<ActivityCommentEntity>
    {
        private readonly IOptions<ApplicationConfigurations> _configurationOptions;

        public MainContextFactory(IOptions<ApplicationConfigurations> configurationOptions)
        {
            _configurationOptions = configurationOptions;
        }

        public IDataContext<AreaEntity> Create() => CreateMainContext();

        IDataContext<ActivityCommentEntity> IQueryFactory<IDataContext<ActivityCommentEntity>>.Create() => CreateMainContext();
        IDataContext<PersonEntity> IQueryFactory<IDataContext<PersonEntity>>.Create() => CreateMainContext();
        IDataContext<TagEntity> IQueryFactory<IDataContext<TagEntity>>.Create() => CreateMainContext();
        IDataContext<ActivityEntity> IQueryFactory<IDataContext<ActivityEntity>>.Create() => CreateMainContext();

        private MainContext CreateMainContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();

            optionsBuilder.UseSqlServer(_configurationOptions.Value.ConnectionStrings.TMSConnectionString);

            return new MainContext(optionsBuilder.Options);
        }
    }
}
