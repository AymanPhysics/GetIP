using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        bool idDoing = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (idDoing) return;
            idDoing = true;
            //MessageBox.Show(Read("https://1drv.ms/t/s!AkKV4fLzhk2CvoU4ZdbWXP0E3j-TiA?e=UREGHr"));

            String s = Read1();
            if (s=="")s= Read2();
            if (s=="")s= Read3();
            if (s=="")s= Read4();
            if (s =="")s= Read5();

            textBox1.Text = s;

            StreamWriter st = new StreamWriter("ip.txt");
            st.WriteLine(s);
            st.Flush();
            st.Close();
            st.Dispose();
            idDoing = false;
        }

         
        String Read(String url)
        {
            try {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //return new StreamReader(response.GetResponseStream()).ReadToEnd();
                return new System.Net.WebClient().DownloadString(url);
            }
            catch (Exception ex) { 
            }
            return "";
        }

        String Read1()
        {
            return Read("http://icanhazip.com/");
        }

        String Read2()
        {
            return Read("http://checkip.dyndns.org/").Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "").Replace("</body></html>", "");
        }

        String Read3()
        {
            return Read("http://bot.whatismyipaddress.com/");
        }
        String Read4()
        {
            return Read("http://ipinfo.io/ip");
        }
        String Read5()
        {
            return Read("https://api.ipify.org");
        }
    }
}
