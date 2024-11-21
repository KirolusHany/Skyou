using System;
using System.Text.Json;
using Company.ClassLibrary1;
using KikoStore.Core.Interfaces;
using StackExchange.Redis;

namespace KikoStore.Infrastructure.Services;

public class CartServices(IConnectionMultiplexer redis) : ICartServices
{
    private readonly IDatabase _database =redis.GetDatabase();
    public async Task<bool> DeleteCartAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<ShoppingCart?> GetCartAsync(string key)
    {
        var cart = await _database.StringGetAsync(key);
        return cart.IsNullOrEmpty? null : JsonSerializer.Deserialize<ShoppingCart>(cart!);
    }

    public async Task<ShoppingCart?> SetCartAsync(ShoppingCart cart)
    {
        var created= await _database.StringSetAsync
        (cart.Id,JsonSerializer.Serialize(cart),TimeSpan.FromDays(30));
        if (!created) return null;

        return await GetCartAsync(cart.Id);
    }
}
