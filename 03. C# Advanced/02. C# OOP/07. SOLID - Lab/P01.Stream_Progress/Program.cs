using System;

namespace P01.Stream_Progress;

public class Program
{
    static void Main()
    {
        Music music = new("Someone", "TheSomething", "something.mp4", 20, 50);

        StreamProgressInfo streamProgressInfo = new(music);
		Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
    }
}
