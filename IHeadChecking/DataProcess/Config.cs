using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace IHeadChecking.DataProcess
{
    public class Config
    {
        public static SqlCeConnection connection = new SqlCeConnection(Properties.Resources.ConnectionSDF);


        public static void ExecuteCmd(string query)
        {
            var command = new SqlCeCommand(query, connection);
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

            var command = new SqlCeCommand(query, connection);
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

        public static DataTable RetreiveData(string query)
        {
            DataTable dtable = new DataTable();
            var command = new SqlCeCommand(query, connection);
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                dtable.Load(reader);
            }
            finally
            {
                connection.Close();
            }

            return dtable;
        }

    }
}
