using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using ViXmlTools;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var export = new ExportHouseholdsWhichHaveExpensesToPay
            {
                Households = context.Households
                .Include(h => h.Expenses)
                .ThenInclude(e => e.Service)
                .Where(h => h.Expenses.Any(e => e.PaymentStatus == PaymentStatus.Unpaid))
                .AsEnumerable()
                .Select(h => new ExportHouseholdDto
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                    .OrderByDescending(e => e.Amount)
                    .Select(e => new ExportExpenseDto
                    {
                        ExpenseName = e.ExpenseName,
                        Amount = e.Amount,
                        PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                        ServiceName = e.Service.ServiceName
                    })
                    .OrderBy(e => e.PaymentDate)
                    .ToList()
                })
                .OrderBy(h => h.ContactPerson)
                .ToList()
            };

            return XmlUtilities.Serialize(export, "Households");
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            return null;
        }
    }
}
