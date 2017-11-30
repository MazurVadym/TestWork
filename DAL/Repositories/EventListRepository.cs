using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BL.Objects.List.EventList;
using BL.Objects.List.ProductList;
using BL.Objects.ProductItem;
using Dapper;

namespace DAL.Repositories
{
    public class EventListRepository
    {
        public Guid Modify(object obj)
        {
            return Repository.GetConnection().Query<Guid>("dbo.EventListModify", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).FirstOrDefault();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection().Query("dbo.EventListDelete", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
        }

        public List<EventList> Get(object obj)
        {
            using (var multi = Repository.GetConnection().QueryMultiple("dbo.EventListGet", obj, commandTimeout: int.MaxValue, commandType: CommandType.StoredProcedure))
            {
                var eventLists = multi.Read<EventList>().ToList();

                var productLists = multi.Read<ProductList>().ToList();

                var productItems = multi.Read<ProductItem>().ToList();

                foreach (var eventList in eventLists)
                {
                    eventList.ProductList = productLists.Where(x => x.EventListId == eventList.Id).ToList();

                    foreach (var productList in eventList.ProductList)
                    {
                        productList.ProductItem =
                            productItems.Where(x => productList.Id != null && x.ProductListId == productList.Id.Value).ToList();
                    }
                }

                return eventLists;
            }
        }
    }
}
