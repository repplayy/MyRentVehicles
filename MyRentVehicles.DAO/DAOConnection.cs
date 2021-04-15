using System;
using System.Data.SqlClient;

namespace MyRentVehicles.DAO
{
    public class DAOConnection
    {
        SqlConnection con = new SqlConnection();
        public DAOConnection()
        {
            con.ConnectionString = @"Data Source=DESKTOP-P1MJGKC;Integrated Security=True";
        }

        public SqlConnection connect()
        {
            if (con.State == System.Data.ConnectionState.Closed)
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
