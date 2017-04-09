<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.N_NUD = New System.Windows.Forms.NumericUpDown()
        Me.M_NUD = New System.Windows.Forms.NumericUpDown()
        Me.R_NUD = New System.Windows.Forms.NumericUpDown()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BuildUpButton = New System.Windows.Forms.Button()
        CType(Me.N_NUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.M_NUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.R_NUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'N_NUD
        '
        Me.N_NUD.Location = New System.Drawing.Point(40, 12)
        Me.N_NUD.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.N_NUD.Name = "N_NUD"
        Me.N_NUD.Size = New System.Drawing.Size(45, 22)
        Me.N_NUD.TabIndex = 0
        Me.N_NUD.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'M_NUD
        '
        Me.M_NUD.Location = New System.Drawing.Point(40, 40)
        Me.M_NUD.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.M_NUD.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.M_NUD.Name = "M_NUD"
        Me.M_NUD.Size = New System.Drawing.Size(45, 22)
        Me.M_NUD.TabIndex = 1
        Me.M_NUD.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'R_NUD
        '
        Me.R_NUD.Location = New System.Drawing.Point(40, 68)
        Me.R_NUD.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.R_NUD.Name = "R_NUD"
        Me.R_NUD.Size = New System.Drawing.Size(75, 22)
        Me.R_NUD.TabIndex = 2
        Me.R_NUD.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(121, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(442, 400)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "n:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "m:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "R:"
        '
        'BuildUpButton
        '
        Me.BuildUpButton.Location = New System.Drawing.Point(15, 96)
        Me.BuildUpButton.Name = "BuildUpButton"
        Me.BuildUpButton.Size = New System.Drawing.Size(100, 27)
        Me.BuildUpButton.TabIndex = 7
        Me.BuildUpButton.Text = "Построить"
        Me.BuildUpButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 419)
        Me.Controls.Add(Me.BuildUpButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.R_NUD)
        Me.Controls.Add(Me.M_NUD)
        Me.Controls.Add(Me.N_NUD)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.N_NUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.M_NUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.R_NUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents N_NUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents M_NUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents R_NUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BuildUpButton As System.Windows.Forms.Button

End Class
