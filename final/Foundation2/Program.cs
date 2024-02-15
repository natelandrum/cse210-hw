using System;

class Program
{
    static void Main(string[] args)
    {
        Order o1 = new Order(new Customer("John Doe", new Address("123 Main St", "Anytown", "NY", "USA")));
        o1.AddProduct(new Product("Widget", 1, 10.99, 2));
        o1.AddProduct(new Product("Gadget", 2, 7.45, 3));

        Console.WriteLine(o1.GeneratePackingLabel());
        Console.WriteLine(o1.GenerateShippingLabel());
        Console.WriteLine(@$"
Total: ${o1.GetTotalPrice()}");

        Order o2 = new Order(new Customer("Jane Doe", new Address("456 Roble St", "Othertown", "Tlalnepantla", "Mexico")));
        o2.AddProduct(new Product("Screwdriver", 3, 3.25, 2));
        o2.AddProduct(new Product("Hatchet", 4, 12.99, 1));

        Console.WriteLine();
        Console.WriteLine(o2.GeneratePackingLabel());
        Console.WriteLine(o2.GenerateShippingLabel());
        Console.WriteLine(@$"
Total: ${o2.GetTotalPrice()}");
    }
}