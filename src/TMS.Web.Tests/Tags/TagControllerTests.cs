using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Database.Entities.People;
using TMS.Layer.Creators;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ViewModelLayer.Models.Activities.Pages;
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
        public void CreateForActivity_ReturnsModel_GivenActivityId(long activityId)
        {
            var mockInitialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();
            var personKeyFactory = GetPersonKeyFactory();
            var data = new CreateTagForActivityPageModelInitialiserData { ActivityId = activityId };

            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(new CreateTagForActivityPageModel { ActivityId = activityId });

            var controller = new TagController(userManager, personKeyFactory.Object, mockInitialiser.Object, mockCreator.Object);

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
            var personKeyFactory = GetPersonKeyFactory();

            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(expectedPageModel);

            var controller = new TagController(userManager, personKeyFactory.Object, mockInitialiser.Object, mockCreator.Object);

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
            var personKeyFactory = GetPersonKeyFactory();
            var expectedPageModel = new CreateTagForActivityPageModel
            {
                ActivityId = activityId
            };
            mockInitialiser
                .Setup(i => i.Initialise(It.IsAny<CreateTagForActivityPageModelInitialiserData>()))
                .Returns(expectedPageModel);
            var controller = new TagController(userManager, personKeyFactory.Object, mockInitialiser.Object, mockCreator.Object);

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
        public void CreateForActivityPost_RedirectsToActivity_GivenModelData(long activityId)
        {
            var initialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();
            var personKeyFactory = GetPersonKeyFactory();

            var controller = new TagController(userManager, personKeyFactory.Object, initialiser.Object, mockCreator.Object);

            var pageModel = new CreateTagForActivityPageModel {
                ActivityId = activityId
            };

            var result = controller.CreateForActivity(pageModel);

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
            var personKeyFactory = GetPersonKeyFactory();

            var pageModel = new CreateTagForActivityPageModel();

            var controller = new TagController(userManager, personKeyFactory.Object, initialiser.Object, mockCreator.Object);

            var result = controller.CreateForActivity(pageModel);

            mockCreator.Verify(c => c.Create(It.Is<Tuple<CreateTagForActivityPageModel, IPersonKey>>(m => ReferenceEquals(m.Item1, pageModel))), Times.Once);
        }

        [Fact]
        public void CreateForActivityPost_SavesAgainstPerson_GivenModelData()
        {
            var initialiser = GetCreateTagPageModelInitialiser();
            var mockCreator = GetMockCreator();
            var userManager = GetUserManager();
            
            var personKeyFactory = GetPersonKeyFactory();

            var mockPersonKey = Mock.Of<IPersonKey>();
            mockPersonKey.Identifier = 1;

            personKeyFactory
                .Setup(f => f.Create(It.IsAny<PersonKeyData>()))
                .Returns(mockPersonKey);

            var pageModel = new CreateTagForActivityPageModel();

            var controller = new TagController(userManager,
                personKeyFactory.Object,
                initialiser.Object,
                mockCreator.Object);

            var result = controller.CreateForActivity(pageModel);

            mockCreator.Verify(c => c.Create(It.Is<Tuple<CreateTagForActivityPageModel, IPersonKey>>(m => ReferenceEquals(m.Item2, mockPersonKey))), Times.Once);
        }

        private static Mock<IFactory<PersonKeyData, IPersonKey>> GetPersonKeyFactory()
        {
            return new Mock<IFactory<PersonKeyData, IPersonKey>>();
        }

        private static UserManager<PersonEntity> GetUserManager()
        {
            var userStore = new Mock<IUserStore<PersonEntity>>();
            return new UserManager<PersonEntity>(userStore.Object,null, null, null, null, null, null, null, null);
        }

        private static Mock<IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel>> GetCreateTagPageModelInitialiser()
        {
            return new Mock<IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel>>();
        }

        private static Mock<ICreator<Tuple<CreateTagForActivityPageModel, IPersonKey>>> GetMockCreator()
        {
            return new Mock<ICreator<Tuple<CreateTagForActivityPageModel, IPersonKey>>>();
        }
    }
}
