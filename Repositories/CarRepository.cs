using DEMO__ASS9.Data;
using DEMO__ASS9.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DEMO__ASS9.Repositories
{
    public class CarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

         public List<Car> GetAllCars()
        {
            return _context.Cars.ToList();   
        }
        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAvailableCars()
        {
            // This should only return cars that are available (IsAvailable = true)
            return _context.Cars.Where(c => c.IsAvailable).ToList();
        }

        public void AddCar(Car car)
        { 

            _context.Cars.Add(car);   
            _context.SaveChanges();   
        }


        public void UpdateCarAvailability(int id, bool isAvailable)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var car = GetCarById(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }
    }
}
