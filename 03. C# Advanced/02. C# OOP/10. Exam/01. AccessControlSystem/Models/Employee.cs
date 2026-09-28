using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models;

public abstract class Employee : IEmployee
{
	protected Employee(string name, int securityId)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidEmployeeName);
		if (securityId < 100 || securityId > 999) throw new ArgumentException(ExceptionMessages.InvalidSecurityId);

		this.Name = name;
		this.SecurityId = securityId;
	}

	public string Name { get; }

	public IDepartment Department { get; private set; }

	public int SecurityId { get; }

	public void AssignToDepartment(IDepartment department)
		=> this.Department = department;

	public override string ToString()
		=> $"Employee: {this.Name}, Department: {this.Department.GetType().Name}, Security ID: {this.SecurityId}";
}
