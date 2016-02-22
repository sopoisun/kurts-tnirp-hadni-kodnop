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
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.group_produk = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_produks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.group_place = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_place = new System.Windows.Forms.DataGridView();
            this.txt_places = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.qtyProduk = new System.Windows.Forms.TextBox();
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
            this.no,
            this.produk_id,
            this.nama_produk,
            this.harga,
            this.qty,
            this.subtotal,
            this.btnDelete});
            this.dgv_produk.Location = new System.Drawing.Point(17, 55);
            this.dgv_produk.Name = "dgv_produk";
            this.dgv_produk.Size = new System.Drawing.Size(758, 266);
            this.dgv_produk.TabIndex = 2;
            // 
            // no
            // 
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 50;
            // 
            // produk_id
            // 
            this.produk_id.HeaderText = "Produk ID";
            this.produk_id.Name = "produk_id";
            this.produk_id.Visible = false;
            // 
            // nama_produk
            // 
            this.nama_produk.HeaderText = "Nama Produk";
            this.nama_produk.Name = "nama_produk";
            this.nama_produk.Width = 300;
            // 
            // harga
            // 
            this.harga.HeaderText = "Harga";
            this.harga.Name = "harga";
            this.harga.ReadOnly = true;
            this.harga.Width = 150;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.Width = 50;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Width = 150;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Action";
            this.btnDelete.Name = "btnDelete";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 4;
            // 
            // group_produk
            // 
            this.group_produk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_produk.Controls.Add(this.qtyProduk);
            this.group_produk.Controls.Add(this.label5);
            this.group_produk.Controls.Add(this.button1);
            this.group_produk.Controls.Add(this.txt_produks);
            this.group_produk.Controls.Add(this.label3);
            this.group_produk.Controls.Add(this.dgv_produk);
            this.group_produk.Location = new System.Drawing.Point(26, 97);
            this.group_produk.Name = "group_produk";
            this.group_produk.Size = new System.Drawing.Size(794, 340);
            this.group_produk.TabIndex = 5;
            this.group_produk.TabStop = false;
            this.group_produk.Text = "Daftar Produk Yang Dibeli";
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
            this.txt_produks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_produks_KeyPress);
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
            this.group_place.Size = new System.Drawing.Size(794, 142);
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
            // 
            // dgv_place
            // 
            this.dgv_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_place.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_place.Location = new System.Drawing.Point(17, 51);
            this.dgv_place.Name = "dgv_place";
            this.dgv_place.Size = new System.Drawing.Size(758, 73);
            this.dgv_place.TabIndex = 2;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Qty";
            // 
            // qtyProduk
            // 
            this.qtyProduk.Location = new System.Drawing.Point(509, 24);
            this.qtyProduk.Name = "qtyProduk";
            this.qtyProduk.Size = new System.Drawing.Size(58, 20);
            this.qtyProduk.TabIndex = 5;
            // 
            // TransaksiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 599);
            this.Controls.Add(this.group_place);
            this.Controls.Add(this.group_produk);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox group_produk;
        private System.Windows.Forms.GroupBox group_place;
        private System.Windows.Forms.DataGridView dgv_place;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn produk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_produk;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.TextBox txt_produks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_places;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox qtyProduk;
    }
}