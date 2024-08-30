using System.Text.Json;
using InventoryManagement;
using InventoryManagement.Models;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Products.json");

        string jsonString = File.ReadAllText(filePath);
        List<Product>? products = JsonSerializer.Deserialize<List<Product>>(jsonString);

        if (products != null)
        {
            var sort_key = "price";
            var ascending = true;

            var sortedProducts = InventoryManager.SortInventory(products, sort_key, ascending);

            string outputFile = "sorted_products.json";
            InventoryManager.SaveProductsToJson(outputFile, sortedProducts);

            string sortedProductString = File.ReadAllText(InventoryManager.GetPath(outputFile));
            Console.WriteLine(sortedProductString);
        }
        else
        {
            Console.WriteLine("An error ocurred while reading input data");
        }
    }
}