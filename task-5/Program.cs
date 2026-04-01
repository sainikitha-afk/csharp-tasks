using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        try
        {
            // Read all text
            string content = File.ReadAllText(inputFile);

            // Process data
            int lineCount = File.ReadAllLines(inputFile).Length;
            int wordCount = content.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            string result = $"Lines: {lineCount}\nWords: {wordCount}";

            // Write result
            File.WriteAllText(outputFile, result);

            Console.WriteLine("Processing complete.");
            Console.WriteLine(result);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Input file not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }
}