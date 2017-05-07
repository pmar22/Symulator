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
    public partial class ParametersPostDetails : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _parametersPost;
        public string ParametersPost {
            get
            {
                return _parametersPost;
            }
            set
            {
                _parametersPost = value;
                OnPropertyChanged("ParametersPost");
            }
        }

        private Test _test;
        public ParametersPostDetails(Test test)
        {
            InitializeComponent();
            _test = test;
            ParametersPost = _test.ParametersJSON;
            jsonBox.Text = ParametersPost;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                ParametersPost = textBox.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _test.ParametersJSON = ParametersPost;
        }
    }
}
