using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace IHeadChecking.DataProcess
{
    public class GlobalVariable
    {
        public static string EmployeeID { get; set; }
        public static int Designation { get; set; }

        public static string ConstructionCode { get; set; }
        public static string HouseCode { get; set; }

    }

}
