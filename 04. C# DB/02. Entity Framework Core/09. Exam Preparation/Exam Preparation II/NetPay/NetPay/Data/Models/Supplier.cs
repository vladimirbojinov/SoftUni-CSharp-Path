namespace NetPay.Data.Models;

using System.ComponentModel.DataAnnotations;
using static NetPay.Common.ValidationConstants;

public class Supplier
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(SupplierNameMaxLength)]
    public string SupplierName { get; set; } = null!;

    public virtual ICollection<SupplierService> SuppliersServices { get; set; }
        = new HashSet<SupplierService>();
}
