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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.group_produk = new System.Windows.Forms.GroupBox();
            this.group_place = new System.Windows.Forms.GroupBox();
            this.dgv_place = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_produk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.dgv_produk.Location = new System.Drawing.Point(17, 23);
            this.dgv_produk.Name = "dgv_produk";
            this.dgv_produk.Size = new System.Drawing.Size(758, 343);
            this.dgv_produk.TabIndex = 2;
            this.dgv_produk.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_produk_CellValueChanged);
            this.dgv_produk.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_produk_RowsAdded);
            this.dgv_produk.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_produk_EditingControlShowing);
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
            this.group_produk.Controls.Add(this.dgv_produk);
            this.group_produk.Location = new System.Drawing.Point(26, 97);
            this.group_produk.Name = "group_produk";
            this.group_produk.Size = new System.Drawing.Size(794, 385);
            this.group_produk.TabIndex = 5;
            this.group_produk.TabStop = false;
            this.group_produk.Text = "Daftar Produk Yang Dibeli";
            // 
            // group_place
            // 
            this.group_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_place.Controls.Add(this.dgv_place);
            this.group_place.Location = new System.Drawing.Point(26, 488);
            this.group_place.Name = "group_place";
            this.group_place.Size = new System.Drawing.Size(794, 97);
            this.group_place.TabIndex = 6;
            this.group_place.TabStop = false;
            this.group_place.Text = "Daftar Tempat Yang digunakan";
            // 
            // dgv_place
            // 
            this.dgv_place.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_place.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_place.Location = new System.Drawing.Point(17, 23);
            this.dgv_place.Name = "dgv_place";
            this.dgv_place.Size = new System.Drawing.Size(758, 56);
            this.dgv_place.TabIndex = 2;
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
            this.group_place.ResumeLayout(false);
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
    }
}