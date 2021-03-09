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
    public class ReceiptController : ApiController
    {

        private ReceiptService CreateReceiptService()
        {
            var ToolService = new ReceiptService();
            return ToolService;
        }

        //Post a Customer Rating
        /// <summary>
        /// Post a new Receipt to the Database
        /// </summary>
        /// <param name="NewReciept">Contains the required fields for a Receipt object</param>
        /// <returns></returns>
        public IHttpActionResult Post(ReceiptCreate NewReciept)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service =
                CreateReceiptService();

            if (!service.CreateReceipt(NewReciept))
                return InternalServerError();

            return Ok();
        }

        //private CustomerRatingService CreateCustomerRatingService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var customerRatingService = new CustomerRatingService();
        //    return customerRatingService;
        //}


        /// <summary>
        /// Changes an existing Receipt object in the Database
        /// </summary>
        /// <param name="editReciept">The new Receipt, with same ID, to replace existing Receipt in Database</param>
        /// <returns></returns>
        public IHttpActionResult Put(ReceiptEdit editReciept)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReceiptService();

            if (!service.UpdateReceipt(editReciept))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Deletes the Receipt specified by the parameter id
        /// </summary>
        /// <param name="id">The id of the Receipt to delete from the Database</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReceiptService();

            if (!service.DeleteReceipt(id))
                return InternalServerError();

            return Ok();
        }
    }
}
