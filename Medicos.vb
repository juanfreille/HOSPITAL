
Imports System.Data.OleDb

Public Class Medicos

    Dim CONECTOR As New OleDbConnection(My.Settings.CADENA)
    Dim COMANDO As New OleDbCommand
    Dim ADAPTADOR As New OleDbDataAdapter(COMANDO)
    Public TABLA As New DataTable

    Public Sub New()

        COMANDO.Connection = CONECTOR
        COMANDO.CommandType = CommandType.TableDirect
        COMANDO.CommandText = "Medicos"
        ADAPTADOR.Fill(TABLA)
        Dim VEC(1) As DataColumn
        VEC(0) = TABLA.Columns("matricula")
        TABLA.PrimaryKey = VEC

    End Sub

    Public Sub VER(COMBO As ComboBox)
        COMBO.DisplayMember = "nombre"
        COMBO.ValueMember = "matricula"
        COMBO.DataSource = TABLA
    End Sub

    Public Sub VER(CL As ListBox)
        CL.DisplayMember = "nombre"
        CL.ValueMember = "matricula"
        CL.DataSource = TABLA
    End Sub

End Class
