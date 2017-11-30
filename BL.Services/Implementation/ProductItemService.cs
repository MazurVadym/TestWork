using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Interface;
using BL.Objects.List.ProductList;
using BL.Objects.ProductItem;
using DAL.Repositories;
using Utils.Extensions;

namespace BL.Services.Implementation
{
    public class ProductItemService : IProductItemService
    {
        private readonly ProductItemRepository _productItemRepository = new ProductItemRepository();

        public Guid Modify(ProductItem productItem)
        {
            return _productItemRepository.Modify(new
            {
                productItem.Id, productItem.ProductListId, productItem.ProductId, productItem.VariantId, productItem.Amount
            });
        }

        public void Delete(List<Guid> ids)
        {
            _productItemRepository.Delete(ids.ToTvp());
        }

        public List<ProductItem> GetAll()
        {
            return _productItemRepository.Get(new { SearchType = 1 });
        }

        public List<ProductItem> GetByIds(List<Guid> ids)
        {
            return _productItemRepository.Get(new { SearchType = 2, Ids = ids.ToTvp() });
        }

        public ProductItem GetById(Guid id)
        {
            return GetByIds(new List<Guid>() { id }).FirstOrDefault();
        }
    }
}
