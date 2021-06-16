using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Production
{
    public partial class Frmprodetail : MetroFramework.Forms.MetroForm
    {
        private SQLiteConnection sqlconn = new SQLiteConnection("Data Source=" + Application.StartupPath.ToString() + "\\Database1.db;version=3");

       // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath.ToString() + "\\Database1.mdf;Integrated Security=True");

        public Frmprodetail()
        {
            InitializeComponent();
        }

        private void Fomproductiondetail_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(Properties.Resources.administrator_icon);
            this.Icon = Icon.FromHandle(bm.GetHicon());


            bindprodata();
        }
        private void bindprodata()
        {
            try
            {
                if (idproductionlist_tx.Text != "")
                {

                    string savedetail = "SELECT * FROM Production where id = '" + idproductionlist_tx.Text + "'";
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

                                    DateTimePicker1.Text = ds.Rows[0]["date"].ToString();
                                    shift_cb.Text = ds.Rows[0]["shift"].ToString();
                                    machine_cb.Text = ds.Rows[0]["machine"].ToString();
                                    operator_cb.Text = ds.Rows[0]["operator"].ToString();
                                    hajri_tx.Text = ds.Rows[0]["hajri"].ToString();
                                    designno_cb.Text = ds.Rows[0]["designno"].ToString();
                                    stiches_tx.Text = ds.Rows[0]["stiches"].ToString();
                                    frame_tx.Text = ds.Rows[0]["frame"].ToString();
                                    tb_tx.Text = ds.Rows[0]["tb"].ToString();
                                    remark_tx.Text = ds.Rows[0]["remark"].ToString();
                                    pagar_tx.Text = ds.Rows[0]["pagar"].ToString();
                                    bonus_tx.Text = ds.Rows[0]["bonus"].ToString();
                                    total_tx.Text = ds.Rows[0]["total"].ToString();

                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Double TOTAL = 0;
            if (total_tx.Text == "" || Convert.ToDouble(total_tx.Text) == 0)
            {
                
                TOTAL = Convert.ToDouble(pagar_tx.Text) + Convert.ToDouble(bonus_tx.Text);
                total_tx.Text = TOTAL.ToString();
            }
            if (stiches_tx.Text == "")
            {
                stiches_tx.Text = "0";
            }
            if (frame_tx.Text == "")
            {
                frame_tx.Text = "0";
            }
            if (tb_tx.Text == "")
            {
                tb_tx.Text = "0";
            }
            if (pagar_tx.Text == "")
            {
                pagar_tx.Text = "0";
            }
            if (hajri_tx.Text == "")
            {
                hajri_tx.Text = "0";
            }
            if (bonus_tx.Text == "")
            {
                bonus_tx.Text = "0";
            }
            TOTAL = Convert.ToDouble(pagar_tx.Text) + Convert.ToDouble(bonus_tx.Text);
            total_tx.Text = TOTAL.ToString();
            if (operator_cb.Text != "")
            {
                if (machine_cb.Text != "")
                {
                    if (designno_cb.Text != "")
                    {
                        if (double.Parse(hajri_tx.Text) > 0)
                        {
                            if (int.Parse(stiches_tx.Text) > 0)
                            {

                                updatdata();
                              
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Please Enter stiches..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                stiches_tx.Focus();
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Please Enter hajri..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            hajri_tx.Focus();
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Please Enter Design No..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        designno_cb.Focus();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please Enter machine..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    machine_cb.Focus();
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter operator..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                operator_cb.Focus();
            }
        }
        private void updatdata()
        {
            try
            {
                if (idproductionlist_tx.Text != "")
                {
                    string update = "UPDATE Production SET date= '" + DateTimePicker1.Value.ToString("dd-MM-yyyy") + "',shift= '" + shift_cb.Text + "', machine= '" + machine_cb.Text + "', operator='" + operator_cb.Text.ToUpper() + "', designno='" + designno_cb.Text.ToUpper() + "', stiches='" + stiches_tx.Text + "', frame='" + frame_tx.Text + "', tb ='" + tb_tx.Text + "', remark='" + remark_tx.Text + "', hajri = '" + hajri_tx.Text + "' , pagar= '" + pagar_tx.Text + "', bonus='" + bonus_tx.Text + "', total='" + total_tx.Text + "'  where Id ='" + idproductionlist_tx.Text + "'";

                    using (SQLiteCommand MyCommand3 = new SQLiteCommand(update, sqlconn))
                    {
                        sqlconn.Open();
                        MyCommand3.ExecuteNonQuery();
                        this.Close();
                        MetroFramework.MetroMessageBox.Show(this, "Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    using (SQLiteCommand cmd = new SQLiteCommand("insert into Production (date,operator,shift,machine,designno,stiches,frame,tb,hajri,pagar,bonus,total,remark) values (@date,@operator,@shift,@machine,@designno,@stiches,@frame,@tb,@hajri,@pagar,@bonus,@total,@remark)", sqlconn))
                    {
                        sqlconn.Open();

                        cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.ToString("dd-MM-yyyy"));
                        cmd.Parameters.AddWithValue("@operator", operator_cb.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@shift", shift_cb.Text);
                        cmd.Parameters.AddWithValue("@machine", machine_cb.Text);
                        cmd.Parameters.AddWithValue("@designno", designno_cb.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@stiches", Convert.ToInt32(stiches_tx.Text));
                        cmd.Parameters.AddWithValue("@frame", Convert.ToInt32(frame_tx.Text));
                        cmd.Parameters.AddWithValue("@tb", Convert.ToInt32(tb_tx.Text));
                        cmd.Parameters.AddWithValue("@hajri", Convert.ToDouble(hajri_tx.Text));
                        cmd.Parameters.AddWithValue("@pagar", Convert.ToInt32(pagar_tx.Text));
                        cmd.Parameters.AddWithValue("@bonus", Convert.ToInt32(bonus_tx.Text));
                        cmd.Parameters.AddWithValue("@total", Convert.ToInt32(total_tx.Text));
                        cmd.Parameters.AddWithValue("@remark", remark_tx.Text);
                        //con.Open();
                        cmd.ExecuteNonQuery();
                        
                        sqlconn.Close();
                        this.Close();
                    }     
                    
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroDateTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                operator_cb.Focus();
            }
        }

        private void operator_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                shift_cb.Focus();
            }
        }

        private void shift_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                machine_cb.Focus();
            }
        }

        private void machine_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                designno_cb.Focus();
            }
        }

        private void designno_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                stiches_tx.Focus();
               
            }
        }

        private void stiches_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frame_tx.Focus();
                if (stiches_tx.Text == "")
                {
                    stiches_tx.Text = "1";
                }
            }
        }

        private void frame_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_tx.Focus();
                if (frame_tx    .Text == "")
                {
                    frame_tx.Text = "0";
                }
            }
        }

        private void tb_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hajri_tx.Focus();
                if (tb_tx.Text == "")
                {
                    tb_tx.Text = "0";
                }
            }
        }

        private void hajri_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pagar_tx.Focus();
                if (hajri_tx.Text == "")
                {
                    hajri_tx.Text = "1.0";
                }
            }
        }

        private void pagar_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bonus_tx.Focus();
                if (pagar_tx.Text == "")
                {
                    pagar_tx.Text = "0";
                }
            }
        }

        private void bonus_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bonus_tx.Text == "")
                {
                    bonus_tx.Text = "0";
                }
                remark_tx.Focus();
            }
        }

        private void remark_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save_bt.Focus();
            }
        }

        private void stiches_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frame_tx_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_tx_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tb_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void hajri_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void pagar_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void bonus_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
