using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Dtos
{
    /// <summary>
    /// Represents the data transfer object for adding a new vehicle.
    /// </summary>
    public class AddVehicleInputDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year of the vehicle.
        /// </summary>
        [Required]
        public DateTime Year { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        [Required]
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the daily rent cost of the vehicle.
        /// </summary>
        [Required]
        public decimal DailyRentCost { get; set; }

        /// <summary>
        /// Gets or sets the status of the vehicle.
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets any additional comments for the vehicle.
        /// </summary>
        public string Comments { get; set; }
    }
}
