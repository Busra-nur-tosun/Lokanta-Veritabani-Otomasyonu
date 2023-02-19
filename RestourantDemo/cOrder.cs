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
    class cOrder
    {
        #region Fields
        private int _ID;
        private int _PRODUCT_ID;
        private int _TABLE_ID;
        private int _PIECE;
        private int _ADDITION_ID;
        #endregion
        #region PROPERTIES
        public int ID { get => _ID; set => _ID = value; }
        public int PRODUCT_ID { get => _PRODUCT_ID; set => _PRODUCT_ID = value; }
        public int TABLE_ID { get => _TABLE_ID; set => _TABLE_ID = value; }
        public int PIECE { get => _PIECE; set => _PIECE = value; }
        public int ADDITION_ID { get => _ADDITION_ID; set => _ADDITION_ID = value; }
        #endregion
        cGeneral gnl = new cGeneral();

        public  void getByOrder(ListView lv,int AdditionId)
        {

           
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select PRODUCTS.PRODUCTNAME,PRODUCTS.PRICE,SALES.ID,SALES.PRODUCT_ID,SALES.PIECE FROM SALES INNER JOIN PRODUCTS ON " +
                "SALES.PRODUCT_ID=PRODUCTS.ID WHERE ADDITION_ID=@AdditionId", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdditionId", SqlDbType.VarChar).Value = AdditionId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int counter = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["PRODUCTNAME"].ToString());
                    lv.Items[counter].SubItems.Add(dr["PIECE"].ToString());
                    lv.Items[counter].SubItems.Add(dr["PRODUCT_ID"].ToString());
                    lv.Items[counter].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["PRICE"]) * Convert.ToDecimal(dr["PIECE"])));
                    lv.Items[counter].SubItems.Add(dr["ID"].ToString());
                    counter++;
                }

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }
            finally
            {

                con.Close();
            }
          //  return TableId;
        }
        public bool setSaveOrder(cOrder Information)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("Insert Into SALES (ADDITION_ID,PRODUCT_ID,TABLE_ID,PIECE) VALUES(@ADDITION_ID,@PRODUCT_ID,@TABLE_ID,@PIECE)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ADDITION_ID", SqlDbType.VarChar).Value = Information._ADDITION_ID;
                cmd.Parameters.Add("@PRODUCT_ID", SqlDbType.VarChar).Value = Information._PRODUCT_ID;
                cmd.Parameters.Add("@TABLE_ID", SqlDbType.VarChar).Value = Information._TABLE_ID;
                cmd.Parameters.Add("@PIECE", SqlDbType.VarChar).Value = Information._PIECE;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
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
        public void setDeleteOrder(int salesId)//GELEN ID YI ALIP SİLİYOR
        {
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("DELETE FROM SALES WHERE ID=@salesId", con);
            cmd.Parameters.Add("@salesId", SqlDbType.Int).Value = salesId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

    }
}
