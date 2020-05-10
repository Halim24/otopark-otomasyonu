using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace otopark
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pw67IU3UXP1Yc6stCcplD85lA8FWKmSyoMWIyipu",
            BasePath = "https://otopark-66568.firebaseio.com/"
        };
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client!=null)
            {
                MessageBox.Show("bağlandı");
            }
            else
            {
                MessageBox.Show("bağlantı yok");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Plaka = textBox1.Text,
                Cins = listBox1.Text,
                GirisSaat = dateTimePicker1.Text
            };

            SetResponse response = await client.SetTaskAsync("Information/" + textBox1.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Araç Grişi Yapıldı : " + result.Plaka);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Information/"+textBox2.Text);
            Data obj = response.ResultAs<Data>();
            DateTime suan = DateTime.Now;

            textBox3.Text = obj.GirisSaat;
            if (obj.Cins == "Araba")
            {
                textBox4.Text = "20 TL";
            }else if(obj.Cins == "Motorsiklet")
            {
                textBox4.Text = "7.5 TL";
            }else if (obj.Cins == "Kamyonet")
            {
                textBox4.Text = "40 TL";
            }
            


        }

        private async void button3_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Information/" + textBox2.Text);
            MessageBox.Show("Araç Çıkışı Yapıldı" );

        }
    }
}