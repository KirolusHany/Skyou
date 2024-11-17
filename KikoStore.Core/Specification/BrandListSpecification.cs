using System;
using System.Linq.Expressions;
using KikoStore.Core.Entities;

namespace KikoStore.Core.Specification;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification(){
        AddSelect(x=>x.Brand);
        ApplyDistinct();
    }
    
}
