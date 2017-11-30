using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Interface;
using BL.Objects.List.ProductList;
using DAL.Repositories;
using Utils.Extensions;

namespace BL.Services.Implementation
{
    public class ProductListService : IProductListService
    {
        private readonly ProductListRepository _productListRepository = new ProductListRepository();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly ProductService _productService = new ProductService();

        public Guid Modify(ProductList productList)
        {
            productList.Active = true;
            return _productListRepository.Modify(new { productList.Id, productList.OwnerId, productList.Active, productList.Flags, productList.Title });
        }

        public void Delete(List<Guid> ids)
        {
            _productListRepository.Delete(new { ids = ids.ToTvp() });
        }

        public void Delete(Guid id)
        {
            Delete(new List<Guid>() { id });
        }

        public List<ProductList> GetAll()
        {
            return FillProduct(FillCustomer(_productListRepository.Get(new { SearchType = 1 })));
        }

        public ProductList GetById(Guid id)
        {
            return GetByIds(new List<Guid>() { id }).FirstOrDefault();
        }

        public List<ProductList> GetByIds(List<Guid> ids)
        {
            return FillProduct(FillCustomer(_productListRepository.Get(new { SearchType = 2, Ids = ids.ToTvp() })));
        }

        public List<ProductList> GetWithoutEvent()
        {
            return FillProduct(FillCustomer(_productListRepository.Get(new { SearchType = 3 })));
        }

        public ProductList FillCustomer(ProductList productList)
        {
            var customers = _customerService.GetAll();

            Guid.TryParse(productList.OwnerId, out var productListOwnerId);
            var currentCustomer = customers.FirstOrDefault(x => x.Id == productListOwnerId);

            if (currentCustomer != null)
                productList.OwnerFullName = $"{currentCustomer.FirstName} {currentCustomer.LastName}";

            return productList;
        }

        public List<ProductList> FillCustomer(List<ProductList> productLists)
        {
            var customers = _customerService.GetAll();

            foreach (var productList in productLists)
            {
                Guid.TryParse(productList.OwnerId, out var productListOwnerId);
                var currentCustomer = customers.FirstOrDefault(x => x.Id == productListOwnerId);

                if (currentCustomer != null)
                    productList.OwnerFullName = $"{currentCustomer.FirstName} {currentCustomer.LastName}";
            }

            return productLists;
        }


        public List<ProductList> FillProduct(List<ProductList> productLists)
        {
            var ids = new List<long>();

            foreach (var productList in productLists)
            {

                ids.AddRange(productList.ProductItem.Select(x => x.ProductId));
            }

            var products = _productService.GetByIds(ids);

            foreach (var productList in productLists)
            {
                foreach (var productItem in productList.ProductItem)
                {
                    productItem.Product = products.FirstOrDefault(x => x.Id == productItem.ProductId);
                }
            }

            return productLists;
        }
    }
}
