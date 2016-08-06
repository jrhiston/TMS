using Microsoft.AspNetCore.Mvc;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags.Pages;
using System;
using TMS.Layer.Creators;
using Microsoft.AspNetCore.Identity;
using TMS.Database.Entities.People;
using System.Threading.Tasks;
using TMS.ModelLayer.People;

namespace TMS.Web.Controllers
{
    public class TagController : ControllerBase
    {
        private IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> _createInitialiser;
        private readonly ICreator<Tuple<CreateTagForActivityPageModel, PersonKey>> _tagCreator;

        public TagController(UserManager<PersonEntity> userManager, 
            IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> createInitialiser,
            ICreator<Tuple<CreateTagForActivityPageModel, PersonKey>> tagCreator) : base(userManager)
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

            _tagCreator.Create(new Tuple<CreateTagForActivityPageModel, PersonKey>(model, personKey));

            return RedirectToAction("Edit", "Activities", new { id = model.ActivityId });
        }
    }
}
