using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace Bot_Application2
{
    public class data
    {

        SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aayush\Documents\data.mdf;Integrated Security=True;Connect Timeout=30");

        public string getdata(string ctr)
        {
            ctr = ctr.ToLower();
            sc.Open();
            string str2;
            SqlCommand cmd1 = new SqlCommand("select capital from cc where country ='" + ctr + "'", sc);
           
            SqlDataReader rdr = null;
            rdr = cmd1.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    str2 = rdr["Capital"].ToString();
                    return str2;
                }
            }
            else
            {
                return "no";
            }
            return "no";
           
           
        }



    }
  
}