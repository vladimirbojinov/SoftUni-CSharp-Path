namespace NetPay.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(SupplierId), nameof(ServiceId))]
public class SupplierService
{
    [ForeignKey(nameof(Supplier))]
    public int SupplierId { get; set; }

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
