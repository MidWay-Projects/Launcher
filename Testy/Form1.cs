using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Testy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.SelectedPath = folderBrowserDialog1.SelectedPath;
            label2.Text = folderBrowserDialog1.SelectedPath;
            label2.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Show();
            progressBar1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    new System.Uri("https://raw.githubusercontent.com/Scorbunny10/Gigachader/main/code.js"), folderBrowserDialog1.SelectedPath + "/code.js");
            }
        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                MessageBox.Show("Instalacja zakończona pomyślnie! :D");
            }
        }
    }
}
