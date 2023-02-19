using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantDemo
{
    class cGeneral
    {
        //öncelikle veri tabanı bağlantısı yapılır
        public string dbConnect = ("Server=DESKTOP-RDDKO5L;Database=RESTOURANT;Trusted_Connection=True");
        public static int _employeeId;
        public static int _employeeTaskId;
        public static string _ButtonValue;
        public static string _ButtonName;
    }
}
