using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Person Introduction App ===");

        // Creating objects
        Person person1 = new Person("Alice", 22);
        Person person2 = new Person("Bob", 30);
        Person person3 = new Person("Charlie", 25);

        // Calling method
        person1.Introduce();
        person2.Introduce();
        person3.Introduce();
    }
}