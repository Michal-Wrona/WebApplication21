using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace WebApplication21.Tests
{
    public class BookControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnOkResult()
        {
            //arrange(
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/book");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
