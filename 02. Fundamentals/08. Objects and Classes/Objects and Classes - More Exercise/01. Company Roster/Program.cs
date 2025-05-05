namespace _01._Company_Roster
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Employee> employees = new List<Employee>();

			int employeesCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < employeesCount; i++)
			{
				string[] data = Console.ReadLine().Split();

				string name = data[0];
				double salary = double.Parse(data[1]);
				string department = data[2];

				Employee employee = new Employee(name, salary, department);
				employees.Add(employee);
			}

			List<Employee> sortedEmployees = 
				FindBestDepartmentBySalary(employees)
				.OrderByDescending(e => e.Salary)
				.ToList();

			string bestDepartment = sortedEmployees.FirstOrDefault().Department;
			Console.WriteLine($"Highest Average Salary: {bestDepartment}");
			Console.WriteLine(string.Join("\n", sortedEmployees));
		}

		private static List<Employee> FindBestDepartmentBySalary(List<Employee> employees)
		{
			List<string> departments = new List<string>();
			foreach (Employee employee in employees)
			{
				if (!departments.Contains(employee.Department))
				{
					departments.Add(employee.Department);
				}
			}

			string bestDepartment = string.Empty;
			double bestAverageSalary = 0;

			foreach (string department in departments)
			{
				List<Employee> sortedEmployees = employees
					.Where(e => e.Department == department)
					.ToList();

				double averageSalary = sortedEmployees.Average(e => e.Salary);
				if (bestAverageSalary < averageSalary)
				{
					bestAverageSalary = averageSalary;
					bestDepartment = department;
				}
			}

			return employees.Where(e => e.Department == bestDepartment).ToList();
		}
	}

	class Employee
	{
		public Employee(string name, double salary, string department)
		{
			Name = name;
			Salary = salary;
			Department = department;
		}

		public string Name { get; set; }
		public double Salary { get; set; }
		public string Department { get; set; }

		public override string ToString()
		{
			return $"{Name} {Salary:F2}";
		}
	}
}