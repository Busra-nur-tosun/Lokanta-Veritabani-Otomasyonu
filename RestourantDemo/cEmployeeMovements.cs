using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantDemo
{
    class cEmployeeMovements
    {
        cGeneral gnl = new cGeneral();

        #region Fields
        private int _Id;
        private int _EmployeeId;
        private string _EmployeeProcess;
        private string _EmployeeSituation;
        private DateTime _EmployeeDate;
        #endregion
        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int EmployeeId { get => _EmployeeId; set => _EmployeeId = value; }
        public string EmployeeProcess { get => _EmployeeProcess; set => _EmployeeProcess = value; }
        public string EmployeeSıtuatıon { get => _EmployeeSituation; set => _EmployeeSituation = value; }
        public DateTime EmployeeDate { get => _EmployeeDate; set => _EmployeeDate = value; }
        #endregion
        public bool EmployeeActionSave(cEmployeeMovements eM)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.dbConnect);
            SqlCommand cmd = new SqlCommand("Insert Into EMPLOYEE_MOVEMENTS(EMPLOYEE_ID,PROCESS,DATE)Values(@employeeId,@Employeeprocess,@Employeedate)", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@employeeId", SqlDbType.Int).Value = eM._Id;
                cmd.Parameters.Add("@Employeeprocess", SqlDbType.VarChar).Value = eM._EmployeeProcess;
                cmd.Parameters.Add("@Employeedate", SqlDbType.DateTime).Value = eM._EmployeeDate;
                //@ işaretli olanlar cmd komutunda @ işaaretli olanlardır
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string error = ex.Message;
                throw;
            }


            return result;

        }
    }
}
