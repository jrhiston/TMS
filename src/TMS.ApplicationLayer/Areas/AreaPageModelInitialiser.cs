using System;
using System.Collections.Generic;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer;
using TMS.Layer.Exceptions;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaPageModelInitialiser : IInitialiser<AreaPageModelInitialiserData, AreaPageModel>
    {
        private readonly IListReader<PersonKey, Area> _reader;

        public AreaPageModelInitialiser(IListReader<PersonKey, Area> reader)
        {
            _reader = reader;
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
                Areas = areas.SelectMany(item => item)
                    .Select(area => area.Accept(new AreaListItemViewModel()))
                    .OfType<AreaListItemViewModel>()
                    .ToList()
            };

            return areaPageModel;
        }

        private Maybe<IEnumerable<Area>> GetAreas(AreaPageModelInitialiserData data) => _reader.Read(data.CurrentUserKey);
    }
}
