using System;
using System.Collections.Generic;
using System.Web.Http;
using BL.Objects.ProductItem;
using BL.Services.Implementation;
using TestWork.Models;

namespace TestWork.Controllers
{
    [RoutePrefix("productItem")]
    public class ProductItemController : ApiController
    {
        private readonly ProductItemService _productItemService= new ProductItemService();

        [HttpPost]
        [Route("")]
        public ApiJsonResult Create(ProductItem productItem)
        {
            return new ApiJsonResult(_productItemService.GetById(_productItemService.Modify(productItem)));
        }

        [HttpPut]
        [Route("")]
        public ApiJsonResult Update(ProductItem productItem)
        {
            return new ApiJsonResult(_productItemService.GetById(_productItemService.Modify(productItem)));
        }

        [HttpDelete]
        [Route("")]
        public ApiJsonResult Delete(List<Guid> ids)
        {
            _productItemService.Delete(ids);

            return new ApiJsonResult();
        }

        [HttpGet]
        [Route("all")]
        public ApiJsonResult GetAll()
        {
            return new ApiJsonResult(_productItemService.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ApiJsonResult GetById(Guid id)
        {
            return new ApiJsonResult(_productItemService.GetById(id));
        }
    }
}
