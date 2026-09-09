namespace P03_SalesDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Store
{
    [Key]
    public int StoreId { get; set; }

    [StringLength(80)]
    [Unicode(true)]
    public string Name { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }
        = new HashSet<Sale>();
}
