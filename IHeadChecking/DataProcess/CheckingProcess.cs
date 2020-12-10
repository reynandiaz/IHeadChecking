using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using IHeadChecking.DataProcess;

namespace IHeadChecking.DataProcess
{
    public class CheckingProcess
    {
        public static void InsertDataHeader(string[] strHeaderData)
        {
            string strCheck = "Select count(constructionCode) from MaterialChecking where constructionCode = '" + strHeaderData[1] + "'";

           
            int cnt = Config.ExecuteIntScalar(strCheck);
            if (cnt == 0)
            {
                int PanelCtr = 4;
                int PitchCtr = 5;
               for( var x=1;x<=(Convert.ToInt32(strHeaderData[3])/2);x++)
               {
                   
                   string strInsert = "Insert into MaterialChecking values (" +
                                        "'" + strHeaderData[1] + "'," +
                                        "'" + strHeaderData[2] + "'," +
                                        "'" + strHeaderData[PanelCtr] + "'," +
                                        "'" + strHeaderData[PitchCtr] + "'," +
                                        "0,"+
                                        "0)";
                   Config.ExecuteCmd(strInsert);
                   PanelCtr = PanelCtr + 2;
                   PitchCtr = PitchCtr + 2 ;
               }
               GlobalVariable.ConstructionCode = strHeaderData[1];
               GlobalVariable.HouseCode = strHeaderData[2];
            }
        }

        public static void UpdatePanel(string ConstructionCode,string PanelNo, string PitchSize)
        {
            string query = "Update MaterialChecking set ScannedFlg = 1 " +
                            "where ConstructionCode = '" + ConstructionCode +"' " +
                            "and PanelNo = '" + PanelNo + "' " +
                            "and PitchSize = '" + PitchSize + "'";
            Config.ExecuteCmd(query);
        }
        public static void DeleteUploadedData()
        {
            string query = "Delete from MaterialChecking where Status=1 or Status=2";
            Config.ExecuteCmd(query);
        }
    }
}
