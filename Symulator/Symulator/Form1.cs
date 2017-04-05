using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symulator
{
    public partial class Form1 : Form
    {
        private const String textPrefix = "http://";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.StartsWith(textPrefix))
            {
                textBox1.Text = textPrefix;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String addressHTTP = textBox1.Text;
            String requestType = listBox1.SelectedItem.ToString();
            Console.WriteLine("SELECTED METHOD: " + listBox1.SelectedItem.ToString());
            RequestInterface request = createProperRequestObject(requestType, addressHTTP);
            String nameParameter1 = textBox2.Text;
            String valueParameter1 = textBox3.Text;
            request.SetParameters(nameParameter1, valueParameter1);
            request.Execute();
            updateStatistics(request);

        }

        private void updateStatistics(RequestInterface request)
        {
            label8.Text = request.GetTimeExecution() + " s";
        }

        private RequestInterface createProperRequestObject(String requestType, String addressHTTP) {
            switch (requestType) {
                case "GET": return new GetRequest(addressHTTP);
                case "POST": return new PostRequest(addressHTTP);
                case "HEAD": return new GetRequest(addressHTTP);
                default: return null; 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
