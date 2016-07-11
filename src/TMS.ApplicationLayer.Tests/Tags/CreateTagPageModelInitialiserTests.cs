using TMS.ApplicationLayer.Tags;
using TMS.ApplicationLayer.Tags.Data;
using TMS.ViewModelLayer.Models.Tags.Pages;
using Xunit;

namespace TMS.ApplicationLayer.Tests.Tags
{
    public class CreateTagPageModelInitialiserTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void PageModelReturnedWithActivityIdAssigned(long value)
        {
            var initialiser = new CreateTagForActivityPageModelInitialiser();
            var pageModel = initialiser.Initialise(new CreateTagForActivityPageModelInitialiserData { ActivityId = value });

            Assert.Equal(value, pageModel.ActivityId);
        }

        [Fact]
        public void PageModelReturnedIsCreateTagPageModel()
        {
            var initialiser = new CreateTagForActivityPageModelInitialiser();
            var pageModel = initialiser.Initialise(new CreateTagForActivityPageModelInitialiserData { ActivityId = 1 });

            Assert.IsType(typeof(CreateTagForActivityPageModel), pageModel);
        }
    }
}
