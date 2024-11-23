using System;
using System.Security.Claims;
using KikoStore.Api.DTOs;
using KikoStore.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KikoStore.Api.Controllers;

public class BuggyController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized(){
        return Unauthorized();
    }
    [HttpGet("badrequest")]
    public IActionResult GetBadRequest(){
        return BadRequest("This is bad request");
    }
    [HttpGet("notfound")]
    public IActionResult GetNotFound(){
        return NotFound();
    }
    [HttpGet("internalerror")]
    public IActionResult GetInternalError(){
        throw new Exception("Internal test error");
    }
    [HttpPost("validationerror")]
    public IActionResult GetValidationError([FromBody]CreateProductDto product)
    {
        return Ok();
    }
    [Authorize]
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        var name = User.FindFirst(ClaimTypes.Name)?.Value;
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok("Hello, " + name + "with id of " + id);
    }
 
}
