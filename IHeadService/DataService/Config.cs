using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace IHeadService.DataService
{
    public class Config
    {
        public static SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);


        public static void ExecuteCmd(string query)
        {
            var command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        public static int ExecuteIntScalar(string query)
        {
            int intReturn = 0;

            var command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                var cnt = command.ExecuteScalar();
                intReturn = Convert.ToInt32(cnt);
                return intReturn;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
