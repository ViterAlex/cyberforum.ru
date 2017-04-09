namespace FlowersBouquet
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.aNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lambdaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buildButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(115, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 255);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.aNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.bNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.lambdaNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.buildButton);
            this.flowLayoutPanel1.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 255);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // aNumericUpDown
            // 
            this.aNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aNumericUpDown.Location = new System.Drawing.Point(52, 3);
            this.aNumericUpDown.Name = "aNumericUpDown";
            this.aNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.aNumericUpDown.TabIndex = 0;
            this.aNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // bNumericUpDown
            // 
            this.bNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bNumericUpDown.Location = new System.Drawing.Point(52, 29);
            this.bNumericUpDown.Name = "bNumericUpDown";
            this.bNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.bNumericUpDown.TabIndex = 1;
            this.bNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lambdaNumericUpDown
            // 
            this.lambdaNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lambdaNumericUpDown.Location = new System.Drawing.Point(52, 55);
            this.lambdaNumericUpDown.Name = "lambdaNumericUpDown";
            this.lambdaNumericUpDown.Size = new System.Drawing.Size(51, 20);
            this.lambdaNumericUpDown.TabIndex = 2;
            this.lambdaNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(3, 81);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(75, 23);
            this.buildButton.TabIndex = 1;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 110);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Цветок";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lambdaNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown aNumericUpDown;
        private System.Windows.Forms.NumericUpDown bNumericUpDown;
        private System.Windows.Forms.NumericUpDown lambdaNumericUpDown;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

