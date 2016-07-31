using Moq;
using System;
using TMS.Database.Converters.Tags;
using TMS.Layer.Factories;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.Database.Tests.Converters.Tags
{
    internal class TagEntityToTagConverterFixture
    {
        internal IFactory<TagData, ITag> tagFactory;
        internal IDecoratorFactory<PersistableTagData, ITag, IPersistableTag> persistableFactory;
        internal IFactory<TagKeyData, ITagKey> tagKeyFactory;
        internal ITag tag;
        internal IPersistableTag persistableTag;
        internal ITagKey tagKey;

        internal TagEntityToTagConverterFixture()
        {
            tagFactory = new Mock<IFactory<TagData, ITag>>().Object;
            persistableFactory = new Mock<IDecoratorFactory<PersistableTagData, ITag, IPersistableTag>>().Object;
            tagKeyFactory = new Mock<IFactory<TagKeyData, ITagKey>>().Object;
            tag = new Mock<ITag>().Object;
            persistableTag = new Mock<IPersistableTag>().Object;
            tagKey = new Mock<ITagKey>().Object;
        }

        internal TagEntityToTagConverterFixture WithPersistableTagFactoryReturningPersistableTagUsingData(TagData tagData = null, PersistableTagData data = null)
        {
            persistableTag
                .AsMock()
                .Setup(t => t.Accept(It.IsAny<Func<IVisitor<TagData>>>()))
                .Callback<Func<IVisitor<TagData>>>(func =>
                {
                    var visitor = func();

                    var visitorAsType = visitor as IVisitor<PersistableTagData>;

                    visitor?.Visit(tagData);
                    visitorAsType?.Visit(data);
                });

            persistableFactory
                .AsMock()
                .Setup((f => f.Create(It.IsAny<PersistableTagData>(), tag)))
                .Returns(persistableTag);

            return this;
        }

        internal TagEntityToTagConverterFixture WithTagFactoryReturningTagUsingData(TagData data = null)
        {
            tag.AsMock()
                .Setup(t => t.Accept(It.IsAny<Func<IVisitor<TagData>>>()))
                .Callback<Func<IVisitor<TagData>>>(func =>
                {
                    var visitor = func();

                    visitor.Visit(data);
                });

            tagFactory
                .AsMock()
                .Setup(f => f.Create(It.IsAny<TagData>()))
                .Returns(tag);

            return this;
        }

        internal TagEntityToTagConverterFixture WithTagKeyFactoryReturningTagKeyUsingData(long id)
        {
            tagKey.AsMock().SetupGet(t => t.Identifier).Returns(id);

            tagKeyFactory
                .AsMock()
                .Setup(f => f.Create(It.IsAny<TagKeyData>()))
                .Returns(tagKey);

            return this;
        }

        internal TagEntityToTagConverter CreateSut()
        {
            return new TagEntityToTagConverter(tagFactory, persistableFactory, tagKeyFactory);
        }
    }
}
