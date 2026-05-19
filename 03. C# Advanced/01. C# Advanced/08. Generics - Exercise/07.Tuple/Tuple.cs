namespace _07.Tuple;

internal class Tuple<T1, T2>
{
	public Tuple(T1 value1, T2 value2)
	{
		this.TupleData = (value1, value2);
	}

	public (T1, T2) TupleData { get; set; }

	public override string ToString()
	{
		return $"{TupleData.Item1} -> {TupleData.Item2}";
	}
}
