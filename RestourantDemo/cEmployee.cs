using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestourantDemo
{
    class cEmployee
    {
        cGeneral gnl = new cGeneral();

        #region Fields


        private int _EmployeeId;
        private string _EmployeeNameSurname;
        private int _EmployeeWage;
        private int _EmployeeTaskId;
        private string _EmployeePassword;
        private string _EmployeeUserName;
        private string _EmployeeSıtuatıon;
        #endregion
        #region Properites



        public int EmployeeId
        {
            get => _EmployeeId;
            set => _EmployeeId = value;
        }
        public string EmployeeNameSurname
        {
            get => _EmployeeNameSurname;
            set => _EmployeeNameSurname = value;
        }
        public int EmployeeWage
        {
            get => _EmployeeWage;
            set => _EmployeeWage = value;
        }
        public int EmployeeTaskId
        {
            get => _EmployeeTaskId;
            set => _EmployeeTaskId = value;
        }
        public string EmployeePassword
        {
            get => _EmployeePassword;
            set => _EmployeePassword = value;
        }
        public string EmployeeSıtuatıon
        {
            get => _EmployeeSıtuatıon;
            set => _EmployeeSıtuatıon = value;
        }
        #endregion
        public bool employeeEntryControl(string password, int UserId)
        {
            bool result = false;//ilk başta işlemlerin yanlış giderse  false döndürmek için

            SqlConnection con = new SqlConnection(gnl.dbConnect);
            // VERİTABANI BAĞLANTISI YAPILAN SINIFLA İLETİŞİM KURULUR
            SqlCommand cmd = new SqlCommand("select * from Employees where  ID=@Id and PASSWORD=@password ", con);
            //gelen ıd ve şifre kontrol edildi var mı diye
            //ID veritabanından gelir

            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;


            try
            {
                if (con.State == ConnectionState.Closed)//BAĞLANTI KAPALIYSA AÇILIR
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
                //sonucum bool türünde olduğu için cmd den gelen komutu  bool türüne çevirmem gerek 
                //işlemler doğru giderse buradan true değeri dönecek
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }
            return result;

        }
        public void employeeGetbyInformatıon(ComboBox cb)//personel bilgilerinin getirileceği yer
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select * from Employees ", con);
            if (con.State == ConnectionState.Closed)//BAĞLANTI KAPALIYSA AÇILIR
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cEmployee cE = new cEmployee();
                cE.EmployeeId = Convert.ToInt32(dr["ID"]);
                cE.EmployeePassword = Convert.ToString(dr["PASSWORD"]);
                cE.EmployeeNameSurname = Convert.ToString(dr["NAME_SURNAME"]);
                cE._EmployeeSıtuatıon = Convert.ToString(dr["SITUATION"]);
                cE._EmployeeTaskId = Convert.ToInt32(dr["TASK_ID"]);
                cE._EmployeeUserName = Convert.ToString(dr["USER_NAME"]);
                cE._EmployeeWage = Convert.ToInt32(dr["WAGE"]);
                cb.Items.Add(cE);//TÜM YAZILAN ÖZELLİKLERİ KOMBOBAXA EKLEDİM
            }
            dr.Close();//ÖNCE OKUMA SONRA BAĞLANTI KAPATILIR
            con.Close();
        }
        public override string ToString()//comboboaxın içine ovveride yaparak isimleri düzgün çekmek için
        {
            return EmployeeNameSurname;
        }
    }
}
