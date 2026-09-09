namespace P01_HospitalDatabase;

using P01_HospitalDatabase.Data.Models;
using static DbOperations;
using static ErrorMessages;

public class Startup
{
    static void Main()
    {
        CreateDatabase();
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            PrintMenu();
            ConsoleKey choice = Console.ReadKey(true).Key;
            Console.Clear();
            HandleUserChoice(choice);
        }
    }

    private static void AddDoctor()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Specialty: ");
        string specialty = Console.ReadLine();

        Doctor doctor = new()
        {
            Name = name,
            Specialty = specialty
        };

        ShowConsoleMessage(
            AddDoctorToDb(doctor)
        );
    }

    private static void AddPatient()
    {
        Console.WriteLine("FirstName: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("LastName: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Email (Optional): ");
        string? email = Console.ReadLine();
        Console.WriteLine("Has insurance True/False: ");
        string stringHasInsurance = Console.ReadLine();

        if (bool.TryParse(stringHasInsurance, out bool hasInsurance) == false)
        {
            ShowConsoleMessage(InvalidInput);
            return;
        }

        Patient patient = new()
        {
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            Email = email,
            HasInsurance = hasInsurance
        };

        ShowConsoleMessage(
            AddPatientToDb(patient)
        );
    }

    private static void AddMedicament()
    {
        Console.WriteLine("Name");
        string name = Console.ReadLine();

        Medicament medicament = new()
        {
            Name = name
        };

        ShowConsoleMessage(
            AddMedicamentToDb(medicament)
        );        
    }

    private static void ViewDoctorById()
    {
        Console.WriteLine("Doctor ID: ");
        int id = -1;

        if (int.TryParse(Console.ReadLine(), out id) == false) ShowConsoleMessage(InvalidInput);

        Doctor doctor = GetDoctorById(id);

        if (doctor is null)
        {
            ShowConsoleMessage(NotFound);
            return;
        }

        ShowConsoleMessage(
            $"""
            -- {nameof(Doctor)} --
            FirstName: {doctor.Name}
            LastName: {doctor.Specialty}
            Visitations: {doctor.Visitations.Count}
            """
        );
    }

    private static void ViewPatientById()
    {
        Console.WriteLine("Patient ID: ");
        int id = -1;

        if (int.TryParse(Console.ReadLine(), out id) == false) ShowConsoleMessage(InvalidInput);

        Patient patient = GetPatientById(id);

        if (patient is null)
        {
            ShowConsoleMessage(NotFound);
            return;
        }

        string insuranceStatus = patient.HasInsurance ? "Insured" : "Not Insured";
        string email = patient.Email ?? "N/A";

        ShowConsoleMessage(
            $"""
            -- {nameof(Patient)} --
            FirstName: {patient.FirstName}
            LastName: {patient.LastName}
            Address: {patient.Address}
            Email: {email}
            Insurance: {insuranceStatus}
            Diagnoses: {patient.Diagnoses.Count}
            Visitations: {patient.Visitations.Count}
            Prescriptions: {patient.Prescriptions.Count}
            """
        );
    }

    private static void ViewMedicamentById()
    {
        Console.WriteLine("Medicament ID: ");
        int id = -1;

        if (int.TryParse(Console.ReadLine(), out id) == false) ShowConsoleMessage(InvalidInput);

        Medicament medicament = GetMedicamentById(id);

        if (medicament is null)
        {
            ShowConsoleMessage(NotFound);
            return;
        }

        ShowConsoleMessage(
            $"""
            -- {nameof(Medicament)} --
            Name: {medicament.Name}
            """
        );
    }

    private static void HandleUserChoice(ConsoleKey choice)
    {
        switch (choice)
        {
            case ConsoleKey.D1: AddDoctor(); break;
            case ConsoleKey.D2: AddPatient(); break;
            case ConsoleKey.D3: AddMedicament(); break;
            case ConsoleKey.D4: ViewDoctorById(); break;
            case ConsoleKey.D5: ViewPatientById(); break;
            case ConsoleKey.D6: ViewMedicamentById(); break;
            case ConsoleKey.D7: Environment.Exit(0); break;
            default: ShowConsoleMessage("Invalid Choice!"); break;
        }
    }

    private static void PrintMenu()
    {
        string menu =
            $"""
            1. Register a new {nameof(Doctor)}
            2. Register a new {nameof(Patient)}
            3. Register a new {nameof(Medicament)} 
            4. View {nameof(Doctor)} by ID
            5. View {nameof(Patient)} by ID
            6. View {nameof(Medicament)} by ID
            7. Exit
            """;

        Console.WriteLine(menu);
    }

    private static void ShowConsoleMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
