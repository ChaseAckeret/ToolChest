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
    public class RentalController : ApiController
    {

        //we need a private method to create a RentalService instance
        private RentalService CreateRentalService()
        {
            //use built in classes and methods to get user id
            var userId = Guid.Parse(User.Identity.GetUserId());

            //now create the rental service
            var RentalService = new RentalService();

            //and now return the instance of rentalService we created
            return RentalService;

        }//end of method CreateRentalService



        //post a rental
        /// <summary>
        /// Post a new Rental object to the Database
        /// </summary>
        /// <param name="Rental">Contains the required fields for a Rental object</param>
        /// <returns></returns>
        public IHttpActionResult Post(RentalCreate Rental)
        {

            //start by checking that the model state is valid
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }//end of if state valid

            //if it's valid create a RentalService
            var service = CreateRentalService();

            //now we are going to call the createRental method inside an if statement
            //if it succeeds great, and if it doesnt we return and InternalServerError
            if (!service.CreateRental(Rental))
            {

                //didn't work, return problem
                return InternalServerError();


            }//end of if not createRental (no success)

            //if we get here it worked, yay
            return Ok();



        }//end of Post method

        /// <summary>
        /// Get Rentals from Database based on the parameter UserId
        /// </summary>
        /// <param name="userID">The id of the User the Rental Objects are associated with</param>
        /// <returns></returns>
        public IHttpActionResult Get(int userID)
        {

            RentalService rentalService = CreateRentalService();
            var rentalsbyID = rentalService.GetRentalByUserID(userID);
            return Ok(rentalsbyID);
        }


    }//end of class RentalController

}


