using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Production
{
    public partial class FrmLogIn : MetroFramework.Forms.MetroForm
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }
        string Downloadurl = "https://shubhamdigital.tk/Publish/DSProduction/DSProductionSetup.msi";
        private void checkupdate()
        {
            Version newversion = null;
            string xmlURL = "https://www.shubhamdigital.tk/Publish/DSProduction/Update.xml";
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlURL);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "dsproduction"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            elementName = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newversion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        Downloadurl = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MetroFramework.MetroMessageBox.Show(this, "Internet is not Conected for News And Update .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (applicationVersion.CompareTo(newversion) < 0)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Do you want to Update this Application . . . ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    // DownloadFile("shubhamdigital.tk/Publish/Setup/Setup.msi", @"C:\Setup.msi");
                    down();
                }
            }
            //else
            //{
            //    MetroFramework.MetroMessageBox.Show(this, "Software is Upto Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private async void down()
        {
            using (System.IO.FileStream fs = System.IO.File.Create("\\DSProductionSetup.msi")) ;
            metroProgressBar1.Visible = true;
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadFileAsync(new Uri("https://www.shubhamdigital.tk/Publish/DSProduction/DSProductionSetup.msi"), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DSProductionSetup.msi");
        }
        void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Enabled = false;
            metroLabel1.Text = e.ProgressPercentage.ToString() + " %";
            metroProgressBar1.Value = e.ProgressPercentage;
        }
        void Completed(object sender, AsyncCompletedEventArgs e)
        {
            this.Enabled = true;
            MetroFramework.MetroMessageBox.Show(this, "Download Successfull . !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metroProgressBar1.Visible = false;
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DSProductionSetup.msi");
            Application.Exit();
        }
        private void newupdate()
        {
            try
            {
                var csb = new MySqlConnectionStringBuilder
                {
                    Server = "34.122.12.194",
                    UserID = "test_remote",
                    Password = "Secure1234!",
                    Database = "companylist",
                    //SslCert = @"C:\Report\client-cert.pem",
                    //SslKey = @"C:\Report\client-key.pem",
                    //SslCa = @"C:\Report\server-ca.pem",
                    //SslMode = MySqlSslMode.VerifyCA,
                };
                using (MySqlConnection con = new MySqlConnection(csb.ConnectionString))
                {
                    string savedetail = "SELECT * FROM `dsproduction`  ";
                    using (MySqlCommand MyCommand2 = new MySqlCommand(savedetail, con))
                    {
                        MyCommand2.CommandType = CommandType.Text;
                        using (MySqlDataAdapter adp = new MySqlDataAdapter(MyCommand2))
                        {
                            using (DataTable ds = new DataTable())
                            {
                                con.Open();
                                adp.Fill(ds);
                                if (con.State == ConnectionState.Open)
                                {
                                    if (ds.Rows[0]["newupdateinfo"].ToString() != "")
                                    {
                                        Properties.Settings.Default.newupdateinfo = ds.Rows[0]["newupdateinfo"].ToString();
                                        Properties.Settings.Default.Save();

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
               // MetroFramework.MetroMessageBox.Show(this, "Internet is not Conected for News And Update .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            newupdate();
            checkupdate();
            metroDateTime1.Value = new DateTime(2022,3,31);
            Bitmap bm = new Bitmap(Properties.Resources.administrator_icon);
            this.Icon = Icon.FromHandle(bm.GetHicon());
            //if(metroDateTime2.Value <= metroDateTime1.Value) 
            {
                loadagain();
            }
          //  else
            {
             //   MetroFramework.MetroMessageBox.Show(this,"Please Contect DIGITAL SHUBHAM FOR FULL VERSION. . . https://shubhamdigital.tk ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             //   Application.Exit();
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
