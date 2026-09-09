using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using ViJsonTools;
using ViXmlTools;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportCustomersDto[] importedCustomers = XmlUtilities.Deserialize<ImportCustomersDto>(xmlString, "Customers");

            List<Customer> existingCustomers = context.Customers.ToList();
            List<Customer> persistedCustomers = new();

            foreach (ImportCustomersDto customerDto in importedCustomers)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = IsDuplicate(existingCustomers, customerDto) ||
                                   IsDuplicate(persistedCustomers, customerDto);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new()
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber
                };

                persistedCustomers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.AddRange(persistedCustomers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportBookingsDto[] importedBookings = JsonUtilities.Deserialize<ImportBookingsDto>(jsonString);

            List<string> validCustomerNames = context.Customers.Select(c => c.FullName).ToList();
            List<string> validTourPackageNames = context.TourPackages.Select(tp => tp.PackageName).ToList();

            List<Booking> persistedBooking = new();

            foreach (ImportBookingsDto bookingDto in importedBookings)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validCustomerNames.Contains(bookingDto.CustomerName) == false ||
                    validTourPackageNames.Contains(bookingDto.TourPackageName) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (DateTime.TryParseExact(
                    bookingDto.BookingDate,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime bookingDate) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = context.Customers.Where(c => c.FullName == bookingDto.CustomerName).First();
                TourPackage tourPackage = context.TourPackages.Where(tp => tp.PackageName == bookingDto.TourPackageName).First();

                Booking booking = new()
                {
                    BookingDate = bookingDate,
                    Customer = customer,
                    TourPackage = tourPackage,
                };

                persistedBooking.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.AddRange(persistedBooking);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }

        private static bool IsDuplicate(List<Customer> collection, ImportCustomersDto customerDto)
        {
            return collection.Any(c => c.FullName == customerDto.FullName ||
                                       c.Email == customerDto.Email ||
                                       c.PhoneNumber == customerDto.PhoneNumber);
        }
    }
}
