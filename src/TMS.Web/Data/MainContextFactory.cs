using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TMS.Database;
using TMS.Database.Entities.Areas;
using TMS.Web.Options;
using TMS.Database.Entities.Activities;
using TMS.Layer.Factories;
using TMS.Database.Entities.People;
using TMS.Database.Entities.Tags;

namespace TMS.Web.Data
{
    public class MainContextFactory : IDatabaseContextFactory<AreaEntity>,
        IDatabaseContextFactory<ActivityEntity>,
        IDatabaseContextFactory<PersonEntity>,
        IDatabaseContextFactory<TagEntity>
    {
        private readonly IOptions<ApplicationConfigurations> _configurationOptions;

        public MainContextFactory(IOptions<ApplicationConfigurations> configurationOptions)
        {
            _configurationOptions = configurationOptions;
        }

        public IDatabaseContext<AreaEntity> Create() => CreateMainContext();

        IDatabaseContext<PersonEntity> IQueryFactory<IDatabaseContext<PersonEntity>>.Create() => CreateMainContext();
        IDatabaseContext<TagEntity> IQueryFactory<IDatabaseContext<TagEntity>>.Create() => CreateMainContext();
        IDatabaseContext<ActivityEntity> IQueryFactory<IDatabaseContext<ActivityEntity>>.Create() => CreateMainContext();

        private MainContext CreateMainContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();

            optionsBuilder.UseSqlServer(_configurationOptions.Value.ConnectionStrings.TMSConnectionString);

            return new MainContext(optionsBuilder.Options);
        }
    }
}
