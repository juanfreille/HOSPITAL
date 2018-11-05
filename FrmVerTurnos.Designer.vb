<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerTurnos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbMedico = New System.Windows.Forms.ListBox()
        Me.bVerGrilla = New System.Windows.Forms.Button()
        Me.GRILLA = New System.Windows.Forms.DataGridView()
        Me.HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE_PACIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.GRILLA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(52, 81)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(139, 22)
        Me.dtpFecha.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "FECHA DEL TURNO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 133)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "NOMBRES DE MEDICOS"
        '
        'lbMedico
        '
        Me.lbMedico.FormattingEnabled = True
        Me.lbMedico.ItemHeight = 16
        Me.lbMedico.Location = New System.Drawing.Point(52, 166)
        Me.lbMedico.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbMedico.Name = "lbMedico"
        Me.lbMedico.Size = New System.Drawing.Size(357, 468)
        Me.lbMedico.TabIndex = 7
        '
        'bVerGrilla
        '
        Me.bVerGrilla.Location = New System.Drawing.Point(52, 666)
        Me.bVerGrilla.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bVerGrilla.Name = "bVerGrilla"
        Me.bVerGrilla.Size = New System.Drawing.Size(359, 36)
        Me.bVerGrilla.TabIndex = 9
        Me.bVerGrilla.Text = "VER GRILLA DE TURNOS"
        Me.bVerGrilla.UseVisualStyleBackColor = True
        '
        'GRILLA
        '
        Me.GRILLA.AllowUserToAddRows = False
        Me.GRILLA.AllowUserToDeleteRows = False
        Me.GRILLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRILLA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HORA, Me.NOMBRE_PACIENTE})
        Me.GRILLA.Location = New System.Drawing.Point(457, 81)
        Me.GRILLA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GRILLA.Name = "GRILLA"
        Me.GRILLA.ReadOnly = True
        Me.GRILLA.Size = New System.Drawing.Size(603, 620)
        Me.GRILLA.TabIndex = 10
        '
        'HORA
        '
        Me.HORA.HeaderText = "HORA"
        Me.HORA.Name = "HORA"
        Me.HORA.ReadOnly = True
        Me.HORA.Width = 80
        '
        'NOMBRE_PACIENTE
        '
        Me.NOMBRE_PACIENTE.HeaderText = "NOMBRE PACIENTE"
        Me.NOMBRE_PACIENTE.Name = "NOMBRE_PACIENTE"
        Me.NOMBRE_PACIENTE.ReadOnly = True
        Me.NOMBRE_PACIENTE.Width = 300
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(453, 44)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(573, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "GRILLA COMPLETA DE TURNOS DADOS Y NO DADOS DE FECHA Y MEDICO ELEGIDO"
        '
        'FrmVerTurnos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 756)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GRILLA)
        Me.Controls.Add(Me.bVerGrilla)
        Me.Controls.Add(Me.lbMedico)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmVerTurnos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VER TURNOS"
        CType(Me.GRILLA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbMedico As System.Windows.Forms.ListBox
    Friend WithEvents bVerGrilla As System.Windows.Forms.Button
    Friend WithEvents GRILLA As System.Windows.Forms.DataGridView
    Friend WithEvents HORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE_PACIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
