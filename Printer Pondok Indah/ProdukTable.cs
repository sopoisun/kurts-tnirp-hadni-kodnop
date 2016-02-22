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
    public partial class ProdukTable : Form
    {
        public ProdukTable()
        {
            InitializeComponent();
        }

        public DataTable DataProduk;
        private DataView dv;

        private void ProdukTable_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            dv = new DataView(DataProduk);
            dv.RowFilter = "nama_produk like '%" + txt_search.Text + "%'";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dv;

            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "Nama Produk";
            dataGridView1.Columns[1].Width = 330;
            dataGridView1.Columns[1].Name = "nama_produk";
            dataGridView1.Columns[2].HeaderText = "Harga";
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[2].Name = "harga_f";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Harga";
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[3].Name = "harga";
            dataGridView1.Columns[4].HeaderText = "Kategori";
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[4].Name = "kategori";
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }
    }
}
