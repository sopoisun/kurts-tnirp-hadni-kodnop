using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Printer_Pondok_Indah
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            printdocument1.PrintPage += DoPrintStruk;

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
        // for print nota
        private PrintDocument printdocument1 = new PrintDocument();
        private DataTable dataProduk;
        private JObject dataBayar;
        private string nota = "", _txt = "";
        private int _length = 0;

        public static string TOKEN;
        public static JObject SETTING, USER;
        public static DataTable PRODUK, PLACE, KARYAWAN;

        /* Print Action */
        public void PrintStruk(string orderId, string _nota)
        {
            this.nota = _nota;
            this.dataProduk = Connection.GetInstance().GetDetail(orderId);
            this.dataBayar = Connection.GetInstance().GetBayar(orderId);

            using (PrintDialog pd = new PrintDialog())
            {
                printdocument1.PrinterSettings = pd.PrinterSettings;
                printdocument1.Print();
            }
        }

        public void PrintStruk(string _nota, DataTable _dataProduk, JObject _dataBayar)
        {
            this.nota = _nota;
            this.dataProduk = _dataProduk;
            this.dataBayar = _dataBayar;

            using (PrintDialog pd = new PrintDialog())
            {
                printdocument1.PrinterSettings = pd.PrinterSettings;
                printdocument1.Print();
            }
        }

        private void DoPrintStruk(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font objFont = new Font("Courier New", 9F);//sets the font type and size
            Font fontHeader = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);//sets the font type and size
            //float fTopMargin = e.MarginBounds.Top;
            float fTopMargin = 0;
            float fLeftMargin = 5;//sets left margin
            float fRightMargin = e.MarginBounds.Right - 150;//sets right margin
            string text = "";

            e.Graphics.DrawString(MainForm.SETTING["title_faktur"].ToString(), fontHeader, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.7;//skip two lines
            e.Graphics.DrawString(MainForm.SETTING["alamat_faktur"].ToString(), objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            e.Graphics.DrawString(MainForm.SETTING["telp_faktur"].ToString(), objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)2;//skip two lines

            text = String.Format("{0} {1, 3} {2}", "Kasir", ":", this.dataBayar["kasir"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            text = String.Format("{0} {1, 0} {2}", "Waiters", ":", this.dataBayar["waiters"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);

            if (this.dataBayar["customer"].ToString() != "")
            {
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
                text = String.Format("{0} {1, 2} {2}", "Member", ":", this.dataBayar["customer"]);
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);                
            }

            fTopMargin += objFont.GetHeight() * (float)1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            this._txt = "Nota : " + this.nota;
            this._length = this._txt.Length;

            text = String.Format("{0, " + this._length + "} {1, " + (10 + (20 - this._length)) + "}", this._txt, DateTime.Now.Date.ToString("dd/MM/yyyy"));

            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.3;//skip two lines

            /* produk */
            foreach (DataRow row in dataProduk.Rows)
            {
                text = string.Concat(row["nama_produk"].ToString());
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

                text = String.Format("   {0, -3} {1, 11} {2, 12}", row["qty"], row["harga"], row["subtotal"]);
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            }
            /* produk */

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            text = String.Format("{0} {1, 7} {2, 17}", "Total", ":", this.dataBayar["total"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " " + this.dataBayar["tax_pro"] + "%";
            this._length = 9 - this._txt.Length;

            text = String.Format("{0, -1} {1, " + this._length + "} {2, 17}", "Tax" + this._txt, ":", this.dataBayar["tax"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " " + this.dataBayar["tax_bayar_pro"] + "%";
            this._length = 5 - this._txt.Length;

            text = String.Format("{0, -1} {1, " + this._length + "} {2, 17}", "Tax Byr" + this._txt, ":", this.dataBayar["tax_bayar"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("{0, -1} {1, 6} {2, 17}", "Jumlah", ":", this.dataBayar["jumlah"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("{0, -1} {1, 6} {2, 17}", "Diskon", ":", this.dataBayar["diskon"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("{0, -1} {1, 8} {2, 17}", "Sisa", ":", this.dataBayar["sisa"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("{0, -1} {1, 7} {2, 17}", "Bayar", ":", this.dataBayar["bayar"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("{0, -1} {1, 5} {2, 17}", "Kembali", ":", this.dataBayar["kembali"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1;//skip two lines

            e.Graphics.DrawString("-------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("TRIMA KASIH ATAS KUNJUNGAN ANDA", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            objFont.Dispose();

            e.HasMorePages = false;
        }
        /* End Print Action */

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
