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
        private ToolService CreateToolService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ToolService = new ToolService();
            return ToolService;
        }

        public IHttpActionResult Get(int id)
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetToolByID(id);
            return Ok(tool);
        }

        public IHttpActionResult GetAllTools()
        {

            ToolService toolService = CreateToolService();
            var tool = toolService.GetAllTools();
            return Ok(tool);
        }
    }
}

