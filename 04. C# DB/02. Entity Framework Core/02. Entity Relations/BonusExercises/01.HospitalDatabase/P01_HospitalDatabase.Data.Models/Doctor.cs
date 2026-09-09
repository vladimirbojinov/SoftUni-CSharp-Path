namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    [StringLength(100)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(true)]
    [Required]
    public string Specialty { get; set; } = null!;

    public virtual ICollection<Visitation> Visitations { get; set; }
        = new HashSet<Visitation>();
}
