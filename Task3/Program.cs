using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Task3
{
    internal static class Program
    {
        public class Connections
        {
            string stringConnect;
            MySqlConnection Connect;
            public MySqlConnection Connection()
            {
                Connect = new MySqlConnection(stringConnect);
                return Connect;
            }
            public string RCon()
            {
                return stringConnect;
            }
            public Connections(string connect)
            {
                stringConnect = connect;
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
