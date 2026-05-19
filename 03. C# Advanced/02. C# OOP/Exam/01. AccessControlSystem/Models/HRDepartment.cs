namespace AccessControlSystem.Models;

internal class HRDepartment : Department
{
	private const int DefaultSecurityLevel = 3;
	private const int DefaultMaxEmployeesCount = 5;

	public HRDepartment()
		: base(DefaultSecurityLevel, DefaultMaxEmployeesCount) { }
}
