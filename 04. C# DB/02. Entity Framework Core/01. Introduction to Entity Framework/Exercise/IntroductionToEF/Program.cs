namespace SoftUni;

using SoftUni.Data;
using SoftUni.Models;
using System.Text;

public class StartUp
{
    static void Main()
    {
        SoftUniContext dbContext = new();

        //Console.WriteLine(GetEmployeesFullInformation(dbContext));
        //Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));
        //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
        //Console.WriteLine(AddNewAddressToEmployee(dbContext));
        //Console.WriteLine(GetEmployeesInPeriod(dbContext));
        //Console.WriteLine(GetAddressesByTown(dbContext));
        //Console.WriteLine(GetEmployee147(dbContext));
        //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));
        //Console.WriteLine(GetLatestProjects(dbContext));
        //Console.WriteLine(IncreaseSalaries(dbContext));
        //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));
        //Console.WriteLine(DeleteProjectById(dbContext));
        Console.WriteLine(RemoveTown(dbContext));
    }

    // 03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");

        return sb.ToString().Trim();
    }

    // 04. Employees with Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        const int salaryThreshold = 50000;

        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > salaryThreshold)
            .OrderBy(e => e.FirstName)
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");

        return sb.ToString().Trim();
    }

    // 05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        const string departmentFilter = "Research and Development";

        var employees = context.Employees
            .Where(e => e.Department.Name == departmentFilter)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");

        return sb.ToString().Trim();
    }

    // 06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Employee nakovEmployee = context.Employees
            .First(e => e.LastName == "Nakov");

        nakovEmployee.Address = new Address
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        context.SaveChanges();
        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Select(e => new
            {
                AddressName = e.Address.AddressText
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
            sb.AppendLine(e.AddressName);

        return sb.ToString().Trim();
    }

    // 07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Select(ep => ep.Project)
                    .Where(p => p.StartDate.Year >= 2001 && 2003 >= p.StartDate.Year)
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
            foreach (Project p in e.Projects)
                sb.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {(p.EndDate?.ToString("M/d/yyyy h:mm:ss tt") ?? "not finished")}");
        }

        return sb.ToString().Trim();
    }

    // 08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeesCount = a.Employees.Count
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new();
        foreach (var a in addresses)
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");

        return sb.ToString().Trim();
    }

    // 09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        const int searchedEmployeeId = 147;

        var employee = context.Employees
            .Where(e => e.EmployeeId == searchedEmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Select(ep => ep.Project)
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employee)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            foreach (Project p in e.Projects)
                sb.AppendLine(p.Name);
        }

        return sb.ToString().Trim();
    }

    // 10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
            foreach (Employee e in d.Employees)
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
        }

        return sb.ToString().Trim();
    }

    // 11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        var projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .OrderBy(p => p.Name)
            .ToArray();

        StringBuilder sb = new();
        foreach (var p in projects)
        {
            sb.AppendLine(p.Name);
            sb.AppendLine(p.Description);
            sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString();
    }

    // 12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        List<string> targetDepartments =
        [
            "Engineering",
            "Tool Design",
            "Marketing",
            "Information Services"
        ];

        Employee[] selectedEmployees = context.Employees
            .Where(e => targetDepartments.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (Employee e in selectedEmployees)
        {
            e.Salary *= 1.12m;
        }

        context.SaveChanges();

        StringBuilder sb = new();
        foreach (var e in selectedEmployees)
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");

        return sb.ToString();
    }

    // 13. Find Employees by First Name Starting with "Sa"
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .Select( e=> new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        StringBuilder sb = new();
        foreach (var e in employees)
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");

        return sb.ToString();
    }

    // 14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        const int idToDelete = 2;

        var projectToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == idToDelete);
        context.EmployeesProjects.RemoveRange(projectToDelete);

        Project? project = context.Projects.Find(idToDelete);
        context.Projects.Remove(project);

        context.SaveChanges();

        var projects = context.Projects
            .Select(p => new
            {
                p.Name
            })
            .Take(10)
            .ToArray();

        StringBuilder sb = new();
        foreach (var p in projects)
            sb.AppendLine(p.Name);

        return sb.ToString();
    }

    // 15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        const string townNameFilter = "Seattle";

        Town townToDelete = context.Towns
            .First(t => t.Name == townNameFilter);

        Address[] addressesToDelete = context.Addresses
            .Where(a => a.TownId == townToDelete.TownId)
            .ToArray();

        Employee[] employeesToUpdate = context.Employees
            .Where(e => addressesToDelete.Contains(e.Address))
            .ToArray();
       
        foreach (Employee e in employeesToUpdate)
        {
            e.AddressId = null;
        }

        int deletedAddressesCount = addressesToDelete.Length;

        context.Addresses.RemoveRange(addressesToDelete);
        context.Towns.Remove(townToDelete);

        context.SaveChanges();

        return $"{deletedAddressesCount} addresses in {townNameFilter} were deleted";
    }
}
