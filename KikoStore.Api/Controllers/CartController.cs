using System;
using Company.ClassLibrary1;
using KikoStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace KikoStore.Api.Controllers;

public class CardController(ICartServices cartServices) :BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCard(string cardId){
        var card =await cartServices.GetCartAsync(cardId);
        return Ok(card?? new ShoppingCart{Id = cardId});
    }


    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> UpdateCard(ShoppingCart cart){
        var updateCard = await cartServices.SetCartAsync(cart);
        if (updateCard==null)  return BadRequest();
        return updateCard;

    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id){
        var result = await cartServices.DeleteCartAsync(id);
        if(!result) return BadRequest("Problem happened when deleting the cart");

        return Ok();
    }
}
