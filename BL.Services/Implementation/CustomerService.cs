using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Customer;
using BL.Objects.Interface;

namespace BL.Services.Implementation
{
    public class CustomerService : ICustomer
    {
        public List<Customer> GetAll()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = new Guid("6f2a109f-1ceb-4372-94c4-67b92c3de553"),
                    FirstName = "FirstName-1",
                    LastName = "LastName-1"
                },
                new Customer()
                {
                    Id = new Guid("768d14e9-2f2f-4ee8-8414-34d011306dbb"),
                    FirstName = "FirstName-2",
                    LastName = "LastName-2"
                },
                new Customer()
                {
                    Id = new Guid("156e382d-1329-46b3-8f44-5c8d688a5404"),
                    FirstName = "FirstName-3",
                    LastName = "LastName-3"
                }
            };
        }
    }
}
