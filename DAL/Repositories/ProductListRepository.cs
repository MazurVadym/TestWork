using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.List.ProductList;
using BL.Objects.ProductItem;
using Dapper;

namespace DAL.Repositories
{
    public class ProductListRepository
    {
        public Guid Modify(object obj)
        {
            return Repository.GetConnection().Query<Guid>("dbo.ProductListModify", obj, commandType: CommandType.StoredProcedure,
                commandTimeout: int.MaxValue).FirstOrDefault();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection().Query("dbo.ProductListDelete", obj, commandType: CommandType.StoredProcedure,
                commandTimeout: int.MaxValue);
        }

        public List<ProductList> Get(object obj)
        {
            using (var multi = Repository.GetConnection().QueryMultiple("dbo.ProductListGet", obj, commandTimeout: int.MaxValue, commandType: CommandType.StoredProcedure))
            {
                var productLists = multi.Read<ProductList>().ToList();

                var productItems = multi.Read<ProductItem>().ToList();

                foreach (var item in productLists)
                {
                    item.ProductItem = productItems.Where(x => x.ProductListId == item.Id.Value).ToList();
                }

                return productLists;
            }
        }
    }
}
