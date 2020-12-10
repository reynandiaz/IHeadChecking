using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHeadChecking.DataProcess;

namespace IHeadChecking
{
    public partial class Checking : Form
    {
        private ScannedBarcodeFormRow bindingEntity = new ScannedBarcodeFormRow();

        public Checking()
        {
            InitializeComponent();
            try
            {
                addGridStyle(dataGrid1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem!!" + ex.ToString());
            }
        }


        private void addGridStyle(DataGrid dg)
        {

            DataGridTableStyle dtStyle = new DataGridTableStyle();
            dtStyle.MappingName = "ScannedBarcode";

            DataTable dt = this.bindingEntity.ScannedBarcode;
            for (int i = 0; i < this.bindingEntity.ScannedBarcode.Columns.Count; i++)
            {

                DataProcess.ColumnStyle myStyle = new DataProcess.ColumnStyle(i);

                myStyle.MappingName = this.bindingEntity.ScannedBarcode.Columns[i].ColumnName;

                if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "PanelNo")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "PanelNo";
                    myStyle.MappingName = "PanelNo";
                    myStyle.Width = 70;
                }
                else if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "PitchSize")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Size";
                    myStyle.MappingName = "PitchSize";
                    myStyle.Width = 70;
                }
                else if (this.bindingEntity.ScannedBarcode.Columns[i].ColumnName == "Status")
                {
                    myStyle.CheckCellEven += new CheckCellEventHandler(myStyle_isEven);
                    myStyle.HeaderText = "Status";
                    myStyle.MappingName = "Status";
                    myStyle.Width = 0;
                }
                dtStyle.GridColumnStyles.Add(myStyle);

            }
            dg.TableStyles.Add(dtStyle);
        }

        public void myStyle_isEven(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                if ((int)dataGrid1[e.Row, 2] == 0)
                {
                    e.MeetsCriteria = 0;
                }
                else if ((int)dataGrid1[e.Row, 2] == 1)
                {
                    e.MeetsCriteria = 1;

                }
                else if ((int)dataGrid1[e.Row, 2] == 2)
                {
                    e.MeetsCriteria = 2;
                }
                else
                {
                    e.MeetsCriteria = 3;
                }

            }
            catch (Exception ex)
            {
                e.MeetsCriteria = 4;
                MessageBox.Show(ex.ToString());
            }
        }



        private void Checking_Load(object sender, EventArgs e)
        {
            chkDirect.Checked = true;
            this.label1.Text = GlobalVariable.EmployeeID +"-"+ (GlobalVariable.Designation==1?"Plate":"");
            txtScan.Focus();
            dataGrid1.DataSource = this.bindingEntity.ScannedBarcode;
        }

        private void txtScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                if (txtScan.Text != "")
                {
                    try
                    {
                        if (txtScan.Text.Substring(0, 1).ToString() == "1")
                        {
                            //header
                            DataProcess.CheckingProcess.InsertDataHeader(txtScan.Text.Split(','));
                            lblConstruction.Text = txtScan.Text.Split(',')[1];
                        }
                        else if (txtScan.Text.Substring(0, 1).ToString() == "2")
                        {
                            //qr
                            if (lblConstruction.Text != "" && (GlobalVariable.ConstructionCode == txtScan.Text.Split(',')[1]))
                            {
                                lblPanelNo.Text = txtScan.Text.Split(',')[2] + "," + txtScan.Text.Split(',')[3];
                            }
                        }
                        else if (txtScan.Text.Substring(0, 1).ToString() == "3")
                        {
                            //barcode
                            if (lblPanelNo.Text != "" && (GlobalVariable.ConstructionCode == lblConstruction.Text))
                            {
                                DataProcess.CheckingProcess.UpdatePanel(lblConstruction.Text, lblPanelNo.Text.Split(',')[0], txtScan.Text.Split('/')[2]);
                                
                                if (chkDirect.Checked)
                                {
                                    List<ScannedBarcodeTableRow> row = CheckingTransmit.RetrieveSingleData(lblConstruction.Text, lblPanelNo.Text.Split(',')[0], txtScan.Text.Split('/')[2]);
                                    
                                    this.bindingEntity.ScannedBarcode.Clear();
                                    this.bindingEntity.SetBarcodes(row);

                                    TransmitData(row, "singledata");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid barcode");
                        }
                    }
                    catch (Exception exc)
                    { MessageBox.Show(exc.ToString()); }
                }
                RefreshTable();
                this.txtScan.Text = "";
                this.txtScan.Focus();
            }
        }

        private void TransmitData(List<ScannedBarcodeTableRow> row, string TransmitType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<IHeadService.UploadScannedBarcodeTableRow> scannedBarcodes;
                scannedBarcodes = CheckingTransmit.RetrieveForService(row);

                List<IHeadService.UploadScannedBarcodeTableRow> batchBarcodes = new List<IHeadService.UploadScannedBarcodeTableRow>();

                IHeadService.UploadScannedResult serviceResult;

                using (var service = new IHeadService.Service1())
                {
                    if(TransmitType=="singledata")
                        service.Url = Utilities.MyUtilities.ServicePath;

                        serviceResult = service.UploadScannedBarcode(scannedBarcodes.ToArray());
                        //STATUS
                        //1=success
                        //2=already scanned
                        //3=failed

                        CheckingTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                        if (serviceResult.ServerStatus > 0)
                        {
                            MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                        }

                    else if(TransmitType=="alldata")
                    {
                        int maxRows = Convert.ToInt32(Properties.Resources.MaxRows_InOneBatch);
                        service.Url = Utilities.MyUtilities.ServicePath;
                        int j = 1;
                        int maxBatches = (int)Math.Ceiling((double)scannedBarcodes.Count / maxRows);
                        while (scannedBarcodes.Count > 0 && j <= maxBatches)
                        {
                            int i = 0;
                            batchBarcodes.Clear();
                            while (scannedBarcodes.Count > 0 && i < maxRows)
                            {
                                var scannedrow = scannedBarcodes.First();
                                batchBarcodes.Add(scannedrow);

                                scannedBarcodes.Remove(scannedrow);
                                i++;
                            }

                            serviceResult = service.UploadScannedBarcode(batchBarcodes.ToArray());

                            CheckingTransmit.UpdateLocalWithTransmittedData(serviceResult.UploadedData);

                            if (serviceResult.ServerStatus > 0)
                            {
                                MessageBox.Show(String.Format("Status: {0}\r\n{1}", serviceResult.ServerStatus, serviceResult.ServerMessage));
                            }
                            j++;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        private void RefreshTable()
        {
            try
            {
                List<ScannedBarcodeTableRow> rows = CheckingTable.RetrieveBarcodes(lblConstruction.Text);
                this.bindingEntity.ScannedBarcode.Clear();
                this.bindingEntity.SetBarcodes(rows);
                dataGrid1.DataSource = this.bindingEntity.ScannedBarcode;
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Checking_Closed(object sender, EventArgs e)
        {
            DataProcess.CheckingProcess.DeleteUploadedData();
        }

        private void btnTransmit_Click(object sender, EventArgs e)
        {
            List<ScannedBarcodeTableRow> row = CheckingTransmit.RetrieveAllBarcodeForTransmit(lblConstruction.Text);
            this.bindingEntity.ScannedBarcode.Clear();
            this.bindingEntity.SetBarcodes(row);

            TransmitData(row, "alldata");
            RefreshTable();
        }

    }


    public class ScannedBarcodeFormRow
    {
        public DataTable ScannedBarcode { get; set; }

        public ScannedBarcodeFormRow()
        {
            this.ScannedBarcode = new DataTable("ScannedBarcode");

            this.ScannedBarcode.Columns.Add("PanelNo", typeof(string));
            this.ScannedBarcode.Columns.Add("PitchSize", typeof(string));
            this.ScannedBarcode.Columns.Add("Status", typeof(int));

        }

        public void SetBarcodes(List<ScannedBarcodeTableRow> barcodes)
        {
            this.ScannedBarcode.Clear();
            foreach (var barcode in barcodes)
            {
                this.ScannedBarcode.Rows.Add(
                    barcode.PanelNo,
                    barcode.PitchSize,
                    barcode.Status
                );
            }
        }
    }



}