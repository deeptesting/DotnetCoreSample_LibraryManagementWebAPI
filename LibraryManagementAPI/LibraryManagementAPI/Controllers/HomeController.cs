using LibraryManagementAPI.Auth.Abstract;
using LibraryManagementAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private readonly IConfiguration configuration;

        public HomeController(IJWTAuthenticationManager jWTAuthenticationManager, IConfiguration _configuration)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this.configuration = _configuration;
        }


        [Route("~/")]
        [Route("Home")]
        [Route("Home/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to API Home Page ");
        }



        [AllowAnonymous]
        [Route("login")]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, "Please enter valid Credentials");//return Unauthorized();
            }
            return Ok(token);
        }

        public class UserCred
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
