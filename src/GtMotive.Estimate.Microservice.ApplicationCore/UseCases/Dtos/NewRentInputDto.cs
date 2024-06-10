using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos
{
    /// <summary>
    /// DTO for creating a new rent.
    /// </summary>
    public class NewRentInputDto
    {
        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the car ID.
        /// </summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rent.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rent.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the rent.
        /// </summary>
        [Required]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets additional comments about the rent.
        /// </summary>
        public string Comments { get; set; }
    }
}
