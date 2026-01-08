using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoOp.ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CoOp.Models;

namespace CoOp.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        

        public Response Registration(User userInfo)
        {
            _ = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNcon"));
            Dal dal = new();
            Response response = dal.Registration(userInfo, connection);


            return response;
        }
        
        

    }
}