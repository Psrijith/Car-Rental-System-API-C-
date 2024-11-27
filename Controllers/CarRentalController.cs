using DEMO__ASS9.Services;
using DEMO__ASS9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DEMO__ASS9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        private readonly CarRentalService _carRentalService;

        public CarRentalController(CarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        // POST api/carrental/rent
        [HttpPost("rent")]
        public async Task<IActionResult> RentCar([FromBody] CarRentalRequest rentalRequest)
        {
            // Check if the car is available
            var isAvailable = _carRentalService.CheckCarAvailability(rentalRequest.CarId);
            if (!isAvailable)
            {
                return BadRequest("The car is not available for rent.");
            }

            // Rent the car and get the total cost
            var totalCost = _carRentalService.RentCar(rentalRequest.CarId, rentalRequest.Days);
            if (totalCost == 0)
            {
                return BadRequest("Failed to rent the car as cost is 0.");
            }

            // Send confirmation email
            var subject = "Car Rental Confirmation";
            var body = $"Your car rental has been confirmed for {rentalRequest.Days} days. Total cost: {totalCost}.";
            await _carRentalService.SendEmailAsync(rentalRequest.UserEmail, subject, body);

            // Return the total cost of the rental
            return Ok(new { totalCost });
        }
    }

    // A simple model for the rental request
    public class CarRentalRequest
    {
        public int CarId { get; set; }
        public int Days { get; set; }
        public string UserEmail { get; set; }
    }

}
