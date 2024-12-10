using System;
using System.Reflection;
using System.Text.Json;
using Company.ClassLibrary1;
using KikoStore.Core.Entities;

namespace KikoStore.Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync
            (path + @"/Data/SeedData/products.json");

            var products = JsonSerializer
            .Deserialize<List<Product>>(productsData);

            if (products == null)
            {
                return;
            }

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

        }
        if (!context.DeliveryMethods.Any())
        {
            var deliveryMethodData = await File.ReadAllTextAsync
            (path + @"/Data/SeedData/delivery.json");

            var methods = JsonSerializer
            .Deserialize<List<DeliveryMethod>>(deliveryMethodData);

            if (methods == null)
            {
                return;
            }

            await context.DeliveryMethods.AddRangeAsync(methods);
            await context.SaveChangesAsync();

        }

    }
}
