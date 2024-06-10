using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Requests
{
    public class AddVehicleRequest
    {
        public string Model { get; set; }

        public DateTime Year { get; set; }

        public string LicensePlate { get; set; }

        public decimal DailyRentCost { get; set; }

        public string Status { get; set; }
    }
}
