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
            MainForm.SETTING    = Connection.GetInstance().GetSetting();
            MainForm.USER       = Connection.GetInstance().GetUser();
            MainForm.KARYAWAN   = Connection.GetInstance().GetKaryawan();
            MainForm.PRODUK     = Connection.GetInstance().GetProduk();
            MainForm.PLACE      = Connection.GetInstance().GetPlace();
        }

        private TransaksiForm transaksiForm;
        private TransaksiTable transaksiTable;
        private ProdukTable produkTable;
        private TransaksiChange transaksiChange;
        private TransaksiClose transaksiClose;
        private ChangePassword changePassword;

        public static string TOKEN;
        public static JObject SETTING, USER;
        public static DataTable PRODUK, PLACE, KARYAWAN;

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
            transaksiForm.DataKaryawanObj = MainForm.KARYAWAN;
            transaksiForm.mainForm = this;
            transaksiForm.Show();
        }

        public void daftarTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is TransaksiTable)
                {
                    return;
                }
            }

            CloseMdiForm();
            transaksiTable = new TransaksiTable();
            transaksiTable.MdiParent = this;
            transaksiTable.WindowState = FormWindowState.Maximized;
            transaksiTable.setting = MainForm.SETTING;
            transaksiTable.mainForm = this;
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

        public void ChangeTransaksi(string orderID, string nota, string karyawan_id, string karyawan, string tanggal)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is TransaksiChange)
                {
                    return;
                }
            }

            CloseMdiForm();
            transaksiChange = new TransaksiChange();
            transaksiChange.MdiParent = this;
            transaksiChange.WindowState = FormWindowState.Maximized;
            transaksiChange.DataProdukObj = MainForm.PRODUK;
            transaksiChange.DataPlaceObj = MainForm.PLACE;
            transaksiChange.DataKaryawanObj = MainForm.KARYAWAN;
            transaksiChange.mainForm = this;
            transaksiChange.orderID = orderID;
            transaksiChange.nota = nota;
            transaksiChange.karyawan_id = karyawan_id;
            transaksiChange.karyawan = karyawan;
            transaksiChange.tanggal = tanggal;
            transaksiChange.Show();
        }

        public void CloseTransaksi(string orderID, string nota, string karyawan_id, string karyawan, string tanggal)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is TransaksiClose)
                {
                    return;
                }
            }

            CloseMdiForm();
            transaksiClose = new TransaksiClose();
            transaksiClose.MdiParent = this;
            transaksiClose.WindowState = FormWindowState.Maximized;
            transaksiClose.mainForm = this;
            transaksiClose.orderID = orderID;
            transaksiClose.nota = nota;
            transaksiClose.karyawan_id = karyawan_id;
            transaksiClose.karyawan = karyawan;
            transaksiClose.tanggal = tanggal;
            transaksiClose.Show();
        }

        private void ubahPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is ChangePassword)
                {
                    return;
                }
            }

            CloseMdiForm();
            changePassword = new ChangePassword();
            changePassword.MdiParent = this;
            changePassword.WindowState = FormWindowState.Maximized;
            changePassword.Show();
        }
    }
}
