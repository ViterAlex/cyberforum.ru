namespace Spiral
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.archRadioButton = new System.Windows.Forms.RadioButton();
            this.hyperbRadioButton = new System.Windows.Forms.RadioButton();
            this.logariphRadioButton = new System.Windows.Forms.RadioButton();
            this.fermatRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(134, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 255);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.archRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.hyperbRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.logariphRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.fermatRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(125, 255);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // archRadioButton
            // 
            this.archRadioButton.AutoSize = true;
            this.archRadioButton.Location = new System.Drawing.Point(3, 3);
            this.archRadioButton.Name = "archRadioButton";
            this.archRadioButton.Size = new System.Drawing.Size(87, 17);
            this.archRadioButton.TabIndex = 0;
            this.archRadioButton.TabStop = true;
            this.archRadioButton.Text = "Архимедова";
            this.archRadioButton.UseVisualStyleBackColor = true;
            this.archRadioButton.CheckedChanged += new System.EventHandler(this.archRadioButton_CheckedChanged);
            // 
            // hyperbRadioButton
            // 
            this.hyperbRadioButton.AutoSize = true;
            this.hyperbRadioButton.Location = new System.Drawing.Point(3, 26);
            this.hyperbRadioButton.Name = "hyperbRadioButton";
            this.hyperbRadioButton.Size = new System.Drawing.Size(114, 17);
            this.hyperbRadioButton.TabIndex = 1;
            this.hyperbRadioButton.TabStop = true;
            this.hyperbRadioButton.Text = "Гиперболическая";
            this.hyperbRadioButton.UseVisualStyleBackColor = true;
            this.hyperbRadioButton.CheckedChanged += new System.EventHandler(this.hyperbRadioButton_CheckedChanged);
            // 
            // logariphRadioButton
            // 
            this.logariphRadioButton.AutoSize = true;
            this.logariphRadioButton.Location = new System.Drawing.Point(3, 49);
            this.logariphRadioButton.Name = "logariphRadioButton";
            this.logariphRadioButton.Size = new System.Drawing.Size(119, 17);
            this.logariphRadioButton.TabIndex = 2;
            this.logariphRadioButton.TabStop = true;
            this.logariphRadioButton.Text = "Логарифмическая";
            this.logariphRadioButton.UseVisualStyleBackColor = true;
            this.logariphRadioButton.CheckedChanged += new System.EventHandler(this.logariphRadioButton_CheckedChanged);
            // 
            // fermatRadioButton
            // 
            this.fermatRadioButton.AutoSize = true;
            this.fermatRadioButton.Location = new System.Drawing.Point(3, 72);
            this.fermatRadioButton.Name = "fermatRadioButton";
            this.fermatRadioButton.Size = new System.Drawing.Size(108, 17);
            this.fermatRadioButton.TabIndex = 3;
            this.fermatRadioButton.TabStop = true;
            this.fermatRadioButton.Text = "Спираль Ферма";
            this.fermatRadioButton.UseVisualStyleBackColor = true;
            this.fermatRadioButton.CheckedChanged += new System.EventHandler(this.fermatRadioButton_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Спирали";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton archRadioButton;
        private System.Windows.Forms.RadioButton hyperbRadioButton;
        private System.Windows.Forms.RadioButton logariphRadioButton;
        private System.Windows.Forms.RadioButton fermatRadioButton;
    }
}

