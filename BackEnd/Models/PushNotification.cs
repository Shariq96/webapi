using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace BackEnd.Models
{
    public class PushNotification
    { UserModel um = new UserModel();
        public String SendNotificationFromFirebase(string latlong, string mobile_no, string Token)
        {
            string customer_id = um.id(mobile_no);
            string str;
            try
            {

                string applicationID = "AAAACaK3asY:APA91bF353EERBZuZvA4t_2O3GFxA6JmcVg2hSpBTh6Yk_7dRth0AU-7Db59KFCgJzt4BiiW9-EEF96bliWxH8dMKLddnDUOeUX6dtoCBvWAiB6Y91_fGjlE8nkR9w-qPga55I3bJ2YP";

                string senderId = "41384635078";

                string deviceId = "cn3NYsa-Ew0:APA91bGqdsFTuhVFYqeDaiwiqL-PWDwS4ivTAOl4Jb-WGgE68C5cDmBMCicF87hT-9cx8X5uGLj9i1ubjXwaCSYDzaxuONYAfrCGes8gi8i75sdOjdaAzuanNLRV2bg9EZSfGGYv4wwX";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = latlong,
                        title = mobile_no,
                        color = Token,
                        sound = customer_id,
                        priority = "high"

                    },
                    token = Token,
                };
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                str = sResponseFromServer;
                                str = "true";
                            }
                        }
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                str = "false";
                return str;
                //     return ex.Message;
            }

        }
        public String NotifyUser(string latlong, string mobile_no, string Token, string myToken,string Trip_id)
        {
            string str;
            try
            {

                string applicationID = "AAAACaK3asY:APA91bF353EERBZuZvA4t_2O3GFxA6JmcVg2hSpBTh6Yk_7dRth0AU-7Db59KFCgJzt4BiiW9-EEF96bliWxH8dMKLddnDUOeUX6dtoCBvWAiB6Y91_fGjlE8nkR9w-qPga55I3bJ2YP";

                string senderId = "41384635078";

                string deviceId = Token;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = latlong,
                        title = mobile_no,
                        color = myToken,
                        sound = Trip_id,
                        priority = "high"

                    }

                };
                string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;
                tRequest.ContentType = "application/json";
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                str = sResponseFromServer;
                                str = "true";
                            }
                        }
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                str = "false";
                return str;
                //     return ex.Message;
            }

        }
    }
}