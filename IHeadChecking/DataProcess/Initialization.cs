using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;

namespace IHeadChecking.DataProcess
{
    public class Initialization
    {
        public static void Initialize()
        {
            if (!File.Exists(Properties.Resources.DatabaseFileName))
            {

            //    File.Delete(Properties.Resources.DatabaseFileName); // TODO 開発用
            //    CreateDatabase();
            //}
            //else
            //{
                CreateDatabase();
            }
        
        }
        private static void CreateDatabase()
        {
            var engine = new SqlCeEngine(Properties.Resources.ConnectionSDF);
            engine.CreateDatabase();

            CreateLoginTable();
            CreateDetailsTable();

        }
        private static void CreateLoginTable()
        {
            string query = "Create table LoginTable(" +
                "EmployeeID nvarchar(20) not null," +
                "Designation int," +
                "Primary key (EmployeeID)" +
                ")";
            Config.ExecuteCmd(query);
        }
        private static void CreateDetailsTable()
        {
            string query = "Create table MaterialChecking(" +
                 "ConstructionCode nvarchar(20) not null," +
                 "HouseCode nvarchar(5) not null," +
                 "PanelNo nvarchar(20) not null," +
                 "PitchSize nvarchar(10) not null," +
                 "ScannedFlg int,"+
                 "Status int ,"+
                 "Primary key (ConstructionCode,PanelNo)" +
                 ")";
            Config.ExecuteCmd(query);
        }
    }
}
