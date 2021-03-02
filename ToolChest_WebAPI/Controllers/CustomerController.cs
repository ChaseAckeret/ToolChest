//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using ToolChest_Models;
//using ToolChest_Service;

//namespace ToolChest_WebAPI.Controllers
//{
//    [Authorize]
//    public class CustomerController : ApiController
//    {
//        private CustomerService CreateCustomerService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var customerService = new CustomerService(userId);
//            return customerService;
//        }

//        public IHttpActionResult Get()
//        {
//            CustomerService customerService = CreateCustomerService();
//            var customers = customerService.GetCustomers();
//            return Ok(customers);
//        }

//        public IHttpActionResult Post(CustomerCreate customer)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var service = CreateCustomerService();

//            if (!service.CreateCustomer(customer))
//                return InternalServerError();

//            return Ok();
//        }
//    }
//}
