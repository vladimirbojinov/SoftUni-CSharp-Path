using NetPay.Common;

namespace NetPay.Data.Models;

using System.ComponentModel.DataAnnotations;
using static ValidationConstants;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(ServiceNameMaxLength)]
    public string ServiceName { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; }
        = new HashSet<Expense>();

    public virtual ICollection<SupplierService> SuppliersServices { get; set; }
        = new HashSet<SupplierService>();
}
