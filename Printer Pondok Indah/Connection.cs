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

        private int HttpPost(string uri, NameValueCollection data)
        {
            try
            {
                webClient = new WebClient();
                responsetBytes = webClient.UploadValues(uri, "POST", data);
                resultString = Encoding.UTF8.GetString(responsetBytes);
                webClient.Dispose();
                return int.Parse(resultString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
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

        public DataTable GetTransaksi(string tanggal)
        {
            DataSet ds = this.HttpGet(this.url + "transaksi?tanggal="+tanggal);
            return ds.Tables[0];
            return null;
        }

        public DataTable GetDetail(string id)
        {
            DataSet ds = this.HttpGet(this.url + "transaksi/detail?id=" + id);
            return ds.Tables[0];
        }

        public JObject GetBayar(string id)
        {
            return this.HttpGetSingle(this.url + "transaksi/bayar?id=" + id);
        }

        public JObject GetSetting()
        {
            return this.HttpGetSingle(this.url + "setting");
        }

    }
}
