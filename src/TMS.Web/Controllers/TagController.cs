using Microsoft.AspNetCore.Mvc;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags.Pages;
using System;
using TMS.Layer.Creators;
using TMS.ModelLayerInterface.People;
using Microsoft.AspNetCore.Identity;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People.Data;
using TMS.Database.Entities.People;
using System.Threading.Tasks;

namespace TMS.Web.Controllers
{
    public class TagController : ControllerBase
    {
        private IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> _createInitialiser;
        private readonly ICreator<Tuple<CreateTagForActivityPageModel, IPersonKey>> _tagCreator;

        public TagController(UserManager<PersonEntity> userManager, 
            IFactory<PersonKeyData, IPersonKey> personKeyFactory, 
            IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> createInitialiser,
            ICreator<Tuple<CreateTagForActivityPageModel,
            IPersonKey>> tagCreator) : base(userManager, personKeyFactory)
        {
            _createInitialiser = createInitialiser;
            _tagCreator = tagCreator;
        }

        public ViewResult CreateForActivity(long id)
        {
            var model = _createInitialiser.Initialise(new CreateTagForActivityPageModelInitialiserData
            {
                ActivityId = id
            });

            return View(model);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> CreateForActivity(CreateTagForActivityPageModel model)
        {
            var personKey = await GetPersonKey();

            _tagCreator.Create(new Tuple<CreateTagForActivityPageModel, IPersonKey>(model, personKey));

            return RedirectToAction("Edit", "Activities", new { id = model.ActivityId });
        }
    }
}
