using System;

namespace KikoStore.Core.Specification;

public class OrderSpecParams : PagingParams
{   
    public string? Status { get; set; }
}
