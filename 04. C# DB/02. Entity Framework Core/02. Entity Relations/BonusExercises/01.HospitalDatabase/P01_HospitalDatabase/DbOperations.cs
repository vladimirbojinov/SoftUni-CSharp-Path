namespace P01_HospitalDatabase;

using P01_HospitalDatabase.Data;
using P01_HospitalDatabase.Data.Models;
using static P01_HospitalDatabase.ErrorMessages;

public static class DbOperations
{
    private static readonly HospitalContext dbContext = new();

    public static void CreateDatabase()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    public static string AddDoctorToDb(Doctor doctor)
    {
        if (string.IsNullOrEmpty(doctor.Name) ||
            string.IsNullOrEmpty(doctor.Specialty))
        {
            return InvalidInput;
        }

        dbContext.Add(doctor);
        dbContext.SaveChanges();

        return $"{nameof(Doctor)} was successfully added!";
    }

    public static string AddPatientToDb(Patient patient)
    {
        if (string.IsNullOrEmpty(patient.FirstName) ||
            string.IsNullOrEmpty(patient.LastName) ||
            string.IsNullOrEmpty(patient.Address))
        {
            return "Invalid input you should enter something!";
        }

        patient.Email = patient.Email.Length >= 2 ? patient.Email : null;

        dbContext.Add(patient);
        dbContext.SaveChanges();

        return $"{nameof(Patient)} was successfully added!";
    }

    public static string AddMedicamentToDb(Medicament medicament)
    {
        if (string.IsNullOrEmpty(medicament.Name)) return InvalidInput;

        dbContext.Add(medicament);
        dbContext.SaveChanges();

        return $"{nameof(Medicament)} successfully added!";
    }

    public static Doctor? GetDoctorById(int id) 
        => dbContext.Doctors.Find(id);

    public static Patient? GetPatientById(int id) 
        => dbContext.Patients.Find(id);

    public static Medicament? GetMedicamentById(int id)
        => dbContext.Medicaments.Find(id);
}
