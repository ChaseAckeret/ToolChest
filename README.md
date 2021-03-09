# ToolChest

Never regret that expensive tool purchase again! Whether you bought a tool for a project that now sits gathering dust in the garage, or need a special tool but can't justify the purchase price, ToolChest is here to help! ToolChest connects tool owners with tool renters, a la Airbnb.

### Details

This is a back end API, with built out endpoints. Postman was used to utilize the endpoints and test the functionality of the API.

### Technologies

* C\#
* .Net
* Microsoft Entity Framework 6.2.2

### Initial Setup and Launch

In order to run the program, open the solution in Visual Studio. You may need to go to Tools-> NuGet Package Manager-> Manage NuGet Packages for Solution to install Entity Framework (and any other packages). Run the solution. A Browser window will open, and in some cases a warning will appear that you must ignore due to the security settings on the browser. Once the browser is showing the Asp.Net webpage, we use postman to interact with the API. Copy the URL of from the open browser, and open Postman. Start a new HTTP request, paste the copied URL and append /api/Account/Register to the localhost url. Be sure that POST is selected from the drop down menu, and change the body to x-www-form-urlencoded. Add three keys: Email, Password and ConfirmPassword. In the value column type an email (real or imaginary is fine) and a password in both the expected places. NOTE, the password will have to be longer than 6 characters and contain at least one capital letter, one digit and one special character. Run the request and see that the return valie is 200. This POST request will create a registered user in the application's database. Next, run a second POST command at /token instead of /api/Account/Register. The body should have three keys, Username, Password and grant-type. The username and password will be those just used to register a user, and the value of "grant-type" will be "password". The body of the return JSON object will contain an access_token, a long string inside quotations. Copy this string without the quotations as it will be needed for all other HTTP requests to the API. Regardless of the nature of the HTTP request, there will be an additional header key-value pair. Make the key "Authorization", and the value "Bearer" with a space and then the long token string that was copied. Congradulations, you have registered a user and are now ready to interact with the rest of the API.

### Helpful Websites

Throughout this project we relied on ourselves, each other, Teacher Assistants at 1150 and the internet. The following websites contain information that allowed us to overcome obstacles and understand the functionality of the underlying technologies as we created this API.

* [Creating API Help Pages](https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages)
* [3 Easy Steps to Create WebAPI Documentations](https://coderwall.com/p/sqmrog/3-easy-steps-to-create-webapi-documentations)
* [Overwriting Local Files With Git Pull](https://www.freecodecamp.org/news/how-to-override-local-files-with-git-pull/)
* [Reset Entity Framework Migrations](https://weblog.west-wind.com/posts/2016/jan/13/resetting-entity-framework-migrations-to-a-clean-slate)
