using Moq;

namespace TMS.Database.Tests.Converters.Tags
{
    internal static class MockExtensions
    {
        internal static Mock<T> AsMock<T>(this T obj) where T : class
        {
            return Mock.Get(obj);
        }
    }
}
