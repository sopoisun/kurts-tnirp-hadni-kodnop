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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        private MainForm mainForm;

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text != "" && txt_password.Text != "")
            {
                string res = Connection.GetInstance().Login(txt_username.Text, txt_password.Text);

                if (res.Length > 1)
                {
                    MainForm.TOKEN = res; // token from response submited data
                    mainForm = new MainForm();
                    mainForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username dan password tidak\nterdaftar !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Username dan password tidak\nboleh kosong !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.button1_Click(null, null);
            }
        }
    }
}
