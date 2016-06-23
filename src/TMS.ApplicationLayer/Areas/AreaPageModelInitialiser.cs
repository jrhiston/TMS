using System;
using System.Collections.Generic;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer;
using TMS.Layer.Exceptions;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ViewModelLayer.Models.Areas;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaPageModelInitialiser : IInitialiser<AreaPageModelInitialiserData, AreaPageModel>
    {
        private readonly IListReader<IPersonKey, IPersistableArea> _personAreaReader;

        public AreaPageModelInitialiser(IListReader<IPersonKey, IPersistableArea> personAreaReader)
        {
            _personAreaReader = personAreaReader;
        }

        public AreaPageModel Initialise(AreaPageModelInitialiserData data)
        {
            if (data == null)
                throw new MustProvideInitialiserDataException("Must provide data to initialise the model with.");

            if (data.CurrentUserKey == null)
                throw new MustProvideInitialiserDataException("Must provide a current user to initialise the area page model.");

            var areas = GetAreas(data);

            if (areas == null)
                throw new InvalidOperationException("Failed to retrieve a list of areas for the given user");

            var areaPageModel = new AreaPageModel
            {
                Areas = areas.SelectMany(item => item).Select(area => new AreaListItemViewModel(area)).ToList()
            };

            return areaPageModel;
        }

        private Maybe<IEnumerable<IPersistableArea>> GetAreas(AreaPageModelInitialiserData data) => _personAreaReader.Read(data.CurrentUserKey);
    }
}
