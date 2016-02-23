using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Printer_Pondok_Indah
{
    public partial class TransaksiClose : Form
    {
        public TransaksiClose()
        {
            InitializeComponent();
        }

        public DataTable oldData;
        public MainForm mainForm;
        public string orderID, nota, karyawan_id, karyawan;

        private void TransaksiClose_Load(object sender, EventArgs e)
        {
            txt_kasir.Enabled = false;
            dateTimePicker1.Enabled = false;

            txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();
            txt_karyawan.Text = karyawan + "     #" + karyawan_id;
            txt_karyawan.Enabled = false;

            this.Text = "Close Transaksi #" + this.nota;

            // Produk yang sudah dipesan ( Old Data )
            oldData = Connection.GetInstance().GetDetail(this.orderID);

            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = oldData;
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].HeaderText = "Nama Produk";
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[1].Name = "nama_produk";
            dataGridView1.Columns[2].HeaderText = "Harga";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].Name = "harga";
            dataGridView1.Columns[3].HeaderText = "Qty";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[3].Name = "qty";
            dataGridView1.Columns[4].HeaderText = "Subtotal";
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[4].Name = "subtotal";
        }
    }
}
