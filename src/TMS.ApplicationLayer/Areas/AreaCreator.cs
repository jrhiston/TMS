using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaCreator : ICreator<Tuple<AreaPageModelBase, PersonKey>>
    {
        private readonly IWriter<Area, AreaKey> _areaWriter;
        private readonly IReader<AreaKey, Area> _reader;

        public AreaCreator(IReader<AreaKey, Area> reader,
            IWriter<Area, AreaKey> areaWriter)
        {
            _reader = reader;
            _areaWriter = areaWriter;
        }

        public void Create(Tuple<AreaPageModelBase, PersonKey> input)
        {
            var model = input.Item1;
            var personKey = input.Item2;

            var list = new List<IAreaElement>
            {
                new Name(model.Name),
                new Description(model.Description),
                personKey
            };

            if (model.AreaId > 0)
            {
                var existingArea = _reader.Read(new AreaKey(model.AreaId)).Single();
                list.AddRange(existingArea.OfType<Activity>());
                list.Add(new AreaKey(model.AreaId));
            }
            else
            {
                list.Add(new CreationDate(model.Created));
            }

            _areaWriter.Save(new Area(list.ToArray()));
        }
    }
}
