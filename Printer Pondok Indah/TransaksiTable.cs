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
        }

        private DataGridViewButtonColumn btnPrint;
        private DataGridViewButtonColumn btnDetail;
        private Detail detail;
        public JObject setting;
        private string nota = "", id = "";
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
                dataGridView1.Columns[2].Width = 220;
                dataGridView1.Columns[2].Name = "nota";
                dataGridView1.Columns[3].HeaderText = "Tempat";
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[3].Name = "tempat";
                dataGridView1.Columns[4].HeaderText = "Status";
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[4].Name = "status";
                dataGridView1.Columns[5].HeaderText = "Karyawan";
                dataGridView1.Columns[5].Width = 230;
                dataGridView1.Columns[5].Name = "karyawan";
                dataGridView1.Columns[6].HeaderText = "Karyawan ID";
                dataGridView1.Columns[6].Width = 130;
                dataGridView1.Columns[6].Name = "karyawan_id";
                dataGridView1.Columns[6].Visible = false;

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
                string karyawan_id = dataGridView1[dataGridView1.Columns["karyawan_id"].Index, e.RowIndex].Value.ToString();
                string nama_karyawan = dataGridView1[dataGridView1.Columns["karyawan"].Index, e.RowIndex].Value.ToString();

                if (e.ColumnIndex == dataGridView1.Columns["btn_print"].Index && e.RowIndex >= 0)
                {
                    if (status == "Closed")
                    {
                        if (MessageBox.Show("Print nota " + nota + " ini ?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.mainForm.PrintStruk(this.id);
                        }
                    }
                    else
                    {
                        this.mainForm.CloseTransaksi(this.id, this.nota, karyawan_id, nama_karyawan, tanggal.Value.ToString("yyyy-MM-dd"));
                    }
                }
                else if (e.ColumnIndex == dataGridView1.Columns["btn_detail"].Index && e.RowIndex >= 0)
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
                        this.mainForm.ChangeTransaksi(this.id, this.nota, karyawan_id, nama_karyawan, tanggal.Value.ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
