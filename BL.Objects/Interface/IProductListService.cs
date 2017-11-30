using System;
using BL.Objects.List.ProductList;
using System.Collections.Generic;

namespace BL.Objects.Interface
{
    public interface IProductListService
    {
        Guid Modify(ProductList productList);
        void Delete(List<Guid> ids);
        void Delete(Guid id);
        List<ProductList> GetAll();
        ProductList GetById(Guid id);
        List<ProductList> GetByIds(List<Guid> ids);
        List<ProductList> GetWithoutEvent();
        ProductList FillCustomer(ProductList productList);
        List<ProductList> FillCustomer(List<ProductList> productLists);
        List<ProductList> FillProduct(List<ProductList> productLists);
    }
}