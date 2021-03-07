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

        public IHttpActionResult Put(ReceiptEdit editReciept)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReceiptService();

            if (!service.UpdateReceipt(editReciept))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReceiptService();

            if (!service.DeleteReceipt(id))
                return InternalServerError();

            return Ok();
        }
    }
}
