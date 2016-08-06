//using Moq;
//using System;
//using System.Linq;
//using TMS.Database.Entities.Tags;
//using TMS.Layer.Visitors;
//using TMS.ModelLayerInterface.Tags;
//using TMS.ModelLayerInterface.Tags.Data;
//using Xunit;

//namespace TMS.Database.Tests.Converters.Tags
//{
//    public class TagEntityToTagConverterTests
//    {
//        [Theory]
//        [InlineData("Name 1")]
//        [InlineData("Name 2")]
//        [InlineData("Name 3")]
//        public void Convert_ReturnsCorrectName_GivenTagEntity(string name)
//        {
//            // Arrange
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(new TagData { Name = name });

//            // Act
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { Name = name });

//            // Assert
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());
//            Assert.Equal(name, tagVisitor.Name);

//            fixture.tagFactory.AsMock().Verify(f => f.Create(It.Is<TagData>(td => td.Name == name)));
//        }

//        [Fact]
//        public void Convert_ReturnsCorrectDate_GivenTagEntity()
//        {
//            var date = DateTime.Now;
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(new TagData { Created = date });
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { Created = date });
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());

//            Assert.Equal(date, tagVisitor.Created);

//            fixture.tagFactory.AsMock().Verify(f => f.Create(It.Is<TagData>(td => td.Created == date)));
//        }

//        [Theory]
//        [InlineData("Description 1")]
//        [InlineData("Description 2")]
//        [InlineData("Description 3")]
//        public void Convert_ReturnsCorrectDescription_GivenTagEntity(string description)
//        {
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(new TagData { Description = description });
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { Description = description });
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());

//            Assert.Equal(description, tagVisitor.Description);

//            fixture.tagFactory.AsMock().Verify(f => f.Create(It.Is<TagData>(td => td.Description == description)));
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        public void Convert_ReturnsCorrectCanSetOnActivity_GivenTagEntity(bool canSetOnActivity)
//        {
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(new TagData { CanSetOnActivity = canSetOnActivity });
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { CanSetOnActivity = canSetOnActivity });
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());

//            Assert.Equal(canSetOnActivity, tagVisitor.CanSetOnActivity);

//            fixture.tagFactory.AsMock().Verify(f => f.Create(It.Is<TagData>(td => td.CanSetOnActivity == canSetOnActivity)));
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        public void Convert_ReturnsCorrectReusable_GivenTagEntity(bool reusable)
//        {
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(new TagData { Reusable = reusable });
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { Reusable = reusable });
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());

//            Assert.Equal(reusable, tagVisitor.Reusable);

//            fixture.tagFactory.AsMock().Verify(f => f.Create(It.Is<TagData>(td => td.Reusable == reusable)));
//        }

//        [Theory]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        public void Convert_ReturnsCorrectId_GivenTagEntity(long id)
//        {
//            var fixture = new TagEntityToTagConverterFixture()
//                .WithTagFactoryReturningTagUsingData()
//                .WithTagKeyFactoryReturningTagKeyUsingData(id)
//                .WithPersistableTagFactoryReturningPersistableTagUsingData(null, new PersistableTagData { Key = Mock.Of<ITagKey>(k => k.Identifier == id) });
//            var tagConverter = fixture.CreateSut();
//            var result = tagConverter.Convert(new TagEntity { Id = id });
//            var tagVisitor = new TagVisitor(result.FirstOrDefault());

//            Assert.Equal(id, tagVisitor.Id);

//            fixture.persistableFactory.AsMock().Verify(f => f.Create(It.Is<PersistableTagData>(td => td.Key != null && td.Key.Identifier == id), fixture.tag));
//        }

//        public class TagVisitor : IVisitor<TagData>, IVisitor<PersistableTagData>
//        {
//            public long Id { get; set; }
//            public string Name { get; private set; }
//            public DateTime Created { get; private set; }
//            public string Description { get; private set; }
//            public bool CanSetOnActivity { get; private set; }
//            public bool Reusable { get; private set; }

//            public TagVisitor(ITag tag)
//            {
//                tag?.Accept(() => this);
//            }

//            public void Visit(TagData data)
//            {
//                if (data == null)
//                    return;

//                Name = data.Name;
//                Created = data.Created;
//                Description = data.Description;
//                CanSetOnActivity = data.CanSetOnActivity;
//                Reusable = data.Reusable;
//            }

//            public void Visit(PersistableTagData data)
//            {
//                if (data == null)
//                    return;
                
//                Id = data.Key.Identifier;
//            }
//        }
//    }
//}
