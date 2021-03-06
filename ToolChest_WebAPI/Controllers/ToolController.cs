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

        public IHttpActionResult Post(ToolCreate Tool)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolService();

            if (!service.CreateTool(Tool))
                return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Get(int id)
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetFullToolDetailByID(id);
            return Ok(tool);
        }

        public IHttpActionResult GetAllTools()
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetAllTools();
            return Ok(tool);
        }

        public IHttpActionResult Put(int toolId, ToolEdit toolEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateToolService();

            if (!service.EditToolItem(toolId, toolEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolService();

            if (!service.DeleteTool(id))
                return InternalServerError();

            return Ok();
        }

    }
}

