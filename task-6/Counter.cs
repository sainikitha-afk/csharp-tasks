using System;

// Delegate definition
public delegate void ThresholdReachedHandler(int count);

public class Counter
{
    private int _count = 0;
    private int _threshold;

    // Event based on delegate
    public event ThresholdReachedHandler ThresholdReached;

    public Counter(int threshold)
    {
        _threshold = threshold;
    }

    public void Increment()
    {
        _count++;

        Console.WriteLine($"Counter: {_count}");

        if (_count == _threshold)
        {
            OnThresholdReached();
        }
    }

    protected virtual void OnThresholdReached()
    {
        ThresholdReached?.Invoke(_count);
    }
}