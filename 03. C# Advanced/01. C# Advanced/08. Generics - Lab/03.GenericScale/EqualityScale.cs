namespace GenericScale
{
	public class EqualityScale<T>
	{
		private T left { get; set; }
		private T right { get; set; }

		public EqualityScale(T left, T right)
		{
			this.left = left;
			this.right = right;
		}

		public bool AreEqual()
		{
			bool areEqual = left.Equals(right);
			return areEqual;
		}
	}
}
