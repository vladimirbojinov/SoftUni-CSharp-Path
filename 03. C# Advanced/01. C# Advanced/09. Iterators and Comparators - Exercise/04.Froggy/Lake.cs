using System.Collections;

namespace _04.Froggy;

public class Lake : IEnumerable<int>
{
	public Lake(string values)
	{
		StonesList = new List<int>(values.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
	}
	public List<int> StonesList { get; set; }

	public IEnumerator<int> GetEnumerator()
	{
		for (int i = 0; i < StonesList.Count; i++)
		{
			if (i % 2 == 0) yield return StonesList[i];
		}

		for (int i = StonesList.Count - 1; i >= 0; i--)
		{
			if (i % 2 != 0) yield return StonesList[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
		=> GetEnumerator();
}
