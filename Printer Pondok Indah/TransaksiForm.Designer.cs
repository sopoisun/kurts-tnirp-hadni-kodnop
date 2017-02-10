namespace Printer_Pondok_Indah
{
    partial class TransaksiForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgv_produk = new System.Windows.Forms.DataGridView();
            this.dgvproduk_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_produk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_nama_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproduk_btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_kasir = new System.Windows.Forms.TextBox();
            this.group_produk = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.qtyProduk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_produks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.group_place = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_place = new System.Windows.Forms.DataGridView();
            this.dgvplace_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvplace_place_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvplace_nama_tempat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvplace_harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvplace_btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_places = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveTransaksi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_karyawan = new System.Windows.Forms.TextBox();
            this.readstok = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produk)).BeginInit();
            this.group_produk.SuspendLayout();
            this.group_place.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_place)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tanggal";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(113, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
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
            this.dgv_produk.Size = new System.Drawing.Size(918, 266);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kasir";
            // 
            // txt_kasir
            // 
            this.txt_kasir.Location = new System.Drawing.Point(113, 22);
            this.txt_kasir.Name = "txt_kasir";
            this.txt_kasir.ReadOnly = true;
            this.txt_kasir.Size = new System.Drawing.Size(248, 20);
            this.txt_kasir.TabIndex = 4;
            // 
            // group_produk
            // 
            this.group_produk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_produk.Controls.Add(this.readstok);
            this.group_produk.Controls.Add(this.button3);
            this.group_produk.Controls.Add(this.qtyProduk);
            this.group_produk.Controls.Add(this.label5);
            this.group_produk.Controls.Add(this.button1);
            this.group_produk.Controls.Add(this.txt_produks);
            this.group_produk.Controls.Add(this.label3);
            this.group_produk.Controls.Add(this.dgv_produk);
            this.group_produk.Location = new System.Drawing.Point(26, 97);
            this.group_produk.Name = "group_produk";
            this.group_produk.Size = new System.Drawing.Size(954, 340);
            this.group_produk.TabIndex = 5;
            this.group_produk.TabStop = false;
            this.group_produk.Text = "Daftar Produk Yang Dibeli";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(674, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cek Komposisi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // group_place
            // 
            this.group_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_place.Controls.Add(this.button2);
            this.group_place.Controls.Add(this.dgv_place);
            this.group_place.Controls.Add(this.txt_places);
            this.group_place.Controls.Add(this.label4);
            this.group_place.Location = new System.Drawing.Point(26, 443);
            this.group_place.Name = "group_place";
            this.group_place.Size = new System.Drawing.Size(954, 142);
            this.group_place.TabIndex = 6;
            this.group_place.TabStop = false;
            this.group_place.Text = "Daftar Tempat Yang digunakan";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(482, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Simpan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgv_place
            // 
            this.dgv_place.AllowUserToAddRows = false;
            this.dgv_place.AllowUserToDeleteRows = false;
            this.dgv_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_place.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_place.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvplace_no,
            this.dgvplace_place_id,
            this.dgvplace_nama_tempat,
            this.dgvplace_harga,
            this.dgvplace_btnDelete});
            this.dgv_place.Location = new System.Drawing.Point(17, 51);
            this.dgv_place.Name = "dgv_place";
            this.dgv_place.Size = new System.Drawing.Size(918, 73);
            this.dgv_place.TabIndex = 2;
            this.dgv_place.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_place_CellContentClick);
            // 
            // dgvplace_no
            // 
            this.dgvplace_no.HeaderText = "No";
            this.dgvplace_no.Name = "dgvplace_no";
            this.dgvplace_no.ReadOnly = true;
            this.dgvplace_no.Width = 50;
            // 
            // dgvplace_place_id
            // 
            this.dgvplace_place_id.HeaderText = "Place ID";
            this.dgvplace_place_id.Name = "dgvplace_place_id";
            this.dgvplace_place_id.ReadOnly = true;
            this.dgvplace_place_id.Visible = false;
            // 
            // dgvplace_nama_tempat
            // 
            this.dgvplace_nama_tempat.HeaderText = "Nama Tempat";
            this.dgvplace_nama_tempat.Name = "dgvplace_nama_tempat";
            this.dgvplace_nama_tempat.ReadOnly = true;
            this.dgvplace_nama_tempat.Width = 300;
            // 
            // dgvplace_harga
            // 
            this.dgvplace_harga.HeaderText = "Harga";
            this.dgvplace_harga.Name = "dgvplace_harga";
            this.dgvplace_harga.ReadOnly = true;
            this.dgvplace_harga.Width = 150;
            // 
            // dgvplace_btnDelete
            // 
            this.dgvplace_btnDelete.HeaderText = "Hapus";
            this.dgvplace_btnDelete.Name = "dgvplace_btnDelete";
            this.dgvplace_btnDelete.Text = "Hapus";
            this.dgvplace_btnDelete.UseColumnTextForButtonValue = true;
            // 
            // txt_places
            // 
            this.txt_places.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_places.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_places.Location = new System.Drawing.Point(137, 21);
            this.txt_places.Name = "txt_places";
            this.txt_places.Size = new System.Drawing.Size(325, 20);
            this.txt_places.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nama Tempat";
            // 
            // btnSaveTransaksi
            // 
            this.btnSaveTransaksi.Location = new System.Drawing.Point(462, 51);
            this.btnSaveTransaksi.Name = "btnSaveTransaksi";
            this.btnSaveTransaksi.Size = new System.Drawing.Size(148, 22);
            this.btnSaveTransaksi.TabIndex = 7;
            this.btnSaveTransaksi.Text = "Simpan Transaksi";
            this.btnSaveTransaksi.UseVisualStyleBackColor = true;
            this.btnSaveTransaksi.Click += new System.EventHandler(this.btnSaveTransaksi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Waiters";
            // 
            // txt_karyawan
            // 
            this.txt_karyawan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_karyawan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_karyawan.Location = new System.Drawing.Point(462, 22);
            this.txt_karyawan.Name = "txt_karyawan";
            this.txt_karyawan.Size = new System.Drawing.Size(231, 20);
            this.txt_karyawan.TabIndex = 9;
            // 
            // readstok
            // 
            this.readstok.AutoSize = true;
            this.readstok.Checked = true;
            this.readstok.CheckState = System.Windows.Forms.CheckState.Checked;
            this.readstok.Location = new System.Drawing.Point(809, 26);
            this.readstok.Name = "readstok";
            this.readstok.Size = new System.Drawing.Size(74, 17);
            this.readstok.TabIndex = 8;
            this.readstok.Text = "Baca stok";
            this.readstok.UseVisualStyleBackColor = true;
            // 
            // TransaksiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 599);
            this.Controls.Add(this.txt_karyawan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSaveTransaksi);
            this.Controls.Add(this.group_place);
            this.Controls.Add(this.group_produk);
            this.Controls.Add(this.txt_kasir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "TransaksiForm";
            this.Text = "Form Transaksi";
            this.Load += new System.EventHandler(this.TransaksiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produk)).EndInit();
            this.group_produk.ResumeLayout(false);
            this.group_produk.PerformLayout();
            this.group_place.ResumeLayout(false);
            this.group_place.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_place)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgv_produk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_kasir;
        private System.Windows.Forms.GroupBox group_produk;
        private System.Windows.Forms.GroupBox group_place;
        private System.Windows.Forms.DataGridView dgv_place;
        private System.Windows.Forms.TextBox txt_produks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_places;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox qtyProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_produk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_nama_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproduk_subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn dgvproduk_btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvplace_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvplace_place_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvplace_nama_tempat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvplace_harga;
        private System.Windows.Forms.DataGridViewButtonColumn dgvplace_btnDelete;
        private System.Windows.Forms.Button btnSaveTransaksi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_karyawan;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox readstok;
    }
}