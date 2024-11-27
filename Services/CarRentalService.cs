using DEMO__ASS9.Data;
using SendGrid.Helpers.Mail;
using SendGrid;
using DEMO__ASS9.Repositories;
using System.Net;

namespace DEMO__ASS9.Services
{
    public class CarRentalService
    {
        private readonly CarRepository _carRepository;

        public CarRentalService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public bool CheckCarAvailability(int carId)
        {
            var car = _carRepository.GetCarById(carId);
            return car != null && car.IsAvailable;
        }

        public decimal RentCar(int carId, int days)
        {
            var car = _carRepository.GetCarById(carId);
            if (car == null || !car.IsAvailable)
            {
                return 0; // Car not available
            }

            // Calculate total cost for rental
            decimal totalCost = car.PricePerDay * days;

            // Rent the car (set IsAvailable to false)
            car.IsAvailable = false;
            _carRepository.UpdateCarAvailability(carId, false);

            // Log to confirm email sending
            Console.WriteLine("Sending email for rental confirmation...");

            // Send confirmation email
            var subject = "Car Rental Confirmation";
            var body = $"Your car rental has been confirmed for {days} days. Total cost: {totalCost}.";
            SendEmailAsync("recipient@example.com", subject, body).Wait();  // Use the correct user email here

            return totalCost;
        }


        public async Task SendEmailAsync(string userEmail, string subject, string body)
        {
            var client = new SendGridClient("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"); 
            var from = new EmailAddress("peddireddysrijith@gmail.com", "Car Rental System");
            var to = new EmailAddress(userEmail);  // Correct recipient's email address
            var emailMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            try
            {
                var response = await client.SendEmailAsync(emailMessage);

                // Log the SendGrid response status code
                Console.WriteLine($"SendGrid response status: {response.StatusCode}");

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var errorResponse = await response.Body.ReadAsStringAsync();
                    Console.WriteLine($"Error response from SendGrid is : {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the email sending process
                Console.WriteLine($"Error sending email is : {ex.Message}");
            }
        }


    }
}
