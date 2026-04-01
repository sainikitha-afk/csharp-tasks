using System;

public class TaskA
{
    [Runnable]
    public void Execute()
    {
        Console.WriteLine("TaskA executed.");
    }

    public void NotRunnable()
    {
        Console.WriteLine("This should not run.");
    }
}