using System;
using KikoStore.Api.Helpers;
using KikoStore.Core.Entities;
using KikoStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KikoStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedSize<T>
    (IGenericRepository<T> repo, ISpecification<T> spec,
     int pageIndex, int pageSize) where T : BaseEntity
    {


        var items = await repo.GetAsync(spec);
        var count = await repo.CountAsync(spec);
        var pagination = new Pagination<T>(pageIndex, pageSize, count, items);
        return Ok(pagination);
    }
}