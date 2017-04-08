namespace CSVtoPARNamespace {
	partial class RowsColumnsSelectForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.UncheckAllLabel = new System.Windows.Forms.Label();
			this.CheckAllLabel = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.EndRowIndexUpDown = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.StartRowIndexUpDown = new System.Windows.Forms.NumericUpDown();
			this.SelectRangeRadioButton = new System.Windows.Forms.RadioButton();
			this.SelectAllRadioButton = new System.Windows.Forms.RadioButton();
			this.ConvertButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.EndRowIndexUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StartRowIndexUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.UncheckAllLabel);
			this.groupBox1.Controls.Add(this.CheckAllLabel);
			this.groupBox1.Controls.Add(this.checkedListBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 216);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Столбцы";
			// 
			// UncheckAllLabel
			// 
			this.UncheckAllLabel.AutoSize = true;
			this.UncheckAllLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UncheckAllLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UncheckAllLabel.ForeColor = System.Drawing.Color.Blue;
			this.UncheckAllLabel.Location = new System.Drawing.Point(115, 200);
			this.UncheckAllLabel.Name = "UncheckAllLabel";
			this.UncheckAllLabel.Size = new System.Drawing.Size(82, 13);
			this.UncheckAllLabel.TabIndex = 2;
			this.UncheckAllLabel.Text = "Снять отметки";
			this.UncheckAllLabel.Click += new System.EventHandler(this.UncheckAllLabel_Click);
			// 
			// CheckAllLabel
			// 
			this.CheckAllLabel.AutoSize = true;
			this.CheckAllLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CheckAllLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CheckAllLabel.ForeColor = System.Drawing.Color.Blue;
			this.CheckAllLabel.Location = new System.Drawing.Point(6, 200);
			this.CheckAllLabel.Name = "CheckAllLabel";
			this.CheckAllLabel.Size = new System.Drawing.Size(77, 13);
			this.CheckAllLabel.TabIndex = 1;
			this.CheckAllLabel.Text = "Отметить всё";
			this.CheckAllLabel.Click += new System.EventHandler(this.CheckAllLabel_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(3, 16);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(194, 184);
			this.checkedListBox1.TabIndex = 0;
			this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.EndRowIndexUpDown);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.StartRowIndexUpDown);
			this.groupBox2.Controls.Add(this.SelectRangeRadioButton);
			this.groupBox2.Controls.Add(this.SelectAllRadioButton);
			this.groupBox2.Location = new System.Drawing.Point(218, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 216);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Строки";
			// 
			// EndRowIndexUpDown
			// 
			this.EndRowIndexUpDown.Location = new System.Drawing.Point(127, 39);
			this.EndRowIndexUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.EndRowIndexUpDown.Name = "EndRowIndexUpDown";
			this.EndRowIndexUpDown.Size = new System.Drawing.Size(52, 20);
			this.EndRowIndexUpDown.TabIndex = 4;
			this.EndRowIndexUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(102, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "по";
			// 
			// StartRowIndexUpDown
			// 
			this.StartRowIndexUpDown.Location = new System.Drawing.Point(44, 39);
			this.StartRowIndexUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StartRowIndexUpDown.Name = "StartRowIndexUpDown";
			this.StartRowIndexUpDown.Size = new System.Drawing.Size(52, 20);
			this.StartRowIndexUpDown.TabIndex = 2;
			this.StartRowIndexUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.StartRowIndexUpDown.ValueChanged += new System.EventHandler(this.StartRowIndexUpDown_ValueChanged);
			// 
			// SelectRangeRadioButton
			// 
			this.SelectRangeRadioButton.AutoSize = true;
			this.SelectRangeRadioButton.Location = new System.Drawing.Point(6, 39);
			this.SelectRangeRadioButton.Name = "SelectRangeRadioButton";
			this.SelectRangeRadioButton.Size = new System.Drawing.Size(32, 17);
			this.SelectRangeRadioButton.TabIndex = 1;
			this.SelectRangeRadioButton.Text = "С";
			this.SelectRangeRadioButton.UseVisualStyleBackColor = true;
			this.SelectRangeRadioButton.CheckedChanged += new System.EventHandler(this.SelectRangeRadioButton_CheckedChanged);
			// 
			// SelectAllRadioButton
			// 
			this.SelectAllRadioButton.AutoSize = true;
			this.SelectAllRadioButton.Checked = true;
			this.SelectAllRadioButton.Location = new System.Drawing.Point(6, 16);
			this.SelectAllRadioButton.Name = "SelectAllRadioButton";
			this.SelectAllRadioButton.Size = new System.Drawing.Size(44, 17);
			this.SelectAllRadioButton.TabIndex = 0;
			this.SelectAllRadioButton.TabStop = true;
			this.SelectAllRadioButton.Text = "Все";
			this.SelectAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// ConvertButton
			// 
			this.ConvertButton.Location = new System.Drawing.Point(162, 234);
			this.ConvertButton.Name = "ConvertButton";
			this.ConvertButton.Size = new System.Drawing.Size(102, 23);
			this.ConvertButton.TabIndex = 2;
			this.ConvertButton.Text = "Конвертировать";
			this.ConvertButton.UseVisualStyleBackColor = true;
			this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
			// 
			// RowsColumnsSelectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 261);
			this.Controls.Add(this.ConvertButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "RowsColumnsSelectForm";
			this.Text = "Выбор строк и столбцов";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.EndRowIndexUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StartRowIndexUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown EndRowIndexUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown StartRowIndexUpDown;
		private System.Windows.Forms.RadioButton SelectRangeRadioButton;
		private System.Windows.Forms.RadioButton SelectAllRadioButton;
		private System.Windows.Forms.Button ConvertButton;
		private System.Windows.Forms.Label UncheckAllLabel;
		private System.Windows.Forms.Label CheckAllLabel;
	}
}