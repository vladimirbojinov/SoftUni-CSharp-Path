using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
	public string StealFieldInfo(string investigated, params string[] investigatedData)
	{
		Type classType = Type.GetType(investigated);
		FieldInfo[] classFields = classType
			.GetFields(BindingFlags.Instance |
			BindingFlags.Static |
			BindingFlags.NonPublic |
			BindingFlags.Public);

		object classInstance = Activator.CreateInstance(classType, new object[] { });

		StringBuilder stringBuilder = new();
		stringBuilder.AppendLine($"Class under investigation: {investigated}");
		classFields.ToList().ForEach(f => stringBuilder.AppendLine($"{f.Name} = {f.GetValue(classInstance)}"));

		return stringBuilder.ToString().Trim();
	}
}
