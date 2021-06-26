using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    public partial class FrmNewUpdate : MetroFramework.Forms.MetroForm
    {
        public FrmNewUpdate()
        {
            InitializeComponent();
        }

        private void FrmNewUpdate_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.oldupdateinfo == Properties.Settings.Default.newupdateinfo)
            {
                metroTextBox1.Text = Properties.Settings.Default.oldupdateinfo;
            }
            else
            {
                metroTextBox1.Text = Properties.Settings.Default.newupdateinfo;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.oldupdateinfo = metroTextBox1.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
