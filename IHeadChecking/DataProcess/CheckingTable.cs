using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace IHeadChecking.DataProcess
{
    public class CheckingTable
    {
        public static List<ScannedBarcodeTableRow> RetrieveBarcodes(string ConstructionCode)
        {
            string query = "Select * from MaterialChecking where ConstructionCode='" + ConstructionCode + "'";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(query, Properties.Resources.ConnectionSDF))
            {
                adapter.Fill(table);
            }
            var result = new List<ScannedBarcodeTableRow>();
            foreach (DataRow row in table.Rows)
            {
                result.Add(new ScannedBarcodeTableRow(row));
            }
            return result;
        }
    }


    public class ScannedBarcodeTableRow
    {
        //creates the field
        public string ConstructionCode { get; set; }
        public string HouseCode { get; set; }
        public string PanelNo { get; set; }
        public string PitchSize { get; set; }
        public int ScannedFlg { get; set; }
        public int Status { get; set; }
        public string EmployeeCode { get; set; }

        public ScannedBarcodeTableRow(DataRow row)
        {
            this.ConstructionCode = row["ConstructionCode"].ToString();
            this.HouseCode = row["HouseCode"].ToString();
            this.PanelNo = row["PanelNo"].ToString();
            this.PitchSize = row["PitchSize"].ToString();
            this.Status = Convert.ToInt32(row["Status"]);
            this.ScannedFlg = Convert.ToInt32(row["ScannedFlg"]);
            this.EmployeeCode = GlobalVariable.EmployeeID;
        }
    }
}
