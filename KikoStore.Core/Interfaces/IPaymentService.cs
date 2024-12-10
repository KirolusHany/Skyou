using System;
using Company.ClassLibrary1;

namespace KikoStore.Core.Interfaces;

public interface IPaymentService
{

    Task<ShoppingCart?> CreateOrUpdatePaymentIntent(string cartId);
}
