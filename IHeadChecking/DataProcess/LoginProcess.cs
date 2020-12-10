using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;


namespace IHeadChecking.DataProcess
{
    public class LoginProcess
    {
        public static void CheckLogin(string prEmployeeID)
        {

            string EmployeeID = prEmployeeID.Length == 10 ? EvaluateEmployeeID(prEmployeeID) : prEmployeeID;

            string checkid = "Select count(EmployeeID) from LoginTable where EmployeeID = '" + EmployeeID + "'";

            string InsertID = "Insert into LoginTable values ('" + EmployeeID + "',0)";

            string selectid = "Select * from LoginTable where EmployeeID = '" + EmployeeID + "'";

            
            int cnt = Config.ExecuteIntScalar(checkid);
            if (cnt == 0)
            {
                Config.ExecuteCmd(InsertID);

                GlobalVariable.EmployeeID = EmployeeID;
                GlobalVariable.Designation = 0;
            }
            else
            {
                DataTable dtable = Config.RetreiveData(selectid);
                foreach (DataRow row in dtable.Rows)
                {
                    GlobalVariable.EmployeeID = row["EmployeeID"].ToString();
                    GlobalVariable.Designation = Convert.ToInt32(row["Designation"]);
                }
            }
        }
        
        public static string EvaluateEmployeeID(string EmployeeID)
        {
            string GetCompanyEmployeeID = "";
            string ValidatedID;
            char validateEmployeeID;

            EmployeeID = EmployeeID.Substring(0, EmployeeID.Length - 1);

            validateEmployeeID = Convert.ToChar(EmployeeID.Substring(2, 1));
            try
            {
                //HR
                if (validateEmployeeID == 'R' || validateEmployeeID == '3')
                {
                    GetCompanyEmployeeID = EmployeeID.Substring(4, 5);
                }
                //PV
                else if (validateEmployeeID == 'P' || validateEmployeeID == '0')
                {
                    GetCompanyEmployeeID = '0' + EmployeeID.Substring(4, 6);
                }
                //SCAD
                else if (validateEmployeeID == 'S' || validateEmployeeID == '1')
                {
                    GetCompanyEmployeeID = '1' + EmployeeID.Substring(4, 6);
                }
                //HTI
                else if (validateEmployeeID == 'H' || validateEmployeeID == '2')
                {
                    GetCompanyEmployeeID = '2' + EmployeeID.Substring(3, 6);
                }
                //WKN
                else if (validateEmployeeID == 'W' || validateEmployeeID == '4')
                {
                    GetCompanyEmployeeID = '4' + EmployeeID.Substring(4, 6);
                }
            }
            finally
            {
                ValidatedID = GetCompanyEmployeeID.ToString();
            }
            return ValidatedID;
        }

        public static void UpdateDesignation(int intDesig)
        {
            string query = "Update LoginTable set Designation = " + intDesig + " where EmployeeID = '" + GlobalVariable.EmployeeID + "'";

            Config.ExecuteCmd(query);

            GlobalVariable.Designation = intDesig;
            
        }
    }
}
