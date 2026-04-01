using System;

class Program
{
    static void Main(string[] args)
    {
        IRepository<Product> repo = new InMemoryRepository<Product>();
        bool running = true;

        Console.WriteLine("=== Product Management System ===");

        while (running)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(repo);
                    break;

                case "2":
                    ViewProducts(repo);
                    break;

                case "3":
                    UpdateProduct(repo);
                    break;

                case "4":
                    DeleteProduct(repo);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddProduct(IRepository<Product> repo)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        repo.Add(new Product(id, name, price));
        Console.WriteLine("Product added.");
    }

    static void ViewProducts(IRepository<Product> repo)
    {
        var products = repo.GetAll();

        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id} | {p.Name} | {p.Price}");
        }
    }

    static void UpdateProduct(IRepository<Product> repo)
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter new name: ");
        string name = Console.ReadLine();

        Console.Write("Enter new price: ");
        double price = double.Parse(Console.ReadLine());

        repo.Update(id, new Product(id, name, price));
        Console.WriteLine("Product updated.");
    }

    static void DeleteProduct(IRepository<Product> repo)
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        repo.Delete(id);
        Console.WriteLine("Product deleted.");
    }
}