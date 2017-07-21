namespace System.Windows.Forms
{
    partial class VoteSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.yesRadioButton = new System.Windows.Forms.RadioButton();
            this.noRadioButton = new System.Windows.Forms.RadioButton();
            this.abstainRadioButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.yesRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.noRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.abstainRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 80);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // yesRadioButton
            // 
            this.yesRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.yesRadioButton.AutoSize = true;
            this.yesRadioButton.Location = new System.Drawing.Point(3, 0);
            this.yesRadioButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.yesRadioButton.Name = "yesRadioButton";
            this.yesRadioButton.Size = new System.Drawing.Size(32, 23);
            this.yesRadioButton.TabIndex = 1;
            this.yesRadioButton.TabStop = true;
            this.yesRadioButton.Text = "Да";
            this.yesRadioButton.UseVisualStyleBackColor = true;
            this.yesRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // noRadioButton
            // 
            this.noRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.noRadioButton.AutoSize = true;
            this.noRadioButton.Location = new System.Drawing.Point(3, 26);
            this.noRadioButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.noRadioButton.Name = "noRadioButton";
            this.noRadioButton.Size = new System.Drawing.Size(36, 23);
            this.noRadioButton.TabIndex = 2;
            this.noRadioButton.TabStop = true;
            this.noRadioButton.Text = "Нет";
            this.noRadioButton.UseVisualStyleBackColor = true;
            this.noRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // abstainRadioButton
            // 
            this.abstainRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.abstainRadioButton.AutoSize = true;
            this.abstainRadioButton.Location = new System.Drawing.Point(3, 52);
            this.abstainRadioButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.abstainRadioButton.Name = "abstainRadioButton";
            this.abstainRadioButton.Size = new System.Drawing.Size(86, 23);
            this.abstainRadioButton.TabIndex = 3;
            this.abstainRadioButton.TabStop = true;
            this.abstainRadioButton.Text = "Воздержался";
            this.abstainRadioButton.UseVisualStyleBackColor = true;
            this.abstainRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // VoteSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "VoteSelector";
            this.Size = new System.Drawing.Size(94, 80);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton yesRadioButton;
        private System.Windows.Forms.RadioButton noRadioButton;
        private System.Windows.Forms.RadioButton abstainRadioButton;
    }
}
