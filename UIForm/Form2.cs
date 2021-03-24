using LogLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI.Models;

namespace UIForm
{
    public partial class Form2 : Form
    {
        public static int id;
        public static string custid;
        int slay = 0;
        int it=1;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Form1.info;
            LogInfo logInfo = new LogInfo();

            if (Form1.which.Equals("customers"))
            {
                it = 0;
            }

            for (int i = it; i < Form1.kolonAdet; i++)
            { //Seçilmiş olan kategori için uygun ekleme ve düzenleme textboxlarının oluşturulması.
                int x = 150;
                int y = 140;
                slay += 30;
                TextBox textBox = new TextBox();
                Label label = new Label();
                label.Name = $"UpdtextLabel{i}";
                label.Text = dataGridView2.Columns[i].HeaderText;
                textBox.Name = $"UpdtextBox{i}";
                textBox.Size = new Size(150, 24);
                textBox.Location = new Point(x, y + slay);
                label.Location = new Point(x / 5, y + slay);
                this.Controls.Add(textBox);
                this.Controls.Add(label);

            }


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Form1.which.Equals("customers"))
            {
                custid = (dataGridView2.Rows[e.RowIndex].Cells[0].FormattedValue).ToString();
                Console.WriteLine(custid);
            }
            else
            {
                try
                {
                dataGridView2.CurrentRow.Selected = true;
                id = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].FormattedValue);
                Console.WriteLine(id);
                }
                catch (Exception)
                {

                    MessageBox.Show("Geçersiz Seçim");
                }
               
            }


            try
            {

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView2.CurrentRow.Selected = true;
                TextBox tb = ((TextBox)this.Controls["UpdtextBox0"]);
                TextBox tb1 = ((TextBox)this.Controls["UpdtextBox1"]);
                TextBox tb2 = ((TextBox)this.Controls["UpdtextBox2"]);
                TextBox tb3 = ((TextBox)this.Controls["UpdtextBox3"]);
                TextBox tb4 = ((TextBox)this.Controls["UpdtextBox4"]);
                TextBox tb5 = ((TextBox)this.Controls["UpdtextBox5"]);
                TextBox tb6 = ((TextBox)this.Controls["UpdtextBox6"]);
                TextBox tb7 = ((TextBox)this.Controls["UpdtextBox7"]);
                TextBox tb8 = ((TextBox)this.Controls["UpdtextBox8"]);
                TextBox tb9 = ((TextBox)this.Controls["UpdtextBox9"]);
                TextBox tb10 = ((TextBox)this.Controls["UpdtextBox10"]);
                TextBox tb11 = ((TextBox)this.Controls["UpdtextBox11"]);
                TextBox tb12 = ((TextBox)this.Controls["UpdtextBox12"]);
                TextBox tb13 = ((TextBox)this.Controls["UpdtextBox13"]);
                TextBox tb14 = ((TextBox)this.Controls["UpdtextBox14"]);
                TextBox[] array = { tb, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14 };

                for (int i = 1; i < Form1.kolonAdet; i++)
                {
                    array[i].Text = dataGridView2.Rows[e.RowIndex].Cells[i].FormattedValue.ToString();

                }

            }
            }
            catch (Exception)
            {
                //Log
                
            }
            


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LogInfo logInfo = new LogInfo();
            var convertedInf= "";
            string islem = "Yeni " + Form1.which + " ekleme";
            TextBox tb = ((TextBox)this.Controls["UpdtextBox0"]);
            TextBox tb1 = ((TextBox)this.Controls["UpdtextBox1"]);
            TextBox tb2 = ((TextBox)this.Controls["UpdtextBox2"]);
            TextBox tb3 = ((TextBox)this.Controls["UpdtextBox3"]);
            TextBox tb4 = ((TextBox)this.Controls["UpdtextBox4"]);
            TextBox tb5 = ((TextBox)this.Controls["UpdtextBox5"]);
            TextBox tb6 = ((TextBox)this.Controls["UpdtextBox6"]);
            TextBox tb7 = ((TextBox)this.Controls["UpdtextBox7"]);
            TextBox tb8 = ((TextBox)this.Controls["UpdtextBox8"]);
            TextBox tb9 = ((TextBox)this.Controls["UpdtextBox9"]);
            TextBox tb10 = ((TextBox)this.Controls["UpdtextBox10"]);
            TextBox tb11 = ((TextBox)this.Controls["UpdtextBox11"]);
            TextBox tb12 = ((TextBox)this.Controls["UpdtextBox12"]);
            TextBox tb13 = ((TextBox)this.Controls["UpdtextBox13"]);
            TextBox tb14 = ((TextBox)this.Controls["UpdtextBox14"]);
            switch (Form1.which)
            {

                case "orders":
                    Orders or = new Orders();

                    WebAPI.ApıDal<Orders>.PostMethod(or, "orders");

                   
                    or.customerId = tb1.Text;
                    or.orderDate = tb2.Text;
                    or.requiredDate = tb3.Text;
                    or.shippedDate = tb4.Text;
                    or.freight = Convert.ToDouble(tb5.Text);
                    or.shipName = tb6.Text;
                    WebAPI.ApıDal<Orders>.PostMethod(or, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(or);
                    logInfo.AddLog(islem, convertedInf  + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "categories":
                    Categories cat = new Categories();
                    cat.name = tb1.Text;
                    cat.description = tb2.Text;
                    WebAPI.ApıDal<Categories>.PostMethod(cat, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(cat);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "employess":
                    Employess emp = new Employess();
                    emp.firstName = tb1.Text;
                    emp.lastName = tb2.Text;
                    emp.title = tb3.Text;
                    emp.titleOfCourtesy = tb4.Text;
                    emp.birthDate = tb5.Text;
                    emp.hireDate = tb6.Text;
                    emp.notes = tb8.Text;
                    emp.reportsTo = tb9.Text;
                    WebAPI.ApıDal<Employess>.PostMethod(emp, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(emp);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "products":
                    Products prod = new Products();
                    prod.name = tb1.Text;
                    prod.quantityPerUnit = tb2.Text;
                    prod.unitPrice = Convert.ToInt32(tb3.Text);
                    prod.unitsInStock = Convert.ToInt32(tb4.Text);
                    prod.unitsOnOrder = Convert.ToInt32(tb5.Text);
                    prod.reorderLevel = Convert.ToInt32(tb6.Text);
                    WebAPI.ApıDal<Products>.PostMethod(prod, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(prod);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "customers":
                    Customers cust = new Customers();
                    cust.id = tb.Text;
                    cust.companyName = tb1.Text;
                    cust.contactName = tb2.Text;
                    cust.contactTitle = tb3.Text;
                    WebAPI.ApıDal<Customers>.PostMethod(cust, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(cust);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "suppliers":
                    Suppliers supp = new Suppliers();
                    supp.companyName = tb1.Text;
                    supp.contactName = tb2.Text;
                    supp.contactTitle = tb3.Text;
                    WebAPI.ApıDal<Suppliers>.PostMethod(supp, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(supp);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                case "shippers":
                    Shippers shipp = new Shippers();
                    shipp.companyName = tb1.Text;
                    shipp.phone = tb2.Text;
                    WebAPI.ApıDal<Shippers>.PostMethod(shipp, Form1.which);
                    convertedInf = JsonConvert.SerializeObject(shipp);
                    logInfo.AddLog(islem, convertedInf + " Eklendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Eklendi!");
                    break;
                default:
                    break;
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            HttpClient client = new HttpClient();
            LogInfo logInfo = new LogInfo();
            string islem = "Kayıt Güncelleme";
            TextBox tb = ((TextBox)this.Controls["UpdtextBox0"]);
            TextBox tb1 = ((TextBox)this.Controls["UpdtextBox1"]);
            TextBox tb2 = ((TextBox)this.Controls["UpdtextBox2"]);
            TextBox tb3 = ((TextBox)this.Controls["UpdtextBox3"]);
            TextBox tb4 = ((TextBox)this.Controls["UpdtextBox4"]);
            TextBox tb5 = ((TextBox)this.Controls["UpdtextBox5"]);
            TextBox tb6 = ((TextBox)this.Controls["UpdtextBox6"]);
            TextBox tb7 = ((TextBox)this.Controls["UpdtextBox7"]);
            TextBox tb8 = ((TextBox)this.Controls["UpdtextBox8"]);
            TextBox tb9 = ((TextBox)this.Controls["UpdtextBox9"]);
            TextBox tb10 = ((TextBox)this.Controls["UpdtextBox10"]);
            TextBox tb11 = ((TextBox)this.Controls["UpdtextBox11"]);
            TextBox tb12 = ((TextBox)this.Controls["UpdtextBox12"]);
            TextBox tb13 = ((TextBox)this.Controls["UpdtextBox13"]);
            TextBox tb14 = ((TextBox)this.Controls["UpdtextBox14"]);
            switch (Form1.which)
            {
                case "categories":
                    Categories cat = new Categories();
                    cat.name = tb1.Text;
                    cat.description = tb2.Text;
                    var convertedInf = JsonConvert.SerializeObject(cat);
                    var stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Categories>.PatchAsync(client,stringContent,Form1.which,id);
                    logInfo.AddLog(islem,convertedInf+" Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "orders":
                    Orders or = new Orders();
                    WebAPI.ApıDal<Orders>.PostMethod(or, "orders");
                    or.customerId = tb1.Text;
                    or.orderDate = tb2.Text;
                    or.requiredDate = tb3.Text;
                    or.shippedDate = tb4.Text;
                    or.freight = Convert.ToDouble(tb5.Text);
                    or.shipName = tb6.Text;
                    convertedInf = JsonConvert.SerializeObject(or);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Orders>.PatchAsync(client, stringContent, Form1.which, id);
                    logInfo.AddLog(islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "employess":
                    Employess emp = new Employess();
                    emp.firstName = tb1.Text;
                    emp.lastName = tb2.Text;
                    emp.title = tb3.Text;
                    emp.titleOfCourtesy = tb4.Text;
                    emp.birthDate = tb5.Text;
                    emp.hireDate = tb6.Text;
                    emp.notes = tb8.Text;
                    emp.reportsTo = tb9.Text;
                    convertedInf = JsonConvert.SerializeObject(emp);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Employess>.PatchAsync(client, stringContent, Form1.which, id);
                    logInfo.AddLog( islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "products":
                    Products prod = new Products();
                    prod.name = tb1.Text;
                    prod.quantityPerUnit = tb2.Text;
                    prod.unitPrice = Convert.ToInt32(tb3.Text);
                    prod.unitsInStock = Convert.ToInt32(tb4.Text);
                    prod.unitsOnOrder = Convert.ToInt32(tb5.Text);
                    prod.reorderLevel = Convert.ToInt32(tb6.Text);
                    convertedInf = JsonConvert.SerializeObject(prod);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Products>.PatchAsync(client, stringContent, Form1.which, id);
                    logInfo.AddLog(islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "customers":
                    Customers cust = new Customers();
                    cust.companyName = tb1.Text;
                    cust.contactName = tb2.Text;
                    cust.contactTitle = tb3.Text;
                    convertedInf = JsonConvert.SerializeObject(cust);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Customers>.PatchAsync(client, stringContent, Form1.which, custid);
                    logInfo.AddLog(islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "suppliers":
                    Suppliers supp = new Suppliers();
                    supp.companyName = tb1.Text;
                    supp.contactName = tb2.Text;
                    supp.contactTitle = tb3.Text;
                    convertedInf = JsonConvert.SerializeObject(supp);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Suppliers>.PatchAsync(client, stringContent, Form1.which, id);
                    logInfo.AddLog(islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi!");
                    break;
                case "shippers":
                    Shippers shipp = new Shippers();
                    shipp.companyName = tb1.Text;
                    shipp.phone = tb2.Text;
                    convertedInf = JsonConvert.SerializeObject(shipp);
                    stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
                    WebAPI.ApıDal<Shippers>.PatchAsync(client, stringContent, Form1.which, id);
                    logInfo.AddLog(islem, convertedInf + " Güncellendi", "basarili", Form1.which);
                    MessageBox.Show("Kayıt Başarıyla Güncellendi");
                    break;
                default:
                    break;
            }
        }


        }
    }

