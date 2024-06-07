using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos
{
    public class AddVehicleInputDto
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public decimal DailyRentCost { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
