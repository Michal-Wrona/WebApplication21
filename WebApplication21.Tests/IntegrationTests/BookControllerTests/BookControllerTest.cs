using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApplication21.Tests.IntegrationTests.BookControllerTests
{
    public class BookControllerTest
    {
        [Fact]
        public async Task GetAll()
        {
            //arrange
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/book");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
