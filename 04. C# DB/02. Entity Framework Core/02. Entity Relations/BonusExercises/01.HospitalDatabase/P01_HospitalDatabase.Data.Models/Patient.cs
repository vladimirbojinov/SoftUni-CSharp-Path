namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Patient
{
    [Key]
    public int PatientId { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    [Required]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(true)]
    [Required]
    public string LastName { get; set; } = null!;

    [StringLength(250)]
    [Unicode(true)]
    [Required]
    public string Address { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string? Email { get; set; }  

    public bool HasInsurance { get; set; }

    public virtual ICollection<Diagnose> Diagnoses { get; set; }
        = new HashSet<Diagnose>();

    public virtual ICollection<Visitation> Visitations { get; set; }
        = new HashSet<Visitation>();

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        = new HashSet<PatientMedicament>();
}
