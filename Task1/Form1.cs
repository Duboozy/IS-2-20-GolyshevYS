using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class PC<T>
        {
            public int price;
            public int year;
            public T Articul;
            public PC(int price, int year, T acrticul)
            {
                this.price = price;
                this.year = year;
                Articul = acrticul;
            }

            public virtual string Display()
            {

                return ($"Цена: {price}р\n{year}Года выпуска\n{Articul}Артикула");
            }
        }
        class HDD<T> : PC<T>
        {
            private int rmp { get; set; }

            private string iface { get; set; }

            private int capacity { get; set; }

            public HDD(int price, int year, T arcticul, int rmp, string iface, int capacity) : base(price, year, arcticul)
            {
                this.rmp = rmp;
                this.iface = iface;
                this.capacity = capacity;
            }
            public override string Display()
            {
                return ($"Цена:{price}руб.\n {year}Год выпуска\n {Articul}Артикул\n Количество оборотов жесткого диска:{rmp}об/мин\n{iface}Интерфейс\n Объем:{capacity}Гб");
            }
        }
        class GPU<T> : PC<T>
        {
            private int freq { get; set; }

            private string manufacture { get; set; }

            private int memory { get; set; }

            public GPU(int price, int year, T arcticul, int freq, string manufacture, int memory) : base(price, year, arcticul)
            {
                this.freq = freq;
                this.manufacture = manufacture;
                this.memory = memory;
            }
            public override string Display()
            {
                return $"Цена: {price}р\nГод выпуска:{year}г\n Артикул:{Articul}\n Частота Видеокарты:{freq}МГц\n Производитель:{manufacture}\nКол.объёма памяти Видеокарты:{memory}Гб";
            }
        }
        HDD<int> hdd;
        GPU<int> vc;
     
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(textBox1.Text);
                int year = Convert.ToInt32(textBox2.Text);
                int arcticul = Convert.ToInt32(textBox3.Text);
                int rmp = Convert.ToInt32(textBox4.Text);
                string iface = textBox5.Text;
                int capacity = Convert.ToInt32(textBox6.Text);
                hdd = new HDD<int>(price, year, arcticul, rmp, iface, capacity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                listBox1.Items.Add(hdd.Display());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                try
                {
                    int price = Convert.ToInt32(textBox1.Text);
                    int year = Convert.ToInt32(textBox2.Text);
                    int arcticul = Convert.ToInt32(textBox3.Text);
                    int freq = Convert.ToInt32(textBox7.Text);
                    string manufacture = textBox8.Text;
                    int memory = Convert.ToInt32(textBox9.Text);
                    vc = new GPU<int>(price, year, arcticul, freq, manufacture, memory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    listBox1.Items.Add(vc.Display());
                }
            }
        }
    }

