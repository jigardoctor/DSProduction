using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Net;
using System.ComponentModel;

namespace Production
{
    public partial class FrmProList : MetroFramework.Forms.MetroForm
    {
       //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath.ToString() + "\\Database1.mdf;Integrated Security=True");

        private SQLiteConnection sqlconn = new SQLiteConnection("Data Source=" + Application.StartupPath.ToString() + "\\Database1.db;version=3");
        
        private SQLiteCommand sqlCmd;
        private DataTable sqlDT = new DataTable();
        private DataSet DS = new DataSet();
        private SQLiteDataAdapter DB;
        private void ExecuteQuery(string query)
        {

            sqlconn.Open();
            sqlCmd = sqlconn.CreateCommand();
            sqlCmd.CommandText=query;
            sqlCmd.ExecuteNonQuery();
            sqlconn.Dispose();
            sqlconn.Close();
        } 
        //private void ()
        //{

        //    sqlconn.Open();
        //    sqlCmd = sqlconn.CreateCommand();
        //    string CommandText = "Select * from Production order by date desc";
        //    DB = new SQLiteDataAdapter(CommandText, sqlconn);
        //    DS.Reset();
        //    DB.Fill(DS);
        //    sqlDT = DS.Tables[0];
        //    metroGrid1.DataSource = sqlDT;
        //    metroGrid1.Columns[0].Visible = false;
        //    sqlconn.Close();
        //}
        public FrmProList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = "operator";
            Bitmap bm = new Bitmap(Properties.Resources.administrator_icon);
            this.Icon = Icon.FromHandle(bm.GetHicon());

            ToolTip t = new ToolTip();
            t.SetToolTip(Export_bt, "Click here To Open Youtube Channel");
            t.SetToolTip(Export_bt, "Click here To Open WebSite Channel");
            Loaddata(); 
            dateTimePicker1.MaxDate = new DateTime(2022, 3, 31);
            dateTimePicker1.MinDate = new DateTime(2021, 3, 31);
            dateTimePicker2.MaxDate = new DateTime(2022, 3, 31);
            dateTimePicker2.MinDate = new DateTime(2021, 3, 31);
            this.WindowState = FormWindowState.Maximized;
       
            if(Properties.Settings.Default.newupdateinfo != Properties.Settings.Default.oldupdateinfo)
            {
                FrmNewUpdate f2 = new FrmNewUpdate();
                f2.metroTextBox1.Text = Properties.Settings.Default.newupdateinfo;
                f2.ShowDialog();
            }
        }
        private void Loaddata()
        {
            try
            {
                string savedetail = "Select * from Production order by date desc";
                using (SQLiteCommand MyCommand2 = new SQLiteCommand(savedetail, sqlconn))
                {
                    MyCommand2.CommandType = CommandType.Text;
                    using (SQLiteDataAdapter adp = new SQLiteDataAdapter(MyCommand2))
                    {
                        using (DataTable ds = new DataTable())
                        {
                            adp.Fill(ds);
                            metroGrid1.DataSource = ds;
                            metroGrid1.Columns[0].Visible = false;
                            calculator();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void calculator()
        {
            
            {
                double sum = 0;
                double hajri = 0;
                double bonus = 0;
                double pagar = 0;
                double total = 0;
               // double mtrs = 0;
                for (int i = 0; i < metroGrid1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(metroGrid1.Rows[i].Cells["stiches"].Value.ToString());
                    hajri += Convert.ToDouble(metroGrid1.Rows[i].Cells["hajri"].Value.ToString());
                    bonus += Convert.ToDouble(metroGrid1.Rows[i].Cells["bonus"].Value.ToString());
                    pagar += Convert.ToDouble(metroGrid1.Rows[i].Cells["pagar"].Value.ToString());
                    total += Convert.ToDouble(metroGrid1.Rows[i].Cells["total"].Value.ToString());
                }
                int count_row = metroGrid1.Rows.Count;
                if (count_row != 0)
                {
                    double avg = sum / count_row;
                    toolStripStatusLabel4.Text = Math.Round(avg, 0).ToString();
                }
                else
                {
                    toolStripStatusLabel4.Text = "0";
                }
                toolStripStatusLabel2.Text = metroGrid1.Rows.Count.ToString();
                toolStripStatusLabel6.Text = hajri.ToString();
                toolStripStatusLabel8.Text = bonus.ToString();
                toolStripStatusLabel10.Text = pagar.ToString();
                toolStripStatusLabel13.Text = total.ToString();
            }
         }
        private void newrec()
        {

            Frmprodetail f2 = new Frmprodetail();
            f2.ShowDialog();
            refreshlist();
        }
        private void refreshlist()
        {
            try
            {
                metroComboBox1.SelectedIndex  = -1;
                metroTextBox1.Text = "";
                Loaddata();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void new_bt_Click(object sender, EventArgs e)
        {
            newrec();
        }
        private void edit()
        {
            if (metroGrid1.Rows.Count > 0)
            {
                Frmprodetail f2 = new Frmprodetail();
                f2.idproductionlist_tx.Text = metroGrid1.SelectedRows[0].Cells["Id"].Value.ToString();
                f2.ShowDialog();
                refreshlist();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "List is empty . . !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void edit_bt_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker2.Visible = true;

            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Visible = false;
                dateTimePicker2.Value = DateTime.Today;
            }
        }

        private void find()
        {
            try
            {
                if (metroTextBox1.Text != "")
                {
                    if (metroComboBox1.SelectedIndex == -1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "ItemList is not selected....please Select The Item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metroComboBox1.Focus();
                    }
                    else
                    {

                        if (metroCheckBox1.Checked == true)
                        {
                            datefilter(metroComboBox1.Text);
                        }
                        else
                        {
                            scomboboxx(metroComboBox1.Text);
                        }
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Data Not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metroTextBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void find_bt_Click(object sender, EventArgs e)
        {
            find();
        }
        string item;
        private void scomboboxx(string item)
        {
            try
            {

               
                    string savedetail = "Select * from Production where "+item+" Like '%"+metroTextBox1.Text+"%'  order by date desc";
                    using (SQLiteCommand MyCommand2 = new SQLiteCommand(savedetail, sqlconn))
                    {
                        MyCommand2.CommandType = CommandType.Text;
                        using (SQLiteDataAdapter adp = new SQLiteDataAdapter(MyCommand2))
                        {
                            using (DataTable ds = new DataTable())
                            {
                                adp.Fill(ds);
                                metroGrid1.DataSource = ds;
                                if (metroGrid1.Rows.Count == 0)
                                {
                                    MetroFramework.MetroMessageBox.Show(this, "Data Not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    metroTextBox1.Text = "";
                                    metroComboBox1.Focus();
                                    Loaddata();
                                }
                                calculator();
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void datefilter(string item)
        {
            try
            {
                DateTime dtFrom = Convert.ToDateTime(dateTimePicker1.Text); //some DateTime value, e.g. DatePicker1.Text;
                DateTime dtTo = Convert.ToDateTime(dateTimePicker2.Text); //some DateTime value, e.g. DatePicker1.Text;


                string savedetail = "Select * from Production where " + item + " Like '%" + metroTextBox1.Text + "%' and date between '"+ dtFrom.ToString("dd.MM.yyyy")+ "' and '" + dtTo.ToString("dd.MM.yyyy") + "' order by date desc";
                using (SQLiteCommand MyCommand2 = new SQLiteCommand(savedetail, sqlconn))
                {
                    MyCommand2.CommandType = CommandType.Text;
                    using (SQLiteDataAdapter adp = new SQLiteDataAdapter(MyCommand2))
                    {
                        using (DataTable ds = new DataTable())
                        {

                           adp.Fill(ds);
                            metroGrid1.DataSource = ds;
                            if (metroGrid1.Rows.Count == 0)
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Data Not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                metroTextBox1.Focus();
                                Loaddata();
                            }
                            calculator();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void clear_bt_Click(object sender, EventArgs e)
        {
            refreshlist();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newrec();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string idproo;
        private void deletedata()
        {
            try
            {
                idproo = metroGrid1.SelectedRows[0].Cells["Id"].Value.ToString();
                if (MetroFramework.MetroMessageBox.Show(this, "Do you want to delete this record...?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    using (SQLiteCommand MyCommand2 = new SQLiteCommand("DELETE FROM Production WHERE Id = '" + idproo + "'", sqlconn))
                    {
                        sqlconn.Open();
                        MyCommand2.ExecuteNonQuery();
                        MetroFramework.MetroMessageBox.Show(this, "Record Deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sqlconn.Close();
                    }
                    Loaddata();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please Select Record to Delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletedata();
        }

        private void FrmProList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Export_bt_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/2kaqygK-Krw");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.shubhamdigital.tk");
        }

        private void metroGrid1_DoubleClick(object sender, EventArgs e)
        {
            edit();
        }

        public void Backup()
        {
            try
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "SQL Server database backup files|*.DSH";
                sd.Title = "Create Database Backup";
                sd.FileName = "Database_BackUp";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    string B = sd.FileName;
                    string keyy = "dsloader";

                    

                    String filepath = "" + Application.StartupPath.ToString() + "";
                    string sqlbackup = "Data Source = " + B + "; version=3;";
                    SQLiteConnection backupcon = new SQLiteConnection(sqlbackup);
                    sqlconn.Open();
                    backupcon.Open();
                    sqlconn.BackupDatabase(backupcon, "main", "main", -1, null, 0);
                   
                    backupcon.Close();
                    sqlconn.Close();
                   // EncryptFile(B, keyy);


                    MetroFramework.MetroMessageBox.Show(this, "Backup Created Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Backup Not Created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private static void DecryptFile(string filePath, string key)
        {
            byte[] encrypted = File.ReadAllBytes(filePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;


                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(encrypted, 0, encrypted.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());
                    //  Console.WriteLine("Decrypted succesfully " + filePath);
                }
            }
        }
        static void EncryptFile(string filePath, string key)
        {
            byte[] plainContent = File.ReadAllBytes(filePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;


                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());
                    //  Console.WriteLine("Encrypted succesfully " + filePath);
                }
            }
        }

        public async void restore()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Backup sql",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "DSH",
                Filter = "backup files (*.DSH)|*.DSH",
                FilterIndex = 2,
                RestoreDirectory = true,
                
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog()  == DialogResult.OK )
            {
                //openFileDialog1.FileName = "ji.bak";
                string B = openFileDialog1.FileName;
                try
                {
                    string keyy = "dsloader";
                   // DecryptFile(B, keyy);
                    string filepath = "" + Application.StartupPath.ToString() + "";
                    //string BackupPath = "Backup/Backup.db";
                    string restorePath = filepath + "\\Database1.db";
                   
                    //
                    //EncryptFile(filePath, keyy);
                    File.Copy(B, restorePath, true);
                    MetroFramework.MetroMessageBox.Show(this, "Restore Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshlist();
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, "restore erreur", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MetroFramework.MetroMessageBox.Show(this, ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        

        
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Backup();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            restore();
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                find();
                find_bt.Focus();
            }
        }
        private void datefilter()
        {
            try
            {
                DateTime dtFrom = Convert.ToDateTime(dateTimePicker1.Text); //some DateTime value, e.g. DatePicker1.Text;
                DateTime dtTo = Convert.ToDateTime(dateTimePicker2.Text); //some DateTime value, e.g. DatePicker1.Text;


                string savedetail = "Select * from Production where date between '" + dtFrom.ToString("dd.MM.yyyy") + "' and '" + dtTo.ToString("dd.MM.yyyy") + "' order by date desc";
                using (SQLiteCommand MyCommand2 = new SQLiteCommand(savedetail, sqlconn))
                {
                    MyCommand2.CommandType = CommandType.Text;
                    using (SQLiteDataAdapter adp = new SQLiteDataAdapter(MyCommand2))
                    {
                        using (DataTable ds = new DataTable())
                        {
                            adp.Fill(ds);
                            metroGrid1.DataSource = ds;
                            //if (metroGrid1.Rows.Count == 0)
                            //{
                            //   // MetroFramework.MetroMessageBox.Show(this, "Data Not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    metroTextBox1.Focus();
                            //    Loaddata();
                            //}
                            //calculator();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            datefilter();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            datefilter();
        }
        string Downloadurl = "https://shubhamdigital.tk/Publish/DSProduction/DSProductionSetup.msi";
        private void update_bt_Click(object sender, EventArgs e)
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
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message");

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
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Software is Upto Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            label2.Text = e.ProgressPercentage.ToString() + " %";
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FrmNewUpdate f2 = new FrmNewUpdate();
            f2.ShowDialog();
        }
    }
}
