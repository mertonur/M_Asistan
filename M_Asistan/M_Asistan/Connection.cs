using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Asistan
{
    class Connection
    {

        public static Connection connection;

        public SqlCommand command;
        public SqlDataAdapter da;

        public SqlConnection conn = new SqlConnection(@"");//SQL CONNECTİON

        public Connection()
        {
            connection = this;
        }


    }
}
