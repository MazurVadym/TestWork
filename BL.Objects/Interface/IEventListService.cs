using System;
using System.Collections.Generic;
using BL.Objects.List.EventList;

namespace BL.Objects.Interface
{
    public interface IEventListService
    {
        Guid Modify(EventList eventList);
        void Delete(List<Guid> ids);
        void Delete(Guid id);
        List<EventList> GetAll();
        EventList GetById(Guid id);
        List<EventList> GetByIds(List<Guid> ids);
        List<EventList> FillCustomer(List<EventList> eventLists);
        List<EventList> FillProduct(List<EventList> eventLists);
    }
}