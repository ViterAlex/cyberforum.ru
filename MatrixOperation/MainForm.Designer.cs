namespace MatrixOperation
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.secondMatrixDgv = new System.Windows.Forms.DataGridView();
            this.secondRowsCountNud = new System.Windows.Forms.NumericUpDown();
            this.secondColumnsCountNud = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.firstMatrixDgv = new System.Windows.Forms.DataGridView();
            this.firstRowsCountNud = new System.Windows.Forms.NumericUpDown();
            this.firstColumnsCountNud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sumMatriciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractMatriciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplyMatriciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.resultMatrixDgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondMatrixDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRowsCountNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondColumnsCountNud)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstMatrixDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRowsCountNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstColumnsCountNud)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultMatrixDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(757, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.secondMatrixDgv, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.secondRowsCountNud, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.secondColumnsCountNud, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 192);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(372, 184);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // secondMatrixDgv
            // 
            this.secondMatrixDgv.AllowUserToAddRows = false;
            this.secondMatrixDgv.AllowUserToDeleteRows = false;
            this.secondMatrixDgv.AllowUserToResizeColumns = false;
            this.secondMatrixDgv.AllowUserToResizeRows = false;
            this.secondMatrixDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.secondMatrixDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.secondMatrixDgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.secondMatrixDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.secondMatrixDgv.ColumnHeadersVisible = false;
            this.tableLayoutPanel3.SetColumnSpan(this.secondMatrixDgv, 3);
            this.secondMatrixDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondMatrixDgv.Location = new System.Drawing.Point(3, 29);
            this.secondMatrixDgv.Name = "secondMatrixDgv";
            this.secondMatrixDgv.ReadOnly = true;
            this.secondMatrixDgv.RowHeadersVisible = false;
            this.secondMatrixDgv.Size = new System.Drawing.Size(366, 152);
            this.secondMatrixDgv.TabIndex = 2;
            // 
            // secondRowsCountNud
            // 
            this.secondRowsCountNud.Location = new System.Drawing.Point(3, 3);
            this.secondRowsCountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondRowsCountNud.Name = "secondRowsCountNud";
            this.secondRowsCountNud.Size = new System.Drawing.Size(57, 20);
            this.secondRowsCountNud.TabIndex = 0;
            this.secondRowsCountNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.secondRowsCountNud.ValueChanged += new System.EventHandler(this.secondRowsCountNud_ValueChanged);
            // 
            // secondColumnsCountNud
            // 
            this.secondColumnsCountNud.Location = new System.Drawing.Point(85, 3);
            this.secondColumnsCountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondColumnsCountNud.Name = "secondColumnsCountNud";
            this.secondColumnsCountNud.Size = new System.Drawing.Size(57, 20);
            this.secondColumnsCountNud.TabIndex = 1;
            this.secondColumnsCountNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.secondColumnsCountNud.ValueChanged += new System.EventHandler(this.secondColumnsCountNud_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(66, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "×";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.firstMatrixDgv, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.firstRowsCountNud, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.firstColumnsCountNud, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(372, 183);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // firstMatrixDgv
            // 
            this.firstMatrixDgv.AllowUserToAddRows = false;
            this.firstMatrixDgv.AllowUserToDeleteRows = false;
            this.firstMatrixDgv.AllowUserToResizeColumns = false;
            this.firstMatrixDgv.AllowUserToResizeRows = false;
            this.firstMatrixDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.firstMatrixDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.firstMatrixDgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.firstMatrixDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.firstMatrixDgv.ColumnHeadersVisible = false;
            this.tableLayoutPanel2.SetColumnSpan(this.firstMatrixDgv, 3);
            this.firstMatrixDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstMatrixDgv.Location = new System.Drawing.Point(3, 29);
            this.firstMatrixDgv.Name = "firstMatrixDgv";
            this.firstMatrixDgv.ReadOnly = true;
            this.firstMatrixDgv.RowHeadersVisible = false;
            this.firstMatrixDgv.Size = new System.Drawing.Size(366, 151);
            this.firstMatrixDgv.TabIndex = 2;
            // 
            // firstRowsCountNud
            // 
            this.firstRowsCountNud.Location = new System.Drawing.Point(3, 3);
            this.firstRowsCountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstRowsCountNud.Name = "firstRowsCountNud";
            this.firstRowsCountNud.Size = new System.Drawing.Size(57, 20);
            this.firstRowsCountNud.TabIndex = 0;
            this.firstRowsCountNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.firstRowsCountNud.ValueChanged += new System.EventHandler(this.firstRowsCountNud_ValueChanged);
            // 
            // firstColumnsCountNud
            // 
            this.firstColumnsCountNud.Location = new System.Drawing.Point(85, 3);
            this.firstColumnsCountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstColumnsCountNud.Name = "firstColumnsCountNud";
            this.firstColumnsCountNud.Size = new System.Drawing.Size(57, 20);
            this.firstColumnsCountNud.TabIndex = 1;
            this.firstColumnsCountNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.firstColumnsCountNud.ValueChanged += new System.EventHandler(this.firstColumnsCountNud_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(66, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "×";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sumMatriciesToolStripMenuItem,
            this.subtractMatriciesToolStripMenuItem,
            this.multiplyMatriciesToolStripMenuItem,
            this.minToolStripMenuItem,
            this.maxToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(757, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sumMatriciesToolStripMenuItem
            // 
            this.sumMatriciesToolStripMenuItem.Name = "sumMatriciesToolStripMenuItem";
            this.sumMatriciesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.sumMatriciesToolStripMenuItem.Text = "Сложить";
            this.sumMatriciesToolStripMenuItem.Click += new System.EventHandler(this.sumMatriciesToolStripMenuItem_Click);
            // 
            // subtractMatriciesToolStripMenuItem
            // 
            this.subtractMatriciesToolStripMenuItem.Name = "subtractMatriciesToolStripMenuItem";
            this.subtractMatriciesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.subtractMatriciesToolStripMenuItem.Text = "Вычесть";
            this.subtractMatriciesToolStripMenuItem.Click += new System.EventHandler(this.subtractMatriciesToolStripMenuItem_Click);
            // 
            // multiplyMatriciesToolStripMenuItem
            // 
            this.multiplyMatriciesToolStripMenuItem.Name = "multiplyMatriciesToolStripMenuItem";
            this.multiplyMatriciesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.multiplyMatriciesToolStripMenuItem.Text = "Умножить";
            this.multiplyMatriciesToolStripMenuItem.Click += new System.EventHandler(this.multiplyMatriciesToolStripMenuItem_Click);
            // 
            // minToolStripMenuItem
            // 
            this.minToolStripMenuItem.Name = "minToolStripMenuItem";
            this.minToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.minToolStripMenuItem.Text = "Минимум";
            this.minToolStripMenuItem.Click += new System.EventHandler(this.minToolStripMenuItem_Click);
            // 
            // maxToolStripMenuItem
            // 
            this.maxToolStripMenuItem.Name = "maxToolStripMenuItem";
            this.maxToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.maxToolStripMenuItem.Text = "Максимум";
            this.maxToolStripMenuItem.Click += new System.EventHandler(this.maxToolStripMenuItem_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.resultMatrixDgv, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(381, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(373, 373);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // resultMatrixDgv
            // 
            this.resultMatrixDgv.AllowUserToAddRows = false;
            this.resultMatrixDgv.AllowUserToDeleteRows = false;
            this.resultMatrixDgv.AllowUserToResizeColumns = false;
            this.resultMatrixDgv.AllowUserToResizeRows = false;
            this.resultMatrixDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultMatrixDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.resultMatrixDgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.resultMatrixDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultMatrixDgv.ColumnHeadersVisible = false;
            this.tableLayoutPanel4.SetColumnSpan(this.resultMatrixDgv, 3);
            this.resultMatrixDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultMatrixDgv.Location = new System.Drawing.Point(3, 3);
            this.resultMatrixDgv.Name = "resultMatrixDgv";
            this.resultMatrixDgv.ReadOnly = true;
            this.resultMatrixDgv.RowHeadersVisible = false;
            this.resultMatrixDgv.Size = new System.Drawing.Size(367, 367);
            this.resultMatrixDgv.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 403);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Действия над матрицами";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondMatrixDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondRowsCountNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondColumnsCountNud)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstMatrixDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstRowsCountNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstColumnsCountNud)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultMatrixDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView secondMatrixDgv;
        private System.Windows.Forms.NumericUpDown secondRowsCountNud;
        private System.Windows.Forms.NumericUpDown secondColumnsCountNud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView firstMatrixDgv;
        private System.Windows.Forms.NumericUpDown firstRowsCountNud;
        private System.Windows.Forms.NumericUpDown firstColumnsCountNud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem sumMatriciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractMatriciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplyMatriciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView resultMatrixDgv;
    }
}

