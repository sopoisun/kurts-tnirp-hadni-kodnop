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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txt_nama_karyawan.Text = MainForm.USER["nama_karyawan"].ToString();
            txt_username.Text = MainForm.USER["username"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_old_password.Text != "" && txt_password.Text != "" && txt_password_conf.Text != "")
                {
                    if (txt_password.Text == txt_password_conf.Text)
                    {
                        int res = int.Parse(Connection.GetInstance().ChangePassword(txt_old_password.Text, txt_password.Text));

                        if (res < 2)
                        {
                            if (res == 1)
                            {
                                MessageBox.Show("Password lama tidak sesuai !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Terjadi Kesalahan !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ubah password sukses !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        txt_old_password.Clear();
                        txt_password.Clear();
                        txt_password_conf.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Password baru dan password konfirmasi\ntidak sama !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
