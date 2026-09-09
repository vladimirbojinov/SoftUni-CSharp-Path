namespace P03_SalesDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    public string Name { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
        = new HashSet<Sale>();
}
