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
            ViewModel.RunPredefinedTest();
        }

        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
