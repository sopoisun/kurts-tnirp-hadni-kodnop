using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Printer_Pondok_Indah
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
        }

        public string nota, status, id;
        private DataTable dataProduk;

        private void Detail_Load(object sender, EventArgs e)
        {

            this.Text = "Nota " + nota;
            this.label1.Text = "Nota \""+nota+"\"";

            dataProduk = Connection.GetInstance().GetDetail(id);
            
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = dataProduk;
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "Nama Produk";
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[1].Name = "nama_produk";
            dataGridView1.Columns[2].HeaderText = "Harga";
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[2].Name = "harga";
            dataGridView1.Columns[3].HeaderText = "Qty";
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[3].Name = "qty";
            dataGridView1.Columns[4].HeaderText = "Subtotal";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[4].Name = "subtotal";
        }
    }
}
