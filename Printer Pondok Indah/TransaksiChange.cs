using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Globalization;

namespace Printer_Pondok_Indah
{
    public partial class TransaksiChange : Form
    {
        public TransaksiChange()
        {
            InitializeComponent();
        }

        public DataTable DataProdukObj, DataPlaceObj, DataKaryawanObj, oldData;
        private DataView dv;
        private string _produk_id, _produk_name, _place_id, _place_name;
        private int _qty, _stokAccept;
        public MainForm mainForm;
        public string orderID, nota, karyawan_id, karyawan, tanggal;
        private List<string> TProduk = new List<string>();
        private List<string> TPlace = new List<string>();
        private Regex regex = new Regex(@"\d+");
        private Match match;

        private void TransaksiChange_Load(object sender, EventArgs e)
        {
            txt_kasir.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = DateTime.Parse(tanggal);

            txt_produks.AutoCompleteCustomSource = this.DataProduk();
            txt_karyawan.AutoCompleteCustomSource = this.DataKaryawan();

            txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();
            txt_karyawan.Text = karyawan + "     #" + karyawan_id;
            txt_karyawan.Enabled = false;

            this.Text = "Change Transaksi #"+this.nota;

            // Produk yang sudah dipesan ( Old Data )
            oldData = Connection.GetInstance().GetDetail(this.orderID);

            if (oldData.Rows.Count > 0)
            {
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

        private AutoCompleteStringCollection DataProduk()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataProdukObj.Rows)
            {
                data.Add(row["nama_produk"].ToString() + "     #" + row["produk_id"].ToString());
            }
            return data;
        }

        private AutoCompleteStringCollection DataKaryawan()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataKaryawanObj.Rows)
            {
                data.Add(row["nama_karyawan"].ToString() + "     #" + row["karyawan_id"].ToString());
            }
            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_produks.Text != "" && qtyProduk.Text != "")
                {
                    _produk_id = txt_produks.Text.Split('#')[1].ToString();
                    _produk_name = txt_produks.Text.Split('#')[0].ToString().Trim();
                    _qty = int.Parse(qtyProduk.Text);

                    this.match = regex.Match(_produk_id);

                    if (this.match.Success)
                    {
                        _produk_id = this.match.Value.ToString();
                        _stokAccept = Connection.GetInstance().CheckStok(_produk_id, _qty);

                        if (_stokAccept >= 1)
                        {
                            if (!TProduk.Contains(_produk_id))
                            {
                                TProduk.Add(_produk_id);

                                dv = new DataView(DataProdukObj);
                                dv.RowFilter = "produk_id = '" + _produk_id + "'";

                                dgv_produk.Rows.Add(dgv_produk.Rows.Count + 1, _produk_id, _produk_name, dv[0]["harga"].ToString(), _qty, (int.Parse(dv[0]["harga"].ToString()) * _qty));

                                qtyProduk.Clear();
                                txt_produks.Clear();
                                txt_produks.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Produk sudah dimasukkan !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Stok tidak cukup !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mohon periksa input produk, karena \nterselip karakter asing !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Input belum lengkap !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void qtyProduk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.button1_Click(null, null);
            }
        }

        private void dgv_produk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_produk.Rows.Count > 0)
                {
                    if (e.ColumnIndex == dgvproduk_btnDelete.Index)
                    {
                        _produk_name = dgv_produk[dgvproduk_nama_produk.Index, e.RowIndex].Value.ToString();
                        if (MessageBox.Show("Hapus " + _produk_name + " ??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                        {
                            TProduk.Remove(dgv_produk[dgvproduk_produk_id.Index, e.RowIndex].Value.ToString());
                            dgv_produk.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnSaveTransaksi_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Simpan Transaksi ??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                {
                    string _dProduk = "";
                    if (dgv_produk.RowCount > 0)
                    {
                        // Generate Data Produk with Json
                        _dProduk = "[";
                        for (int i = 0; i < dgv_produk.RowCount; i++)
                        {
                            _dProduk += "{ \"id\": \"" +
                                    dgv_produk[dgvproduk_produk_id.Index, i].Value.ToString() + "\", \"qty\": \"" +
                                    dgv_produk[dgvproduk_qty.Index, i].Value.ToString() + "\", \"harga\": \"" +
                                    dgv_produk[dgvproduk_harga.Index, i].Value.ToString() + "\" }";
                            if ((i + 1) < dgv_produk.RowCount) { _dProduk += ","; }

                        }
                        _dProduk += "]";
                    }

                    int res = int.Parse(Connection.GetInstance().ChangeTransaksi(this.orderID, _dProduk));

                    if (res > 0)
                    {
                        MessageBox.Show("Sukses Change Transaksi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.mainForm.daftarTransaksiToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Terjadi Kesalahan !!", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
