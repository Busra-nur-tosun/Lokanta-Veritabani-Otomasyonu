using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantDemo
{
    class cAddition
    {
        #region Fields
        private int _ID;
        private int _SERVICE_TYPEID;
        private int _DATE;
        private int _EMPLOYEE_ID;
        private int _STIUATION;
        private int _TABLE_ID;
        private decimal _AMOUNT;
        #endregion
        #region PROPERTIES
        public decimal AMOUNT { get => _AMOUNT; set => _AMOUNT = value; }
        public int ID { get => _ID; set => _ID = value; }
        public int SERVICE_TYPEID { get => _SERVICE_TYPEID; set => _SERVICE_TYPEID = value; }
        public int DATE { get => _DATE; set => _DATE = value; }
        public int EMPLOYEE_ID { get => _EMPLOYEE_ID; set => _EMPLOYEE_ID = value; }
        public int STIUATION { get => _STIUATION; set => _STIUATION = value; }
        public int TABLE_ID { get => _TABLE_ID; set => _TABLE_ID = value; }
        #endregion
        cGeneral gnl = new cGeneral();
        public int getByAddition(int TableId)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select Stop 1 ID from ADDITIONS where  TABLE_ID=@TABLE_ID ORDER BY ID DESC ", con);


            cmd.Parameters.Add("@TABLE_ID", SqlDbType.VarChar).Value = TableId;
           


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                TableId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                
            }
            finally
            {
                
                con.Close();
            }
            return TableId;//açık olan masanın adisyon numarası
        }
        public bool setByAdditionNew(cAddition Informatiıons)//MÜŞTERİ ADİYON OLUŞTURUYOR
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("Insert into ADDITIONS(SERVICE_TYPEID,DATE,EMPLOYEE_ID,TABLE_ID,STIUATION) VALUES(@SERVICE_TYPEID,@DATE,@EMPLOYEE_ID,@TABLE_ID,@STIUATION)", con);
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@SERVICE_TYPEID", SqlDbType.Int).Value = Informatiıons.SERVICE_TYPEID;
                cmd.Parameters.Add("@DATE", SqlDbType.Int).Value = Informatiıons.DATE;
                cmd.Parameters.Add("@EMPLOYEE_ID", SqlDbType.Int).Value = Informatiıons.EMPLOYEE_ID;
                cmd.Parameters.Add("@TABLE_ID", SqlDbType.Int).Value = Informatiıons.TABLE_ID;
                cmd.Parameters.Add("@STIUATION", SqlDbType.Int).Value = Informatiıons.STIUATION;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }
    }
}
