using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace IHeadChecking.DataProcess
{
    public class CheckingTransmit
    {
        public static List<ScannedBarcodeTableRow> RetrieveSingleData(string ConstructionCode,string PanelNo,string PitchSize)
        {
            string query = "Select * from MaterialChecking where ConstructionCode='" + ConstructionCode + "' and PanelNo = '" + PanelNo + "' and PitchSize='"+PitchSize+"'";

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

        public static List<ScannedBarcodeTableRow> RetrieveAllBarcodeForTransmit(string ConstructionCode)
        {
            string query = "Select * from ContainerDetails where status =0 and ConstructionCode='" + ConstructionCode + "'";

            var table = new DataTable();
            using (var adapter = new SqlCeDataAdapter(query.ToString(), Properties.Resources.ConnectionSDF))
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

        public static List<IHeadService.UploadScannedBarcodeTableRow> RetrieveForService(List<ScannedBarcodeTableRow> rows)
        {
            List<ScannedBarcodeTableRow> localRows;

            localRows = rows;

            var allServiceRow = new List<IHeadService.UploadScannedBarcodeTableRow>();

            foreach (ScannedBarcodeTableRow localRow in localRows)
            {
                var serviceRow = new IHeadService.UploadScannedBarcodeTableRow();

                serviceRow.ConstructionCode = localRow.ConstructionCode;
                serviceRow.HouseCode = localRow.HouseCode;
                serviceRow.PanelNo = localRow.PanelNo;
                serviceRow.PitchSize = localRow.PitchSize;
                serviceRow.ScannedFlg = localRow.ScannedFlg;
                serviceRow.Status = localRow.Status;
                serviceRow.EmployeeCode = localRow.EmployeeCode;

                allServiceRow.Add(serviceRow);
            }
            return allServiceRow;
        }

        public static void UpdateLocalWithTransmittedData(IHeadService.UploadScannedBarcodeTableRow[] servicerows)
        {
            foreach (IHeadService.UploadScannedBarcodeTableRow row in servicerows)
            {
                string query = "Update MaterialChecking set Status = "+row.Status+" " +
                 "where ConstructionCode = '" + row.ConstructionCode + "' " +
                 "and PanelNo = '" + row.PanelNo + "' " +
                 "and PitchSize = '" + row.PitchSize + "'";
                Config.ExecuteCmd(query);
            }
        }
    }
}
