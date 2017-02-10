using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Printer_Pondok_Indah
{
    class Connection
    {
        public Connection()
        {

        }

        /* using singleton pattern*/
        public static Connection koneksi = null;
        public static Connection GetInstance()
        {
            if (koneksi == null)
            {
                koneksi = new Connection();
            }
            return koneksi;
        }
        /*end singleton*/
        private WebClient webClient;
        private byte[] responsetBytes;
        private string resultString;
        private DataSet ds = new DataSet();
        private NameValueCollection data = new NameValueCollection();
        private string url = "http://localhost/restoran/public/api/";

        private string HttpPost(string uri, NameValueCollection data)
        {
            try
            {
                webClient = new WebClient();
                responsetBytes = webClient.UploadValues(uri, "POST", data);
                resultString = Encoding.UTF8.GetString(responsetBytes);
                webClient.Dispose();
                return resultString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private DataSet HttpGet(string uri)
        {
            try
            {
                webClient = new WebClient();
                var data = webClient.DownloadString(uri);
                return JsonConvert.DeserializeObject<DataSet>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private JObject HttpGetSingle(string uri)
        {
            try
            {
                webClient = new WebClient();
                var data = webClient.DownloadString(uri);
                return JObject.Parse(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private string HttpGetOriginal(string uri)
        {
            try
            {
                webClient = new WebClient();
                responsetBytes = webClient.DownloadData(uri);
                resultString = Encoding.UTF8.GetString(responsetBytes);
                webClient.Dispose();
                return resultString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public string Login(string username, string password)
        {
            this.data = new NameValueCollection();
            this.data["username"] = username;
            this.data["password"] = password;

            return this.HttpPost(this.url + "login", data);
        }

        public DataTable GetTransaksi(string tanggal)
        {
            DataSet ds = this.HttpGet(this.url + "transaksi?api_token="+MainForm.TOKEN+"&tanggal="+tanggal);
            return ds.Tables[0];
        }

        public DataTable GetDetail(string id)
        {
            DataSet ds = this.HttpGet(this.url + "transaksi/detail?api_token=" + MainForm.TOKEN + "&id=" + id);
            return ds.Tables[0];
        }

        public JObject GetBayar(string id)
        {
            return this.HttpGetSingle(this.url + "transaksi/bayar?api_token=" + MainForm.TOKEN + "&id=" + id);
        }

        public JObject GetSetting()
        {
            return this.HttpGetSingle(this.url + "setting?api_token=" + MainForm.TOKEN);
        }

        public JObject GetUser()
        {
            return this.HttpGetSingle(this.url + "user?api_token=" + MainForm.TOKEN);
        }

        public DataTable GetKaryawan()
        {
            DataSet ds = this.HttpGet(this.url + "karyawan?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetTax()
        {
            DataSet ds = this.HttpGet(this.url + "tax?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetBank()
        {
            DataSet ds = this.HttpGet(this.url + "bank?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetBankTax()
        {
            DataSet ds = this.HttpGet(this.url + "bank/tax?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetCustomer()
        {
            DataSet ds = this.HttpGet(this.url + "customer?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetProduk()
        {
            DataSet ds = this.HttpGet(this.url + "produk?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetPlace()
        {
            DataSet ds = this.HttpGet(this.url + "place?api_token=" + MainForm.TOKEN);
            return ds.Tables[0];
        }

        public DataTable GetProdukComposition(string id, int qty)
        {
            DataSet ds = this.HttpGet(this.url + "produk/composite?api_token=" + MainForm.TOKEN + "&id=" + id+"&qty=" + qty);
            return ds.Tables[0];
        }

        public int CheckStok(string produk_id, int qty)
        {
            string str = this.HttpGetOriginal(this.url + "produk/stok?api_token=" + MainForm.TOKEN + "&id=" + produk_id + "&qty=" + qty);
            return int.Parse(str);
        }

        public string OpenTransaksi(string tanggal, string data_order, string karyawan_id, string places)
        {
            this.data = new NameValueCollection();
            this.data["tanggal"]        = tanggal;
            this.data["data_order"]     = data_order;
            this.data["karyawan_id"]    = karyawan_id;
            this.data["places"]         = places;

            return this.HttpPost(this.url + "transaksi/save?api_token=" + MainForm.TOKEN, data);
        }

        public string OpenTransaksi(string tanggal, string data_order, string karyawan_id, string places, int readstok)
        {
            this.data = new NameValueCollection();
            this.data["tanggal"] = tanggal;
            this.data["data_order"] = data_order;
            this.data["karyawan_id"] = karyawan_id;
            this.data["places"] = places;
            this.data["readstok"] = "yes";

            return this.HttpPost(this.url + "transaksi/save?api_token=" + MainForm.TOKEN, data);
        }

        public string ChangeTransaksi(string orderID, string data_order)
        {
            this.data = new NameValueCollection();
            this.data["id"] = orderID;
            this.data["data_order"] = data_order;

            return this.HttpPost(this.url + "transaksi/change?api_token=" + MainForm.TOKEN, data);
        }

        public string ChangeTransaksi(string orderID, string data_order, int readstok)
        {
            this.data = new NameValueCollection();
            this.data["id"] = orderID;
            this.data["data_order"] = data_order;
            this.data["readstok"] = "yes";

            return this.HttpPost(this.url + "transaksi/change?api_token=" + MainForm.TOKEN, data);
        }

        public string CloseTransaksi(string orderID, string service_cost, string tax_id, string tax_procentage, string diskon, string bayar, string type_bayar,
            string bank_id, string tax_bayar_procentage, string customer_id)
        {
            this.data = new NameValueCollection();
            this.data["id"] = orderID;
            this.data["service_cost"] = service_cost;
            this.data["tax_id"] = tax_id;
            this.data["tax_procentage"] = tax_procentage;
            this.data["diskon"] = diskon;
            this.data["bayar"] = bayar;
            this.data["type_bayar"] = type_bayar;
            this.data["bank_id"] = bank_id;
            this.data["tax_bayar_procentage"] = tax_bayar_procentage;
            this.data["customer_id"] = customer_id;

            return this.HttpPost(this.url + "transaksi/close?api_token=" + MainForm.TOKEN, data);
        }

        public string ChangePassword(string oldPassword, string newPassword)
        {
            this.data = new NameValueCollection();
            this.data["old_password"] = oldPassword;
            this.data["password"] = newPassword;

            return this.HttpPost(this.url + "user/change-password?api_token=" + MainForm.TOKEN, data);
        }
    }
}
