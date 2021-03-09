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
    public class OwnerRatingController : ApiController
    {
        //Post an Owner Rating
        /// <summary>
        /// Post a new OwnerRental object to the Database
        /// </summary>
        /// <param name="ownerRating">Contains the required fields for a new OwnerRating object</param>
        /// <returns></returns>
        public IHttpActionResult Post(OwnerRatingCreate ownerRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOwnerRatingService();

            if (!service.CreateOwnerRating(ownerRating))
                return InternalServerError();

            return Ok();
        }

        private OwnerRatingService CreateOwnerRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerRatingService = new OwnerRatingService();
            return ownerRatingService;
        }
        /// <summary>
        /// Change an existing OwnerRating in the Database
        /// </summary>
        /// <param name="rating">The new OwnerRating, with the same ID, to replace the existing OwnerRating in the Database</param>
        /// <returns></returns>
        public IHttpActionResult Put(OwnerRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOwnerRatingService();

            if (!service.UpdateOwnerRating(rating))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete OwnerRating specified by parameter id
        /// </summary>
        /// <param name="id">Id of the OwnerRating to delete from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateOwnerRatingService();

            if (!service.DeleteOwnerRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
