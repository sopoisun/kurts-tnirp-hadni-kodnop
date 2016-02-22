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

        public DataTable DataProdukObj;
        private Dictionary<string, string> temporaryNama = new Dictionary<string, string>();
        private int mark = 0;

        private void TransaksiForm_Load(object sender, EventArgs e)
        {
            mark = 10;
        }

        private AutoCompleteStringCollection DataProduk()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataProdukObj.Rows)
            {
                data.Add(row["produk_id"].ToString());
            }
            return data;
        }

        private AutoCompleteStringCollection DataProdukNama()
        {
            int temp = 0;
            string str = "";

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataProdukObj.Rows)
            {
                temp = 70 - row["nama_produk"].ToString().Length;

                str = "";
                for (int i = 0; i<temp; i++)
                {
                    str += " ";
                }

                data.Add(row["nama_produk"].ToString() + str + "#" + row["produk_id"].ToString());
            }
            return data;
        }

        private void dgv_produk_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    if (dgv_produk.CurrentCell.ColumnIndex == dgv_produk.Columns["produk_id"].Index)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteCustomSource = DataProduk();
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                    else if (dgv_produk.CurrentCell.ColumnIndex == dgv_produk.Columns["nama_produk"].Index)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteCustomSource = DataProdukNama();
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                    else
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.None;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void dgv_produk_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_produk.RowCount > 0 && mark >= 10)
                {
                    byte selectedRow = (byte)dgv_produk.CurrentCell.RowIndex;

                    if ( e.ColumnIndex == dgv_produk.Columns["produk_id"].Index )
                    {
                        MessageBox.Show("Index produk_id Changed");
                    }

                    if (e.ColumnIndex == dgv_produk.Columns["nama_produk"].Index )
                    {                        
                        MessageBox.Show("Index nama_produk Changed");

                        string key = dgv_produk[dgv_produk.Columns["nama_produk"].Index, selectedRow].Value.ToString().Split('#')[1];
                        dgv_produk[dgv_produk.Columns["produk_id"].Index, selectedRow].Value = key;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void dgv_produk_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dgv_produk[0, e.RowIndex - 1].Value = e.RowIndex;
                dgv_produk[0, e.RowIndex].Value = e.RowIndex + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
