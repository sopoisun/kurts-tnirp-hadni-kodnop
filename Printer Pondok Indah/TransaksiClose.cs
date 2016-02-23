using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        private int tempSplit1, tempSplit2, tax_procentage = 0, tax_bayar_procentage = 0;
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
            try{
                txt_kasir.Enabled = false;
                dateTimePicker1.Enabled = false;
                txt_karyawan.Enabled = false;
                txt_customer.Enabled = false;
                txt_total.ReadOnly = true;
                txt_tax.ReadOnly = true;
                txt_tax_bayar.ReadOnly = true;
                txt_total_akhir.ReadOnly = true;
                txt_jumlah.ReadOnly = true;
                txt_kembali.ReadOnly = true;

                txt_kasir.Text = MainForm.USER["nama_karyawan"].ToString();
                txt_karyawan.Text = karyawan;
                txt_karyawan.Enabled = false;
                this.Text = "Close Transaksi #" + this.nota;

                // Produk yang sudah dipesan ( Old Data )
                oldData = Connection.GetInstance().GetDetail(this.orderID);

                int total = 0;
                foreach (DataRow row in oldData.Rows)
                {
                    total += int.Parse(row["subtotal"].ToString().Replace(".", ""));
                }
                txt_total.Text = total.ToString();

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

                HitungTotalAkhir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmb_type_bayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_type_bayar.SelectedItem.ToString() != "Tunai")
                {
                    cmb_bank.Enabled = true;
                }
                else
                {
                    cmb_bank.Enabled = false;                
                }

                this.cmb_bank_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmb_type_tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                this.tax_procentage = int.Parse(dvTax[0]["procentage"].ToString());

                HitungTotalAkhir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cmb_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    this.tax_bayar_procentage = int.Parse(dvBank[0]["credit_card_tax"].ToString());
                }
                else
                {
                    lbl_tax_bayar.Text = "Tax Bayar 0%";
                    this.tax_bayar_procentage = 0;
                }

                HitungTotalAkhir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txt_customer_ID_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txt_customer_ID_TextChanged(object sender, EventArgs e)
        {
            if (txt_customer_ID.Text == "")
            {
                txt_customer.Clear();
            }
        }

        private void txt_diskon_TextChanged(object sender, EventArgs e)
        {
            HitungTotalAkhir();
        }

        private void txt_bayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void HitungTotalAkhir()
        {
            try
            {
                double total = int.Parse(txt_total.Text);
                double tax = Math.Round(total * (double.Parse(this.tax_procentage.ToString()) / 100));
                double tax_bayar = Math.Round((total + tax) * (double.Parse(this.tax_bayar_procentage.ToString()) / 100));
                double total_akhir = total + tax + tax_bayar;
                double diskon = 0;

                if (txt_diskon.Text != "")
                {
                    diskon = double.Parse(txt_diskon.Text);
                }

                double jumlah = total_akhir - diskon;

                txt_tax.Text = tax.ToString();
                txt_tax_bayar.Text = tax_bayar.ToString();
                txt_total_akhir.Text = total_akhir.ToString();
                txt_jumlah.Text = jumlah.ToString();

                HitungKembalian();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void HitungKembalian()
        {
            try
            {
                
                int jumlah = 0;
                if (txt_jumlah.Text != "")
                {
                    jumlah = int.Parse(txt_jumlah.Text);
                }

                int bayar = 0;
                if (txt_bayar.Text != "")
                {
                    bayar = int.Parse(txt_bayar.Text);
                }

                int kembalian = bayar - jumlah;

                if (kembalian > 0)
                {
                    txt_kembali.Text = kembalian.ToString();
                }
                else
                {
                    txt_kembali.Text = "0";
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
                if (txt_bayar.Text != "")
                {
                    bool lanjut = true;
                    string customerID = "";

                    if (txt_customer_ID.Text != "")
                    {
                        lanjut = false;
                    }

                    if (!lanjut)
                    {
                        dvCustomer = new DataView(DataCustomerObj);
                        dvCustomer.RowFilter = "customer_code = '" + txt_customer_ID.Text + "'";
                        if (dvCustomer.Count > 0)
                        {
                            customerID = dvCustomer[0]["customer_id"].ToString();
                            lanjut = true;
                        }
                        else
                        {
                            MessageBox.Show("ID Customer tidak terdaftar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (lanjut)
                    {
                        if (MessageBox.Show("Tutup Transaksi ??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            == DialogResult.Yes)
                        {
                            int diskon = int.Parse(txt_diskon.Text);
                            int bayar = int.Parse(txt_bayar.Text);

                            int res = int.Parse(Connection.GetInstance().CloseTransaksi(this.orderID, cmb_type_tax.SelectedValue.ToString(), this.tax_procentage.ToString(),
                                diskon.ToString(), bayar.ToString(), cmb_type_bayar.SelectedItem.ToString().ToLower().Replace(" ", "_"), cmb_bank.SelectedValue.ToString(), this.tax_bayar_procentage.ToString(),
                                customerID));

                            if (res > 0)
                            {
                                MessageBox.Show("Sukses Close Transaksi.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.mainForm.daftarTransaksiToolStripMenuItem_Click(null, null);
                            }
                            else
                            {
                                MessageBox.Show("Terjadi Kesalahan !!", "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Input belum lengkap", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
