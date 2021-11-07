using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeTable
{
    public class Program
    {
        public static List<(int, string)> tasks = new List<(int, string)>
        {
            (55,"WORK"),
            (5,"REST NO MONITORS!"),
            (25,"WORK"),
            (30,"MEETINGS"),
            (5,"REST NO MONITORS!"),
            (50,"WORK"),
            (5,"REST NO MONITORS!"),
            (60,"STUDY"),
            (30,"NAP"),
            (30,"LUNCH"),
            (25,"WORK"),
            (5,"REST NO MONITORS!"),
            (55,"STUDY"),
            (5,"REST NO MONITORS!"),
            (55,"WORK"),
            (5,"REST NO MONITORS!"),
            (55,"WORK"),
            (5,"REST NO MONITORS!"),
            (30,"WORK")
        };

        private static async Task Main(string[] args)

        {
            var time = DateTime.Now;
            Console.Title = "Schedule";
            var lastTask = "";
            while (true)
            {
                time = DateTime.Now;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                var startHour = 12;
                var endHour = 13;
                if (time.Hour <= startHour - 1 || time.Hour >= endHour)
                {
                    Console.WriteLine("Out of work");
                    break;
                }

                var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endHour, 0, 0);
                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startHour, 0, 0);

                var allTasksTime = 0;
                tasks.ForEach(x => allTasksTime += x.Item1);
                var tickLength = (endDate - startDate) / allTasksTime;
                var currentTick = (time - startDate) / tickLength;

                var name = CurrentTask(currentTick);
                var timeLeft = name.Item2 * tickLength;
                if (lastTask == name.Item1)
                {
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(5000);
                }
                else
                {
                    lastTask = name.Item1;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(500);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(500);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(500);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(500);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                    await Task.Delay(500);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(
                        $"Time remaining: {timeLeft.Hours}:{timeLeft.Minutes}:{timeLeft.Seconds}. Current task: {name.Item1}");
                }
            }
        }

        private static (string, float) CurrentTask(double currentTick)
        {
            var timeLeft = currentTick;
            foreach (var task in tasks)
            {
                timeLeft -= task.Item1;
                if (timeLeft < 0)
                {
                    return ((string, float))(task.Item2, -timeLeft);
                }
            }

            return (null, 0);
        }
    }
}