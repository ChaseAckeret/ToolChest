using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolChest_Models;
using ToolChest_Service;

namespace ToolChest_WebAPI.Controllers
{
    [Authorize]
    public class CustomerRatingController : ApiController
    {
        //Post a Customer Rating
        public IHttpActionResult Post(CustomerRatingCreate customerRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service =
                CreateCustomerRatingService();

            if (!service.CreateCustomerRating(customerRating))
                return InternalServerError();

            return Ok();
        }

        private CustomerRatingService CreateCustomerRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerRatingService = new CustomerRatingService();
            return customerRatingService;
        }

        public IHttpActionResult Put(CustomerRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerRatingService();

            if (!service.UpdateCustomerRating(rating))
                return InternalServerError();

            return Ok();
        }

        public  IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerRatingService();

            if (!service.DeleteCustomerRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
