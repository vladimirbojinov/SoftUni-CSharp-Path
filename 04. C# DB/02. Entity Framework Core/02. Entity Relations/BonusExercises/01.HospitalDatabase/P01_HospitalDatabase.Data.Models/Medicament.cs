namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Medicament
{
    [Key]
    public int MedicamentId { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        = new HashSet<PatientMedicament>();
}
