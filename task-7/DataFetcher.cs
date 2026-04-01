using System;
using System.Threading.Tasks;

public class DataFetcher
{
    private static Random random = new Random();

    public async Task<string> FetchFromSourceAsync(string sourceName, int delay)
    {
        Console.WriteLine($"Fetching from {sourceName}...");

        await Task.Delay(delay);

        // Simulate random failure
        if (random.Next(0, 5) == 0)
        {
            throw new Exception($"{sourceName} failed.");
        }

        return $"{sourceName} data received";
    }
}