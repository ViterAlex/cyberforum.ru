namespace AlarmClockNamespace {
	partial class MainForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.HSetButton = new System.Windows.Forms.Button();
			this.MSetButton = new System.Windows.Forms.Button();
			this.AlarmButton = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(284, 43);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// HSetButton
			// 
			this.HSetButton.AutoSize = true;
			this.HSetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.HSetButton.Location = new System.Drawing.Point(7, 46);
			this.HSetButton.Name = "HSetButton";
			this.HSetButton.Size = new System.Drawing.Size(25, 23);
			this.HSetButton.TabIndex = 1;
			this.HSetButton.Text = "H";
			this.HSetButton.UseVisualStyleBackColor = true;
			this.HSetButton.Click += new System.EventHandler(this.HSetButton_Click);
			// 
			// MSetButton
			// 
			this.MSetButton.AutoSize = true;
			this.MSetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.MSetButton.Location = new System.Drawing.Point(38, 46);
			this.MSetButton.Name = "MSetButton";
			this.MSetButton.Size = new System.Drawing.Size(26, 23);
			this.MSetButton.TabIndex = 3;
			this.MSetButton.Text = "M";
			this.MSetButton.UseVisualStyleBackColor = true;
			this.MSetButton.Click += new System.EventHandler(this.MSetButton_Click);
			// 
			// AlarmButton
			// 
			this.AlarmButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.AlarmButton.AutoSize = true;
			this.AlarmButton.Location = new System.Drawing.Point(70, 46);
			this.AlarmButton.Name = "AlarmButton";
			this.AlarmButton.Size = new System.Drawing.Size(24, 23);
			this.AlarmButton.TabIndex = 4;
			this.AlarmButton.Text = "A";
			this.AlarmButton.UseVisualStyleBackColor = true;
			this.AlarmButton.CheckedChanged += new System.EventHandler(this.AlarmButton_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 82);
			this.Controls.Add(this.AlarmButton);
			this.Controls.Add(this.MSetButton);
			this.Controls.Add(this.HSetButton);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Будильник";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button HSetButton;
		private System.Windows.Forms.Button MSetButton;
		private System.Windows.Forms.CheckBox AlarmButton;
	}
}

