//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System.Linq;
//using TMS.Database.Commands.Tags;
//using TMS.Database.Entities.Tags;
//using TMS.Layer.Factories;
//using TMS.Layer.Visitors;
//using TMS.ModelLayerInterface.Tags;
//using TMS.ModelLayerInterface.Tags.Data;
//using TMS.ModelLayerInterface.Tags.Decorators;
//using TMS.Web.Data;
//using Xunit;
//using System;
//using TMS.ModelLayer.Tags;
//using System.Collections.Generic;
//using TMS.ModelLayerInterface.Activities;

//namespace TMS.Database.Tests.Commands.Tags
//{
//    public class ListPersistableTagsCommandTests
//    {
//        private readonly MainContext _context;

//        public ListPersistableTagsCommandTests()
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
//            optionsBuilder.UseInMemoryDatabase();
//            optionsBuilder.EnableSensitiveDataLogging();

//            _context = new MainContext(optionsBuilder.Options);

//            _context.Database.EnsureDeleted();
//            _context.Database.EnsureCreated();
//        }

//        [Theory]
//        [InlineData("Dave")]
//        [InlineData("Jack")]
//        public void ExecuteCommand_ReturnsCorrectTags_GivenTagName(string tagName)
//        {
//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = Mock.Of<IFactory<TagKeyData, ITagKey>>();
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            Assert.True(result.Any());

//            tagFactoryMock.Verify(f => f.Create(It.Is<TagData>(td => td.Name == tagName)), Times.Once);
//        }

//        [Fact]
//        public void ExecuteCommand_ReturnsCreatedDate_GivenMatchingTag()
//        {
//            var expected = DateTime.Now;
//            var tagName = "Name";

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName,
//                Created = expected
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = Mock.Of<IFactory<TagKeyData, ITagKey>>();
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            Assert.True(result.Any());

//            tagFactoryMock.Verify(f => f.Create(It.Is<TagData>(td => td.Created == expected)), Times.Once);
//        }

//        [Theory]
//        [InlineData("Dave")]
//        [InlineData("Jack")]
//        [InlineData("Claire")]
//        public void ExecuteCommand_ReturnsThreeTags_GivenThreeTagsMatchingName(string tagName)
//        {
//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName
//            });

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName
//            });

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = Mock.Of<IFactory<TagKeyData, ITagKey>>();
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            var tags = result.SelectMany(item => item);

//            Assert.Equal(3, tags.Count());
//        }

//        [Theory]
//        [InlineData("Description 1")]
//        [InlineData("Description 2")]
//        [InlineData("Description 3")]
//        public void ExecuteCommand_ReturnsDescription_GivenTagName(string expected)
//        {
//            var tagName = "Name";

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName,
//                Description = expected
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = Mock.Of<IFactory<TagKeyData, ITagKey>>();
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            tagFactoryMock.Verify(t => t.Create(It.Is<TagData>(td => td.Description == expected)), Times.Once);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        public void ExecuteCommand_PopulatesCanBetSetOnActivity_GivenValue(bool expected)
//        {            
//            var tagName = "Name";

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName,
//                CanSetOnActivity = expected
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = Mock.Of<IFactory<TagKeyData, ITagKey>>();
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            tagFactoryMock.Verify(f => f.Create(It.Is<TagData>(td => td.CanSetOnActivity == expected)), Times.Once);
//        }

//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        public void ExecuteCommand_AssignsCorrectIdentifier_GivenMatchingTagName(long id)
//        {
//            var tagName = "Name";

//            _context.Tags.Add(new TagEntity
//            {
//                Name = tagName,
//                Id = id
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

//            tagKeyFactoryMock
//                .Setup(f => f.Create(It.Is<TagKeyData>(tkd => tkd.Identifier == id)))
//                .Returns(new TagKey { Identifier = id });

//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock.Object);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                TagName = tagName
//            });

//            tagKeyFactoryMock.Verify(f => f.Create(It.Is<TagKeyData>(tkd => tkd.Identifier == id)), Times.Once);
//            persistableTagFactoryMock.Verify(f => f.Create(It.Is<PersistableTagData>(ptd => ptd.Key != null && ptd.Key.Identifier == id), It.IsAny<ITag>()), Times.Once);
//        }

//        [Fact]
//        public void ExecuteCommand_ReusableTagReturned_GivenReusableTagFilter()
//        {
//            var expected = true;

//            _context.Tags.Add(new TagEntity
//            {
//                Reusable = expected
//            });

//            _context.Tags.Add(new TagEntity
//            {
//                Reusable = false
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();
//            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();
            
//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock.Object);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                Reusable = expected
//            });

//            var tags = result.SelectMany(item => item);

//            Assert.Equal(1, tags.Count());

//            tagFactoryMock.Verify(f => f.Create(It.Is<TagData>(td => td.Reusable == expected)), Times.Once);
//        }

//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        public void ExecuteCommand_TagsForActivityReturned_GivenActivityKey(int activityId)
//        {
//            _context.Tags.Add(new TagEntity
//            {
//                Name = "Tag Name",
//                Activities = new HashSet<TagActivityEntity>
//                {
//                    new TagActivityEntity
//                    {
//                        ActivityId = activityId
//                    }
//                }
//            });

//            _context.SaveChanges();

//            var tagFactoryMock = new Mock<IFactory<TagData, ITag>>();

//            var tagKeyFactoryMock = new Mock<IFactory<TagKeyData, ITagKey>>();

//            var persistableTagFactoryMock = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>();

//            var activityKeyMock = Mock.Of<IActivityKey>(a => a.Identifier == activityId);

//            var objectToTest = new ListPersistableTagsCommand(_context, persistableTagFactoryMock.Object, tagFactoryMock.Object, tagKeyFactoryMock.Object);

//            var result = objectToTest.ExecuteCommand(new TagFilterData
//            {
//                ActivityKey = activityKeyMock
//            });

//            var tags = result.SelectMany(item => item);

//            Assert.Equal(1, tags.Count());

//            tagFactoryMock.Verify(f => f.Create(It.Is<TagData>(td => td.Name == "Tag Name")), Times.Once());
//        }

//        class TagVisitor : IVisitor<TagData>
//        {
//            public string Name { get; private set; }

//            public TagVisitor(ITag tag)
//            {
//                tag.Accept(() => this);
//            }

//            public void Visit(TagData data)
//            {
//                Name = data.Name;
//            }
//        }
//    }
//}
