using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectBD;
using MySql.Data.MySqlClient;

namespace Task4
{
    public partial class tk4 : Form
    {
        public tk4()
        {
            InitializeComponent();
        }
        MySqlConnection сon;
        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;user=st_2_20_7;database=is_2_20_st7_KURS;password=68251690;");
        DataTable datatable = new DataTable();
        MySqlDataAdapter mahtable = new MySqlDataAdapter();
        BindingSource bas = new BindingSource();

        private void Form1_Load(object sender, EventArgs e)
        {
            сon = connect.Connection();
            Inform();
        }
        public void Inform()
        {
            datatable.Clear();

            string sqlI1 = ($"SELECT t_datatime.id AS 'ID', t_datatime.fio AS 'Имя', t_datatime.date_of_Birth AS 'Дата рождения', t_datatime.photoUrl AS 'Фото' FROM t_datatime;");
            сon.Open();

            mahtable.SelectCommand = new MySqlCommand(sqlI1, сon);
            mahtable.Fill(datatable);

            bas.DataSource = datatable;

            dataGridView1.DataSource = bas;
            сon.Close();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;
        }
        void InicilPhoto(string x)
        {
            var p = WebRequest.Create(x);
            using (var pp = p.GetResponse())
            using (var GRS = pp.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(GRS);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            сon.Open();
            string i1 = "";
            string i2 = "";
            string i3 = "";
            string i4 = "";
            string sql = ($"SELECT t_datatime.id AS 'ID', t_datatime.fio AS 'Имя', t_datatime.date_of_Birth AS 'Дата рождения', t_datatime.photoUrl AS 'Фото' FROM t_datatime WHERE t_datatime.id = " + id);
            MySqlCommand cmd = new MySqlCommand(sql, сon);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i1 = reader[0].ToString();
                i2 = reader[1].ToString();
                i3 = reader[2].ToString();
                i4 = reader[3].ToString();
            }
            reader.Close();
            label1.Text = ($"Id: " + i1 + "\n" + "Имя: " + i2 + "\n" + "Дата рождения: " + i3);
            label1.Visible = true;
            сon.Close();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            try
            {
                сon.Open();
                string sqlq = "SELECT t_datatime.photoUrl AS 'Фото' FROM t_datatime WHERE t_datatime.id = " + id;
                MySqlCommand cmd1 = new MySqlCommand(sqlq, сon);
                string pictur = cmd1.ExecuteScalar().ToString();
                InicilPhoto(pictur);
                MySqlDataReader reader = cmd1.ExecuteReader();
                сon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }
    }
}


