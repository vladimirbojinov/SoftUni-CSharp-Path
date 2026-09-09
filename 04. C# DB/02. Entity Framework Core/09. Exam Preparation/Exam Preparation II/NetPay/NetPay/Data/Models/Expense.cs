namespace NetPay.Data.Models;

using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NetPay.Common.ValidationConstants;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(ExpenseNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime DueDate { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    [ForeignKey(nameof(Household))]
    public int HouseholdId { get; set; }

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }

    public virtual Household Household { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
