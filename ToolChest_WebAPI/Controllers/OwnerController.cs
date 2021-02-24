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
    public class OwnerController : ApiController
    {
        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            return ownerService;
        }

        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.GetOwners();
            return Ok(owners);
        }

        public IHttpActionResult Post(OwnerCreate owner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOwnerService();

            if (!service.CreateOwner(owner))
                return InternalServerError();

            return Ok();
        }
    }
}
