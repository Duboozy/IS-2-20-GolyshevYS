using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ConnectBD;
using MySqlX.XDevAPI.Relational;

namespace Task5
{
    public partial class tk5 : Form
    {
        public tk5()
        {
            InitializeComponent();
        }
        MySqlConnection сon;
        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;user=st_2_20_7;database=is_2_20_st7_KURS;password=68251690;");
        DataTable datatable = new DataTable();
        MySqlDataAdapter mahtable = new MySqlDataAdapter();
        BindingSource bas = new BindingSource();

        public void InForm()
        {
            datatable.Clear();
            string sqlq = ($"SELECT t_Uchebka_Golyshev.idStud AS 'Код', t_Uchebka_Golyshev.fioStud AS 'Имя', t_Uchebka_Golyshev.datetimeStud AS 'Дата' FROM t_Uchebka_Golyshev;");
            сon.Open();
            mahtable.SelectCommand = new MySqlCommand(sqlq, сon);
            mahtable.Fill(datatable);
            bas.DataSource = datatable;
            dataGridView1.DataSource = bas;
            сon.Close();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            сon = connect.Connection();
            InForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBox1.Text;
            string data = textBox2.Text;
            try
            {
                сon.Open();

                string add = "INSERT INTO `t_Uchebka_Golyshev` (fioStud, datetimeStud) VALUES (@a, @b)";
                MySqlCommand cmd = new MySqlCommand(add, сon);
                cmd.Parameters.Add("@a", MySqlDbType.VarChar).Value = fio;
                cmd.Parameters.Add("@b", MySqlDbType.VarChar).Value = data;
               
                cmd.ExecuteNonQuery();
                сon.Close();
            }
            catch (Exception ex)
            {
                label3.Visible = true;
                label3.ForeColor = Color.Red;
                label3.Text = ("Ошибка!" + ex);
            }
            finally
            {
               
                label3.Visible = true;
                label3.ForeColor = Color.Green;
                label3.Text = "Строка успешно добавлена";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InForm();
        }
    }
}