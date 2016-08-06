using Moq;
using System;
using TMS.ApplicationLayer.Exceptions;
using TMS.ApplicationLayer.Tags;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer;
using TMS.Layer.Exceptions;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.ModelLayer;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;
using TMS.ViewModelLayer.Models.Tags.Pages;
using Xunit;

namespace TMS.ApplicationLayer.Tests.Tags
{
    public class EditTagPageModelInitialiserTests
    {
        [Fact]
        public void EditTagPageModelInitialiserReturnsCorrectPageModel()
        {
            var tagReaderMock = CreateTagReader(new Tag());

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 1 });

            Assert.IsType(typeof(EditTagPageModel), pageModel);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void EditTagPageModelInitialiserAssignTagId(long tagId)
        {
            var tagReaderMock = CreateTagReader(new Tag(new TagKey(tagId)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId });

            Assert.Equal(tagId, pageModel.TagId);
        }

        private static Mock<IReader<TagKey, Tag>> CreateTagReader(Tag tag)
        {
            var tagReaderMock = new Mock<IReader<TagKey, Tag>>();

            tagReaderMock
                .Setup(r => r.Read(It.IsAny<TagKey>()))
                .Returns(new Maybe<Tag>(tag));

            return tagReaderMock;
        }

        [Theory]
        [InlineData("Tag Name 1")]
        [InlineData("Tag Name 2")]
        [InlineData("Tag Name 3")]
        public void ReturnsCorrectTagName(string tagName)
        {
            var tagReaderMock = CreateTagReader(new Tag(new Name(tagName)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(tagName, pageModel.TagName);
        }

        [Fact]
        public void InitialiserUsesReaderTagId()
        {
            var tagReaderMock = CreateTagReader(new Tag(new TagKey(1)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(1, pageModel.TagId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TagNotFoundSuitableErrorThrown(long tagId)
        {
            var tagReaderMock = new Mock<IReader<TagKey, Tag>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            Exception ex = Assert.Throws<ModelObjectNotFoundException>(() => initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId }));

            Assert.Equal($"Failed to find tag with id {tagId}", ex.Message);
        }

        [Fact]
        public void NullDataGiven_ArgumentNullThrown()
        {
            var tagReaderMock = new Mock<IReader<TagKey, Tag>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            Exception ex = Assert.Throws<ArgumentNullException>(() => initialiser.Initialise(null));

            Assert.Equal("Must provide tag id to create an edit page model with.\r\nParameter name: data", ex.Message);
        }

        [Fact]
        public void ReturnsCorrectCreationDate()
        {
            var date = DateTime.Now;
            var tagReaderMock = CreateTagReader(new Tag(new CreationDate(date)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(date, expected.Created);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ReturnsCorrectCanSetOnActivity(bool canSetOnActivity)
        {
            var canSetOnActivityBase = canSetOnActivity ?(CanSetOnActivityBase) new CanSetOnActivity() : new CanNotSetOnActivity();

            var tagReaderMock = CreateTagReader(new Tag(canSetOnActivityBase));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(canSetOnActivity, expected.CanSetOnActivity);
        }

        [Theory]
        [InlineData("Description 1")]
        [InlineData("Description 2")]
        [InlineData("Description 3")]
        public void ReturnsCorrectDescription(string description)
        {
            var tagReaderMock = CreateTagReader(new Tag(new Description(description)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(description, expected.Description);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(0)]
        public void TagIdIsZero_ReturnsCorrectException(long tagId)
        {
            var tagReaderMock = CreateTagReader(new Tag(new TagKey(tagId)));

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object);

            var ex = Assert.Throws<IdentifierNotSpecifiedException>(() => initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId }));

            Assert.Equal("Must provide an identifier greater than zero to edit a tag.", ex.Message);
        }
    }
}
