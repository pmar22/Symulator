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
    public partial class MainForm : Form
    {
        #region Properties

        MainWindowViewModel ViewModel { get; set; }

        #endregion

        #region Ctor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Events

        private void OnLoad(object sender, EventArgs e)
        {
            ViewModel = new MainWindowViewModel(this);
            bindingSourceViewModel.DataSource = ViewModel;
            listBox1.SelectedIndex = 0;
            ViewModel.refreshDataFields(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.StartsWith(ConstantNames.textPrefix))
            {
                textBox1.Text = ConstantNames.textPrefix;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void DoRequest(object sender, EventArgs e)
        {
            ViewModel.DoRequest();
        }

        private void btnRunPredefinedTest_Click(object sender, EventArgs e)
        {
            ViewModel.DoRequest();
        }

        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbExportToExcel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbShowChart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nudRunXTimes_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                switch (listBox1.SelectedItem.ToString())
                {
                    case "GET":
                        hidePostProperties();
                        showGetProperties();
                        break;
                    case "POST":
                        hideGetProperties();
                        showPostProperties();
                        break;
                    case "HEAD":
                        hidePostProperties();
                        showGetProperties();
                        break;
                }
            }
        }

        private void hideGetProperties() {
            label3.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
        }
        private void showGetProperties()
        {
            label3.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;
        }
        private void showPostProperties() {
            textBox4.Visible = true;
            label9.Visible = true;
            textBox4.Location = new Point(127, 53);
        }
        private void hidePostProperties()
        {
            textBox4.Visible = false;
            label9.Visible = false;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel.refreshDataFields(comboBox1.SelectedIndex);
        }

        private void bindingSourceViewModel_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void predefinedTestsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
