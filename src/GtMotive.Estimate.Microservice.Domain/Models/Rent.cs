using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    public class Rent
    {
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public string Status { get; set; }

        public string Comments { get; set; }
    }
}
