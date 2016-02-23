using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Printer_Pondok_Indah
{
    public partial class TransaksiClose : Form
    {
        public TransaksiClose()
        {
            InitializeComponent();
        }

        public DataTable oldData, DataBank, DataTax, DataCustomerObj;
        public MainForm mainForm;
        public string orderID, nota, karyawan_id, karyawan, selectedCmb;
        private int tempSplit1, tempSplit2, mark = 0;
        private DataView dvTax, dvBank, dvCustomer;

        private AutoCompleteStringCollection DataCustomer()
        {
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in DataCustomerObj.Rows)
            {
                data.Add(row["customer_code"].ToString());
            }
            return data;
        }

        private void TransaksiClose_Load(object sender, EventArgs e)
        {
            txt_kasir.Enabled = false;
            dateTimePicker1.Enabled = false;
            txt_tempat.Enabled = false;
            txt_customer.Enabled = false;
            txt_total.ReadOnly = true;
            txt_tax.ReadOnly = true;
            txt_tax_bayar.ReadOnly = true;
            txt_total_akhir.ReadOnly = true;
            txt_jumlah.ReadOnly = true;
            txt_kembali.ReadOnly = true;

            txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();

            this.Text = "Close Transaksi #" + this.nota;

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

            cmb_type_bayar.SelectedIndex = 0;

            DataTax = Connection.GetInstance().GetTax();
            DataBank = Connection.GetInstance().GetBank();

            var taxs = new Dictionary<string, string>();
            foreach (DataRow row in DataTax.Rows)
            {
                taxs[row["tax_id"].ToString()] = row["type"].ToString();
            }
            cmb_type_tax.DataSource = new BindingSource(taxs, null);
            cmb_type_tax.DisplayMember = "Value";
            cmb_type_tax.ValueMember = "Key";

            var banks = new Dictionary<string, string>();
            foreach (DataRow row in DataBank.Rows)
            {
                banks[row["bank_id"].ToString()] = row["nama_bank"].ToString();
            }
            cmb_bank.DataSource = new BindingSource(banks, null);
            cmb_bank.DisplayMember = "Value";
            cmb_bank.ValueMember = "Key";

            DataCustomerObj = Connection.GetInstance().GetCustomer();
            txt_customer_ID.AutoCompleteCustomSource = DataCustomer();
        }

        private void cmb_type_bayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_bayar.SelectedItem.ToString() != "Tunai")
            {
                cmb_bank.Enabled = true;

                this.cmb_bank_SelectedIndexChanged(null, null);
            }
            else
            {
                cmb_bank.Enabled = false;                
            }
        }

        private void cmb_type_tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCmb = cmb_type_tax.SelectedValue.ToString();

            if (selectedCmb.IndexOf('[') >= 0)
            {
                tempSplit1 = selectedCmb.IndexOf('[');
                tempSplit2 = selectedCmb.IndexOf(',');

                selectedCmb = selectedCmb.Substring(tempSplit1 + 1, (tempSplit2 - tempSplit1 - 1));
            }

            dvTax = new DataView(DataTax);
            dvTax.RowFilter = "tax_id = '" + selectedCmb + "'";
            lbl_tax.Text = "Tax " + dvTax[0]["procentage"].ToString() + "%";
        }

        private void cmb_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_type_bayar.SelectedItem.ToString() == "Credit Card")
            {
                selectedCmb = cmb_bank.SelectedValue.ToString();

                if (selectedCmb.IndexOf('[') >= 0)
                {
                    tempSplit1 = selectedCmb.IndexOf('[');
                    tempSplit2 = selectedCmb.IndexOf(',');

                    selectedCmb = selectedCmb.Substring(tempSplit1 + 1, (tempSplit2 - tempSplit1 - 1));
                }

                dvBank = new DataView(DataBank);
                dvBank.RowFilter = "bank_id = '" + selectedCmb + "'";
                lbl_tax_bayar.Text = "Tax Bayar " + dvBank[0]["credit_card_tax"].ToString() + "%";
            }
            else
            {
                lbl_tax_bayar.Text = "Tax Bayar 0%";
            }
        }

        private void txt_customer_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dvCustomer = new DataView(DataCustomerObj);
                dvCustomer.RowFilter = "customer_code = '" + txt_customer_ID.Text + "'";

                if (dvCustomer.Count > 0)
                {
                    txt_customer.Text = dvCustomer[0]["nama_customer"].ToString();
                }
                else
                {
                    MessageBox.Show("ID Customer tidak terdaftar");
                }
            }
        }

        private void txt_customer_ID_TextChanged(object sender, EventArgs e)
        {
            if (txt_customer_ID.Text == "")
            {
                txt_customer.Clear();
            }
        }
    }
}
