using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Web;
using System.IO;


namespace Михаузэр
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items) // rtb
            {
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
                richTextBox1.AppendText("Заголовок: " + item.Title.Text + Environment.NewLine + Environment.NewLine);

                richTextBox1.SelectionColor = Color.Chocolate;
                richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
                richTextBox1.AppendText("Дата: " + item.PublishDate.ToString("yyyy/MM/dd H:MM:ss") + Environment.NewLine + Environment.NewLine);

                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
                richTextBox1.AppendText("Описание: " + item.Summary.Text + Environment.NewLine);

                richTextBox1.SelectionColor = Color.Green;
                richTextBox1.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
                richTextBox1.AppendText("Ссылка: " + item.Links[0].Uri.ToString()  + Environment.NewLine + Environment.NewLine);

                richTextBox1.AppendText("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" + Environment.NewLine + Environment.NewLine);
            }      
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            webBrowser1.Navigate(e.LinkText);
            webBrowser1.ScriptErrorsSuppressed = true;
        }
    }
}