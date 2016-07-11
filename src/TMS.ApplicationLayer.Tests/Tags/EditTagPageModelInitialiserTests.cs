using Moq;
using System;
using TMS.ApplicationLayer.Exceptions;
using TMS.ApplicationLayer.Tags;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer;
using TMS.Layer.Exceptions;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;
using Xunit;

namespace TMS.ApplicationLayer.Tests.Tags
{
    public class EditTagPageModelInitialiserTests
    {
        [Fact]
        public void EditTagPageModelInitialiserReturnsCorrectPageModel()
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Name = "Name"
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 1 });

            Assert.IsType(typeof(EditTagPageModel), pageModel);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void EditTagPageModelInitialiserAssignTagId(long tagId)
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Identifier = tagId,
                Name = "Name"
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId });

            Assert.Equal(tagId, pageModel.TagId);
        }

        private static Mock<IReader<ITagKey, ITag>> CreateTagReader(PersistableTagMock tag)
        {
            var tagReaderMock = new Mock<IReader<ITagKey, ITag>>();

            tagReaderMock
                .Setup(r => r.Read(It.IsAny<ITagKey>()))
                .Returns(new Maybe<ITag>(tag));

            return tagReaderMock;
        }

        [Theory]
        [InlineData("Tag Name 1")]
        [InlineData("Tag Name 2")]
        [InlineData("Tag Name 3")]
        public void ReturnsCorrectTagName(string tagName)
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Name = tagName
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(tagName, pageModel.TagName);
        }

        [Fact]
        public void InitialiserUsesReaderTagId()
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Identifier = 1,
                Name = ""
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var pageModel = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(1, pageModel.TagId);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TagNotFoundSuitableErrorThrown(long tagId)
        {
            var tagReaderMock = new Mock<IReader<ITagKey, ITag>>();

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            Exception ex = Assert.Throws<ModelObjectNotFoundException>(() => initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId }));

            Assert.Equal($"Failed to find tag with id {tagId}", ex.Message);
        }

        [Fact]
        public void NullDataGiven_ArgumentNullThrown()
        {
            var tagReaderMock = new Mock<IReader<ITagKey, ITag>>();

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            Exception ex = Assert.Throws<ArgumentNullException>(() => initialiser.Initialise(null));

            Assert.Equal("Must provide tag id to create an edit page model with.\r\nParameter name: data", ex.Message);
        }

        [Fact]
        public void ReturnsCorrectCreationDate()
        {
            var date = DateTime.Now;
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Created = date
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(date, expected.Created);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ReturnsCorrectCanSetOnActivity(bool canSetOnActivity)
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                CanSetOnActivity = canSetOnActivity
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(canSetOnActivity, expected.CanSetOnActivity);
        }

        [Theory]
        [InlineData("Description 1")]
        [InlineData("Description 2")]
        [InlineData("Description 3")]
        public void ReturnsCorrectDescription(string description)
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock
            {
                Description = description
            });

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var expected = initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = 3 });

            Assert.Equal(description, expected.Description);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(0)]
        public void TagIdIsZero_ReturnsCorrectException(long tagId)
        {
            var tagReaderMock = CreateTagReader(new PersistableTagMock());

            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

            var initialiser = new EditTagPageModelInitialiser(tagReaderMock.Object, tagKeyFactoryMock.Object);

            var ex = Assert.Throws<IdentifierNotSpecifiedException>(() => initialiser.Initialise(new EditTagPageModelInitialiserData { TagId = tagId }));

            Assert.Equal("Must provide an identifier greater than zero to edit a tag.", ex.Message);
        }
    }

    internal class PersistableTagMock : IPersistableTag
    {
        public DateTime Created { get; internal set; }
        public string Description { get; set; }
        public bool CanSetOnActivity { get; set; }
        public long Identifier { get; set; }
        public string Name { get; set; }

        public void Accept(Func<IVisitor<TagData>> visitorFactory)
        {
            var key = Mock.Of<ITagKey>();
            key.Identifier = Identifier;

            var visitor = visitorFactory();

            var visitorAsType = visitor as IVisitor<PersistableTagData>;
            visitorAsType?.Visit(new PersistableTagData
            {
                Key = key
            });

            visitor.Visit(new TagData
            {
                Name = Name,
                Created = Created,
                CanSetOnActivity = CanSetOnActivity,
                Description = Description
            });
        }
    }
}
