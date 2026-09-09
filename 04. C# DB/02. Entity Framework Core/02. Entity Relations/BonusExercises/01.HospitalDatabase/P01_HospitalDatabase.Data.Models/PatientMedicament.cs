namespace P01_HospitalDatabase.Data.Models;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(PatientId), nameof(MedicamentId))]
public class PatientMedicament
{
    public int PatientId { get; set; }

    public int MedicamentId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Medicament Medicament { get; set; } = null!;
}
