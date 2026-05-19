using System.Collections.Generic;

namespace P03.DetailPrinter;

class Program
{
	static void Main()
	{
		Employee employee = new("Ivan");

		List<string> documents = new() { "file1.txt", "file2.pdf", "file3.ppx" };
		Manager manager = new("Georgi", documents);

		List<Employee> employees = new() { employee, manager };
		DetailsPrinter printer = new(employees);
		printer.PrintDetails();
	}
}
