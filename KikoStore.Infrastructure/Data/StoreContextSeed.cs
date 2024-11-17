using System;
using System.Text.Json;
using KikoStore.Core.Entities;

namespace KikoStore.Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync
            ("../KikoStore.Infrastructure/Data/SeedData/products.json");

            var products = JsonSerializer
            .Deserialize<List<Product>>(productsData);

            if (products == null)
            {
                return;
            }

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

        }

    }
}
