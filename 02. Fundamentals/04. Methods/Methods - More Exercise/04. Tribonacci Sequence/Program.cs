namespace _04._Tribonacci_Sequence
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());
			int[] array = TribonacciSequence(num);

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					Console.Write($"{array[i]} ");
				}
			}
		}

		private static int[] TribonacciSequence(int num)
		{
			int[] array = new int[num + 2];
			array[0] = 0;
			array[1] = 0;
			array[2] = 1;

			for (int i = 3; i < array.Length; i++)
			{
				array[i] = array[i - 1] + array[i - 2] + array[i - 3];
			}

			return array;
		}

		/* RECURSIVE 
		private static int PrintTribonacciNum(int num)
		{
			if (num <= 0) return 0;
			else if (num == 1) return 1;
			else
			{
				return
					PrintTribonacciNum(num - 1) +
					PrintTribonacciNum(num - 2) +
					PrintTribonacciNum(num - 3);
			}
		}*/
	}
}
