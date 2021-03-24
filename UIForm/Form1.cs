using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI;
using WebAPI.Models;
using LogLib;

namespace UIForm
{
    public partial class Form1 : Form
    {
        public static string which = " ";
        public static object info = " ";
        public static int kolonAdet = 0;
        public static int iddel;
        public static string islem = " ";
        public static string sonuc = " ";
        LogInfo logInfo = new LogInfo();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
       
        public async void button1_Click(object sender, EventArgs e)
        {
            
           info = dataGridView1.DataSource = await ApıDal<Employess>.GetInfo("employess");
           which = "employess";
           islem = " Listeleme";
           sonuc = JsonConvert.SerializeObject(info);
           logInfo.AddLog(islem,sonuc,"basarili", Form1.which); //response sonucuna göre basarili olma durumu değiştirilebilir.
           kolonAdet = dataGridView1.ColumnCount;
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            info = dataGridView1.DataSource = await ApıDal<Products>.GetInfo("products");
            which = "products";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            info = dataGridView1.DataSource = await ApıDal<Customers>.GetInfo("customers");
            which = "customers";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
           
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            info = dataGridView1.DataSource = await ApıDal<Shippers>.GetInfo("shippers");
            which = "shippers";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
            
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            info = dataGridView1.DataSource = await ApıDal<Suppliers>.GetInfo("suppliers");
            which = "suppliers";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
           
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            info = dataGridView1.DataSource = await ApıDal<Orders>.GetInfo("orders");
            which = "orders";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
            
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            info = dataGridView1.DataSource = await ApıDal<Categories>.GetInfo("categories");
            which = "categories";
            islem = "Listeleme";
            sonuc = JsonConvert.SerializeObject(info);
            logInfo.AddLog(islem, sonuc, "basarili", Form1.which);
            kolonAdet = dataGridView1.ColumnCount;
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            

        }

        private async void button15_Click(object sender, EventArgs e)
        {
            islem = "Silme";
            if (which.Equals("customers"))
            {
                
             WebAPI.ApıDal<Orders>.DeleteMethod(which, Form2.custid);
             logInfo.AddLog(islem, Form2.custid + " id'li kayıt silindi ", "basarili", which);
             MessageBox.Show("Kayıt Başarıyla Silindi.");
            }
            else
            {
            WebAPI.ApıDal<Orders>.DeleteMethod(which,iddel);
            logInfo.AddLog(islem, iddel.ToString() + " id'li kayıt silindi ", "basarili", which);
            MessageBox.Show("Kayıt Başarıyla Silindi.");
            }
           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Form1.which.Equals("customers"))
                {
                    Form2.custid = (dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue).ToString();
                    Console.WriteLine(Form2.custid);
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                iddel = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue);
                Console.WriteLine(iddel);
            }
            }
            catch (Exception)
            {
                
                MessageBox.Show("Geçersiz Hücre");
                //Alınan hata loglanabilir.
            }
            


        }

        private void button9_Click(object sender, EventArgs e)
        {
            LogInfo inf = new LogInfo();
            dataGridView1.DataSource = inf.GetAllLog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            logInfo.DeleteLog();
            MessageBox.Show("Loglar Silindi!");
        }

        
    }
}
