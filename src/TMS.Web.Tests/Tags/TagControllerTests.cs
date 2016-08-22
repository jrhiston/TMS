using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Data.Entities.People;
using TMS.Layer.Creators;
using TMS.Layer.Initialisers;
using TMS.Layer.Persistence;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;
using TMS.Web.Controllers;
using Xunit;

namespace TMS.Web.Tests.Tags
{
    public class TagControllerTests
    {
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task CreateForActivityPost_RedirectsToActivity_GivenModelData(long activityId)
        {
            var initialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();

            var controller = new TagsController(userManager, initialiser.Object, Mock.Of<IInitialiser<TagsPageModelInitialiserData, TagsPageModel>>(),
                mockCreator.Object,
                Mock.Of<ICreator<AddTagToTagViewModel>>(),
                Mock.Of<IInitialiser<DeleteTagPageModelInitialiserData, DeleteTagPageModel>>(),
                Mock.Of<IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel>>(),
                Mock.Of<IWriter<Tag, TagKey>>(),
                Mock.Of<ILogger<TagsController>>(),
                Mock.Of<ICreator<TagPageModelBase>>());

            var pageModel = new AddTagViewModel {
                ObjectId = activityId
            };

            controller.ControllerContext.HttpContext = Mock.Of<HttpContext>(c => c.User == new ClaimsPrincipal(new[]
            {
                new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "1") })
            }));

            var result = await controller.CreateForActivity(pageModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Activities", redirectToActionResult.ControllerName);
            Assert.Equal("Edit", redirectToActionResult.ActionName);
            Assert.NotNull(redirectToActionResult.RouteValues);
            Assert.True(redirectToActionResult.RouteValues.ContainsKey("id"));
            var idValue = redirectToActionResult.RouteValues["id"];
            Assert.Equal(activityId, idValue);
        }

        [Fact]
        public void CreateForActivityPost_SavesTag_GivenModelData()
        {
            var initialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();

            var pageModel = new AddTagViewModel();

            var controller = new TagsController(userManager, initialiser.Object, Mock.Of<IInitialiser<TagsPageModelInitialiserData, TagsPageModel>>(), mockCreator.Object,
                Mock.Of<ICreator<AddTagToTagViewModel>>(), Mock.Of<IInitialiser<DeleteTagPageModelInitialiserData, DeleteTagPageModel>>(),
                Mock.Of<IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel>>(),
                Mock.Of<IWriter<Tag, TagKey>>(),
                Mock.Of<ILogger<TagsController>>(),
                Mock.Of<ICreator<TagPageModelBase>>());

            controller.ControllerContext.HttpContext = Mock.Of<HttpContext>(c => c.User == new ClaimsPrincipal(new[]
            {
                new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "1") })
            }));

            var result = controller.CreateForActivity(pageModel);

            mockCreator.Verify(c => c.Create(It.Is<AddTagToActivityViewModel>(m => ReferenceEquals(m, pageModel))), Times.Once);
        }

        private static FakeUserManager GetUserManager()
        {
            return new FakeUserManager();
        }

        public class FakeUserManager : UserManager<PersonEntity>
        {
            public bool FindByIdAsyncCalled { get; set; }

            public FakeUserManager()
                : base(new Mock<IUserStore<PersonEntity>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<PersonEntity>>().Object,
                      new IUserValidator<PersonEntity>[0],
                      new IPasswordValidator<PersonEntity>[0],
                      new Mock<ILookupNormalizer>().Object,
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<PersonEntity>>>().Object)
            { }

            public override Task<IdentityResult> CreateAsync(PersonEntity user, string password)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            public override async Task<PersonEntity> FindByIdAsync(string userId)
            {
                FindByIdAsyncCalled = true;

                return await Task.Run(() => new PersonEntity());
            }
        }

        private static Mock<IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel>> GetCreateTagPageModelInitialiser()
        {
            return new Mock<IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel>>();
        }

        private static Mock<ICreator<AddTagToActivityViewModel>> GetMockCreator()
        {
            return new Mock<ICreator<AddTagToActivityViewModel>>();
        }
    }
}
