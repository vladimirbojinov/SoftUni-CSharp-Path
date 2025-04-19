namespace _01._Encrypt__Sort_and_Print_Array
{
	internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());
            string[] arrayOfNames = new string[loop];
            int[] encryptedNames = new int[arrayOfNames.Length];
            int sum = 0;

            for (int i = 0; i < loop; i++)
            {
                arrayOfNames[i] = Console.ReadLine();
                string name = arrayOfNames[i];
                for (int j = 0; j < name.Length; j++)
                {
                    char letter = name[j];
                    switch (letter)
                    {
                        case 'A':
                        case 'a':
                        case 'E':
                        case 'e':
                        case 'I':
                        case 'i':
                        case 'O':
                        case 'o':
                        case 'U':
                        case 'u':
                            sum += (int)letter * name.Length;
                            break;
                        default:
                            sum += (int)letter / name.Length; break;
                    }
                }

                encryptedNames[i] = sum;
                sum = 0;
            }

            Array.Sort(encryptedNames);
			foreach (int encryptedName in encryptedNames)
            {
                Console.WriteLine(encryptedName);
            }
        }
    }
}