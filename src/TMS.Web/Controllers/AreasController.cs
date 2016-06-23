using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ApplicationLayer.Areas;
using TMS.ModelLayerInterface.People;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People.Data;
using TMS.Database.Entities.People;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.Areas;
using TMS.Layer.Persistence;
using TMS.ModelLayerInterface.People.Decorators;
using System.Collections.Generic;
using TMS.Layer.Readers;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;

namespace TMS.Web.Controllers
{
    [Authorize]
    public class AreasController : ControllerBase
    {
        private readonly IInitialiser<AreaPageModelInitialiserData, AreaPageModel> _areaPageModelInitialiser;
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;
        private readonly UserManager<PersonEntity> _userManager;
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;
        private readonly IWriter<IPersistableArea, IAreaKey> _areaWriter;
        private readonly IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> _areaWithPeopleFactory;
        private readonly IReader<IPersonKey, IPersistablePerson> _personReader;
        private readonly IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel> _deleteAreaPageModelInitialiser;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel> _areaEditPageModelInitialiser;

        public AreasController(
            UserManager<PersonEntity> userManager,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IInitialiser<AreaPageModelInitialiserData, AreaPageModel> areaPageModelInitialiser,
            IWriter<IPersistableArea, IAreaKey> areaWriter,
            IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> areaWithPeopleFactory,
            IReader<IPersonKey, IPersistablePerson> personReader,
            IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel> deleteAreaPageModelInitialiser,
            IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel> areaEditPageModelInitialiser,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory) : base(userManager, personKeyFactory)
        {
            _userManager = userManager;
            _personKeyFactory = personKeyFactory;
            _areaPageModelInitialiser = areaPageModelInitialiser;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _areaWriter = areaWriter;
            _areaWithPeopleFactory = areaWithPeopleFactory;
            _personReader = personReader;
            _deleteAreaPageModelInitialiser = deleteAreaPageModelInitialiser;
            _areaKeyFactory = areaKeyFactory;
            _areaEditPageModelInitialiser = areaEditPageModelInitialiser;
        }

        // GET: Areas
        public async Task<ActionResult> Index()
        {
            IPersonKey personKey = await GetPersonKey();

            var model = _areaPageModelInitialiser.Initialise(new AreaPageModelInitialiserData
            {
                CurrentUserKey = personKey
            });

            return View(model);
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAreaPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                var person = _personReader.Read(personKey);

                var area = _areaFactory.Create(new AreaData
                {
                    Name = model.Name,
                    Description = model.Description,
                    Created = DateTime.UtcNow
                });

                var persistableArea = _persistableAreaFactory.Create(new PersistableAreaData(), area);

                var areaWithPeople = _areaWithPeopleFactory.Create(new AreaWithPeopleData
                {
                    People = new List<IPersistablePerson> { person.FirstOrDefault() }
                }, persistableArea);

                _areaWriter.Save(areaWithPeople);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(int id)
        {
            var pageModel = _areaEditPageModelInitialiser.Initialise(new AreaEditPageModelInitialiserData
            {
                AreaId = id
            });

            return View(pageModel);
        }

        // POST: Areas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Areas/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var personKey = await GetPersonKey();

            var model = _deleteAreaPageModelInitialiser.Initialise(new DeleteAreaPageModelInitialiserData
            {
                AreaId = id,
                PersonId = personKey.Identifier
            });

            return View(model);
        }

        // POST: Areas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteAreaPageModel model)
        {
            try
            {
                var areaKey = _areaKeyFactory.Create(new AreaKeyData
                {
                    Identifier = model.Id
                });

                _areaWriter.Delete(areaKey);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}