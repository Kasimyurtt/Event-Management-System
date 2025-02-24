using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace ConsoleApp1.FACADE
{
    internal class CONNECTDB
    {
        public static readonly SqlConnection con = new
            SqlConnection(ConfigurationManager.ConnectionStrings["myCs_1"].ConnectionString);

        public static void connect()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public static void disconnect()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
