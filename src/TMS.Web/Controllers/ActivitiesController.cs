using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TMS.ApplicationLayer.Activities.Data;
using TMS.Database.Entities.People;
using TMS.Layer.Creators;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.Web.Controllers
{
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        private readonly ICreator<Tuple<CreateActivityPageModel, IPersonKey>> _activityCreator;
        private readonly IFactory<ActivityData, IActivity> _activityFactory;
        private readonly IInitialiser<CreateActivityPageModelInitialiserData, CreateActivityPageModel> _createActivityPageInitialiser;
        private readonly IReader<IPersonKey, IPersistablePerson> _personReader;

        public ActivitiesController(UserManager<PersonEntity> userManager, 
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IInitialiser<CreateActivityPageModelInitialiserData, CreateActivityPageModel> createActivityPageInitialiser,
            ICreator<Tuple<CreateActivityPageModel, IPersonKey>> activityCreator) : base(userManager, personKeyFactory)
        {
            _activityCreator = activityCreator;
            _createActivityPageInitialiser = createActivityPageInitialiser;
        }

        public ActionResult Create(long id)
        {
            var model = _createActivityPageInitialiser.Initialise(new CreateActivityPageModelInitialiserData
            {
                AreaId = id
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

                _activityCreator.Create(new Tuple<CreateActivityPageModel, IPersonKey>(model, personKey));

                return RedirectToAction("Details", "Areas", new { id = model.AreaId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
