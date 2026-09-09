namespace NetPay.DataProcessor;

using Data;
using Data.Models;
using Data.Models.Enums;
using DataProcessor.ImportDtos;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using ViJsonTools;
using ViXmlTools;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format!";
    private const string DuplicationDataMessage = "Error! Data duplicated.";
    private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
    private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

    public static string ImportHouseholds(NetPayContext context, string xmlString)
    {
        StringBuilder sb = new();

        ImportHouseholdsDto[] importedHouseholds = XmlUtilities.Deserialize<ImportHouseholdsDto>(xmlString, "Households");

        List<Household> existingHouseholds = context.Households.ToList();
        List<Household> persistedHouseholds = new();

        foreach (ImportHouseholdsDto householdDto in importedHouseholds)
        {
            if (!IsValid(householdDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isDuplicate = HasDuplicateHousehold(existingHouseholds, householdDto) ||
                               HasDuplicateHousehold(persistedHouseholds, householdDto);

            if (isDuplicate)
            {
                sb.AppendLine(DuplicationDataMessage);
                continue;
            }

            Household household = new()
            {
                ContactPerson = householdDto.ContactPerson,
                Email = householdDto.Email,
                PhoneNumber = householdDto.PhoneNumber
            };

            sb.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));
            persistedHouseholds.Add(household);
        }

        context.AddRange(persistedHouseholds);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportExpenses(NetPayContext context, string jsonString)
    {
        StringBuilder sb = new();

        ImportExpensesDto[] importedExpenses = JsonUtilities.Deserialize<ImportExpensesDto>(jsonString);

        List<int> validHouseholdIds = context.Households.Select(h => h.Id).ToList();
        List<int> validServiceIds = context.Services.Select(s => s.Id).ToList();
        List<Expense> persistedExpenses = new();

        foreach (ImportExpensesDto expenseDto in importedExpenses)
        {
            if (!IsValid(expenseDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!validHouseholdIds.Contains(expenseDto.HouseholdId) ||
                !validServiceIds.Contains(expenseDto.ServiceId))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isEnumValid = Enum.TryParse(expenseDto.PaymentStatus, true, out PaymentStatus paymentStatus);
            bool isDateTimeValid = DateTime.TryParseExact
            (
                expenseDto.DueDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dueDate
            );

            if (isEnumValid == false ||
                isDateTimeValid == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Expense expense = new()
            {
                ExpenseName = expenseDto.ExpenseName,
                Amount = expenseDto.Amount,
                DueDate = dueDate,
                PaymentStatus = paymentStatus,
                HouseholdId = expenseDto.HouseholdId,
                ServiceId = expenseDto.ServiceId,
            };

            persistedExpenses.Add(expense);
            sb.AppendLine(string.Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("F2")));
        }

        context.AddRange(persistedExpenses);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        foreach (var result in validationResults)
        {
            string currvValidationMessage = result.ErrorMessage;
        }

        return isValid;
    }

    private static bool HasDuplicateHousehold(IEnumerable<Household> households, ImportHouseholdsDto householdDto)
        => households.Any(h => h.ContactPerson == householdDto.ContactPerson ||
                               h.Email == householdDto.Email ||
                               h.PhoneNumber == householdDto.PhoneNumber);
}
