using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    /// <summary>
    /// Unit tests for the VehiclesController class.
    /// </summary>
    [Collection(TestCollections.TestServer)]
    public class VehiclesControllerTests : InfrastructureTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesControllerTests"/> class with the provided test server fixture.
        /// </summary>
        /// <param name="fixture">The test server fixture used for integration testing.</param>
        public VehiclesControllerTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        /// <summary>
        /// Tests the HTTP POST method for adding a vehicle.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        [Fact]
        public async Task PostAddVehicle()
        {
            var vehicle = new
            {
                Model = "Test Model",
                Year = DateTime.Now,
                LicensePlate = "TEST123",
                DailyRentCost = 100,
                Status = "Available",
                Comments = "Test vehicle"
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(vehicle), Encoding.UTF8, "application/json");

            var response = await Fixture.Server.CreateClient().PostAsync(new Uri("/api/Vehicles", UriKind.Relative), jsonContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            jsonContent.Dispose();
            response.Dispose();
        }
    }
}
