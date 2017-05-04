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
    public partial class ParametersDetails : Form
    {
        public List<Parameter<string,string>> Parameters { get; set; }

        public ParametersDetails(Dictionary<string,string> parameters)
        {
            InitializeComponent();
            Parameters = parameters.Select(p => new Parameter<string,string>(p.Key, p.Value)).ToList();
            gvParameters.DataSource = Parameters;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvParameters.SelectedRows.Count > 0)
            {
                var selectedRows = gvParameters.SelectedRows.Cast<DataGridViewRow>().Select(r => (Parameter<string,string>)r.DataBoundItem).ToList();
                foreach (var selectedRow in selectedRows)
                {
                    Parameters.Remove(selectedRow);
                }
                gvParameters.DataSource = null;
                gvParameters.DataSource = Parameters;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Parameters.Add(new Parameter<string, string>("", ""));
            gvParameters.DataSource = null;
            gvParameters.DataSource = Parameters;
        }
    }

    public class Parameter<T1, T2>
    {
        public T1 Name { get; set; }
        public T2 Value { get; set; }

        public Parameter(T1 t1, T2 t2)
        {
            Name = t1;
            Value = t2;
        }
    }
}
