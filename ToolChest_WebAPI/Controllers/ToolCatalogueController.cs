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
            var ToolService = new ToolService();
            return ToolService;

        }
        public IHttpActionResult Put(int toolCatalogueItemId, ToolCatalogItemCreate toolCatalogeItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolCatalogueItemService();

            if (!service.EditCatalogItem(toolCatalogueItemId, toolCatalogeItem))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetAllToolsCatalogueItems()
        {

            ToolService toolService = CreateToolCatalogueItemService();
            var tool = toolService.GetAllToolCatalogueItems();
            return Ok(tool);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolCatalogueItemService();

            if (!service.DeleteToolCatalogueItem(id))
                return InternalServerError();

            return Ok();
        }

    }


}
