using System;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        cGeneral gnl = new cGeneral();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cEmployee emp = new cEmployee();
            emp.employeeGetbyInformatıon(cbUser);
        }

        private void btnLogin_Click(object sender, EventArgs e)//giriş butonu
        {
            cGeneral gnl = new cGeneral();
            cEmployee emp = new cEmployee();
            bool result = emp.employeeEntryControl(txtPassword.Text, cGeneral._employeeId);
            if (result)
            {
                cEmployeeMovements empM = new cEmployeeMovements();
                empM.EmployeeId = cGeneral._employeeId;
                empM.EmployeeProcess = "Giriş Yapıldı";
                empM.EmployeeDate = DateTime.Now;
                empM.EmployeeActionSave(empM);
                this.Hide();//giriş doğuysa form ekranını gizleyereke menü formunun gelmesi sağlanacak
                frmMenu menu = new frmMenu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "!!uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            cEmployee emp = (cEmployee)cbUser.SelectedItem;
            cGeneral._employeeId = emp.EmployeeId;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğininize emin misiniz?", "!!UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
