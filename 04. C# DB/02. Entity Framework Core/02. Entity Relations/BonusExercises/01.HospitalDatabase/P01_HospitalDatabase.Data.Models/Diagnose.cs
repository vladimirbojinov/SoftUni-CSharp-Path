namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    [Unicode(true)]
    public string Comments { get; set; }

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
