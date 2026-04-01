using System;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Reflection Runner ===");

        var assembly = Assembly.GetExecutingAssembly();

        var runnableMethods = assembly.GetTypes()
            .SelectMany(type => type.GetMethods())
            .Where(method => method.GetCustomAttributes(typeof(RunnableAttribute), false).Length > 0);

        foreach (var method in runnableMethods)
        {
            Console.WriteLine($"\nExecuting: {method.DeclaringType.Name}.{method.Name}");

            var instance = Activator.CreateInstance(method.DeclaringType);
            method.Invoke(instance, null);
        }
    }
}