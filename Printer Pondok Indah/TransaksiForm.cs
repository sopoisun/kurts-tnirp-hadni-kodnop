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
        private string _produk_id;
        private int _qty, _stokAccept;

        private void TransaksiForm_Load(object sender, EventArgs e)
        {
            txt_produks.AutoCompleteCustomSource = this.DataProduk();
            txt_places.AutoCompleteCustomSource = this.DataPlace();
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
                    _qty = int.Parse(qtyProduk.Text);

                    _stokAccept = Connection.GetInstance().CheckStok(_produk_id, _qty);

                    if (_stokAccept >= 1)
                    {

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
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void txt_produks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                qtyProduk.Focus();
            }
        }
    }
}
