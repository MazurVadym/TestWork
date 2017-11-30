using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Comman;
using BL.Services.Implementation;
using TestWork.Models;

namespace TestWork.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : ApiController
    {
        private readonly ProductService _productService = new ProductService();

        [HttpGet]
        [Route("")]
        public ApiJsonResult GetAll()
        {
            return new ApiJsonResult(_productService.GetAll());
        }

    }
}
