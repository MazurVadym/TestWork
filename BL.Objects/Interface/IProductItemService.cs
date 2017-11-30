using System;
using System.Collections.Generic;

namespace BL.Objects.Interface
{
    public interface IProductItemService
    {
        Guid Modify(ProductItem.ProductItem productItem);
        void Delete(List<Guid> ids);
        List<ProductItem.ProductItem> GetAll();
        List<ProductItem.ProductItem> GetByIds(List<Guid> ids);
        ProductItem.ProductItem GetById(Guid id);
    }
}