namespace CurrencyViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.downloadRatesFileButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.fromNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.toNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fromBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadRatesFileButton
            // 
            this.downloadRatesFileButton.AutoSize = true;
            this.downloadRatesFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downloadRatesFileButton.Location = new System.Drawing.Point(3, 3);
            this.downloadRatesFileButton.Name = "downloadRatesFileButton";
            this.downloadRatesFileButton.Size = new System.Drawing.Size(100, 23);
            this.downloadRatesFileButton.TabIndex = 1;
            this.downloadRatesFileButton.Text = "Обновить курсы";
            this.downloadRatesFileButton.UseVisualStyleBackColor = true;
            this.downloadRatesFileButton.Click += new System.EventHandler(this.downloadRatesFileButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(851, 364);
            this.dataGridView1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.currentDateLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.downloadRatesFileButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 432);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentDateLabel.Location = new System.Drawing.Point(192, 0);
            this.currentDateLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(662, 29);
            this.currentDateLabel.TabIndex = 4;
            this.currentDateLabel.Text = "currentDate";
            this.currentDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(109, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Курс валют за ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.fromNumericUpDown, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.fromComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.toNumericUpDown, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.toComboBox, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 402);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(851, 27);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // fromNumericUpDown
            // 
            this.fromNumericUpDown.DecimalPlaces = 4;
            this.fromNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.fromNumericUpDown.Location = new System.Drawing.Point(3, 3);
            this.fromNumericUpDown.Name = "fromNumericUpDown";
            this.fromNumericUpDown.Size = new System.Drawing.Size(161, 20);
            this.fromNumericUpDown.TabIndex = 0;
            this.fromNumericUpDown.ThousandsSeparator = true;
            this.fromNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.fromNumericUpDown.ValueChanged += new System.EventHandler(this.fromNumericUpDown_ValueChanged);
            // 
            // fromComboBox
            // 
            this.fromComboBox.DataSource = this.fromBindingSource;
            this.fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Location = new System.Drawing.Point(170, 3);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(121, 21);
            this.fromComboBox.TabIndex = 1;
            this.fromComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // toNumericUpDown
            // 
            this.toNumericUpDown.DecimalPlaces = 4;
            this.toNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.toNumericUpDown.Location = new System.Drawing.Point(316, 3);
            this.toNumericUpDown.Name = "toNumericUpDown";
            this.toNumericUpDown.Size = new System.Drawing.Size(161, 20);
            this.toNumericUpDown.TabIndex = 2;
            this.toNumericUpDown.ThousandsSeparator = true;
            this.toNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // toComboBox
            // 
            this.toComboBox.DataSource = this.toBindingSource;
            this.toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Location = new System.Drawing.Point(483, 3);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(121, 21);
            this.toComboBox.TabIndex = 1;
            this.toComboBox.SelectedIndexChanged += new System.EventHandler(this.fromComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(297, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 432);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Курсы валют центрального банка России";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fromNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadRatesFileButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown fromNumericUpDown;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.NumericUpDown toNumericUpDown;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource toBindingSource;
        private System.Windows.Forms.BindingSource fromBindingSource;
    }
}

