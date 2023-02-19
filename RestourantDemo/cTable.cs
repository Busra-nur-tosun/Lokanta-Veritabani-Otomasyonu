using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantDemo
{
    class cTable
    {

        #region Fields
        private int _ID;
        private int _Table_Capacity;
        private int _Table_Situation;
        private int _Service_Type;
        private int _Table_Confirmation;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int Table_Capacity { get => _Table_Capacity; set => _Table_Capacity = value; }
        public int Table_Situation { get => _Table_Situation; set => _Table_Situation = value; }
        public int Service_Type { get => _Service_Type; set => _Service_Type = value; }
        public int Table_Confirmation { get => _Table_Confirmation; set => _Table_Confirmation = value; }
        #endregion
        cGeneral gnl = new cGeneral();
        public string SessionSum(int state,string TABLE_ID)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select DATE,TABLE_ID FROM ADDITIONS RIGHT JOIN TABLES ON ADDITIONS.TABLE_ID =TABLES.ID WHERE TABLES TABLES.TABLE_SITUATION=@TSıtuatıon AND ADDITIONS.TABLE_SITUATION=0 and TABLES.ID=@TABLE_ID", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("@TSıtuatıon", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@TABLE_ID", SqlDbType.Int).Value = state;

            try
            {
                if (con.State == ConnectionState.Closed)//BAĞLANTI KAPALIYSA AÇILIR
                {
                    con.Open();
                }

                // SqlDataReader dr = cmd.ExecuteReader();
                dr = cmd.ExecuteReader();//yazılan sql sorgusunu okur
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["DATE"]).ToString();//sorgu daki tarih bilgisini string değere çevirir
                }

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;
        }
        public int TableGetByNumber(string TableValue)
        {//masa numarasını alma işlemi yapılır
            string aa = TableValue;
            int length = aa.Length;
            return Convert.ToInt32(aa.Substring(length - 1, 1));//son değer gönderilir
        }
        public bool TableGetByState (int ButtonName,int state)
        {
            //masa durumunu getiren fonksiyon
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select TABLE_SITUATION from TABLES where  ID=@ID and TABLE_SITUATION=@state ", con);
           

            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = state;


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
               
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
          
            }
            finally
            {
                con.Dispose();
                con.Close();//tüm bağlantılar kapatılır
            }
            return result;

        }
        public  void SetChangeTableState(string ButtonName,int state)//masa durumunu değiştir
        {
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("update TABLES SET TABLE_SITUATION=@state WHERE ID=@ID", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            String aa = ButtonName;
            int length = aa.Length;
            cmd.Parameters.Add("@state",SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = aa.Substring(-1,1);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();


        }
    }
}

