namespace Database.Tests
{
    using NUnit.Framework;
	using System;

	[TestFixture]
    public class DatabaseTests
    {
        private const int BaseCapacity = 16;

        [TestCase(BaseCapacity), TestCase(1), TestCase(0)]
        public void DatabaseShouldBeInitializedCorrectly(int n)
        {
            int[] array = FillArray(n);
            Database database = new(array);

            Assume.That(database.Fetch(), Is.EqualTo(array));
            Assume.That(database.Count, Is.EqualTo(array.Length));
        }

		[Test]
		public void DatabaseShouldThrowExceptionWhenAboveCapacity()
        {
			int[] array = FillArray(BaseCapacity + 1);

            Assume.That(() => new Database(array), Throws.TypeOf<InvalidOperationException>());
		}

        [TestCase(BaseCapacity), TestCase(5)]
        public void DatabaseShouldRemoveElementsCorrectly(int n)
        {
            int[] array = FillArray(n);
            Database database = new(array);

            database.Remove();

			Assume.That(database.Count, Is.EqualTo(array.Length - 1));
        }

        [Test]
        public void EmptyDatabaseShouldThrowExceptionWhenRemoving()
        {
			int[] array = FillArray(0);
			Database database = new(array);

			Assume.That(() => database.Remove(), Throws.TypeOf<InvalidOperationException>());
		}


		private static int[] FillArray(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i < n; i++) array[i] = i;

            return array;
        }
    }
}
