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
    }
}
