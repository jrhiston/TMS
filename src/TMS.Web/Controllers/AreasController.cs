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

        public AreasController(
            UserManager<PersonEntity> userManager,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IInitialiser<AreaPageModelInitialiserData, AreaPageModel> areaPageModelInitialiser,
            IWriter<IPersistableArea, IAreaKey> areaWriter) : base(userManager, personKeyFactory)
        {
            _userManager = userManager;
            _personKeyFactory = personKeyFactory;
            _areaPageModelInitialiser = areaPageModelInitialiser;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _areaWriter = areaWriter;
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
        public ActionResult Create(CreateAreaPageModel model)
        {
            try
            {
                var area = _areaFactory.Create(new AreaData
                {
                    Name = model.Name,
                    Description = model.Description,
                    Created = DateTime.UtcNow
                });

                var persistableArea = _persistableAreaFactory.Create(new PersistableAreaData
                {

                }, area);

                _areaWriter.Save(persistableArea);

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
            return View();
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Areas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}