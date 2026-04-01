using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Student Management System ===");

        List<Student> students = new List<Student>
        {
            new Student("Alice", 85, 20),
            new Student("Bob", 72, 21),
            new Student("Charlie", 90, 19),
            new Student("David", 65, 22),
            new Student("Eve", 88, 20)
        };

        Console.Write("Enter grade threshold: ");
        int threshold = int.Parse(Console.ReadLine());

        var filteredStudents = students
            .Where(s => s.Grade > threshold)
            .OrderBy(s => s.Name);

        Console.WriteLine("\nFiltered and Sorted Students:");

        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"{student.Name} | Grade: {student.Grade} | Age: {student.Age}");
        }
    }
}