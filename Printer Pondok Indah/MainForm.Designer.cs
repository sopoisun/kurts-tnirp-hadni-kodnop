namespace Printer_Pondok_Indah
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarTransaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarProdukToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubahPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaksiToolStripMenuItem,
            this.daftarTransaksiToolStripMenuItem,
            this.daftarProdukToolStripMenuItem,
            this.ubahPasswordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(763, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            this.transaksiToolStripMenuItem.Click += new System.EventHandler(this.transaksiToolStripMenuItem_Click);
            // 
            // daftarTransaksiToolStripMenuItem
            // 
            this.daftarTransaksiToolStripMenuItem.Name = "daftarTransaksiToolStripMenuItem";
            this.daftarTransaksiToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.daftarTransaksiToolStripMenuItem.Text = "Daftar Transaksi";
            this.daftarTransaksiToolStripMenuItem.Click += new System.EventHandler(this.daftarTransaksiToolStripMenuItem_Click);
            // 
            // daftarProdukToolStripMenuItem
            // 
            this.daftarProdukToolStripMenuItem.Name = "daftarProdukToolStripMenuItem";
            this.daftarProdukToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.daftarProdukToolStripMenuItem.Text = "Daftar Produk";
            this.daftarProdukToolStripMenuItem.Click += new System.EventHandler(this.daftarProdukToolStripMenuItem_Click);
            // 
            // ubahPasswordToolStripMenuItem
            // 
            this.ubahPasswordToolStripMenuItem.Name = "ubahPasswordToolStripMenuItem";
            this.ubahPasswordToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.ubahPasswordToolStripMenuItem.Text = "Ubah Password";
            this.ubahPasswordToolStripMenuItem.Click += new System.EventHandler(this.ubahPasswordToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 409);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplikasi Kasir Pondok Indah";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarTransaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daftarProdukToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubahPasswordToolStripMenuItem;
    }
}