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

        public IHttpActionResult Put(OwnerRatingEdit rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOwnerRatingService();

            if (!service.UpdateOwnerRating(rating))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateOwnerRatingService();

            if (!service.DeleteOwnerRating(id))
                return InternalServerError();

            return Ok();
        }
    }
}
