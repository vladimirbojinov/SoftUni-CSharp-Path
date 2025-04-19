namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixNum = int.Parse(Console.ReadLine());

            MatrixPrinter(matrixNum);
        }

        static void MatrixPrinter(int matrixNum)
        {
            for (int i = 0; i < matrixNum; i++)
            {
                for (int j = 0; j < matrixNum; j++)
                {
                    Console.Write(matrixNum + " ");
                }

                Console.WriteLine();
            }
        }
    }
}