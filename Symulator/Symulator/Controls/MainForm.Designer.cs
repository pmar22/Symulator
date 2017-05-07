namespace Symulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.bindingSourceViewModel = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxPredefinedTests = new System.Windows.Forms.ComboBox();
            this.predefinedTestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTests = new System.Windows.Forms.DataGridView();
            this.colTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunXTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMainUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameters = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoadPredefined = new System.Windows.Forms.Button();
            this.cbExportToExcel = new System.Windows.Forms.CheckBox();
            this.cbShowChart = new System.Windows.Forms.CheckBox();
            this.labelProgres = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predefinedTestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunTests
            // 
            this.btnRunTests.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "CanRunTests", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnRunTests.Location = new System.Drawing.Point(863, 402);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(75, 23);
            this.btnRunTests.TabIndex = 11;
            this.btnRunTests.Text = "Wykonaj";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.DoRequest);
            // 
            // bindingSourceViewModel
            // 
            this.bindingSourceViewModel.DataSource = typeof(Symulator.MainWindowViewModel);
            // 
            // comboBoxPredefinedTests
            // 
            this.comboBoxPredefinedTests.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceViewModel, "SelectedPredefinedTest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxPredefinedTests.DataSource = this.predefinedTestsBindingSource;
            this.comboBoxPredefinedTests.DisplayMember = "TestName";
            this.comboBoxPredefinedTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPredefinedTests.FormattingEnabled = true;
            this.comboBoxPredefinedTests.Location = new System.Drawing.Point(493, 4);
            this.comboBoxPredefinedTests.Name = "comboBoxPredefinedTests";
            this.comboBoxPredefinedTests.Size = new System.Drawing.Size(364, 21);
            this.comboBoxPredefinedTests.TabIndex = 0;
            // 
            // predefinedTestsBindingSource
            // 
            this.predefinedTestsBindingSource.DataMember = "PredefinedTests";
            this.predefinedTestsBindingSource.DataSource = this.bindingSourceViewModel;
            // 
            // testsBindingSource
            // 
            this.testsBindingSource.DataMember = "Tests";
            this.testsBindingSource.DataSource = this.bindingSourceViewModel;
            // 
            // gvTests
            // 
            this.gvTests.AllowUserToAddRows = false;
            this.gvTests.AllowUserToDeleteRows = false;
            this.gvTests.AutoGenerateColumns = false;
            this.gvTests.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTestName,
            this.colRunXTimes,
            this.colMethod,
            this.colMainUrl,
            this.colParameters});
            this.gvTests.DataSource = this.testsBindingSource;
            this.gvTests.Location = new System.Drawing.Point(0, 33);
            this.gvTests.Name = "gvTests";
            this.gvTests.Size = new System.Drawing.Size(950, 331);
            this.gvTests.TabIndex = 18;
            this.gvTests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTests_CellContentClick);
            this.gvTests.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvTests_EditingControlShowing);
            this.gvTests.SelectionChanged += new System.EventHandler(this.gvTests_SelectionChanged);
            // 
            // colTestName
            // 
            this.colTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTestName.DataPropertyName = "TestName";
            this.colTestName.HeaderText = "Nazwa Testu";
            this.colTestName.MinimumWidth = 150;
            this.colTestName.Name = "colTestName";
            this.colTestName.Width = 150;
            // 
            // colRunXTimes
            // 
            this.colRunXTimes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRunXTimes.DataPropertyName = "RunXTimes";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.colRunXTimes.DefaultCellStyle = dataGridViewCellStyle1;
            this.colRunXTimes.HeaderText = "Ilość powtórzeń";
            this.colRunXTimes.MinimumWidth = 50;
            this.colRunXTimes.Name = "colRunXTimes";
            this.colRunXTimes.Width = 97;
            // 
            // colMethod
            // 
            this.colMethod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMethod.DataPropertyName = "Method";
            this.colMethod.HeaderText = "Metoda";
            this.colMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "POST(JSON)",
            "HEAD"});
            this.colMethod.Name = "colMethod";
            this.colMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMethod.Width = 68;
            // 
            // colMainUrl
            // 
            this.colMainUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMainUrl.DataPropertyName = "MainUrl";
            this.colMainUrl.HeaderText = "Adres";
            this.colMainUrl.MinimumWidth = 200;
            this.colMainUrl.Name = "colMainUrl";
            this.colMainUrl.Width = 200;
            // 
            // colParameters
            // 
            this.colParameters.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colParameters.DataPropertyName = "ParametersString";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colParameters.DefaultCellStyle = dataGridViewCellStyle2;
            this.colParameters.HeaderText = "Parametry";
            this.colParameters.Name = "colParameters";
            this.colParameters.ReadOnly = true;
            this.colParameters.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colParameters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(94, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Usuń";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoadPredefined
            // 
            this.btnLoadPredefined.Location = new System.Drawing.Point(863, 4);
            this.btnLoadPredefined.Name = "btnLoadPredefined";
            this.btnLoadPredefined.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPredefined.TabIndex = 22;
            this.btnLoadPredefined.Text = "Wczytaj";
            this.btnLoadPredefined.UseVisualStyleBackColor = true;
            this.btnLoadPredefined.Click += new System.EventHandler(this.btnLoadPredefined_Click);
            // 
            // cbExportToExcel
            // 
            this.cbExportToExcel.AutoSize = true;
            this.cbExportToExcel.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceViewModel, "ExportToExcel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbExportToExcel.Location = new System.Drawing.Point(647, 406);
            this.cbExportToExcel.Name = "cbExportToExcel";
            this.cbExportToExcel.Size = new System.Drawing.Size(105, 17);
            this.cbExportToExcel.TabIndex = 16;
            this.cbExportToExcel.Text = "Export do excela";
            this.cbExportToExcel.UseVisualStyleBackColor = true;
            // 
            // cbShowChart
            // 
            this.cbShowChart.AutoSize = true;
            this.cbShowChart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceViewModel, "ShowChart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowChart.Location = new System.Drawing.Point(758, 406);
            this.cbShowChart.Name = "cbShowChart";
            this.cbShowChart.Size = new System.Drawing.Size(99, 17);
            this.cbShowChart.TabIndex = 15;
            this.cbShowChart.Text = "Generuj wykres";
            this.cbShowChart.UseVisualStyleBackColor = true;
            // 
            // labelProgres
            // 
            this.labelProgres.AutoSize = true;
            this.labelProgres.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.labelProgres.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelProgres.ForeColor = System.Drawing.SystemColors.Control;
            this.labelProgres.Location = new System.Drawing.Point(0, 96);
            this.labelProgres.MinimumSize = new System.Drawing.Size(950, 200);
            this.labelProgres.Name = "labelProgres";
            this.labelProgres.Size = new System.Drawing.Size(950, 200);
            this.labelProgres.TabIndex = 23;
            this.labelProgres.Text = "Progress";
            this.labelProgres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelProgres.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 431);
            this.Controls.Add(this.labelProgres);
            this.Controls.Add(this.btnLoadPredefined);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.comboBoxPredefinedTests);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvTests);
            this.Controls.Add(this.cbExportToExcel);
            this.Controls.Add(this.cbShowChart);
            this.Controls.Add(this.btnRunTests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Symulator żądań";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predefinedTestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.BindingSource bindingSourceViewModel;
        private System.Windows.Forms.ComboBox comboBoxPredefinedTests;
        private System.Windows.Forms.BindingSource testsBindingSource;
        private System.Windows.Forms.DataGridView gvTests;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadPredefined;
        private System.Windows.Forms.CheckBox cbExportToExcel;
        private System.Windows.Forms.CheckBox cbShowChart;
        private System.Windows.Forms.BindingSource predefinedTestsBindingSource;
        private System.Windows.Forms.Label labelProgres;
        private System.Windows.Forms.DataGridViewButtonColumn colParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMainUrl;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunXTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestName;
    }
}

