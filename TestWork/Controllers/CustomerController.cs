using System.Web.Http;
using BL.Services.Implementation;
using TestWork.Models;

namespace TestWork.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly CustomerService _customerService = new CustomerService();

        [HttpGet]
        [Route("")]
        public ApiJsonResult GetAll()
        {
            return new ApiJsonResult(_customerService.GetAll());
        }
    }
}
