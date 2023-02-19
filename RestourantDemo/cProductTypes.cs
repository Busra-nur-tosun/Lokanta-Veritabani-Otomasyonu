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
    class cProductTypes
    {
        cGeneral gnl = new cGeneral();
        #region FİELDS
        private int _PRODUCT_TYPE_NO;
        private string _CATEGORY_NAME;
        private string _EXPLANATION;
        #endregion
        #region PROPERTIES
        public int PRODUCT_TYPE_NO { get => _PRODUCT_TYPE_NO; set => _PRODUCT_TYPE_NO = value; }
        public string CATEGORY_NAME { get => _CATEGORY_NAME; set => _CATEGORY_NAME = value; }
        public string EXPLANATION { get => _EXPLANATION; set => _EXPLANATION = value; }
        #endregion
        public void GetByProductTypes(ListView types,Button btn)
           // butona bastığım zaman ürün bilgilerimin
        {
            types.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("select PRODUCTNAME,PRICE,PRODUCTS.ID  FROM CATEGORYIES INNER JOIN PRODUCTS ON  CATEGORYIES.ID=PRODUCTS.CATEGORY_ID WHERE PRODUCTS.CATEGORY_ID=@CATEGORYID", con);
            string aa = btn.Name;
            int length = aa.Length;
            SqlDataReader dr = null;
            cmd.Parameters.Add("@CATEGORYID", SqlDbType.Int).Value = aa.Substring(length-1,1);//son değer alınır bu şekilde

            
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int counter = 0;
                while (dr.Read())
                {
                    types.Items.Add(dr["PRODUCTNAME"].ToString());
                    types.Items[counter].SubItems.Add(dr["PRICE"].ToString());
                    types.Items[counter].SubItems.Add(dr["ID"].ToString());

                    counter++;
                }
          
                dr.Close();
                con.Dispose();
                con.Close();
               
            

                  
          
          
            
        }
    }
}
