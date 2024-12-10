using System;
using System.Linq.Expressions;
using KikoStore.Core.Entities;

namespace KikoStore.Core.Specification;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecificationsParams productSpecs) : base(x =>
    (string.IsNullOrEmpty(productSpecs.Search) || x.Name.ToLower().Contains(productSpecs.Search))&&
    (productSpecs.Brands.Count==0 || productSpecs.Brands.Contains(x.Brand))&&
    (productSpecs.Types.Count==0 || productSpecs.Types.Contains(x.Type))
    )
    {
        ApplyPaging(productSpecs.PageSize*(productSpecs.PageIndex-1),productSpecs.PageSize); 
        switch (productSpecs.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;

        }

    }
}
