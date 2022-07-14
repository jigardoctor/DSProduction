using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    public partial class ActivationFrm : MetroFramework.Forms.MetroForm
    {
        private static TimeZoneInfo Indiamtime = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public ActivationFrm()
        {
            InitializeComponent();
        }

        private void ActivationFrm_Load(object sender, EventArgs e)
        {
            string savedetail = "SELECT * FROM HostName ";
            using (SQLiteCommand MyCommand2 = new SQLiteCommand(savedetail, sqlconn))
            {
                MyCommand2.CommandType = CommandType.Text;
                using (SQLiteDataAdapter adp = new SQLiteDataAdapter(MyCommand2))
                {
                    using (DataTable ds = new DataTable())
                    {

                        adp.Fill(ds);
                        if (ds.Rows.Count == 1)
                        {
                            company_tx.Text = ds.Rows[0]["CompanyName"].ToString();
                            key_tx.Text = ds.Rows[0]["ActivationKey"].ToString();
                            system_code.Text = ds.Rows[0]["SystemCode"].ToString();
                            phno_tx.Text = ds.Rows[0]["PhNo"].ToString();
                            Properties.Settings.Default.CompanyName = company_tx.Text;
                            Properties.Settings.Default.PhNo = phno_tx.Text;
                            Properties.Settings.Default.SystemCode = system_code.Text;
                            Properties.Settings.Default.ActivationKey = key_tx.Text;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                           // if (Properties.Settings.Default.SystemCode == string.Empty)
                            {
                                DateTime indiatime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Indiamtime);
                                int mnts = indiatime.Minute;
                                int hour = indiatime.Hour;
                                int day_in_month = indiatime.Day;
                                int Month = indiatime.Month;
                                int day_in_year = indiatime.DayOfYear;
                                int year = indiatime.Year;
                                string rslt = year.ToString()+"N" + mnts.ToString() + "U" + hour.ToString() + "Y" + day_in_month.ToString() + "T" + day_in_year.ToString() + "R" + Month.ToString()  +"J" ;
                                Properties.Settings.Default.SystemCode = rslt;
                               
                                int otp = day_in_month * Month * year*day_in_year;
                                Properties.Settings.Default.ActivationKey = otp.ToString();
                                Properties.Settings.Default.Save();
                                system_code.Text = Properties.Settings.Default.SystemCode;
                            }
                        }
                    }
                }
            }

        }
        public static String Encrypt(string value)
        {
            // if (value != string.Empty)
            {
                string hash = "$D!G!T@L58592nd";
                byte[] data = UTF8Encoding.UTF8.GetBytes(value);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                        return Convert.ToBase64String(result, 0, result.Length);
                    }
                }
            }
        }
        public static String Decrypt(string value)
        {
            // if (value != string.Empty)
            {
                string hash = "$D!G!T@L58592nd";
                byte[] data = Convert.FromBase64String(value);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(result);
                    }
                }
            }
        }
        private SQLiteConnection sqlconn = new SQLiteConnection("Data Source=" + Application.StartupPath.ToString() + "\\Database1.db;version=3");

        private void insrthostname()
        {
            if (company_tx.Text != string.Empty)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("insert into HostName (CompanyName,ActivationKey,SystemCode,PhNo) values (@CompanyName,@ActivationKey,@SystemCode,@PhNo)", sqlconn))
                {
                    sqlconn.Open();

                    cmd.Parameters.AddWithValue("@CompanyName", company_tx.Text);
                    cmd.Parameters.AddWithValue("@ActivationKey", key_tx.Text);
                    cmd.Parameters.AddWithValue("@SystemCode", system_code.Text);
                    cmd.Parameters.AddWithValue("@PhNo", phno_tx.Text);
                    Properties.Settings.Default.PhNo = phno_tx.Text;
                    Properties.Settings.Default.CompanyName = company_tx.Text;
                    Properties.Settings.Default.SystemCode = system_code.Text;
                    Properties.Settings.Default.ActivationKey = key_tx.Text;
                    Properties.Settings.Default.Save();
                    //con.Open();
                    cmd.ExecuteNonQuery();
                    sqlconn.Close();
                   // this.Close();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "The Enter Company Name .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                company_tx.Focus();
            }
        }
        private void cancel_bt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Submit_bt_Click(object sender, EventArgs e)
        {
            if(key_tx.Text == Properties.Settings.Default.ActivationKey.ToString())
            {
                this.Hide();
                insrthostname();
                Properties.Settings.Default.isActivated = true;
                Properties.Settings.Default.Save();
                FrmLogIn f2 = new FrmLogIn();
                f2.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "The Enter Activation Code is not correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                key_tx.Focus();
            }
        }
    }
}
