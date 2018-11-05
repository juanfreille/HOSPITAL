Public Class FrmVerTurnos
    Structure CUADRO
        Dim HORA As String
        Dim PACIENTE As String
    End Structure

    Dim objTURNOS As New Turnos
    Dim objMEDICOS As New Medicos

    Private Sub FrmVerTurnos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        objMEDICOS.VER(lbMedico)
    End Sub

    Private Sub bVerGrilla_Click(sender As System.Object, e As System.EventArgs) Handles bVerGrilla.Click
        'Aqui aplicaremos la misma estrategia que en el metodo FrmNuevoTurno.LLENAR_CMB_HORA()
        'La diferencia se dará al crear una variable llamada PACIENTE, que contendra el resultado de la funcion Turnos.Nombre; a dicha funcion le enviamos
        'medico, fecha y hora, si hace el recorrido y encuentra el paciente, entonces devuelve el nombre del paciente, sino nada.
        'Seguiremos llenando los horarios libres con celdas vacias "nothing" a menos que el paciente exista, y en ese caso se agrega su nombre en el horario
        'correspondiente.

        Dim INICIO As DateTime
        Dim FINAL As DateTime

        GRILLA.Rows.Clear()
        For Each FILA As DataRow In objMEDICOS.TABLA.Rows
            INICIO = CDate(FILA(objMEDICOS.TABLA.Columns("desde")))
            If FILA(objMEDICOS.TABLA.Columns("matricula")) = lbMedico.SelectedValue Then
                FINAL = CDate(FILA(objMEDICOS.TABLA.Columns("hasta")))
                While INICIO < FINAL
                    Dim PACIENTE As String
                    PACIENTE = objTURNOS.Nombre(lbMedico.SelectedValue, dtpFecha.Value.ToShortDateString, INICIO.ToString("HH:mm"))
                    If objTURNOS.Buscar(lbMedico.SelectedValue, dtpFecha.Value.ToShortDateString, INICIO.ToString("HH:mm")) <> INICIO.ToString("HH:mm") Then
                        GRILLA.Rows.Add(INICIO.ToString("HH:mm"))
                    Else
                        GRILLA.Rows.Add(INICIO.ToString("HH:mm"), PACIENTE)
                    End If
                    INICIO = INICIO + TimeSpan.FromMinutes(FILA(objMEDICOS.TABLA.Columns("duracion")))
                End While
            End If
        Next
    End Sub

End Class