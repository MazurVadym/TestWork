using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Comman;
using BL.Objects.Interface;
using BL.Objects.List.EventList;
using DAL.Repositories;
using Utils.Extensions;

namespace BL.Services.Implementation
{
    public class EventListService : IEventListService
    {
        private readonly EventListRepository _eventListRepository = new EventListRepository();
        private readonly CustomerService _customerService = new CustomerService();
        private readonly ProductService _productService = new ProductService();

        public Guid Modify(EventList eventList)
        {
            var productListsId = eventList.ProductList.Select(x => x.Id.Value).ToList();

            return _eventListRepository.Modify(new
            {
                eventList.Id,
                eventList.OwnerId,
                eventList.Title,
                eventList.Active,
                eventList.Description,
                eventList.Flags,
                eventList.Public,
                ProductListsId = productListsId.ToTvp()
            });
        }

        public void Delete(List<Guid> ids)
        {
            _eventListRepository.Delete(new { ids = ids.ToTvp() });
        }

        public void Delete(Guid id)
        {
            Delete(new List<Guid>() { id });
        }

        public List<EventList> GetAll()
        {
            return FillProduct(FillCustomer(_eventListRepository.Get(new { SearchType = 1 })));
        }

        public EventList GetById(Guid id)
        {
            return GetByIds(new List<Guid>() { id }).FirstOrDefault();
        }

        public List<EventList> GetByIds(List<Guid> ids)
        {
            return FillProduct(FillCustomer(_eventListRepository.Get(new { SearchType = 2, Ids = ids.ToTvp() })));
        }

        public List<EventList> FillCustomer(List<EventList> eventLists)
        {
            var customers = _customerService.GetAll();

            foreach (var eventList in eventLists)
            {
                Guid.TryParse(eventList.OwnerId, out var eventListOwnerId);
                var currentCustomer = customers.FirstOrDefault(x => x.Id == eventListOwnerId);

                if (currentCustomer != null)
                    eventList.OwnerFullName = $"{currentCustomer.FirstName} {currentCustomer.LastName}";
            }

            return eventLists;
        }

        public List<EventList> FillProduct(List<EventList> eventLists)
        {
            var ids = new List<long>();

            foreach (var eventList in eventLists)
            {
                foreach (var productList in eventList.ProductList)
                {
                    ids.AddRange(productList.ProductItem.Select(x => x.ProductId));
                }
            }

            var products = _productService.GetByIds(ids);

            foreach (var eventList in eventLists)
            {
                foreach (var productList in eventList.ProductList)
                {
                    foreach (var productItem in productList.ProductItem)
                    {
                        productItem.Product = products.FirstOrDefault(x => x.Id == productItem.ProductId);
                    }
                }
            }

            return eventLists;
        }
    }
}
