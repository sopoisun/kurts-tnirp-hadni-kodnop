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
    public partial class TransaksiForm : Form
    {
        public TransaksiForm()
        {
            InitializeComponent();
        }

        public DataTable DataProdukObj, DataPlaceObj, DataKaryawanObj;
        private DataView dv;
        private string _produk_id, _produk_name, _place_id, _place_name;
        private int _qty, _stokAccept;
        public MainForm mainForm;
        private List<string> TProduk = new List<string>();
        private List<string> TPlace = new List<string>();
        private ProdukComposition produkComposition;
        private Regex regex = new Regex(@"\d+");
        private Match match;

        private void TransaksiForm_Load(object sender, EventArgs e)
        {
            txt_kasir.Enabled = false;
            //dateTimePicker1.Enabled = false;

            txt_produks.AutoCompleteCustomSource = this.DataProduk();
            txt_places.AutoCompleteCustomSource = this.DataPlace();
            txt_karyawan.AutoCompleteCustomSource = this.DataKaryawan();

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
                data.Add(row["nama"].ToString() + " - "+row["kategori"]+"    #" + row["place_id"].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_places.Text != "")
                {
                    _place_id = txt_places.Text.Split('#')[1].ToString();
                    _place_name = txt_places.Text.Split('#')[0].ToString().Trim();

                    this.match = regex.Match(_place_id);

                    if (this.match.Success)
                    {
                        _place_id = this.match.Value.ToString();
                        if (!TPlace.Contains(_place_id))
                        {
                            TPlace.Add(_place_id);

                            dv = new DataView(DataPlaceObj);
                            dv.RowFilter = "place_id = '" + _place_id + "'";

                            dgv_place.Rows.Add(dgv_place.Rows.Count + 1, _place_id, _place_name, dv[0]["harga"].ToString());

                            txt_places.Clear();
                            txt_places.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Tempat sudah dimasukkan !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mohon periksa input tempat, karena \nterselip karakter asing !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            TPlace.Remove(dgv_place[dgvplace_place_id.Index, e.RowIndex].Value.ToString());
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
                if (dgv_produk.Rows.Count > 0 && dgv_place.Rows.Count > 0 && txt_karyawan.Text != "")
                {
                    if (MessageBox.Show("Simpan Transaksi ??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                    {

                        // Generate Data Produk with Json
                        string _dProduk = "[";
                        for (int i = 0; i < dgv_produk.RowCount; i++)
                        {
                            _dProduk += "{ \"id\": \"" +
                                    dgv_produk[dgvproduk_produk_id.Index, i].Value.ToString() + "\", \"qty\": \"" +
                                    dgv_produk[dgvproduk_qty.Index, i].Value.ToString() + "\", \"harga\": \"" +
                                    dgv_produk[dgvproduk_harga.Index, i].Value.ToString() + "\" }";
                            if ((i + 1) < dgv_produk.RowCount) { _dProduk += ","; }

                        }
                        _dProduk += "]";

                        // Generate Data Place
                        string _dPlace = "";
                        for (int i = 0; i < dgv_place.RowCount; i++)
                        {
                            _dPlace += dgv_place[dgvplace_place_id.Index, i].Value.ToString();
                            if ((i + 1) < dgv_place.RowCount) { _dPlace += ","; }
                        }

                        string _karyawan_id = txt_karyawan.Text.ToString().Split('#')[1]; // waiters
                        this.match = regex.Match(_karyawan_id);
                        _karyawan_id = this.match.Value.ToString();

                        int res = int.Parse(Connection.GetInstance().OpenTransaksi(dateTimePicker1.Value.ToString("yyyy-MM-dd"), _dProduk, _karyawan_id, _dPlace));

                        if (res > 0)
                        {
                            MessageBox.Show("Sukses Open Transaksi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.mainForm.daftarTransaksiToolStripMenuItem_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Terjadi Kesalahan !!", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Input belum lengkap !!\nMohon periksa produk yang dibeli,\ntempat yang digunakan dan\nwaiters yang melayani.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_produks.Text != "" && qtyProduk.Text != "")
                {
                    _produk_id = txt_produks.Text.Split('#')[1].ToString();
                    _produk_name = txt_produks.Text.Split('#')[0].ToString().Trim();
                    _qty = int.Parse(qtyProduk.Text);

                    produkComposition = new ProdukComposition();
                    produkComposition.namaProduk = _produk_name;
                    produkComposition.idProduk = _produk_id;
                    produkComposition.QtyReq = _qty;
                    produkComposition.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Input belum lengkap !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
    }
}
