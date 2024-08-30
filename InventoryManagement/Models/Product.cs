﻿namespace InventoryManagement.Models
{
    public class Product
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
    }
}
