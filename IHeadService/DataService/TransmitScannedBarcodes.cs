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
    public class TransmitScannedBarcodes
    {
        public static void TransmitScannedData(SqlConnection connection, UploadScannedBarcodeTableRow row, SqlTransaction transaction)
        {
            try
            {
                string strCheck = "Select count(PanelNo) from IHeadChecking " +
                                    "where ConstructionCode ='" + row.ConstructionCode + "' " +
                                    "and PanelNo ='" + row.PanelNo + "' " +
                                    "and PitchSize = '" + row.PitchSize + "'";

                string strInsert = "INSERT INTO dbo.IHeadChecking "+
                                    "	( "+
                                    "	ConstructionCode, "+
                                    "	HouseCode, "+
                                    "	PanelNo, "+
                                    "	PitchSize, "+
                                    "	ScannedDate, "+
                                    "	CreatedDate, "+
                                    "	DeletedDate, "+
                                    "	UpdatedDate, "+
                                    "	UpdatedBy "+
                                    "	) "+
                                    "VALUES  "+
                                    "	( "+
                                    "	'"+ row.ConstructionCode +"', "+
                                    "	'"+ row.HouseCode + "', "+
                                    "	'"+ row.PanelNo +"', "+
                                    "	'"+ row.PitchSize +"', "+
                                    "	getdate(), "+
                                    "	getdate(), "+
                                    "	null, "+
                                    "	getdate(), "+
                                    "	'"+ row.EmployeeCode +"' "+
                                    "	) ";

                int cntCheck = Config.ExecuteIntScalar(strCheck);
                if (cntCheck == 0)
                {
                    Config.ExecuteCmd(strInsert);
                    row.Status = 1;
                }
                else
                {
                    row.Status = 2;
                }
            }
            catch(Exception exc)
            {
                row.Status = 3;
                row.ErrMsg = exc.ToString();
            }
        }
    }

    public class UploadScannedBarcodeTableRow
    {
        public UploadScannedBarcodeTableRow()
        {
        }

        public UploadScannedBarcodeTableRow(DataRow row)
        {
            this.ConstructionCode = row["ConstructionCode"].ToString();
            this.HouseCode = row["HouseCode"].ToString();
            this.PanelNo = row["PanelNo"].ToString();
            this.PitchSize = row["PitchSize"].ToString();
            this.Status = Convert.ToInt32(row["Status"]);
            this.ScannedFlg = Convert.ToInt32(row["ScannedFlg"]);
            this.EmployeeCode = row["EmployeeCode"].ToString();
        }
        //creates the field
        public string ConstructionCode { get; set; }
        public string HouseCode { get; set; }
        public string PanelNo { get; set; }
        public string PitchSize { get; set; }
        public int ScannedFlg { get; set; }
        public int Status { get; set; }
        public string EmployeeCode { get; set; }

        public string ErrMsg {get;set;}

    }

}
