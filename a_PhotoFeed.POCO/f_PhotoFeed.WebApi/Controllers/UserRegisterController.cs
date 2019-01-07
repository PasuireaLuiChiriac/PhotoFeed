using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using d_PhotoFeed.DTO;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/register")]
    public class UserRegisterController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserRegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("signup")]
        public IHttpActionResult AddNewUser([FromBody] UserDTO newUser)
        {
            /*
             {
	            "IdUser": 1,
                "UserName": "User1",
                "Email": "User@email.com",
                "Password": "password",
                "Description": "",
                "ProfilePicture": "",
                "Verified": 1,
                "Points": 0,
                "Moderator": 1
            }
            */
            return Ok(_userService.AddNewUser(newUser)); //return true if the user was created
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult LoginUser([FromBody] LoginInfo userLoginInfo)
        {
            /*{
                "Email": "User@email.com",
                "Password": "passworsd"
            }*/
            return Ok(_userService.LoginUser(userLoginInfo)); //returns user's info if account exists
        }

    }
}
