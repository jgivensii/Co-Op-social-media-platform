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
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
         [HttpPost]

        public Response Login(User userInfo)
        {
            _ = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(@"Data Source=LAPTOP-OCNL6HD6\SQLEXPRESS02;Database=CoOP;Integrated Security=sspi;"));
            Dal dal = new Dal();
            Response response = dal.Login(userInfo, connection);


            return response;
        }
    }
}