using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoOp.ClientApp.Models
{
    public class Post
    {
        public int Id {get; set; }

        public int UserId {get; set; }

        public required string Content {get; set; }

        public required string Image {get; set; }

        public DateTime CreateAt {get; set; }



       
    }
}