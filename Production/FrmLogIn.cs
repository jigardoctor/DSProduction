using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    public partial class FrmLogIn : MetroFramework.Forms.MetroForm
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }
 
        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            metroDateTime1.Value = new DateTime(2022,3,31);
            Bitmap bm = new Bitmap(Properties.Resources.administrator_icon);
            this.Icon = Icon.FromHandle(bm.GetHicon());
            if(metroDateTime2.Value <= metroDateTime1.Value) 
            {
                loadagain();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"Please Contect DIGITAL SHUBHAM FOR FULL VERSION. . . https://shubhamdigital.tk ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
        private void loadagain()
        {
            try
            {
                metroProgressBar1.Value = 0;
                timer1.Enabled = true;
                timer1.Start();
                timer1.Interval =1;
                metroProgressBar1.Maximum = 100;
                timer1.Tick += new EventHandler(timer_tick);
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this,  "Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                if (metroProgressBar1.Value != 100)
                {
                    metroProgressBar1.Value++;
                }
                else
                {
                    timer1.Stop();
                    FrmProList f2 = new FrmProList();
                    f2.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.shubhamdigital.tk");
        }
    }
}
