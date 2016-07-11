using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TMS.Web.Tests.Integration
{
    public class TagControllerIntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public TagControllerIntegrationTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task CreateForActivity_ReturnsPageModel_GivenActivityId()
        {
            var response = await _client.GetAsync("Tag/CreateForActivity/1");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(responseString);

            // N.B. - this could be used to actually parse the razor document returned
            //var parser = new RazorParser(new CSharpCodeParser(), new HtmlMarkupParser(), new TagHelperDescriptorResolver(false));

            //using (var reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            //{
            //    var parseResult = parser.Parse(reader);
            //}
        }
    }

}
