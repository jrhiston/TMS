using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.ApplicationLayer.Activities;
using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using Xunit;

namespace TMS.ApplicationLayer.Tests.Activities
{
    public class EditActivityPageModelInitialiserTests
    {
        [Theory]
        [InlineData("Dave")]
        [InlineData("Fred")]
        [InlineData("Jack")]
        public void Initialise_ReturnsTags_GivenActivityWithTags(string tagName)
        {
            var expected = new Mock<ITag>();
            expected.Setup(t => t.Accept(It.IsAny<Func<IVisitor<TagData>>>()))
                .Callback<Func<IVisitor<TagData>>>(f =>
                {
                    var visitor = f();
                    visitor.Visit(new TagData { Name = tagName });
                });

            var areaKey = Mock.Of<IActivityKey>(k => k.Identifier == 1);
            var activity = new Mock<IActivity>();

            activity.Setup(a => a.Accept(It.IsAny<Func<IVisitor<ActivityData>>>()))
                .Callback<Func<IVisitor<ActivityData>>>(f => {
                    var visitor = f() as IVisitor<TaggableActivityData>;
                    if (visitor != null)
                    {
                        visitor.Visit(new TaggableActivityData
                        {
                            Tags = new List<ITag>
                            {
                                expected.Object
                            }
                        });
                    }
                });

            var mockReader = Mock.Of<IReader<IActivityKey, IActivity>>(f => f.Read(areaKey) == new Maybe<IActivity>(activity.Object));
            var mockActivityKeyFactory = Mock.Of<IFactory<ActivityKeyData, IActivityKey>>(f => f.Create(It.Is<ActivityKeyData>(akd => akd.Identifier == 1)) == areaKey);

            var objectToTest = new EditActivityPageModelInitialiser(mockReader, mockActivityKeyFactory);

            var result = objectToTest.Initialise(new ApplicationLayer.Activities.Data.EditActivityPageModelInitialiserData
            {
                ActivityId = 1,
                AreaId = 1
            });

            Assert.Collection(result.Tags, el => { Assert.Equal(el.Name, tagName); });
        }
    }
}
