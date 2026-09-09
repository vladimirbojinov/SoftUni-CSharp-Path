namespace P03_SalesDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(100)]
    [Unicode(true)]
    public string Name { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string Email { get; set; }

    [Unicode(false)]
    public string CreditCardNumber { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
        = new HashSet<Sale>();
}
