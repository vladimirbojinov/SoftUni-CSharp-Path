using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loop = int.Parse(Console.ReadLine());
            string[] arrayOfNames = new string[loop];
            int[] decryptedNames = new int[arrayOfNames.Length];
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
                        case 'a':
                        case 'A':
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

                decryptedNames[i] = sum;
                sum = 0;
            }

            Array.Sort(decryptedNames);
            foreach (var i in decryptedNames)
            {
                Console.WriteLine(i);
            }
        }
    }
}