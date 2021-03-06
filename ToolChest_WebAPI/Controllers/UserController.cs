﻿using Microsoft.AspNet.Identity;
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
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userService = new UserService();
            return userService;
        }

        public IHttpActionResult Get(string which)
        {
            UserService userService = CreateUserService();
            if (which == "Owners")
            {
                var owners = userService.GetAllOwners();
                return Ok(owners);
            }
            if (which == "Customers")
            {
                var owners = userService.GetAllCustomers();
                return Ok(owners);
            }
            //

            return Ok();


        }


        public IHttpActionResult Post(UserCreate User)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(User))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        /*
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();
        }
        */
    }

}