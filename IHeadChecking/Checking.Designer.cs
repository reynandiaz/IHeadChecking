namespace IHeadChecking
{
    partial class Checking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTransmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPanelNo = new System.Windows.Forms.Label();
            this.lblConstruction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDirect = new System.Windows.Forms.CheckBox();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 215);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 215);
            this.dataGrid1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnTransmit);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 294);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 26);
            // 
            // btnTransmit
            // 
            this.btnTransmit.Location = new System.Drawing.Point(145, 3);
            this.btnTransmit.Name = "btnTransmit";
            this.btnTransmit.Size = new System.Drawing.Size(92, 21);
            this.btnTransmit.TabIndex = 1;
            this.btnTransmit.Text = "Transmit&9";
            this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 21);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "<&0";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblPanelNo);
            this.panel1.Controls.Add(this.lblConstruction);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkDirect);
            this.panel1.Controls.Add(this.txtScan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 79);
            // 
            // lblPanelNo
            // 
            this.lblPanelNo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblPanelNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPanelNo.Location = new System.Drawing.Point(3, 48);
            this.lblPanelNo.Name = "lblPanelNo";
            this.lblPanelNo.Size = new System.Drawing.Size(150, 17);
            // 
            // lblConstruction
            // 
            this.lblConstruction.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblConstruction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConstruction.Location = new System.Drawing.Point(3, 4);
            this.lblConstruction.Name = "lblConstruction";
            this.lblConstruction.Size = new System.Drawing.Size(136, 17);
            this.lblConstruction.Text = "---";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(145, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.Text = "EMPLOYEE";
            // 
            // chkDirect
            // 
            this.chkDirect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkDirect.Location = new System.Drawing.Point(159, 51);
            this.chkDirect.Name = "chkDirect";
            this.chkDirect.Size = new System.Drawing.Size(78, 20);
            this.chkDirect.TabIndex = 5;
            this.chkDirect.Text = "Direct";
            // 
            // txtScan
            // 
            this.txtScan.Location = new System.Drawing.Point(3, 24);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(234, 21);
            this.txtScan.TabIndex = 0;
            this.txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScan_KeyPress);
            // 
            // Checking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Checking";
            this.Text = "Checking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Checking_Load);
            this.Closed += new System.EventHandler(this.Checking_Closed);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTransmit;
        private System.Windows.Forms.CheckBox chkDirect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConstruction;
        private System.Windows.Forms.Label lblPanelNo;
    }
}