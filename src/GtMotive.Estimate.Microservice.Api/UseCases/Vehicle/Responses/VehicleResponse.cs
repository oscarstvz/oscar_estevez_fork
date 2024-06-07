﻿using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.Responses
{
    public class VehicleResponse
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public decimal DailyRentCost { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}

