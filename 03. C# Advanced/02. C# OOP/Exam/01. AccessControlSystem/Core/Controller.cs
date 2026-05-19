using AccessControlSystem.Core.Contracts;
using AccessControlSystem.Models;
using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories;
using AccessControlSystem.Utilities.Messages;
using System.Net.Http.Headers;
using System.Text;

namespace AccessControlSystem.Core;

internal class Controller : IController
{
	private List<IDepartment> _departments;
	private EmployeeRepository _employeeRepository;
	private SecurityZoneRepository _securityZoneRepository;

	public Controller()
	{
		_departments = new List<IDepartment>();
		_employeeRepository = new EmployeeRepository();
		_securityZoneRepository = new SecurityZoneRepository();
	}

	public string AddDepartment(string departmentTypeName)
	{
		IDepartment? department = departmentTypeName switch
		{
			nameof(ITDepartment) => new ITDepartment(),
			nameof(HRDepartment) => new HRDepartment(),
			nameof(FinanceDepartment) => new FinanceDepartment(),
			_ => null
		};

		if (department is null) return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);

		if (_departments.Any(d => d is ITDepartment) &&
			_departments.Any(d => d is HRDepartment) &&
			_departments.Any(d => d is FinanceDepartment))
			return string.Format(OutputMessages.DepartmentExists, departmentTypeName);

		_departments.Add(department);
		return string.Format(OutputMessages.DepartmentAdded, departmentTypeName);
	}

	public string AddEmployeeToApplication(string employeeName, string employeeTypeName, int securityId)
	{
		if (_employeeRepository.GetByName(employeeName) is not null)
			return string.Format(OutputMessages.EmployeeExistsInApplication, employeeName);

		if (_employeeRepository.Models.Any(e => e.SecurityId == securityId))
			return string.Format(OutputMessages.SecurityIdExists, securityId);

		IEmployee? employee = employeeTypeName switch
		{
			nameof(GeneralEmployee) => new GeneralEmployee(employeeName, securityId),
			nameof(ITSpecialist) => new ITSpecialist(employeeName, securityId),
			_ => null
		};

		if (employee is null) return string.Format(OutputMessages.InvalidEmployeeType, employeeTypeName);

		_employeeRepository.AddNew(employee);
		return string.Format(OutputMessages.EmployeeAddedToApplication, employeeName);
	}

	public string AddEmployeeToDepartment(string employeeName, string departmentTypeName)
	{
		IEmployee employee = _employeeRepository.GetByName(employeeName);
		if (employee is null) return string.Format(OutputMessages.EmployeeNotInApplication, employeeName);

		IDepartment department = _departments.FirstOrDefault(d => d.GetType().Name == departmentTypeName);
		if (department is null && (
			departmentTypeName == nameof(ITDepartment) ||
			departmentTypeName == nameof(FinanceDepartment) ||
			departmentTypeName == nameof(HRDepartment))) return string.Format(OutputMessages.DepartmentIsNotAvailable, departmentTypeName);
		
		if (department is null) return string.Format(OutputMessages.InvalidDepartmentType, departmentTypeName);

		if (employee is ITSpecialist &&
			department is not ITDepartment)
			return string.Format(OutputMessages.ContractNotAllowed, employee.GetType().Name, departmentTypeName);

		if (employee is GeneralEmployee &&
			(department is not HRDepartment &&
			department is not FinanceDepartment))
			return string.Format(OutputMessages.ContractNotAllowed, employee.GetType().Name, departmentTypeName);

		if (department.Employees.Contains(employeeName)) return string.Format(OutputMessages.EmployeeExistsInDepartment, employeeName);

		try
		{
			department.ContractEmployee(employeeName);
		}
		catch (ArgumentException)
		{
			return string.Format(OutputMessages.DepartmentFull, departmentTypeName);
		}

		employee.AssignToDepartment(department);
		return string.Format(OutputMessages.EmployeeAddedToDepartment, employee.GetType().Name, departmentTypeName);
	}

	public string AddSecurityZone(string securityZoneName, int accessLevelRequired)
	{
		ISecurityZone securityZone = this._securityZoneRepository.GetByName(securityZoneName);
		if (securityZone is not null) return string.Format(OutputMessages.SecurityZoneExists, securityZoneName);

		securityZone = new SecurityZone(securityZoneName, accessLevelRequired);
		this._securityZoneRepository.AddNew(securityZone);
		return string.Format(OutputMessages.SecurityZoneAdded, securityZoneName);
	}

	public string AuthorizeAccess(string securityZoneName, string employeeName)
	{
		ISecurityZone securityZone = this._securityZoneRepository.GetByName(securityZoneName);
		if (securityZone is null) return string.Format(OutputMessages.SecurityZoneNotFound, securityZoneName);

		IEmployee employee = this._employeeRepository.GetByName(employeeName);
		if (employee is null) return string.Format(OutputMessages.EmployeeNotInApplication, employeeName);

		if (employee.Department is null ||
			employee.Department.SecurityLevel < securityZone.AccessLevelRequired)
			return string.Format(OutputMessages.AccessDenied, employeeName, securityZoneName);

		if (securityZone.AccessLog.Contains(employee.SecurityId))
			return string.Format(OutputMessages.EmployeeAlreadyAuthorized, employeeName, securityZoneName);

		securityZone.LogAccessKey(employee.SecurityId);
		return string.Format(OutputMessages.EmployeeAuthorized, employeeName, securityZoneName);
	}

	public string SecurityReport()
	{
		StringBuilder sb = new();

		sb.AppendLine("Security Report:");

		List<ISecurityZone> orderedSecurityZone = _securityZoneRepository.Models
			.OrderByDescending(z => z.AccessLevelRequired)
			.ToList();

		foreach (ISecurityZone securityZone in orderedSecurityZone)
		{
			sb.AppendLine($"-{securityZone.Name} (Access level required: {securityZone.AccessLevelRequired})");

			List<IEmployee> employeesInSecurityZone = _employeeRepository.Models
				.Where(e => securityZone.AccessLog.Contains(e.SecurityId))
				.OrderBy(e => e.Name)
				.ToList();

			foreach (IEmployee employee in employeesInSecurityZone)
				sb.AppendLine($"--{employee}");
		}

		return sb.ToString().Trim();
	}}