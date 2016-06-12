using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.Web.Persons;

namespace TMS.Web.Models.Areas
{
    public class UserAreasViewModel
    {
        public PersonModel PersonModel { get; set; }
        public List<AreaActivitiesViewModel> UserAreas { get; set; }

        public UserAreasViewModel(IPerson person,
            IListReader<IPersonKey, IArea> areaReader,
            IListReader<IAreaKey, IActivity> activityReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory)
        {
            InitialiseViewModel(person, areaReader, activityReader, areaKeyFactory, personKeyFactory);
        }

        private void InitialiseViewModel(IPerson person,
            IListReader<IPersonKey, IArea> areaReader,
            IListReader<IAreaKey, IActivity> activityReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory)
        {
            PersonModel = new PersonModel(person);

            UserAreas = areaReader
                .Read(personKeyFactory.Create(new PersonKeyData { Identifier = PersonModel.Identifier }))
                .SelectMany(item => item.Select(pa => new AreaActivitiesViewModel(pa, activityReader, areaKeyFactory)))
                .ToList();
        }
    }
}