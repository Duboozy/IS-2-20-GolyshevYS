using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public class DataBase
        {
            MySqlConnection connection = new MySqlConnection("server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;");
            public void Proverka()
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Подключено");


                }
                catch
                {
                    MessageBox.Show("Не подключено!");
                }
                finally
                {
                    MessageBox.Show("Вы подключены");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase data = new DataBase();
            data.Proverka();
        }
    }
}

