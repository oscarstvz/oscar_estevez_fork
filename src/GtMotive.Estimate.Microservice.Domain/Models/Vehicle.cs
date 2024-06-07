using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public decimal DailyRentCost { get; set; }

        [Required]
        public string Status { get; set; }

        public string Comments { get; set; }
    }
}
