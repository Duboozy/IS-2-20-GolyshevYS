using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task3.Program;

namespace Task3
{
    public partial class tk3 : Form
    {
        public tk3()
        {
            InitializeComponent();
        }
        MySqlConnection сon;
        Connections connect = new Connections("server=chuc.caseum.ru;port=33333;user=st_2_20_7;database=is_2_20_st7_KURS;password=68251690;");
        DataTable datatable = new DataTable();
        MySqlDataAdapter mahtable = new MySqlDataAdapter();
        BindingSource bas = new BindingSource();
        public void Infomation()
        {
            datatable.Clear();
            string sqlq = "SELECT Patient.id_patient AS 'ID', Patient.fio_patient AS 'Name', Patient.number_patient AS 'Phone', Patient.number_policy_patient AS 'NumberPolicy' FROM Patient JOIN Main ON Patient.id_patient = Main.ID_Patient";
            сon.Open();

            mahtable.SelectCommand = new MySqlCommand(sqlq, сon);
            mahtable.Fill(datatable);

            bas.DataSource = datatable;

            dataGridView1.DataSource = bas;
            сon.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;

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
            private void Form1_Load(object sender, EventArgs e)
            {
                сon = connect.Connection();
                Infomation();
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            сon.Open();
            string i1 = "";
            string i2 = "";
            string i3 = "";
            string i4 = "";
            string sql = ($"SELECT Patient.id_patient AS 'ID', Patient.fio_patient AS 'Name', Patient.number_patient AS 'Phone', Patient.number_policy_patient AS 'NumberPolicy' FROM Patient JOIN Main ON Patient.id_patient = Main.ID_Patient WHERE Patient.ID = " + id);
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
            label1.Text = $"ID: " + i1 + "\n" + "Name: " + i2 + "\n" + "Phone: " + i3 + "\n" + "NumberPolicy: " + i4;
            label1.Visible = true;
            сon.Close();
        }
    }
}
