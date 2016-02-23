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
using System.Drawing.Printing;

namespace Printer_Pondok_Indah
{
    public partial class TransaksiTable : Form
    {
        public TransaksiTable()
        {
            InitializeComponent();
            printdocument1.PrintPage += printDocument1_PrintPage;
        }

        private DataGridViewButtonColumn btnPrint;
        private DataGridViewButtonColumn btnDetail;
        private Detail detail;
        private DataTable dataProduk;
        private JObject dataBayar;
        public JObject setting;
        private string nota = "", id = "", _txt = "";
        private int _length = 0;
        PrintDocument printdocument1 = new PrintDocument();
        public MainForm mainForm;

        private void TransaksiTable_Load(object sender, EventArgs e)
        {
            GetDataTransaksi();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetDataTransaksi();
        }

        private void GetDataTransaksi()
        {
            DataTable dt = Connection.GetInstance().GetTransaksi(tanggal.Value.ToString("yyyy-MM-dd"));

            dataGridView1.Columns.Clear();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "No";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].HeaderText = "ID";
                dataGridView1.Columns[1].Width = 30;
                dataGridView1.Columns[1].Name = "id";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "No. Nota";
                dataGridView1.Columns[2].Width = 450;
                dataGridView1.Columns[2].Name = "nota";
                dataGridView1.Columns[3].HeaderText = "Status";
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[3].Name = "status";
                dataGridView1.Columns[4].HeaderText = "Karyawan";
                dataGridView1.Columns[4].Width = 230;
                dataGridView1.Columns[4].Name = "karyawan";
                dataGridView1.Columns[5].HeaderText = "Karyawan ID";
                dataGridView1.Columns[5].Width = 130;
                dataGridView1.Columns[5].Name = "karyawan_id";
                dataGridView1.Columns[5].Visible = false;

                btnDetail = new DataGridViewButtonColumn();
                btnDetail.Name = "btn_detail";
                btnDetail.HeaderText = "Action";
                btnDetail.Text = "Change/Detail";
                btnDetail.Width = 100;
                btnDetail.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnDetail);

                btnPrint = new DataGridViewButtonColumn();
                btnPrint.Name = "btn_print";
                btnPrint.HeaderText = "Action";
                btnPrint.Text = "Close/Print";
                btnPrint.Width = 100;
                btnPrint.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnPrint);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.nota = dataGridView1[dataGridView1.Columns["nota"].Index, e.RowIndex].Value.ToString();
                this.id = dataGridView1[dataGridView1.Columns["id"].Index, e.RowIndex].Value.ToString();
                string status = dataGridView1[dataGridView1.Columns["status"].Index, e.RowIndex].Value.ToString();                

                if (e.ColumnIndex == dataGridView1.Columns["btn_print"].Index && e.RowIndex >= 0)
                {
                    if (status == "Closed")
                    {
                        if (MessageBox.Show("Print nota " + nota + " ini ?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dataProduk = Connection.GetInstance().GetDetail(this.id);
                            dataBayar = Connection.GetInstance().GetBayar(this.id);

                            this.PrintCsharp();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Belum Close, tidak bisa di print :)", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (e.ColumnIndex == dataGridView1.Columns["btn_detail"].Index && e.RowIndex >= 0)
                {
                    if (status == "Closed")
                    {
                        detail = new Detail();
                        detail.id = this.id;
                        detail.nota = this.nota;
                        detail.status = status;
                        detail.ShowDialog();
                    }
                    else
                    {
                        string karyawan_id = dataGridView1[dataGridView1.Columns["karyawan_id"].Index, e.RowIndex].Value.ToString();
                        string nama_karyawan = dataGridView1[dataGridView1.Columns["karyawan"].Index, e.RowIndex].Value.ToString();

                        this.mainForm.OpenChangeTransaksi(this.id, this.nota, karyawan_id, nama_karyawan);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintCsharp()
        {
            using (PrintDialog pd = new PrintDialog())
            {
                printdocument1.PrinterSettings = pd.PrinterSettings;
                printdocument1.Print();
            }
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font objFont = new Font("Courier New", 10F);//sets the font type and size
            Font fontHeader = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);//sets the font type and size
            //float fTopMargin = e.MarginBounds.Top;
            float fTopMargin = 0;
            float fLeftMargin = 5;//sets left margin
            float fRightMargin = e.MarginBounds.Right - 150;//sets right margin

            e.Graphics.DrawString(this.setting["title_faktur"].ToString(), fontHeader, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.7;//skip two lines
            e.Graphics.DrawString(this.setting["alamat_faktur"].ToString(), objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            e.Graphics.DrawString(this.setting["telp_faktur"].ToString(), objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.3;//skip two lines

            e.Graphics.DrawString("------------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("Nota : " + this.nota + "\t\t" + DateTime.Now.Date.ToString("dd/MM/yyyy"), objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("------------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.3;//skip two lines

            /* produk */
            string text = "";
            foreach (DataRow row in dataProduk.Rows)
            {
                text = string.Concat(row["nama_produk"].ToString());
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

                text = String.Format("   {0, -3} {1, 13} {2, 15}", row["qty"], row["harga"], row["subtotal"]);
                e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
                fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines
            }
            /* produk */

            e.Graphics.DrawString("------------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            text = String.Format("          {0} {1, 7} {2, 12}", "Total", ":", this.dataBayar["total"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " " + this.dataBayar["tax_pro"] + "%";
            this._length = 9 - this._txt.Length;

            text = String.Format("          {0, -1} {1, " + this._length + "} {2, 12}", "Tax" + this._txt, ":", this.dataBayar["tax"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            this._txt = " " + this.dataBayar["tax_bayar_pro"] + "%";
            this._length = 5 - this._txt.Length;

            text = String.Format("          {0, -1} {1, " + this._length + "} {2, 12}", "Tax Byr" + this._txt, ":", this.dataBayar["tax_bayar"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("          {0, -1} {1, 6} {2, 12}", "Jumlah", ":", this.dataBayar["jumlah"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("          {0, -1} {1, 6} {2, 12}", "Diskon", ":", this.dataBayar["diskon"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("          {0, -1} {1, 8} {2, 12}", "Sisa", ":", this.dataBayar["sisa"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("          {0, -1} {1, 7} {2, 12}", "Bayar", ":", this.dataBayar["bayar"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            text = String.Format("          {0, -1} {1, 5} {2, 12}", "Kembali", ":", this.dataBayar["kembali"]);
            e.Graphics.DrawString(text, objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * (float)1.5;//skip two lines

            e.Graphics.DrawString("------------------------------------", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            e.Graphics.DrawString("TERIMA KASIH ATAS KUNJUNGAN ANDA", objFont, Brushes.Black, fLeftMargin, fTopMargin);
            fTopMargin += objFont.GetHeight() * 1;//skip two lines

            objFont.Dispose();

            e.HasMorePages = false;
        }
    }
}
