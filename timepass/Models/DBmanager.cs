using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace timepass.Models
{
    public class DBmanager
    {

        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=TimePass;Integrated Security=True");
        SqlCommand cmd = null;
        public bool MyInsertUpdateDelete(string command)
        {
            con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=TimePass;Integrated Security=True");
            cmd = new SqlCommand(command, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return true;
            else
                return false;

        }

        //method for display all recorder
        public DataTable GetAllRecords(string command)
        {
            cmd = new SqlCommand(command, con);
            SqlDataAdapter sa = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }
        //Method of capta code genrator
        public string GetCaptchaCode()
        {
            char ch1, ch2, ch3, ch4, ch5, ch6;
            Random r = new Random();
            ch1 = (char)(r.Next(65, 92));
            ch2 = (char)(r.Next(50, 55));
            ch3 = (char)(r.Next(97, 122));
            ch4 = (char)(r.Next(100, 120));
            ch5 = (char)(r.Next(76, 91));
            ch6 = (char)(r.Next(50, 55));
            return ch1 + "" + ch2 + "" + ch3 + "" + ch4 + "" + ch5 + "" + ch6;

        }
    }
}