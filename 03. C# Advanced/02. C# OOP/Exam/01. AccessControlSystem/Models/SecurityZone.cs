using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;
using System.Security;

namespace AccessControlSystem.Models;

internal class SecurityZone : ISecurityZone
{
	private List<int> _accessLog;

	public SecurityZone(string name, int accessLevelRequired)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidSecurityZoneName);
		if (accessLevelRequired < 0) throw new ArgumentException(ExceptionMessages.InvalidAccessLevel);

		this.Name = name;
		this.AccessLevelRequired = accessLevelRequired;

		this._accessLog = new List<int>();
		this.AccessLog = this._accessLog.AsReadOnly();
	}

	public string Name { get; }

	public int AccessLevelRequired { get; }

	public IReadOnlyCollection<int> AccessLog { get; }

	public void LogAccessKey(int securityId)
		=> this._accessLog.Add(securityId);
}
