using System.IO.Pipes;

namespace AccessControlSystem.Models;

internal class ITDepartment : Department
{
	private const int DefaultSecurityLevel = 5;
	private const int DefaultMaxEmployeesCount = 8;

	public ITDepartment()
		: base(DefaultSecurityLevel, DefaultMaxEmployeesCount) { }
}
