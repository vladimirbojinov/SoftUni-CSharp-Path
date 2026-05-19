using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;
using System.Runtime.ExceptionServices;

namespace AccessControlSystem.Models;

public abstract class Department : IDepartment
{
	private List<string> _employees;

	public Department(int securityLevel, int maxEmployeesCount)
	{
		this.SecurityLevel = securityLevel;
		this.MaxEmployeesCount = maxEmployeesCount;

		this._employees = new List<string>();
		this.Employees = this._employees.AsReadOnly(); ;
	}

	public int SecurityLevel { get; }

	public int MaxEmployeesCount { get; }

	public IReadOnlyCollection<string> Employees { get; }


	public void ContractEmployee(string employeeName)
	{
		if (this.Employees.Count == this.MaxEmployeesCount)
			throw new ArgumentException(ExceptionMessages.InvalidDepartmentCapacity);

		if (this.Employees.Contains(employeeName))
			throw new ArgumentException(ExceptionMessages.EmployeeAlreadyAdded);

		this._employees.Add(employeeName);
	}
}
