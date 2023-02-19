using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestourantDemo
{
    public partial class frmTables : Form
    {
        public frmTables()
        {
            InitializeComponent();
        }

        private void btnExit_3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğininize emin misiniz?", "!!UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnTable_1_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_1.Text.Length;
            cGeneral._ButtonValue = btnTable_1.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_1.Name;
            this.Close();
            frm.ShowDialog();//sipariş kısmı açılır
        }

        private void btnTable_2_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_2.Text.Length;
            cGeneral._ButtonValue = btnTable_2.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_3_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_3.Text.Length;
            cGeneral._ButtonValue = btnTable_3.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_4_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_4.Text.Length;
            cGeneral._ButtonValue = btnTable_4.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_5_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_5.Text.Length;
            cGeneral._ButtonValue = btnTable_5.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_6_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_6.Text.Length;
            cGeneral._ButtonValue = btnTable_6.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_7_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_7.Text.Length;
            cGeneral._ButtonValue = btnTable_7.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_8_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_8.Text.Length;
            cGeneral._ButtonValue = btnTable_8.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_9_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_9.Text.Length;
            cGeneral._ButtonValue = btnTable_9.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnTable_10_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();

            int length = btnTable_10.Text.Length;
            cGeneral._ButtonValue = btnTable_10.Text.Substring(length - 6, 6);
            cGeneral._ButtonName = btnTable_10.Name;
            this.Close();
            frm.ShowDialog();
        }
        cGeneral gnl = new cGeneral();

        private void frmTables_Load(object sender, EventArgs e)
        {
            cGeneral gnl = new cGeneral();

            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("SELECT TABLE_SITUATION,ID from TABLES", con);
            SqlDataReader dr = null;
            if (con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())//verileri okuma işlemi yapılıyor
            {
                foreach (Control item in this.Controls)//gelen verilerin yani elamanların kontrol işlemi yapılır
                {
                    if (item is Button)//buton ise
                    {
                        if (item.Name=="btnTable_"+dr["ID"].ToString() && dr["TABLE_SITUATION"].ToString() =="1" )//ID Sİ BİR OLANIN ARKA PLANINI DEĞİŞTİRİ
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.MASA1);
                        }
                        else if (item.Name == "btnTable_" + dr["ID"].ToString() && dr["TABLE_SITUATION"].ToString() == "2")
                        //{
                        //    cTable tb = new cTable();
                        //    DateTime dt1 = Convert.ToDateTime(tb.SessionSum(2, dr["ID"].ToString()));//TABLE SINIFINDAKİ FONKSİYONA DEĞER GÖNDERİYOR
                        //                                                                             //session sum fonksiyonundan dönecek değer alınıyor
                        //    DateTime dt2 = DateTime.Now;
                        //    string st1 = Convert.ToDateTime(tb.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                        //    //gelen değerin kısa saati alınıyor
                        //    string st2 = DateTime.Now.ToShortTimeString();
                        //    //şu anın kısa saati alınıyor
                        //    DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                        //    DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);
                        //    var diffirence = t2 - t1;
                        //    item.Text = String.Format("{0}{1}{2}",
                        //    diffirence.Days > 0 ? string.Format("{0} gün ", diffirence.Days) : "",
                        //    diffirence.Hours > 0 ? string.Format("{1} saat  ", diffirence.Days) : "",
                        //    diffirence.Minutes > 0 ? string.Format("{2} dakika ", diffirence.Days) : "").Trim() + "\n\n\nMASA" + dr["ID"].ToString();
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                        }
                        else if (item.Name == "btnTable_" + dr["ID"].ToString() && dr["TABLE_SITUATION"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.acıkmasa);
                        }
                        else if (item.Name == "btnTable_" + dr["ID"].ToString() && dr["TABLE_SITUATION"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve);
                        }
                    }
                }
            }
           

        }
    }
}
