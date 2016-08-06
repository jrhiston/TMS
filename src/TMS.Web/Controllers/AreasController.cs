using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMS.Layer.Initialisers;
using TMS.Database.Entities.People;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TMS.Layer.Persistence;
using TMS.ApplicationLayer.Areas.Data;
using TMS.ViewModelLayer.Models.Areas.Pages;
using TMS.Layer.Creators;
using Microsoft.Extensions.Logging;
using TMS.Web.Logging;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;

namespace TMS.Web.Controllers
{
    [Authorize]
    public class AreasController : ControllerBase
    {
        private readonly IInitialiser<AreaPageModelInitialiserData, AreaPageModel> _areasPageInitialiser;
        private readonly UserManager<PersonEntity> _userManager;

        private readonly IWriter<Area, AreaKey> _areaWriter;

        private readonly IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel> _deletePageInitialiser;
        private readonly IInitialiser<AreaDetailsPageModelInitialiserData, AreaDetailsPageModel> _detailsPageInitialiser;
        private readonly IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel> _editPageInitialiser;
        private readonly ICreator<Tuple<AreaPageModelBase, PersonKey>> _areaCreator;
        private readonly ILogger<AreasController> _logger;

        public AreasController(
            UserManager<PersonEntity> userManager,
            IInitialiser<AreaPageModelInitialiserData, AreaPageModel> areasPageInitialiser,
            IWriter<Area, AreaKey> areaWriter,
            IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel> deletePageInitialiser,
            IInitialiser<AreaDetailsPageModelInitialiserData, AreaDetailsPageModel> detailsPageInitialiser,
            IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel> editPageInitialiser,
            ICreator<Tuple<AreaPageModelBase, PersonKey>> areaCreator,
            ILogger<AreasController> logger) : base(userManager)
        {
            _userManager = userManager;
            _areasPageInitialiser = areasPageInitialiser;
            _areaWriter = areaWriter;
            _deletePageInitialiser = deletePageInitialiser;
            _detailsPageInitialiser = detailsPageInitialiser;
            _editPageInitialiser = editPageInitialiser;
            _areaCreator = areaCreator;
            _logger = logger;
        }

        // GET: Areas
        public async Task<ActionResult> Index()
        {
            var personKey = await GetPersonKey();

            var model = _areasPageInitialiser.Initialise(new AreaPageModelInitialiserData
            {
                CurrentUserKey = personKey
            });

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _editPageInitialiser.Initialise(new AreaEditPageModelInitialiserData
            {
                AreaId = id
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AreaEditPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                _logger.LogInformation(LoggingEvents.UPDATE_ITEM, $"Saving area {model.AreaId}: {model.Name}");

                _areaCreator.Create(new Tuple<AreaPageModelBase, PersonKey>(model, personKey));

                _logger.LogInformation(LoggingEvents.UPDATE_ITEM, $"Saved area {model.AreaId}: {model.Name}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.UPDATE_ITEM, ex, $"Failed to save changes to area {model.AreaId}.");
                return View();
            }
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

                model.Created = DateTime.UtcNow;

                _areaCreator.Create(new Tuple<AreaPageModelBase, PersonKey>(model, personKey));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.INSERT_ITEM, ex, "Failed to create area.");
                return View();
            }
        }

        // GET: Areas/Edit/5
        public ActionResult Details(int id)
        {
            var pageModel = _detailsPageInitialiser.Initialise(new AreaDetailsPageModelInitialiserData
            {
                AreaId = id
            });

            return View(pageModel);
        }

        // GET: Areas/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var personKey = await GetPersonKey();

            var model = _deletePageInitialiser.Initialise(new DeleteAreaPageModelInitialiserData
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
                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleting area {model.Id}");

                _areaWriter.Delete(new AreaKey(model.Id));

                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleted area {model.Id}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.DELETE_ITEM, ex, $"Failed to delete area {model.Id}.");
                return View();
            }
        }
    }
}