using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Repositories.Contracts;

namespace AccessControlSystem.Repositories;

internal class SecurityZoneRepository : IRepository<ISecurityZone>
{
	private List<ISecurityZone> _models;

	public SecurityZoneRepository()
	{
		this._models = new();
		this.Models = this._models.AsReadOnly();
	}

	public IReadOnlyCollection<ISecurityZone> Models { get; }

	public void AddNew(ISecurityZone model)
		=> this._models.Add(model);

	public ISecurityZone GetByName(string modelName)
		=> this._models.FirstOrDefault(m => m.Name == modelName);

	public int SecurityCheck(string modelName)
	{
		ISecurityZone securityZone = GetByName(modelName);

		return securityZone.AccessLevelRequired;
	}
}
