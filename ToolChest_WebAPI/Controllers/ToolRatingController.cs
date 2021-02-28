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
    public class ToolRatingController : ApiController
    {
        // Post a Tool Rating
        public IHttpActionResult Post(ToolRatingCreate ToolRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolRatingService();

            if (!service.CreateToolRating(ToolRating))
                return InternalServerError();

            return Ok();
        }
        private ToolService CreateToolRatingService()
        {
            // this is the userID for the person initiating the Post

            //var userId = Guid.Parse(User.Identity.GetUserId());           
            string userId = User.Identity.GetUserId();
            var ToolService = new ToolService();
            return ToolService;

        }
    }
}
