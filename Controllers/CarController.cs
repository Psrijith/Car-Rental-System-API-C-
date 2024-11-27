using DEMO__ASS9.Models;
using DEMO__ASS9.Repositories;
using DEMO__ASS9.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEMO__ASS9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;
        private readonly CarRentalService _carRentalService;

        public CarController(CarRepository carRepository, CarRentalService carRentalService)
        {
            _carRepository = carRepository;
            _carRentalService = carRentalService;
        }

        [HttpGet("all")]
        public IActionResult GetAllCars()
        {
            var cars = _carRepository.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("available")]
        public IActionResult GetAvailableCars()
        {
            return Ok(_carRepository.GetAvailableCars());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCar([FromBody] Car car)
        {
            _carRepository.AddCar(car);
            return CreatedAtAction(nameof(GetAvailableCars), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            var existingCar = _carRepository.GetCarById(id);
            if (existingCar == null) return NotFound();

            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.PricePerDay = car.PricePerDay;
            existingCar.IsAvailable = car.IsAvailable;

            _carRepository.UpdateCarAvailability(id, existingCar.IsAvailable);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCar(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null) return NotFound();

            _carRepository.Delete(id);
            return NoContent();
        }
         
    }
} 
