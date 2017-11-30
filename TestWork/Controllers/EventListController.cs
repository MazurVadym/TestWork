using System;
using System.Web.Http;
using BL.Objects.List.EventList;
using BL.Services.Implementation;
using TestWork.Models;

namespace TestWork.Controllers
{
    [RoutePrefix("eventList")]
    public class EventListController : ApiController
    {
        private readonly EventListService _eventListService = new EventListService();

        [HttpPost]
        [Route("")]
        public ApiJsonResult Create(EventList eventList)
        {
            return new ApiJsonResult(_eventListService.GetById(_eventListService.Modify(eventList)));
        }

        [HttpPut]
        [Route("")]
        public ApiJsonResult Update(EventList eventList)
        {
            return new ApiJsonResult(_eventListService.GetById(_eventListService.Modify(eventList)));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public ApiJsonResult Delete(Guid id)
        {
            _eventListService.Delete(id);

            return new ApiJsonResult();
        }

        [HttpGet]
        [Route("")]
        public ApiJsonResult GetAll()
        {
            return new ApiJsonResult(_eventListService.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ApiJsonResult GetById(Guid id)
        {
            return new ApiJsonResult(_eventListService.GetById(id));
        }
    }
}
