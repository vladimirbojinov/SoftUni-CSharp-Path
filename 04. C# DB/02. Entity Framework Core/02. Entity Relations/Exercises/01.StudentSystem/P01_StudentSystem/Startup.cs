namespace P01_StudentSystem;

using P01_StudentSystem.Data;

public class Startup
{
    static void Main(string[] args)
    {
        using StudentSystemContext context = new();
    }
}
