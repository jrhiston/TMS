using TMS.Layer.Factories;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Activities.Decorators;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.Areas.Decorators;
using TMS.ModelLayer.People;
using TMS.ModelLayer.People.Decorators;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.Decorators;
using TMS.ModelLayer.UserGroups;
using TMS.ModelLayer.UserGroups.Decorators;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;
using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Data;
using TMS.ModelLayerInterface.UserGroups.Decorators;

namespace TMS.ModelLayer
{
    public static class FactoryRegistrarExtensions
    {
        public static void InitialiseModelLayer(this IFactoryRegistrar fc)
        {
            RegisterActivities(fc);
            RegisterAreas(fc);
            RegisterPeople(fc);
            RegisterTags(fc);
            RegisterUserGroups(fc);
        }

        private static void RegisterUserGroups(IFactoryRegistrar fc)
        {
            fc.Register<AuthoredUserGroupData, IUserGroup>((d, ug) => new AuthoredUserGroup(ug, d));
            fc.Register<UserGroupData>(d => new UserGroup(d));
            fc.Register<PersistableUserGroupData, IAuthoredUserGroup>((d, ug) => new PersistableUserGroup(ug, d));
        }

        private static void RegisterTags(IFactoryRegistrar fc)
        {
            fc.Register<TagData>(d => new Tag(d));
            fc.Register<DeletedTagData, ITag>((d, t) => new DeletedTag(t, d));
            fc.Register<OwnedTagData, IOwnedTag>((d, t) => new OwnedTag(t, d.Owner));
            fc.Register<PersistableTagData, IOwnedTag>((d, t) => new PersistableTag(t, d));
            fc.Register<ReusableTagData, ITag>((d, t) => new ReusableTag(t, d.Reusable));
            fc.Register<TaggableTagData, IPersistableTag>((d, t) => new TaggableTag(t, d));
        }

        private static void RegisterPeople(IFactoryRegistrar fc)
        {
            fc.Register<PersonData>(d => new Person(d));
            fc.Register<PersistablePersonData, IPerson>((d, p) => new PersistablePerson(p, d));
            fc.Register<PersonKeyData>(d => new PersonKey { Identifier = d.Identifier });
        }

        private static void RegisterAreas(IFactoryRegistrar fc)
        {
            fc.Register<AreaData>(d => new Area(d));
            fc.Register<AreaKeyData>(d => new AreaKey { Identifier = d.Identifier });
            fc.Register<AreaWithPeopleData, IPersistableArea>((d, a) => new AreaWithPeople(a, d));
            fc.Register<PersistableAreaData, IArea>((d, a) => new PersistableArea(a, d));
            fc.Register<PersistableActivitiesAreaData, IPersistableArea>((d, a) => new PersistableActivitiesArea(a, d.Activities));
        }

        private static void RegisterActivities(IFactoryRegistrar fc)
        {
            fc.Register<ActivityData>(d => new Activity(d.Title, d.Description, d.Created));
            fc.Register<ActivityKeyData>(d => new ActivityKey { Identifier = d.Identifier });
            fc.Register<ActivityAreaData, IActivity>((d, a) => new ActivityArea(a, d));
            fc.Register<TaggableActivityData, IPersistableActivity>((d, a) => new TaggableActivity(a, d));
            fc.Register<OwnedActivityData, IActivity>((d, a) => new OwnedActivity(a, d));
            fc.Register<PersistableActivityData, IOwnedActivity>((d, a) => new PersistableActivity(a, d));
        }
    }
}
