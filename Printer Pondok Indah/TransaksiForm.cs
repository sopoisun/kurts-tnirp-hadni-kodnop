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
    public partial class TransaksiForm : Form
    {
        public TransaksiForm()
        {
            InitializeComponent();
        }

        public DataTable DataProdukObj, DataPlaceObj;
        private DataView dv;
        private string _produk_id, _produk_name, _place_id, _place_name;
        private int _qty, _stokAccept;

        private void TransaksiForm_Load(object sender, EventArgs e)
        {
            txt_produks.AutoCompleteCustomSource = this.DataProduk();
            txt_places.AutoCompleteCustomSource = this.DataPlace();

            txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();
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
                        dv.RowFilter = "produk_id = '"+_produk_id+"'";

                        dgv_produk.Rows.Add(dgv_produk.Rows.Count + 1, _produk_id, _produk_name, dv[0]["harga"].ToString(), _qty, (int.Parse(dv[0]["harga"].ToString())*_qty));

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
            try
            {
                if (dgv_produk.Rows.Count > 0 && dgv_place.Rows.Count > 0)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }        
    }
}
