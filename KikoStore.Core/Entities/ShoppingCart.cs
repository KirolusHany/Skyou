using System;
using KikoStore.Core.Entities;

namespace Company.ClassLibrary1;

public class ShoppingCart
{
    public required string Id { get; set; }
    public List<CartItem> Items { get; set; }=[];
    public int? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
}
