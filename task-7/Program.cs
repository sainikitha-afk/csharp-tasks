using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Async Data Aggregator ===");

        var fetcher = new DataFetcher();

        var stopwatch = Stopwatch.StartNew();

        var tasks = new List<Task<string>>
        {
            SafeFetch(fetcher, "Source A", 2000),
            SafeFetch(fetcher, "Source B", 3000),
            SafeFetch(fetcher, "Source C", 1500),
            SafeFetch(fetcher, "Source D", 2500)
        };

        string[] results = await Task.WhenAll(tasks);

        stopwatch.Stop();

        Console.WriteLine("\nResults:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

        Console.WriteLine($"\nTotal Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Wrapper to handle exceptions per task
    static async Task<string> SafeFetch(DataFetcher fetcher, string name, int delay)
    {
        try
        {
            return await fetcher.FetchFromSourceAsync(name, delay);
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}