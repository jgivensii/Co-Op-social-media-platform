using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoOp.ClientApp.Models;

namespace CoOp.Models
{
    public class Dal
    {
        public Response Registration(User userInfo, SqlConnection connection)

        {
            Response response= new();
            SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo(FirstName, LastName, Email, UserName, Password, IsActive, IsApproved) VALUES('"+userInfo.FirstName +"','" + userInfo.LastName +"','" + userInfo.Email +"','" + userInfo.UserName  +"','" + userInfo.Password + "',1,0) "
            , connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close(); 
            if(i>0)
            {
                response.StatusCode = 200;  
                response.StatusMessage = "Registration Successful";
            }
            else
            {
                response.StatusCode = 100;  
                response.StatusMessage = "Registration Failed";
            }
            return response;
        }

        public Response Login(User userInfo, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UserInfo WHERE Email = '" + userInfo.Email + "' AND Password = '" + userInfo.Password + "' ", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if(dt.Rows.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login successful";
                User reg = new User();
                reg.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
                reg.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                reg.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);
                response.Info = reg;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login Failed";
                response.Info = null;
            }
            return response;
        }
    }
}