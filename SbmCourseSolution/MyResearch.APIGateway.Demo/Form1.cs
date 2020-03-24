﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyResearch.APIGateway.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyApplication.APIHost\bin\Debug\netcoreapp3.1\MyApplication.APIHost.exe", "http://localhost:9001;https://localhost:10001");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MyApplication.APIHost\bin\Debug\netcoreapp3.1\MyApplication.APIHost.exe", "http://localhost:9002;https://localhost:10002");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.File.Copy(Environment.CurrentDirectory + @"\..\..\..\MySoftwareCompany.APIGateway.Host\ocelot.json", Environment.CurrentDirectory + @"\ocelot.json", true);
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"\..\..\..\MySoftwareCompany.APIGateway.Host\bin\Debug\netcoreapp3.1\MySoftwareCompany.APIGateway.Host.exe");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 500; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(@"https://localhost:10000/gateway/ping");
                    var json = await response.Content.ReadAsStringAsync();
                    label1.Text = i.ToString() + " " + json;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label8.Text = "docker run -p 8500:8500 consul";
            label1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:8500");
        }
    }
}
