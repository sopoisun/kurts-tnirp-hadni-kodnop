﻿namespace Printer_Pondok_Indah
{
    partial class TransaksiChange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_karyawan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveTransaksi = new System.Windows.Forms.Button();
            this.txt_kasir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.group_produk = new System.Windows.Forms.GroupBox();
            this.qtyProduk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_produks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_produk = new System.Windows.Forms.DataGridView();
            this.dgvproduk_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_produk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_nama_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.readstok = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.group_produk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produk)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_karyawan
            // 
            this.txt_karyawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_karyawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_karyawan.Location = new System.Drawing.Point(461, 21);
            this.txt_karyawan.Name = "txt_karyawan";
            this.txt_karyawan.Size = new System.Drawing.Size(231, 20);
            this.txt_karyawan.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Waiters";
            // 
            // btnSaveTransaksi
            // 
            this.btnSaveTransaksi.Location = new System.Drawing.Point(461, 50);
            this.btnSaveTransaksi.Name = "btnSaveTransaksi";
            this.btnSaveTransaksi.Size = new System.Drawing.Size(148, 22);
            this.btnSaveTransaksi.TabIndex = 14;
            this.btnSaveTransaksi.Text = "Simpan Transaksi";
            this.btnSaveTransaksi.UseVisualStyleBackColor = true;
            this.btnSaveTransaksi.Click += new System.EventHandler(this.btnSaveTransaksi_Click);
            // 
            // txt_kasir
            // 
            this.txt_kasir.Location = new System.Drawing.Point(112, 21);
            this.txt_kasir.Name = "txt_kasir";
            this.txt_kasir.ReadOnly = true;
            this.txt_kasir.Size = new System.Drawing.Size(248, 20);
            this.txt_kasir.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kasir";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tanggal";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(22, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 378);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.group_produk);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Baru";
            // 
            // group_produk
            // 
            this.group_produk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_produk.Controls.Add(this.readstok);
            this.group_produk.Controls.Add(this.qtyProduk);
            this.group_produk.Controls.Add(this.label5);
            this.group_produk.Controls.Add(this.button1);
            this.group_produk.Controls.Add(this.txt_produks);
            this.group_produk.Controls.Add(this.label3);
            this.group_produk.Controls.Add(this.dgv_produk);
            this.group_produk.Location = new System.Drawing.Point(15, 11);
            this.group_produk.Name = "group_produk";
            this.group_produk.Size = new System.Drawing.Size(954, 335);
            this.group_produk.TabIndex = 7;
            this.group_produk.TabStop = false;
            this.group_produk.Text = "Daftar Produk Yang Dibeli";
            // 
            // qtyProduk
            // 
            this.qtyProduk.Location = new System.Drawing.Point(509, 24);
            this.qtyProduk.Name = "qtyProduk";
            this.qtyProduk.Size = new System.Drawing.Size(58, 20);
            this.qtyProduk.TabIndex = 5;
            this.qtyProduk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtyProduk_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Qty";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Simpan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_produks
            // 
            this.txt_produks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_produks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_produks.Location = new System.Drawing.Point(137, 24);
            this.txt_produks.Name = "txt_produks";
            this.txt_produks.Size = new System.Drawing.Size(325, 20);
            this.txt_produks.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nama Produk";
            // 
            // dgv_produk
            // 
            this.dgv_produk.AllowUserToAddRows = false;
            this.dgv_produk.AllowUserToDeleteRows = false;
            this.dgv_produk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_produk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_produk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvproduk_no,
            this.dgvproduk_produk_id,
            this.dgvproduk_nama_produk,
            this.dgvproduk_harga,
            this.dgvproduk_qty,
            this.dgvproduk_subtotal,
            this.dgvproduk_btnDelete});
            this.dgv_produk.Location = new System.Drawing.Point(17, 55);
            this.dgv_produk.Name = "dgv_produk";
            this.dgv_produk.Size = new System.Drawing.Size(918, 263);
            this.dgv_produk.TabIndex = 2;
            this.dgv_produk.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_produk_CellContentClick);
            // 
            // dgvproduk_no
            // 
            this.dgvproduk_no.HeaderText = "No";
            this.dgvproduk_no.Name = "dgvproduk_no";
            this.dgvproduk_no.ReadOnly = true;
            this.dgvproduk_no.Width = 50;
            // 
            // dgvproduk_produk_id
            // 
            this.dgvproduk_produk_id.HeaderText = "Produk ID";
            this.dgvproduk_produk_id.Name = "dgvproduk_produk_id";
            this.dgvproduk_produk_id.ReadOnly = true;
            this.dgvproduk_produk_id.Visible = false;
            // 
            // dgvproduk_nama_produk
            // 
            this.dgvproduk_nama_produk.HeaderText = "Nama Produk";
            this.dgvproduk_nama_produk.Name = "dgvproduk_nama_produk";
            this.dgvproduk_nama_produk.ReadOnly = true;
            this.dgvproduk_nama_produk.Width = 300;
            // 
            // dgvproduk_harga
            // 
            this.dgvproduk_harga.HeaderText = "Harga";
            this.dgvproduk_harga.Name = "dgvproduk_harga";
            this.dgvproduk_harga.ReadOnly = true;
            this.dgvproduk_harga.Width = 150;
            // 
            // dgvproduk_qty
            // 
            this.dgvproduk_qty.HeaderText = "Qty";
            this.dgvproduk_qty.Name = "dgvproduk_qty";
            this.dgvproduk_qty.ReadOnly = true;
            this.dgvproduk_qty.Width = 50;
            // 
            // dgvproduk_subtotal
            // 
            this.dgvproduk_subtotal.HeaderText = "Subtotal";
            this.dgvproduk_subtotal.Name = "dgvproduk_subtotal";
            this.dgvproduk_subtotal.ReadOnly = true;
            this.dgvproduk_subtotal.Width = 150;
            // 
            // dgvproduk_btnDelete
            // 
            this.dgvproduk_btnDelete.HeaderText = "Delete";
            this.dgvproduk_btnDelete.Name = "dgvproduk_btnDelete";
            this.dgvproduk_btnDelete.Text = "Delete";
            this.dgvproduk_btnDelete.UseColumnTextForButtonValue = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(984, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Lama";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(952, 563);
            this.dataGridView1.TabIndex = 7;
            // 
            // readstok
            // 
            this.readstok.AutoSize = true;
            this.readstok.Checked = true;
            this.readstok.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readstok.Location = new System.Drawing.Point(687, 26);
            this.readstok.Name = "readstok";
            this.readstok.Size = new System.Drawing.Size(74, 17);
            this.readstok.TabIndex = 7;
            this.readstok.Text = "Baca stok";
            this.readstok.UseVisualStyleBackColor = true;
            // 
            // TransaksiChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 503);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txt_karyawan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveTransaksi);
            this.Controls.Add(this.txt_kasir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "TransaksiChange";
            this.Text = "TransaksiChange";
            this.Load += new System.EventHandler(this.TransaksiChange_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.group_produk.ResumeLayout(false);
            this.group_produk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produk)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_karyawan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveTransaksi;
        private System.Windows.Forms.TextBox txt_kasir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox group_produk;
        private System.Windows.Forms.TextBox qtyProduk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_produks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_produk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_nama_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn dgvproduk_btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox readstok;
    }
}