using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        string contratto = "affitto";
        String address = "Carlentini, Italia";
        int price = 0;
        GMapOverlay markersOverlay = null;
        public void removeJson()
        {
            if (markersOverlay != null)
            {
                using (StreamReader r = new StreamReader("C:\\Users\\Sergio\\Desktop\\pds_malnati\\lab5\\map.json"))
                {
                    String json = r.ReadToEnd();
                    List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);


                    foreach (var item in items)
                    {
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(item.lat, item.lng), GMarkerGoogleType.blue_pushpin);
                        markersOverlay.Markers.Add(marker);
                        gMapControl1.Overlays.Remove(markersOverlay);
                    }

                }
            }
        }
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Sergio\\Desktop\\pds_malnati\\lab5\\map.json"))
            {
                String json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                markersOverlay = new GMapOverlay("markers");

                foreach (var item in items)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(item.lat, item.lng), GMarkerGoogleType.blue_pushpin);
                    if (((item.tipo == comboBox1.Text || comboBox1.Text == "Qualsiasi") && (item.prezzo <= price || price == 0) && contratto == item.contratto))
                    {
                        markersOverlay.Markers.Add(marker);
                    }
                }
                gMapControl1.Overlays.Add(markersOverlay);
            }
        }

        

        public Form1()
        {
            InitializeComponent();
            groupBox1.Hide();
            groupBox2.Hide();
            String appartamento = "Appartamento";
            String villa = "Villa";
            String monolocale = "Monolocale";
            String condominio = "Condominio";
            String qualsiasi = "Qualsiasi";
            String primo = "Primo";
            String secondo = "Secondo";
            String terzo = "Terzo";

            comboBox1.Items.Add(appartamento);
            comboBox1.Items.Add(villa);
            comboBox1.Items.Add(monolocale);
            comboBox1.Items.Add(condominio);
            comboBox1.Items.Add(qualsiasi);

            comboBox2.Items.Add(qualsiasi);
            comboBox2.Items.Add(primo);
            comboBox2.Items.Add(secondo);
            comboBox2.Items.Add(terzo);

            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gMapControl1.SetPositionByKeywords(address);
            gMapControl1.Zoom = 15;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out price);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Villa")
            {
                groupBox2.Show();
            }
            else
            {
                groupBox2.Hide();

            }

            if (comboBox1.Text=="Appartamento")
            {
                groupBox1.Show();
            }
            else
            {
                groupBox1.Hide();

            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void click_on_search(Object obj, EventArgs ea)
        {
            removeJson();
            address = textBox1.Text;
            gMapControl1.SetPositionByKeywords(address);
            LoadJson();
        }

        private void click_clear_box1(Object obj, EventArgs ea)
        {
            textBox1.Text = "";

        }
        private void click_clear_box2(Object obj, EventArgs ea)
        {
            textBox2.Text = "";

        }
        private void click_clear_box3(Object obj, EventArgs ea)
        {
            textBox3.Text = "";

        }
        private void add_price(Object obj, EventArgs ea)
        {
       
            price += 10;
            textBox2.Text = "" + price;

        }
        private void sub_price(Object obj, EventArgs ea)
        {
            price -= 10;
            if (price < 0)
            {
                price = 0;
            }
            textBox2.Text = "" + price;
        }

        internal class Item
        {
            public Double lat { get; set; }
            public Double lng { get; set; }
            public string tipo { get; set; }
            public int prezzo { get; set; }
            public string contratto { get; set; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            contratto = "vendita";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            contratto = "affitto";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
