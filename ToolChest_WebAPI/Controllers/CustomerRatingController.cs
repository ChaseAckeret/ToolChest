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
        /// <summary>
        /// Post new CustomerRating to the Database
        /// </summary>
        /// <param name="customerRating">Contains the required fields for a CustomerRating object</param>
        /// <returns></returns>
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
        /// <summary>
        /// Change an existing CustomerRating object in the Database
        /// </summary>
        /// <param name="rating">The new CustomerRating, with same id, to replace existing CustomerRating in the Database</param>
        /// <returns></returns>
        public IHttpActionResult Put(CustomerRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerRatingService();

            if (!service.UpdateCustomerRating(rating))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Deletes the CustomerRating specified by the parameter id
        /// </summary>
        /// <param name="id">The id of the CustomerRating to be deleted from the Database</param>
        /// <returns></returns>
        public  IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerRatingService();

            if (!service.DeleteCustomerRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
