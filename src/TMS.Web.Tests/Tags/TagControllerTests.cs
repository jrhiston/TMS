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
using TMS.Database.Entities.People;
using TMS.Layer.Creators;
using TMS.Layer.Initialisers;
using TMS.ModelLayer.People;
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
        public void CreateForActivity_ReturnsModel_GivenActivityId(long activityId)
        {
            var mockInitialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();
            var data = new CreateTagForActivityPageModelInitialiserData { ActivityId = activityId };

            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(new CreateTagForActivityPageModel { ActivityId = activityId });

            var controller = new TagController(userManager, mockInitialiser.Object, mockCreator.Object);

            var result = controller.CreateForActivity(activityId);

            var actionResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<CreateTagForActivityPageModel>(actionResult.Model);

            Assert.Equal(activityId, model.ActivityId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void CreateForActivity_InitialiserCalled_GivenActivityId(long activityId)
        {
            var expectedPageModel = new CreateTagForActivityPageModel();

            var mockInitialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();

            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(expectedPageModel);

            var controller = new TagController(userManager, mockInitialiser.Object, mockCreator.Object);

            var result = controller.CreateForActivity(activityId);

            var actionResult = Assert.IsType<ViewResult>(result);

            mockInitialiser
                .Verify(i => i.Initialise(It.Is<CreateTagForActivityPageModelInitialiserData>(v => v.ActivityId == activityId)), Times.Once);

            Assert.Same(expectedPageModel, actionResult.Model);
        }

        [Fact]
        public void CreateForActivity_ReturnsActivityId_GivenActivityId()
        {
            long activityId = 1;
            var mockInitialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();
            var expectedPageModel = new CreateTagForActivityPageModel
            {
                ActivityId = activityId
            };
            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(expectedPageModel);
            var controller = new TagController(userManager, mockInitialiser.Object, mockCreator.Object);

            // Act
            var result = controller.CreateForActivity(activityId);

            var actionResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<CreateTagForActivityPageModel>(actionResult.Model);

            Assert.Equal(activityId, model.ActivityId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task CreateForActivityPost_RedirectsToActivity_GivenModelData(long activityId)
        {
            var initialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();

            var controller = new TagController(userManager, initialiser.Object, mockCreator.Object);

            var pageModel = new CreateTagForActivityPageModel {
                ActivityId = activityId
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

            var pageModel = new CreateTagForActivityPageModel();

            var controller = new TagController(userManager, initialiser.Object, mockCreator.Object);

            controller.ControllerContext.HttpContext = Mock.Of<HttpContext>(c => c.User == new ClaimsPrincipal(new[]
            {
                new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "1") })
            }));

            var result = controller.CreateForActivity(pageModel);

            mockCreator.Verify(c => c.Create(It.Is<Tuple<CreateTagForActivityPageModel, PersonKey>>(m => ReferenceEquals(m.Item1, pageModel))), Times.Once);
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

        private static Mock<ICreator<Tuple<CreateTagForActivityPageModel, PersonKey>>> GetMockCreator()
        {
            return new Mock<ICreator<Tuple<CreateTagForActivityPageModel, PersonKey>>>();
        }
    }
}
