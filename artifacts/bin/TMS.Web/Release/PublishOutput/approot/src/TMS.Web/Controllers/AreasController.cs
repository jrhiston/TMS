using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using System.Threading.Tasks;
using System.Linq;
using TMS.Web.Models.Areas;
using System;
using TMS.Layer.Factories;
using TMS.Layer.Conversion;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.Layer;
using Microsoft.AspNet.Authorization;

namespace TMS.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AreasController : TMSControllerBase
    {
        private readonly IReader<IPersonKey, IEnumerable<IPersistableArea>> _areaListReader;
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IConverter<AreaViewModel, IPersistableArea> _areaViewModelToPersistableAreaConverter;
        private readonly IReader<IAreaKey, IPersistableArea> _areaReader;

        public AreasController(IReader<IPersonKey, IEnumerable<IPersistableArea>> areaListReader,
            IReader<IAreaKey, IPersistableArea> areaReader,
            IFactory<AreaData, IArea> areaFactory,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IReader<IPersonKey, IPerson> personReader,
            IConverter<AreaViewModel, IPersistableArea> areaViewModelToPersistableAreaConverter) : base(personKeyFactory, personReader)
        {
            _areaListReader = areaListReader;
            _areaReader = areaReader;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _areaKeyFactory = areaKeyFactory;
            _areaViewModelToPersistableAreaConverter = areaViewModelToPersistableAreaConverter;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<IEnumerable<AreaViewModel>> Get()
        {
            var personKey = GetPersonKey();

            return await Task.Run(() => _areaListReader
                .Read(GetPersonKey())
                .SelectMany(item => item.Select(area => new AreaViewModel(area))));
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var existingArea = GetAreaFromId(id);

                return Ok(existingArea.Select(item => new AreaViewModel(item)));
            });
        }

        // POST: api/Areas
        [HttpPost]
        public AreaViewModel Post([FromBody]AreaViewModel value)
        {
            var conversionResult = _areaViewModelToPersistableAreaConverter.Convert(value);

            var persistableArea = conversionResult.FirstOrDefault();

            //persistableArea?.Save();

            return persistableArea != null ? new AreaViewModel(persistableArea) : null;
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = GetAreaFromId(id);

                var existingArea = result?.FirstOrDefault();
                if (existingArea != null)
                {
                    //existingArea.Delete();
                    return base.Ok();
                }

                return base.InternalServerError(new Exception("Given area does not exist."));
            });
        }

        private Maybe<IPersistableArea> GetAreaFromId(long id)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData { Identifier = id });

            var result = _areaReader.Read(areaKey);

            return result;
        }
    }
}
