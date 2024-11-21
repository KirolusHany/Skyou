using System;
using Company.ClassLibrary1;
using KikoStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace KikoStore.Api.Controllers;

public class CartController(ICartServices cartServices) :BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCart(string cartId){
        var cart =await cartServices.GetCartAsync(cartId);
        return Ok(cart?? new ShoppingCart{Id = cartId});
    }


    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> Updatecart(ShoppingCart cart){
        var updatecart = await cartServices.SetCartAsync(cart);
        if (updatecart==null)  return BadRequest();
        return updatecart;

    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id){
        var result = await cartServices.DeleteCartAsync(id);
        if(!result) return BadRequest("Problem happened when deleting the cart");

        return Ok();
    }
}
