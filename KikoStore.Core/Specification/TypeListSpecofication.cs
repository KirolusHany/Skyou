using System;
using KikoStore.Core.Entities;

namespace KikoStore.Core.Specification;

public class TypeListSpecfication : BaseSpecification<Product, string>
{
    public TypeListSpecfication()
    {
        AddSelect(x => x.Type);
        ApplyDistinct();
    }
}
