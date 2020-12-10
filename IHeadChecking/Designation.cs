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
    public partial class Designation : Form
    {
        public Designation()
        {
            InitializeComponent();
        }

        private void btnSteelPlate_Click(object sender, EventArgs e)
        {
            try
            {
                LoginProcess.UpdateDesignation(1);
                this.Close();
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}