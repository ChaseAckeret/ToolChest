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
        /// <summary>
        /// Post a new ToolRating to the Database
        /// </summary>
        /// <param name="ToolRating">Contains the required fields for a ToolRating object</param>
        /// <returns></returns>
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
        /// <summary>
        /// Deletes the ToolRating specified by the parameter id
        /// </summary>
        /// <param name="id">Id of the ToolRating to delete from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolRatingService();

            if (!service.DeleteToolRating(id))
                return InternalServerError();

            return Ok();
        }

    }
}
