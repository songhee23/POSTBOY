﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSTBOY
{
    public partial class POSTBOY : Form
    {
        public POSTBOY()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            this.Size = new Size(982, 763);
        }


        

        public string SEND_REQUEST()
        {
            string responseText = "";
            try
            {
                string url = TB_URL.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = comboBox1.Text;
                request.Timeout = 1000 * 10;    //10초

                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    HttpStatusCode status = resp.StatusCode;
                    Console.WriteLine(status);  // 정상이면 "OK"

                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        responseText = sr.ReadToEnd();
                    }
                }

                Console.WriteLine(responseText);
                return responseText;
            }
            catch(Exception ex)
            {
                return responseText;
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            TB_RESULT.Text = SEND_REQUEST();
        }

        private void POSTBOY_SizeChanged(object sender, EventArgs e)
        {
            int a = this.Size.Width;
            int b = this.Size.Height;
            int c = a * b;
            //TB_RESULT.Size = new Size(Convert.ToInt32(this.Size.Width * 0.9), Convert.ToInt32(this.Size.Height * 0.55));
            TB_RESULT.Size = new Size(Convert.ToInt32(this.Size.Width -50), Convert.ToInt32(this.Size.Height - 300));
        }
    }
}
