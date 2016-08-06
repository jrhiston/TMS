using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TMS.ApplicationLayer.Activities.Data;
using TMS.Database.Entities.People;
using TMS.Layer.Creators;
using TMS.Layer.Initialisers;
using TMS.Layer.Persistence;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Activities.Pages;
using TMS.Web.Logging;

namespace TMS.Web.Controllers
{
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly ICreator<Tuple<ActivityPageModelBase, PersonKey>> _activityCreator;
        private readonly IWriter<Activity, ActivityKey> _activityWriter;
        private readonly IInitialiser<CreateActivityPageModelInitialiserData, CreateActivityPageModel> _createInitialiser;
        private readonly IInitialiser<DeleteActivityPageModelInitialiserData, DeleteActivityPageModel> _deleteInitialiser;
        private readonly IInitialiser<EditActivityPageModelInitialiserData, EditActivityPageModel> _editInitialiser;
        private readonly ILogger<ActivitiesController> _logger;

        public ActivitiesController(UserManager<PersonEntity> userManager, 
            IInitialiser<CreateActivityPageModelInitialiserData, CreateActivityPageModel> createInitialiser,
            IInitialiser<DeleteActivityPageModelInitialiserData, DeleteActivityPageModel> deleteInitialiser,
            IInitialiser<EditActivityPageModelInitialiserData, EditActivityPageModel> editInitialiser,
            ICreator<Tuple<ActivityPageModelBase, PersonKey>> activityCreator,
            ILogger<ActivitiesController> logger,
            IWriter<Activity,ActivityKey> activityWriter) : base(userManager)
        {
            _activityCreator = activityCreator;
            _createInitialiser = createInitialiser;
            _deleteInitialiser = deleteInitialiser;
            _logger = logger;
            _activityWriter = activityWriter;
            _editInitialiser = editInitialiser;
        }

        public ActionResult Create(long areaId)
        {
            var model = _createInitialiser.Initialise(new CreateActivityPageModelInitialiserData
            {
                AreaId = areaId
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateActivityPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                model.Created = DateTime.UtcNow;

                _activityCreator.Create(new Tuple<ActivityPageModelBase, PersonKey>(model, personKey));

                return RedirectToAction("Details", "Areas", new { id = model.AreaId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var personKey = await GetPersonKey();

                var model = _deleteInitialiser.Initialise(new DeleteActivityPageModelInitialiserData
                {
                    ActivityId = id,
                    PersonId = personKey.Identifier,
                });

                return View(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(LoggingEvents.DELETE_ITEM, exception, $"Failed to load page for deleting activity {id}.");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteActivityPageModel model)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleting activity {model.Id}");

                _activityWriter.Delete(new ActivityKey(model.Id));

                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleted activity {model.Id}");

                return RedirectToAction("Details", "Areas", new { id = model.AreaId });
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.DELETE_ITEM, ex, $"Failed to delete activity {model.Id}.");
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _editInitialiser.Initialise(new EditActivityPageModelInitialiserData
            {
                ActivityId = id
            });

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditActivityPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                _logger.LogInformation(LoggingEvents.UPDATE_ITEM, $"Saving activity {model.Id}: {model.Name}");

                _activityCreator.Create(new Tuple<ActivityPageModelBase, PersonKey>(model, personKey));

                _logger.LogInformation(LoggingEvents.UPDATE_ITEM, $"Saved activity {model.Id}: {model.Name}");

                return RedirectToAction("Details", "Areas", new { id = model.AreaId });
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.UPDATE_ITEM, ex, $"Failed to save changes to activity {model.Id}.");
                return View();
            }
        }
    }
}
