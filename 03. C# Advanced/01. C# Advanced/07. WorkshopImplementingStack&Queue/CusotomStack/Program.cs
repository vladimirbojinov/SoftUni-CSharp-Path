namespace CustomStack;

internal class Program
{
    static void Main(string[] args)
    {
        CustomStack<int> customStack = new();

        customStack.Push(1);
        customStack.Push(2);
        customStack.Push(3);
		customStack.Pop();
		customStack.Push(4);

		Console.WriteLine("CustomStack result:");
		foreach (int i in customStack)
        {
            Console.WriteLine(i);
        }
    }
}
