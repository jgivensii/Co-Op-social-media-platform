using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoOp.ClientApp.Models
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string? StatusMessage { get; set; }

        public List<User>? ListUserInfo {get;set;}

        public User? Info{ get; set; }

        public List<Post>? ListPost {get;set;}

    }
}