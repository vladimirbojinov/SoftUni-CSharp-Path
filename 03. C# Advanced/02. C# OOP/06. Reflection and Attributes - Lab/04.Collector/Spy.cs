using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
	public string StealFieldInfo(string investigated, params string[] investigatedData)
	{
		Type classType = Type.GetType(investigated);
		FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

		object classInstance = Activator.CreateInstance(classType, new object[] { });

		StringBuilder stringBuilder = new();
		stringBuilder.AppendLine($"Class under investigation: {investigated}");
		classFields.ToList().ForEach(f => stringBuilder.AppendLine($"{f.Name} = {f.GetValue(classInstance)}"));

		return stringBuilder.ToString().Trim();
	}

	public string AnalyzeAccessModifiers(string investigated)
	{
		StringBuilder stringBuilder = new();

		Type classType = Type.GetType(investigated);
		FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
		MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

		List<MethodInfo> methodsList = new();
		methodsList.AddRange(classPublicMethods);
		methodsList.AddRange(classNonPublicMethods);

		classFields.ToList().ForEach(f => stringBuilder.AppendLine($"{f.Name} must be private"));

		foreach (MethodInfo method in methodsList)
		{
			if (method.Name.StartsWith("get")) stringBuilder.AppendLine($"{method.Name} have to be public");
			else if (method.Name.StartsWith("set")) stringBuilder.AppendLine($"{method.Name} have to be private");
		}

		return stringBuilder.ToString().Trim();
	}

	public string RevealPrivateMethods(string investigated)
	{
		StringBuilder stringBuilder = new();

		Type classType = Type.GetType(investigated);
		MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

		stringBuilder.AppendLine($"All Private Methods of Class: {classType.FullName}");
		stringBuilder.AppendLine($"Base Class {classType.BaseType.Name}");
		classNonPublicMethods.ToList().ForEach(m => stringBuilder.AppendLine(m.Name));

		return stringBuilder.ToString().Trim();
	}

	public string CollectGettersAndSetters(string investigated)
	{
		StringBuilder stringBuilder = new();

		Type classType = Type.GetType(investigated);
		MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		foreach (MethodInfo method in classMethods)
		{
			if (method.Name.StartsWith("get") || method.Name.StartsWith("set"))
				stringBuilder.AppendLine($"{method.Name} will return {method.ReturnParameter}");
		}

		return stringBuilder.ToString().Trim();
	}
}
