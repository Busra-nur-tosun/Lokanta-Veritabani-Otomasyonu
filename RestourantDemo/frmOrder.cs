using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestourantDemo
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

       

        private void btnTurnBack_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnExit_3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğininize emin misiniz?", "!!UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //hesap makinesi
        void process(object sender, EventArgs e)
        {

        }
        int TableId;
        int AdditionId;
        private void frmOrder_Load(object sender, EventArgs e)
        {
            label1.Text = cGeneral._ButtonValue;
            cTable t = new cTable();
            TableId = t.TableGetByNumber(cGeneral._ButtonName);
            if (t.TableGetByState(TableId, 2) == true || t.TableGetByState(TableId, 4) == true)
                // durumu 21 olan masa dolu 4 olan masa rezerve olduğu için  bu masalarda ,işlem yapılır
            {
                cAddition Ad = new cAddition();
                AdditionId = Ad.getByAddition(TableId);//adisyon alındı
                cOrder orders = new cOrder();
                orders.getByOrder(lvOrder, AdditionId);
            }
            btn1.Click += new EventHandler(process);
            btn2.Click += new EventHandler(process);
            btn3.Click += new EventHandler(process);
            btn4.Click += new EventHandler(process);
            btn5.Click += new EventHandler(process);
            btn6.Click += new EventHandler(process);
            btn7.Click += new EventHandler(process);
            btn8.Click += new EventHandler(process);
            btn9.Click += new EventHandler(process);
            btn0.Click += new EventHandler(process);
        }
        cProductTypes pt = new cProductTypes();
        //menü listesindeki butona basılınca listviewde veri tabanı bilgilerin gelmesi sağlanır
        private void btnMAINCOURSE3_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnMAINCOURSE3);//fonksiyona  listview ve  button gönderilir
        }

        private void btnDrinks8_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnDrinks8);
        }

        private void btnDESSERTS7_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnDESSERTS7);
        }

        private void btnSALAD6_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnSALAD6);
        }

        private void btnSOUP1_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnSOUP1);
        }

        private void btnFASTFOOD5_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnFASTFOOD5);
        }

        private void btnPASTA4_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnPASTA4);
        }

        private void btnBREAKHOT2_Click(object sender, EventArgs e)
        {
            pt.GetByProductTypes(lvMenu, btnBREAKHOT2);
        }
        int counter = 0;
        int counter2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtNumber.Text=="")//adet girilen değer boş ise default olarak 11 gelecek
            {
                txtNumber.Text = "1";
            }
            if (lvMenu.Items.Count>0)//menü lisviewindeki değerler 0 dan büyükse yani listede eleman varsa sipraişler lisviewine ekleyecek
            {
                counter = lvOrder.Items.Count;
                lvOrder.Items.Add(lvMenu.SelectedItems[0].Text);//isimlerin olduğu yer
                lvOrder.Items[counter].SubItems.Add(txtNumber.Text);// defaoult olarak 1 giriliyor
                lvOrder.Items[counter].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);//ürün no alınıyor subitems ile isimlerin altındaki boşluklar dlduruluyr
                lvOrder.Items[counter].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text)*Convert.ToDecimal(txtNumber.Text)).ToString());
                //fiyat ile adet çarpılıyor 
                lvOrder.Items[counter].SubItems.Add("0");
                counter2 = lvnewlyadded.Items.Count;
                lvOrder.Items[counter].SubItems.Add(counter.ToString());

                lvnewlyadded.Items.Add(AdditionId.ToString());
                lvnewlyadded.Items[counter2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvnewlyadded.Items[counter2].SubItems.Add(txtNumber.Text);
                lvnewlyadded.Items[counter2].SubItems.Add(TableId.ToString());
                lvnewlyadded.Items[counter2].SubItems.Add(counter2.ToString());
                counter2++;
                txtNumber.Text = "";

            }
        }
        ArrayList delete = new ArrayList();
        private void btnOrder_Click(object sender, EventArgs e)
        {
            /* 1 masa boş
             * 2 masa dolur
             * 3 masa rezerve
             */
            cTable tablle = new cTable();
            frmTables frmTable = new frmTables();
            cAddition newAdiditon = new cAddition();
            cOrder order = new cOrder();
            bool result = false;
            if (tablle.TableGetByState(TableId,1)==true)
            {
                newAdiditon.SERVICE_TYPEID = 1;
                newAdiditon.EMPLOYEE_ID = 1;
                newAdiditon.TABLE_ID = 1;
                newAdiditon.DATE = 1;
                result = newAdiditon.setByAdditionNew(newAdiditon);
                tablle.SetChangeTableState(cGeneral._ButtonName, 2);
                if (lvOrder.Items.Count>0)
                {
                    for (int i = 0; i < lvOrder.Items.Count; i++)
                    {
                        order.TABLE_ID = TableId;
                        order.PRODUCT_ID = Convert.ToInt32(lvOrder.Items[i].SubItems[2].Text);
                        order.ADDITION_ID = newAdiditon.getByAddition(TableId);
                        order.PIECE = Convert.ToInt32(lvOrder.Items[i].SubItems[1].Text);
                        order.setSaveOrder(order);

                    }
                    frmTable.Show();
                }
            }
            else  if (tablle.TableGetByState(TableId, 2) == true)
            {
               
                if (lvnewlyadded.Items.Count > 0)
                {
                    for (int i = 0; i < lvnewlyadded.Items.Count; i++)//kaç tane item varsa o kadar veri dönderecek
                    {
                        order.TABLE_ID = TableId;
                        order.PRODUCT_ID = Convert.ToInt32(lvnewlyadded.Items[i].SubItems[1].Text);
                        order.ADDITION_ID = newAdiditon.getByAddition(TableId);
                        order.PIECE = Convert.ToInt32(lvnewlyadded.Items[i].SubItems[2].Text);
                        order.setSaveOrder(order);

                    }
                    
                }
                //if (delete.count > 0)
                //{
                //    foreach (string item in delete)
                //    {
                //        order.setSaveOrder(Convert.ToInt32(item));
                //    }
                //}
                this.Close();
                frmTable.Show();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void lvOrder_DoubleClick(object sender, EventArgs e)
        {
            if (lvOrder.Items.Count>0)
            {
                if (lvOrder.SelectedItems[0].SubItems[4].Text!="0")//0 değilse veri tabanına kaydedilmiş
                {
                    cOrder saveOrder = new cOrder();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvOrder.Items[0].SubItems[4].Text));
                    
                }
                else
                {
                    for (int i = 0; i < lvnewlyadded.Items.Count; i++)
                    {
                        if (lvnewlyadded.Items[i].SubItems[4].Text==lvOrder.SelectedItems[0].SubItems[5].Text )//silinen ıdsi 0 ise sil
                        {
                            lvnewlyadded.Items.RemoveAt(i);
                        }
                    }
                }
                lvOrder.Items.RemoveAt(lvOrder.SelectedItems[0].Index);//hangisine tıkladıysam onun silinmesi gerek
            }
        }
    }
}
