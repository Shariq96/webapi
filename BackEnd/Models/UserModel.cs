using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BackEnd.Models
{
    public class UserModel
    {
        int i = 0;

        public string pass { get; set; }
        public string Customer_name { get; set; }
        public string CNIC { get; set; }
        public DateTime DOB { get; set; }
        public string Blood_Grp { get; set; }
        public string Address { get; set; }
        public string Contact_No { get; set; }
        public string Emergency_No { get; set; }
        public string token_no { get; set; }
        public int Driver_id {get;set;}
        public int Vehicle_id {get;set;}
        public bool login(string mobile_no, string password)
        {
            SqlCommand command = new SqlCommand("login", connection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Contact_no", mobile_no);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][9].Equals(password))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool login(string mobile_no)
        {
            SqlCommand command = new SqlCommand("login", connection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Contact_no", mobile_no);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;   
            }
            return false;
        }
        public string id(string mobile_no)
        {
            string id = null;
            SqlCommand command = new SqlCommand("login", connection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Contact_no", mobile_no);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0][0].ToString();
            }
            return id;
        }
        public bool addUser(UserModel ud)
        {
         try
            { 
         
                SqlCommand sq_com = new SqlCommand("addUser", connection.getConnection());
                sq_com.CommandType = CommandType.StoredProcedure;
                sq_com.Parameters.AddWithValue("@Customer_name", ud.Customer_name);
                sq_com.Parameters.AddWithValue("@pass", ud.pass);
                sq_com.Parameters.AddWithValue("@DOB", "1996 - 12 - 15");
                sq_com.Parameters.AddWithValue("@CNIC", "");
                sq_com.Parameters.AddWithValue("@Contact_No", ud.Contact_No);
                sq_com.Parameters.AddWithValue("@Emergency_No", ud.Contact_No);
                sq_com.Parameters.AddWithValue("@Address", ud.Address);
                sq_com.Parameters.AddWithValue("@token_no", ud.token_no);
                sq_com.Parameters.AddWithValue("@Blood_Grp", "0ve");
                sq_com.ExecuteNonQuery();
            
                return true;
            
           }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool addTrip(RequestClass rc)
         {
             try
              {
                    SqlCommand sq_com = new SqlCommand("addTrip1", connection.getConnection());
                    sq_com.CommandType = CommandType.StoredProcedure;
                    sq_com.Parameters.AddWithValue("@token_no", rc.myToken);
                    sq_com.Parameters.AddWithValue("@user_token_no", rc.token);
                    sq_com.Parameters.AddWithValue("@Source", rc.latlong);
                    sq_com.Parameters.AddWithValue("@Destination", rc.latlong);
                    sq_com.Parameters.AddWithValue("@Est_Duration", DateTime.Now);
                    sq_com.Parameters.AddWithValue("@Est_Fare", "400");
                    sq_com.Parameters.AddWithValue("@Final_Fare", "350");
                    sq_com.Parameters.AddWithValue("@Trip_status", "Ride To Patient");
                    sq_com.ExecuteNonQuery();
                    return true;
                }
               catch (Exception ex)
                {
                    return false;
                }
          }

        public bool addRoute(string Driver_id, string Customer_id,string StateUpdate,string Status_id)
        {
            try
            {
                SqlCommand sq_com = new SqlCommand("addRoute1", connection.getConnection());
                sq_com.CommandType = CommandType.StoredProcedure;
                sq_com.Parameters.AddWithValue("@Driver_id", Driver_id);
                sq_com.Parameters.AddWithValue("@Customer_id", Customer_id);
                sq_com.Parameters.AddWithValue("@StateUpdate", StateUpdate);
                sq_com.Parameters.AddWithValue("@Status_id", Status_id);
                sq_com.Parameters.AddWithValue("@Latitude", 10);
                sq_com.Parameters.AddWithValue("@Longitude", 20);
                sq_com.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
