namespace AccessControlSystem.Models;

internal class FinanceDepartment : Department
{
	private const int DefaultSecurityLevel = 4;
	private const int DefaultMaxEmployeesCount = 3;

	public FinanceDepartment()
		: base(DefaultSecurityLevel, DefaultMaxEmployeesCount) { }
}
