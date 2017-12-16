using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using BackEnd.Models;
namespace BackEnd.Controllers
{
    public class UserAccController : ApiController
    {
        UserModel um = new UserModel();
        [HttpGet]
        public bool Get(string mobile_no, string password)
        {
            bool result = um.login(mobile_no, password);
            return result;
        }
        [HttpPost]
        public IHttpActionResult Post(Object Json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            UserModel ud = jss.Deserialize<UserModel>(Json.ToString());
            bool res = um.login(ud.Contact_No);
            if (res == true)
            {
                return Ok("Acc Already Takes Place");
            }

            bool result = um.addUser(ud);
            return Ok(result);
        }
        PushNotification pn = new PushNotification();
        [HttpGet]
        public bool GetRequest(string mobile_no, string latlong, string token)
        {
            string result = pn.SendNotificationFromFirebase(latlong, mobile_no, token);
            if (result == "true")
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public bool postStartRide(string trip_id, string Driver_id, string Customer_id, string StateUpdate, string Status_id)
        {

            bool result = um.addRoute(trip_id, Driver_id, Customer_id, StateUpdate, Status_id);
            return result;
        }
        [HttpGet]
        public bool cancelRide(string Trip_id, string cancelOption)
        {
            bool cancel = um.Cancel_Trip(Trip_id, cancelOption);
            return cancel;
        }

        [HttpPost]
        public string postnotifyUser(Object Json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            RequestClass rc = jss.Deserialize<RequestClass>(Json.ToString());
            string rest = um.addTrip(rc);
            if (rest != null && rest != "false")
            {
                string result = pn.NotifyUser(rc.latlong, rc.mobile_no, rc.token, rc.myToken, rest);
                if (result == "false")
                {
                    um.deleteTrip(rest);
                }
                return rest;
            }
            else {
                return "false";
            }
            return "false";
        }

    
       /* [HttpGet]
        public bool id(string mobile)
        {
            bool result = um.id(mobile);
            return result;
        }*/
    }
}