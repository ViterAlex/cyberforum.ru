namespace ColorUITypeEditor
{
    partial class ColorEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorEditor));
            this.colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.prevColorPanel = new System.Windows.Forms.Panel();
            this.currColorPanel = new System.Windows.Forms.Panel();
            this.screenColorPicker1 = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorWheel1
            // 
            this.colorWheel1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorWheel1.Location = new System.Drawing.Point(0, 0);
            this.colorWheel1.Name = "colorWheel1";
            this.colorWheel1.Size = new System.Drawing.Size(247, 247);
            this.colorWheel1.TabIndex = 0;
            // 
            // colorEditor1
            // 
            this.colorEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorEditor1.Location = new System.Drawing.Point(256, 3);
            this.colorEditor1.Name = "colorEditor1";
            this.tableLayoutPanel1.SetRowSpan(this.colorEditor1, 2);
            this.colorEditor1.Size = new System.Drawing.Size(200, 326);
            this.colorEditor1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.colorEditor1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 332);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.prevColorPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.currColorPanel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 256);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(247, 26);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // prevColorPanel
            // 
            this.prevColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevColorPanel.Location = new System.Drawing.Point(3, 3);
            this.prevColorPanel.Name = "prevColorPanel";
            this.prevColorPanel.Size = new System.Drawing.Size(117, 20);
            this.prevColorPanel.TabIndex = 0;
            // 
            // currColorPanel
            // 
            this.currColorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currColorPanel.Location = new System.Drawing.Point(126, 3);
            this.currColorPanel.Name = "currColorPanel";
            this.currColorPanel.Size = new System.Drawing.Size(118, 20);
            this.currColorPanel.TabIndex = 1;
            // 
            // screenColorPicker1
            // 
            this.screenColorPicker1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("screenColorPicker1.BackgroundImage")));
            this.screenColorPicker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.screenColorPicker1.Color = System.Drawing.Color.Black;
            this.screenColorPicker1.Location = new System.Drawing.Point(212, 3);
            this.screenColorPicker1.Name = "screenColorPicker1";
            this.screenColorPicker1.Size = new System.Drawing.Size(32, 32);
            // 
            // colorEditorManager1
            // 
            this.colorEditorManager1.ColorEditor = this.colorEditor1;
            this.colorEditorManager1.ColorWheel = this.colorWheel1;
            this.colorEditorManager1.ScreenColorPicker = this.screenColorPicker1;
            this.colorEditorManager1.ColorChanged += new System.EventHandler(this.colorEditorManager1_ColorChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.screenColorPicker1);
            this.panel1.Controls.Add(this.colorWheel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 247);
            this.panel1.TabIndex = 5;
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorEditor";
            this.Size = new System.Drawing.Size(459, 332);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel prevColorPanel;
        private System.Windows.Forms.Panel currColorPanel;
        private System.Windows.Forms.Panel panel1;
    }
}
