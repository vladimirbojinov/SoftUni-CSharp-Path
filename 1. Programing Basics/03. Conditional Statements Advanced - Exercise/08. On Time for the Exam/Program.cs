namespace _08._On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minOfArrival = int.Parse(Console.ReadLine());

            int examTotalMin = hourOfExam * 60 + minOfExam;
            int arrivalTotalMin = hourOfArrival * 60 + minOfArrival;

            if (arrivalTotalMin > examTotalMin)
            {
                Console.WriteLine("Late");
                int minDiff = arrivalTotalMin - examTotalMin;
                if (minDiff < 60)
                {
                    Console.WriteLine($"{minDiff} minutes after the start");
                }
                else
                {
                    int hours = minDiff / 60;
                    int min = minDiff % 60;
                    Console.WriteLine($"{hours}:{min:d2} hours after the start");
                }
            }
            else if(arrivalTotalMin < examTotalMin - 30)
            {
                Console.WriteLine("Early");
                int minDiff = examTotalMin - arrivalTotalMin;
                if (minDiff < 60)
                {
                    Console.WriteLine($"{minDiff} minutes before the start");
                }
                else
                {
                    int hours = minDiff / 60;
                    int min = minDiff % 60;
                    Console.WriteLine($"{hours}:{min:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                int minDiff = examTotalMin - arrivalTotalMin;
                Console.WriteLine($"{minDiff} minutes before the start");
            }
        }
    }
}