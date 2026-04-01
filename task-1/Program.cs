using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class TaskItem
{
    public string Title { get; set; }
    public bool IsDone { get; set; }
}

class Program
{
    static string filePath = "tasks.json";
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        LoadTasks();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== TASK MANAGER ===\n");
            Console.ResetColor();

            ShowTasks();

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Mark Complete");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Exit");

            Console.Write("\nChoose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": AddTask(); break;
                case "2": MarkComplete(); break;
                case "3": DeleteTask(); break;
                case "4": SaveTasks(); return;
            }
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet!");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            var t = tasks[i];

            if (t.IsDone)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"{i + 1}. [{(t.IsDone ? "✔" : " ")}] {t.Title}");
            Console.ResetColor();
        }
    }

    static void AddTask()
    {
        Console.Write("\nEnter task: ");
        string title = Console.ReadLine();

        tasks.Add(new TaskItem { Title = title, IsDone = false });
        SaveTasks();
    }

    static void MarkComplete()
    {
        Console.Write("\nTask number: ");
        int i = int.Parse(Console.ReadLine()) - 1;

        if (i >= 0 && i < tasks.Count)
        {
            tasks[i].IsDone = true;
            SaveTasks();
        }
    }

    static void DeleteTask()
    {
        Console.Write("\nTask number: ");
        int i = int.Parse(Console.ReadLine()) - 1;

        if (i >= 0 && i < tasks.Count)
        {
            tasks.RemoveAt(i);
            SaveTasks();
        }
    }

    static void SaveTasks()
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}