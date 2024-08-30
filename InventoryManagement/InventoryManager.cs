using System.Diagnostics;
using System.Text.Json;
using InventoryManagement.Models;

namespace InventoryManagement
{
    class InventoryManager
    {
        public static string GetPath(string file)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Data/{file}");
        }

        public static List<Product> SortInventory(List<Product> products, string sortBy, bool ascending)
        {
            var sortedProducts = products.AsQueryable();

            switch (sortBy)
            {
                case "name":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Name) : sortedProducts.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Price) : sortedProducts.OrderByDescending(p => p.Price);
                    break;
                case "stock":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Stock) : sortedProducts.OrderByDescending(p => p.Stock);
                    break;
            }

            return [.. sortedProducts];
        }

        public static void SaveProductsToJson(string outputFile, List<Product> products)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true
            };
            var options = jsonSerializerOptions;

            var jsonString = JsonSerializer.Serialize(products, options);
            File.WriteAllText(GetPath(outputFile), jsonString);
        }

        public static void OpenFileContent(string file)
        {
            string path = GetPath(file);

            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
    }
}
