﻿using System;
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
    }
}
