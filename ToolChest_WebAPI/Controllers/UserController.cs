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
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userService = new UserService();
            return userService;
        }

        /// <summary>
        /// Get list of users, either Owners or Customers
        /// </summary>
        /// <param name="which">String to indicate Owners or Customers</param>
        /// <returns></returns>
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

        /// <summary>
        /// Post new User to the Database
        /// </summary>
        /// <param name="User">Contains the required fields for a new User object</param>
        /// <returns></returns>
        public IHttpActionResult Post(UserCreate User)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(User))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Change an existing User object in the Database
        /// </summary>
        /// <param name="user">The User object, with matching id, to be changed in the Database</param>
        /// <returns></returns>
        public IHttpActionResult Put(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id))
                return InternalServerError();

            return Ok();
        }
  
    }

}