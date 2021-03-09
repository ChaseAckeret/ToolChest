using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolChest_Data;
using ToolChest_Models;
using ToolChest_Service;

namespace ToolChest_WebAPI.Controllers
{
    [Authorize]
    public class ToolController : ApiController
    {
        private ToolService CreateToolService()
        {
            var ToolService = new ToolService();
            return ToolService;
        }

        //Post a Tool
        /// <summary>
        /// Post a new Tool object to the Database
        /// </summary>
        /// <param name="Tool">Contains the required fields for a new Tool object</param>
        /// <returns></returns>
        public IHttpActionResult Post(ToolCreate Tool)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolService();

            if (!service.CreateTool(Tool))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Get a Tool from the Database specified by the parameter id
        /// </summary>
        /// <param name="id">The id of the Tool to return from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetFullToolDetailByID(id);
            return Ok(tool);
        }
        /// <summary>
        /// Get Tools that are of a particular type and located in a particular zip
        /// </summary>
        /// <param name="type">The type of Tool to be returned from the Database</param>
        /// <param name="zip">The zip code for the tools we want returned</param>
        /// <returns></returns>
        public IHttpActionResult Get(int type, int zip)
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetToolsByTypeAndZip(type, zip);
            return Ok(tool);
        }
        /// <summary>
        /// Get all Tool objects stored in the Database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAllTools()
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetAllTools();
            return Ok(tool);
        }

        /// <summary>
        /// Changes an existing Tool object in the Database
        /// </summary>
        /// <param name="toolId">The id of the Tool to change</param>
        /// <param name="toolEdit">The new Tool, with id, to replace existing Tool</param>
        /// <returns></returns>
        public IHttpActionResult Put(int toolId, ToolEdit toolEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolService();

            if (!service.EditToolItem(toolId, toolEdit))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Delete Tool object specified by parameter by id
        /// </summary>
        /// <param name="id">Id of the Tool to be deleted from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolService();

            if (!service.DeleteTool(id))
                return InternalServerError();

            return Ok();
        }

    }
}

