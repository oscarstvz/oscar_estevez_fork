using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    /// <summary>
    /// Represents a rental transaction.
    /// </summary>
    public class Rent
    {
        /// <summary>
        /// Gets or sets the unique identifier for the rent.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the client.
        /// </summary>
        [Required]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the car.
        /// </summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the rent.
        /// </summary>
        [Required]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the status of the rent.
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets any additional comments for the rent.
        /// </summary>
        public string Comments { get; set; }
    }
}
