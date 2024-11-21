using System;
using Company.ClassLibrary1;
using KikoStore.Core.Entities;

namespace KikoStore.Core.Interfaces;

public interface ICartServices
{
    Task<ShoppingCart?> GetCartAsync(string key);
    Task<ShoppingCart?> SetCartAsync(ShoppingCart cart);
    Task<bool> DeleteCartAsync(string key);
}
