using System;
using System.Collections;
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
        private bool _readOnly;

        #region Properties

        MainWindowViewModel ViewModel { get; set; }
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetControlsReadOnly(this, value);
            }
        }

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
        }

        private void DoRequest(object sender, EventArgs e)
        {
            ViewModel.RunTests();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ViewModel.AddNewTest();
            gvTests.DataSource = null;
            gvTests.DataSource = ViewModel.Tests;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ViewModel.DeleteTests();
            gvTests.DataSource = null;
            gvTests.DataSource = ViewModel.Tests;
            gvTests.ClearSelection();
        }

        private void btnLoadPredefined_Click(object sender, EventArgs e)
        {
            ViewModel.LoadPredefinedTests();
            gvTests.DataSource = null;
            gvTests.DataSource = ViewModel.Tests;
        }
        
        private void gvTests_SelectionChanged(object sender, EventArgs e)
        {
            if (gvTests.SelectedRows.Count > 0)
            {
                ViewModel.SelectedTests = gvTests.SelectedRows.Cast<DataGridViewRow>().Select(r => (Test)r.DataBoundItem).ToList();
            }
        }

        private void gvTests_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColRunXTimes_KeyPress);
            e.Control.TextChanged -= new EventHandler(textBox1_TextChanged);

            if (gvTests.CurrentCell.ColumnIndex == colRunXTimes.Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColRunXTimes_KeyPress);
                }
            }
            else if (gvTests.CurrentCell.ColumnIndex == colMainUrl.Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.TextChanged += new EventHandler(textBox1_TextChanged);
                }
            }
        }
        
        private void ColRunXTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (!tb.Text.StartsWith(ConstantNames.textPrefix) && !tb.Text.StartsWith(ConstantNames.textPrefixHTTPS))
            {
                tb.Text = ConstantNames.textPrefix;
                tb.SelectionStart = tb.Text.Length;
            }
        }

        internal void UpdateProgress(string text)
        {
            labelProgres.Visible = true;
            labelProgres.Text = text;
        }

        internal void HideProgressBar()
        {
            labelProgres.Visible = false;
        }

        private void gvTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colParameters.Index)
            {
                ViewModel.OpenParametersWindow((Test)gvTests.CurrentRow.DataBoundItem);
            }
        }

        #endregion

        #region Private Methods

        private void SetControlsReadOnly(System.Windows.Forms.Control Container, bool readOnly)
        {
            try
            {
                foreach (Control ctrl in Container.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                        ((TextBox)ctrl).ReadOnly = readOnly;
                    if (ctrl.GetType() == typeof(ComboBox))
                        ((ComboBox)ctrl).Enabled = !readOnly;
                    if (ctrl.GetType() == typeof(CheckBox))
                        ((CheckBox)ctrl).Enabled = !readOnly;
                    if (ctrl.GetType() == typeof(Button))
                        ((Button)ctrl).Enabled = !readOnly;
                    if (ctrl.GetType() == typeof(DataGridView))
                        ((DataGridView)ctrl).Enabled = !readOnly;

                    if (ctrl.GetType() == typeof(DateTimePicker))
                        ((DateTimePicker)ctrl).Enabled = !readOnly;

                    if (ctrl.Controls.Count > 0)
                        SetControlsReadOnly(ctrl, readOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        internal void RefresGrid()
        {
            gvTests.DataSource = null;
            gvTests.DataSource = ViewModel.Tests;
        }

        #endregion
    }
}
