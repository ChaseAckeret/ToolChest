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
        /// <summary>
        /// Post a new ToolCalalogItem to the Database
        /// </summary>
        /// <param name="toolCatalogeItem">Contains the required fields for a ToolCatalogItem</param>
        /// <returns></returns>
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

        /// <summary>
        /// Change an existing ToolCatalogueItem object in the Database
        /// </summary>
        /// <param name="toolCatalogueItemId">Int to identify the existing ToolCatalogueItem</param>
        /// <param name="toolCatalogeItem">The new ToolCatalogueItem to replace the existing ToolCatalogueItem in the Database</param>
        /// <returns></returns>
        public IHttpActionResult Put(int toolCatalogueItemId, ToolCatalogItemCreate toolCatalogeItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolCatalogueItemService();

            if (!service.EditCatalogItem(toolCatalogueItemId, toolCatalogeItem))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Get all ToolCatalogueItems from the Database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllToolsCatalogueItems()
        {

            ToolService toolService = CreateToolCatalogueItemService();
            var tool = toolService.GetAllToolCatalogueItems();
            return Ok(tool);
        }

        /// <summary>
        /// Deletes the ToolCatalogueItem specified by the parameter id
        /// </summary>
        /// <param name="id">The id of the ToolCatalogue Item to be deleted from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolCatalogueItemService();

            if (!service.DeleteToolCatalogueItem(id))
                return InternalServerError();

            return Ok();
        }

    }


}
