namespace _08.Threeuple;

internal class Tuple<T1, T2, T3>
{
	public Tuple(T1 value1, T2 value2, T3 value3)
	{
		this.TupleData = (value1, value2, value3);
	}

	public (T1, T2, T3) TupleData { get; set; }

	public override string ToString()
	{
		return $"{TupleData.Item1} -> {TupleData.Item2} -> {TupleData.Item3}";
	}
}
