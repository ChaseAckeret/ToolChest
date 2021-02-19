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
    public class ToolCatalogueController : ApiController
    {
        // Post a Tool Catalogue Item
        public IHttpActionResult Post(ToolCatalogItemCreate toolCatalogeItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolCatalogueItemService();

            if (!service.CreateCatalogItem(toolCatalogeItem))
                return InternalServerError();

            return Ok();
        }
        private ToolService CreateToolCatalogueItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ToolService = new ToolService();
            return ToolService;

        }
    }
}
