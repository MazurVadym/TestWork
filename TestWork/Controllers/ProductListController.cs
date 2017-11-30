using System;
using System.Web.Http;
using BL.Objects.List.ProductList;
using BL.Services.Implementation;
using TestWork.Models;

namespace TestWork.Controllers
{
    [RoutePrefix("productList")]
    public class ProductListController : ApiController
    {
        private readonly ProductListService _listService = new ProductListService();

        [HttpPost]
        [Route("")]
        public ApiJsonResult CreateProductList(ProductList productList)
        {
            return new ApiJsonResult(_listService.GetById(_listService.Modify(productList)));
        }

        [HttpPut]
        [Route("")]
        public ApiJsonResult UpdateProductList(ProductList productList)
        {
            return new ApiJsonResult(_listService.GetById(_listService.Modify(productList)));
        }

        [HttpGet]
        [Route("")]
        public ApiJsonResult GetAll()
        {
            return new ApiJsonResult(_listService.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ApiJsonResult GetById(Guid id)
        {
            return new ApiJsonResult(_listService.GetById(id));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public ApiJsonResult Delete(Guid id)
        {
            _listService.Delete(id);

            return new ApiJsonResult();
        }

        [HttpGet]
        [Route("only")]//todo
        public ApiJsonResult GetWithoutEvent()
        {
            return new ApiJsonResult(_listService.GetWithoutEvent());
        }
    }
}
