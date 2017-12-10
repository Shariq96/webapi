using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BackEnd.Models
{
    public class RequestClass
    {
        public string mobile_no { get; set; }
        public string latlong { get; set; }
        public string token { get; set; }
        public string myToken { get; set; }
        public string user_mobile { get; set; }
        
        
    }
}