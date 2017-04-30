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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bindingSourceViewModel = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudRunXTimes = new System.Windows.Forms.NumericUpDown();
            this.groupBoxPredefinedTests = new System.Windows.Forms.GroupBox();
            this.btnRunPredefinedTest = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.predefinedTestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbShowChart = new System.Windows.Forms.CheckBox();
            this.cbExportToExcel = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunXTimes)).BeginInit();
            this.groupBoxPredefinedTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.predefinedTestsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceViewModel, "Request", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "GET",
            "POST",
            "HEAD"});
            this.listBox1.Location = new System.Drawing.Point(127, 191);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(324, 43);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bindingSourceViewModel
            // 
            this.bindingSourceViewModel.DataSource = typeof(Symulator.MainWindowViewModel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Metoda żądania";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "Url", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(127, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "http://";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adres URL";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "NameParameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(127, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "ValueParameter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(323, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(128, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nazwa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wartość";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(38, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Statystyki";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Czas odpowiedzi: ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Wykonaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DoRequest);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "LastExecutionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label8.Location = new System.Drawing.Point(270, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "0.0 s";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // nudRunXTimes
            // 
            this.nudRunXTimes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceViewModel, "RunXTimes", true));
            this.nudRunXTimes.Location = new System.Drawing.Point(303, 243);
            this.nudRunXTimes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRunXTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRunXTimes.Name = "nudRunXTimes";
            this.nudRunXTimes.Size = new System.Drawing.Size(67, 20);
            this.nudRunXTimes.TabIndex = 13;
            this.nudRunXTimes.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRunXTimes.ValueChanged += new System.EventHandler(this.nudRunXTimes_ValueChanged);
            // 
            // groupBoxPredefinedTests
            // 
            this.groupBoxPredefinedTests.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBoxPredefinedTests.Controls.Add(this.btnRunPredefinedTest);
            this.groupBoxPredefinedTests.Controls.Add(this.comboBox1);
            this.groupBoxPredefinedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBoxPredefinedTests.Location = new System.Drawing.Point(0, 407);
            this.groupBoxPredefinedTests.Name = "groupBoxPredefinedTests";
            this.groupBoxPredefinedTests.Size = new System.Drawing.Size(485, 77);
            this.groupBoxPredefinedTests.TabIndex = 14;
            this.groupBoxPredefinedTests.TabStop = false;
            this.groupBoxPredefinedTests.Text = "Predefiniowane Testy";
            // 
            // btnRunPredefinedTest
            // 
            this.btnRunPredefinedTest.Location = new System.Drawing.Point(377, 36);
            this.btnRunPredefinedTest.Name = "btnRunPredefinedTest";
            this.btnRunPredefinedTest.Size = new System.Drawing.Size(97, 35);
            this.btnRunPredefinedTest.TabIndex = 1;
            this.btnRunPredefinedTest.Text = "Wykonaj";
            this.btnRunPredefinedTest.UseVisualStyleBackColor = true;
            this.btnRunPredefinedTest.Click += new System.EventHandler(this.btnRunPredefinedTest_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceViewModel, "SelectedPredefineTest", true));
            this.comboBox1.DataSource = this.predefinedTestsBindingSource;
            this.comboBox1.DisplayMember = "TestName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(364, 32);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // predefinedTestsBindingSource
            // 
            this.predefinedTestsBindingSource.DataMember = "PredefinedTests";
            this.predefinedTestsBindingSource.DataSource = this.bindingSourceViewModel;
            // 
            // cbShowChart
            // 
            this.cbShowChart.AutoSize = true;
            this.cbShowChart.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceViewModel, "ShowChart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowChart.Location = new System.Drawing.Point(201, 246);
            this.cbShowChart.Name = "cbShowChart";
            this.cbShowChart.Size = new System.Drawing.Size(99, 17);
            this.cbShowChart.TabIndex = 15;
            this.cbShowChart.Text = "Generuj wykres";
            this.cbShowChart.UseVisualStyleBackColor = true;
            this.cbShowChart.CheckedChanged += new System.EventHandler(this.cbShowChart_CheckedChanged);
            // 
            // cbExportToExcel
            // 
            this.cbExportToExcel.AutoSize = true;
            this.cbExportToExcel.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceViewModel, "ExportToExcel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbExportToExcel.Location = new System.Drawing.Point(90, 246);
            this.cbExportToExcel.Name = "cbExportToExcel";
            this.cbExportToExcel.Size = new System.Drawing.Size(105, 17);
            this.cbExportToExcel.TabIndex = 16;
            this.cbExportToExcel.Text = "Export do excela";
            this.cbExportToExcel.UseVisualStyleBackColor = true;
            this.cbExportToExcel.CheckedChanged += new System.EventHandler(this.cbExportToExcel_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(38, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ustawienia";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 484);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbExportToExcel);
            this.Controls.Add(this.cbShowChart);
            this.Controls.Add(this.groupBoxPredefinedTests);
            this.Controls.Add(this.nudRunXTimes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Symulator żądań";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunXTimes)).EndInit();
            this.groupBoxPredefinedTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.predefinedTestsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bindingSourceViewModel;
        private System.Windows.Forms.NumericUpDown nudRunXTimes;
        private System.Windows.Forms.GroupBox groupBoxPredefinedTests;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnRunPredefinedTest;
        private System.Windows.Forms.CheckBox cbShowChart;
        private System.Windows.Forms.CheckBox cbExportToExcel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource predefinedTestsBindingSource;
    }
}

