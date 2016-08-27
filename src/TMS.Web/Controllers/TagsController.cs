using Microsoft.AspNetCore.Mvc;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags.Pages;
using System;
using TMS.Layer.Creators;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TMS.Web.Logging;
using TMS.ModelLayer.Tags;
using TMS.Layer.Persistence;
using TMS.ViewModelLayer.Models.Tags;
using TMS.Data.Entities.People;

namespace TMS.Web.Controllers
{
    [Authorize]
    public class TagsController : ControllerBase
    {
        private IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> _createInitialiser;
        private readonly ICreator<AddTagToActivityViewModel> _tagForActivityCreator;
        private readonly ICreator<AddTagToTagViewModel> _tagForTagCreator;
        private readonly IInitialiser<TagsPageModelInitialiserData, TagsPageModel> _tagsPageModelInitialiser;
        private readonly IInitialiser<DeleteTagPageModelInitialiserData, DeleteTagPageModel> _deleteTagPadeModelInitialiser;
        private readonly ILogger<TagsController> _logger;
        private readonly IWriter<Tag, TagKey> _tagWriter;
        private readonly ICreator<TagPageModelBase> _tagCreator;
        private readonly IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel> _editTagPageModelInitialiser;

        public TagsController(UserManager<PersonEntity> userManager,
            IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel> createInitialiser,
            IInitialiser<TagsPageModelInitialiserData, TagsPageModel> tagsPageModelInitialiser,
            ICreator<AddTagToActivityViewModel> tagForActivityCreator,
            ICreator<AddTagToTagViewModel> tagForTagCreator,
            IInitialiser<DeleteTagPageModelInitialiserData, DeleteTagPageModel> deleteTagPadeModelInitialiser,
            IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel> editTagPageModelInitialiser,
            IWriter<Tag, TagKey> tagWriter,
            ILogger<TagsController> logger,
            ICreator<TagPageModelBase> tagCreator) : base(userManager)
        {
            _createInitialiser = createInitialiser;
            _tagForActivityCreator = tagForActivityCreator;
            _tagForTagCreator = tagForTagCreator;
            _tagsPageModelInitialiser = tagsPageModelInitialiser;
            _deleteTagPadeModelInitialiser = deleteTagPadeModelInitialiser;
            _editTagPageModelInitialiser = editTagPageModelInitialiser;
            _logger = logger;
            _tagWriter = tagWriter;
            _tagCreator = tagCreator;
        }

        // GET: Tags
        public async Task<ActionResult> Index()
        {
            var personKey = await GetPersonKey();

            var model = _tagsPageModelInitialiser.Initialise(new TagsPageModelInitialiserData
            {
                CurrentUserKey = personKey
            });

            return View(model);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateTagPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                model.AuthorId = personKey.Identifier;
                model.Created = DateTime.UtcNow;

                _tagCreator.Create(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.INSERT_ITEM, ex, "Failed to create tag.");
                return View();
            }
        }

        // GET: Areas/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var personKey = await GetPersonKey();

            var model = _deleteTagPadeModelInitialiser.Initialise(new DeleteTagPageModelInitialiserData
            {
                TagId = id,
                PersonId = personKey.Identifier
            });

            return View(model);
        }

        // POST: Areas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteTagPageModel model)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleting tag {model.Id}");

                _tagWriter.Delete(new TagKey(model.Id));

                _logger.LogInformation(LoggingEvents.DELETE_ITEM, $"Deleted tag {model.Id}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.DELETE_ITEM, ex, $"Failed to delete tag {model.Id}.");
                return View();
            }
        }

        [HttpPost]
        public async Task<RedirectToActionResult> CreateForActivity(AddTagViewModel model)
        {
            var personKey = await GetPersonKey();

            model.PersonKey = personKey;

            _tagForActivityCreator.Create(new AddTagToActivityViewModel
            {
                ActivityId = model.ObjectId,
                TagToAddId = model.TagToAddId
            });

            return RedirectToAction("Edit", "Activities", new { id = model.ObjectId });
        }

        [HttpPost]
        public async Task<RedirectToActionResult> CreateForTag(AddTagViewModel model)
        {
            var personKey = await GetPersonKey();

            model.PersonKey = personKey;

            _tagForTagCreator.Create(new AddTagToTagViewModel
            {
                TagId = model.ObjectId,
                TagToAddId = model.TagToAddId
            });

            return RedirectToAction("Edit", "Tags", new { id = model.ObjectId });
        }

        public ViewResult Edit(long id)
        {
            var model = _editTagPageModelInitialiser.Initialise(new EditTagPageModelInitialiserData
            {
                TagId = id
            });

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditTagPageModel model)
        {
            try
            {
                var personKey = await GetPersonKey();

                _tagCreator.Create(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.UPDATE_ITEM, ex, "Failed to update tag.");
                return View();
            }
        }
    }
}
