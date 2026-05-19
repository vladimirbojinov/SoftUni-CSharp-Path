using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

internal class EmployeeRepository : IRepository<IEmployee>
{
	private List<IEmployee> _models;

	public EmployeeRepository()
	{
		this._models = new();
		this.Models = this._models.AsReadOnly();
	}

	public IReadOnlyCollection<IEmployee> Models { get; }

	public void AddNew(IEmployee model)
		=> this._models.Add(model);

	public IEmployee GetByName(string modelName)
		=> this._models.FirstOrDefault(m => m.Name == modelName);

	public int SecurityCheck(string modelName)
	{
		IEmployee employee = GetByName(modelName);

		if (employee.Department == null) return 0;
		else return employee.Department.SecurityLevel;
	}
}
