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
    public partial class ProdukComposition : Form
    {
        public ProdukComposition()
        {
            InitializeComponent();
        }

        public string namaProduk, idProduk;
        public int QtyReq;
        private DataTable dataKomposisi;

        private void ProdukComposition_Load(object sender, EventArgs e)
        {
            this.Text = "Komposisi Produk #"+this.namaProduk;
            this.dataKomposisi = Connection.GetInstance().GetProdukComposition(this.idProduk, this.QtyReq);

            dataGridView1.Columns.Clear();

            if (this.dataKomposisi.Rows.Count > 0)
            {
                dataGridView1.DataSource = this.dataKomposisi;
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "Nama Bahan";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].Name = "nama";
                dataGridView1.Columns[2].HeaderText = "Qty Bahan";
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[2].Name = "qty_bahan";
                dataGridView1.Columns[3].HeaderText = "Qty Req";
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[3].Name = "qty_req";
                dataGridView1.Columns[4].HeaderText = "Total Req";
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[4].Name = "total";
                dataGridView1.Columns[5].HeaderText = "Qty Stok";
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[5].Name = "stok";
                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 110;
                dataGridView1.Columns[6].Name = "state";
            }
        }
    }
}
