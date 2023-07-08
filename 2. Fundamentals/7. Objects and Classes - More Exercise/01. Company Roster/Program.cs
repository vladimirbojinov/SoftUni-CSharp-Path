using System.Security.Cryptography.X509Certificates;

namespace _01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeesList = new List<Employee>();
            List<Employee> bestDepartment = new List<Employee>();

            string highestSalaryDepartment = string.Empty;
            double maxSalary = int.MinValue; 
            int employeeNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeeNumber; i++)
            {
                string[] employeeData = Console.ReadLine().Split();
                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string department = employeeData[2];

                if (maxSalary < salary)
                {
                    maxSalary = salary;
                    highestSalaryDepartment = department;
                }

                Employee employee = new Employee(name, salary, department);
                employeesList.Add(employee);
            }

            foreach (Employee employee in employeesList)
            {
                if (employee.Department == highestSalaryDepartment)
                {
                    bestDepartment.Add(employee);
                }
            }

            var sortedList = bestDepartment.OrderByDescending(x => x.Salary);

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment}");
            Console.WriteLine(string.Join("\n", sortedList));
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