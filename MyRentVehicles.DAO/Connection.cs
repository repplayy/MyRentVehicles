﻿using System;
using System.Data.SqlClient;

namespace MyRentVehicles.DAO
{
    public class Connection
    {
        SqlConnection con = new SqlConnection();
        public Connection()
        {
            con.ConnectionString = @"Data Source=DESKTOP-P1MJGKC;Integrated Security=True";

        }

       public SqlConnection connect()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }


            return con; 
        }

        public void disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }

    }
}
