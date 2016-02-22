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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Load Data
            MainForm.SETTING = Connection.GetInstance().GetSetting();
            MainForm.USER = Connection.GetInstance().GetUser();
            MainForm.PRODUK = Connection.GetInstance().GetProduk();
            MainForm.PLACE = Connection.GetInstance().GetPlace();
        }

        private TransaksiForm transaksiForm;
        private TransaksiTable transaksiTable;
        private ProdukTable produkTable;

        public static string TOKEN;
        public static JObject SETTING, USER;
        public static DataTable PRODUK, PLACE;

        private void CloseMdiForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.transaksiToolStripMenuItem_Click(null, null);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is TransaksiForm)
                {
                    return;
                }
            }

            CloseMdiForm();
            transaksiForm = new TransaksiForm();
            transaksiForm.MdiParent = this;
            transaksiForm.WindowState = FormWindowState.Maximized;
            transaksiForm.DataProdukObj = MainForm.PRODUK;
            transaksiForm.DataPlaceObj = MainForm.PLACE;
            transaksiForm.Show();
        }

        private void daftarTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is TransaksiList)
                {
                    return;
                }
            }

            CloseMdiForm();
            transaksiTable = new TransaksiTable();
            transaksiTable.MdiParent = this;
            transaksiTable.WindowState = FormWindowState.Maximized;
            transaksiTable.setting = MainForm.SETTING;
            transaksiTable.Show();
        }

        private void daftarProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is ProdukTable)
                {
                    return;
                }
            }

            CloseMdiForm();
            produkTable = new ProdukTable();
            produkTable.MdiParent = this;
            produkTable.WindowState = FormWindowState.Maximized;
            produkTable.DataProduk = MainForm.PRODUK;
            produkTable.Show();
        }
    }
}
