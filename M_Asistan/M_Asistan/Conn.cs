using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Asistan
{
    class Conn
    {

        public static Conn conn;

        public SqlCommand command;
        public SqlDataAdapter da;

        public SqlConnection connection = new SqlConnection(@"");//SQL CONNECTİON

        public Conn()
        {
            conn = this;
        }


    }
}
