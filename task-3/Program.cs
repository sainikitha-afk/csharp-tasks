using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> items = new List<string>();
        bool running = true;

        Console.WriteLine("=== List Manager App ===");

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item");
            Console.WriteLine("3. Display items");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            string input = Console.ReadLine().Trim();

            switch (input)
            {
                case "1":
                    AddItem(items);
                    break;

                case "2":
                    RemoveItem(items);
                    break;

                case "3":
                    DisplayItems(items);
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Exiting app...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddItem(List<string> items)
    {
        Console.Write("Enter item: ");
        string item = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(item))
        {
            items.Add(item.ToUpper());
            Console.WriteLine("Item added.");
        }
        else
        {
            Console.WriteLine("Empty input not allowed.");
        }
    }

    static void RemoveItem(List<string> items)
    {
        Console.Write("Enter item to remove: ");
        string item = Console.ReadLine().Trim().ToUpper();

        if (items.Remove(item))
        {
            Console.WriteLine("Item removed.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    static void DisplayItems(List<string> items)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Console.WriteLine("\nItems:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }
    }
}