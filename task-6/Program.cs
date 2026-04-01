using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Counter Event Demo ===");

        Counter counter = new Counter(5);

        // Subscribe event handlers
        counter.ThresholdReached += NotifyUser;
        counter.ThresholdReached += LogEvent;

        for (int i = 0; i < 7; i++)
        {
            counter.Increment();
        }
    }

    // Event handler 1
    static void NotifyUser(int count)
    {
        Console.WriteLine($"[Notification] Threshold reached at {count}");
    }

    // Event handler 2
    static void LogEvent(int count)
    {
        Console.WriteLine($"[Logger] Event triggered when count = {count}");
    }
}