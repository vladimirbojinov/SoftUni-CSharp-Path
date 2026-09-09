namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    public DateTime Date { get; set; }

    [Required]
    [StringLength(250)]
    [Unicode(true)]
    public string Comments { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}
