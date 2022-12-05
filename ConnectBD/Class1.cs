using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectBD
{
    public class Connect
    {
        string stringConnect;
        MySqlConnection Conn;
        public MySqlConnection Connection()
        {
            Conn = new MySqlConnection(stringConnect);
            return Conn;
        }
        public string RecConnection()
        {
            return stringConnect;
        }
        public Connect(string connect)
        {
            stringConnect = connect;
        }
    }
}
