namespace CustomStack;

public class StackOfStrings
{
	public StackOfStrings()
	{
		Stack = new Stack<string>();
	}

	public Stack<string> Stack { get; set; }

	public void Push(string value)
		=> Stack.Push(value);

	public void Pop()
		=> Stack.Pop();

	public bool IsEmpty()
		=> Stack.Any();

	public Stack<string> AddRange(int range)
	{
		Stack<string> newStack = this.Stack;

		for (int i = 0; i < range; i++) newStack.Push(string.Empty);
		this.Stack = newStack;

		return newStack;
	}
}
