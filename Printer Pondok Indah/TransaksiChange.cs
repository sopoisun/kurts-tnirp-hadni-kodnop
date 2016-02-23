using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public string orderID, nota, karyawan_id, karyawan;

        private void TransaksiChange_Load(object sender, EventArgs e)
        {
            txt_kasir.Enabled = false;
            dateTimePicker1.Enabled = false;

            txt_produks.AutoCompleteCustomSource = this.DataProduk();
            txt_places.AutoCompleteCustomSource = this.DataPlace();
            txt_karyawan.AutoCompleteCustomSource = this.DataKaryawan();

            txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();
            txt_karyawan.Text = karyawan + "     #" + karyawan_id;
            txt_karyawan.Enabled = false;

            this.Text = "Change Transaksi #"+this.nota;

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

        private AutoCompleteStringCollection DataProduk()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataProdukObj.Rows)
            {
                data.Add(row["nama_produk"].ToString() + "     #" + row["produk_id"].ToString());
            }
            return data;
        }

        private AutoCompleteStringCollection DataPlace()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataPlaceObj.Rows)
            {
                data.Add(row["nama"].ToString() + "     #" + row["place_id"].ToString());
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

                    _stokAccept = Connection.GetInstance().CheckStok(_produk_id, _qty);

                    if (_stokAccept >= 1)
                    {
                        dv = new DataView(DataProdukObj);
                        dv.RowFilter = "produk_id = '" + _produk_id + "'";

                        dgv_produk.Rows.Add(dgv_produk.Rows.Count + 1, _produk_id, _produk_name, dv[0]["harga"].ToString(), _qty, (int.Parse(dv[0]["harga"].ToString()) * _qty));

                        qtyProduk.Clear();
                        txt_produks.Clear();
                        txt_produks.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Stok tidak cukup !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_places.Text != "")
                {
                    _place_id = txt_places.Text.Split('#')[1].ToString();
                    _place_name = txt_places.Text.Split('#')[0].ToString().Trim();

                    dv = new DataView(DataPlaceObj);
                    dv.RowFilter = "place_id = '" + _place_id + "'";

                    dgv_place.Rows.Add(dgv_place.Rows.Count + 1, _place_id, _place_name, dv[0]["harga"].ToString());

                    txt_places.Clear();
                    txt_places.Focus();
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

        private void dgv_place_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_place.Rows.Count > 0)
                {
                    if (e.ColumnIndex == dgvplace_btnDelete.Index)
                    {
                        _place_name = dgv_place[dgvplace_nama_tempat.Index, e.RowIndex].Value.ToString();
                        if (MessageBox.Show("Hapus " + _place_name + " ??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                        {
                            dgv_place.Rows.RemoveAt(e.RowIndex);
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

        }
    }
}
