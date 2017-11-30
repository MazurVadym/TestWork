using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BL.Objects.ProductItem;
using Dapper;

namespace DAL.Repositories
{
    public class ProductItemRepository
    {
        public Guid Modify(object obj)
        {
            return Repository.GetConnection().Query<Guid>("dbo.ProductItemModify", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).FirstOrDefault();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection().Query("dbo.ProductItemDelete", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
        }

        public List<ProductItem> Get(object obj)
        {
            return Repository.GetConnection().Query<ProductItem>("dbo.ProductItemGet", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).ToList();
        }
    }
}
