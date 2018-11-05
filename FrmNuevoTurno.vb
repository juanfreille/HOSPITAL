Imports System.ComponentModel

Public Class FrmNuevoTurno

    Dim objMEDICOS As New Medicos
    Dim objTURNOS As New Turnos

    Private Sub FrmNuevoTurno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        objMEDICOS.VER(cbMedico)
        LLENAR_CMB_HORA()
        CALENDARIO_INICIAL()
        bReservar.Enabled = False
    End Sub

    Sub CALENDARIO_INICIAL()
        'Cuando iniciamos hacemos comprobacion de que el dia actual no sea ni sabado ni domingo, y de darse esta condicion la fecha actual se correrá a lunes.
        dtpFecha.MinDate = Today
        If dtpFecha.Value.DayOfWeek = DayOfWeek.Saturday Or dtpFecha.Value.DayOfWeek = DayOfWeek.Sunday Then
            If dtpFecha.Value.DayOfWeek = DayOfWeek.Saturday Then
                dtpFecha.MinDate = Today.AddDays(2)
            Else
                dtpFecha.MinDate = Today.AddDays(1)
            End If
        End If
    End Sub
    Sub LLENAR_CMB_HORA()
        ' Vamos a crear 2 variables una que contenga el inicio de los horarios de los medicos y otra que contenga el final del horario de trabajo
        ' La variable INICIO se irá incrementando mientras sea menor a FINAL para completar los turnos siempre teninendo en cuenta la duracion de los turnos
        ' que extraemos de la columna duracion de la tabla Medicos. La duracion se sumará a la variable INICIO siempre al estar dentro del while pero solo
        ' aparecerá dentro del combobox de hora cuando se haga una busqueda para saber si ese turno no ha sido dado ya a otro paciente.

        Dim INICIO As DateTime
        Dim FINAL As DateTime

        'Limpiamos el combo
        cbHora.Items.Clear()

        'Empezamos el recorrido for para las filas de la tabla medicos
        For Each FILA As DataRow In objMEDICOS.TABLA.Rows
            'Asignamos el horario de inicio a la variable
            INICIO = CDate(FILA(objMEDICOS.TABLA.Columns("desde")))
            If FILA(objMEDICOS.TABLA.Columns("matricula")) = cbMedico.SelectedValue Then
                'Asignamos el horario de finalizacion a la variable
                FINAL = CDate(FILA(objMEDICOS.TABLA.Columns("hasta")))
                'Dentro del while usamos una funcion para consultar en la otra tabla (Turnos) para ver si ya esta asignado ese turno, si no esta agregamos,
                'la variable inicio al combobox.
                While INICIO < FINAL
                    If objTURNOS.Buscar(cbMedico.SelectedValue, dtpFecha.Value.ToShortDateString, INICIO.ToString("HH:mm")) <> INICIO.ToString("HH:mm") Then
                        cbHora.Items.Add(INICIO.ToString("HH:mm"))
                    End If
                    INICIO = INICIO + TimeSpan.FromMinutes(FILA(objMEDICOS.TABLA.Columns("duracion")))
                End While
            End If
        Next

        'Usamos un try catch para intentar seleccionar el primer item del combobox, si no existe el index 0 porque todos los turnos del dia han sido dados,
        'llenaremos el combo con un string que nos informe que esta LLENO.
        Try
            cbHora.SelectedIndex = 0
        Catch
            cbHora.Items.Add("LLENO")
            cbHora.SelectedItem = "LLENO"
        End Try

    End Sub
    Private Sub bReservar_Click(sender As System.Object, e As System.EventArgs) Handles bReservar.Click
        'Si la fecha es distinta de sabado o domingo, mandamos a funcion grabar, de lo contrario mostramos mensaje de que se debe corregir la fecha.
        'Usamos la funcion grabar para enviar los datos del nuevo turno, salta el popup, y luego se recarga el combo, y se limpia el campo del txt.
        If dtpFecha.Value.DayOfWeek <> DayOfWeek.Saturday And dtpFecha.Value.DayOfWeek <> DayOfWeek.Sunday Then
            Dim fecha As String = dtpFecha.Value.ToShortDateString
            Dim OK As Boolean = objTURNOS.Grabar((cbMedico.SelectedValue), dtpFecha.Value.ToShortDateString, cbHora.SelectedItem, txtPaciente.Text)
            If OK = True Then
                MessageBox.Show("EL TURNO HA SIDO AGENDADO:" & vbLf & "Día: " & dtpFecha.Value.ToShortDateString & vbLf & "Hora: " & cbHora.SelectedItem, "MENSAJE")
                LLENAR_CMB_HORA()
                txtPaciente.Clear()
                txtPaciente.Focus()
            End If
        Else
            MessageBox.Show("Debe corregir la fecha, debe ser un dia de lunes a viernes.", "MENSAJE")
        End If
    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        LLENAR_CMB_HORA()
    End Sub
    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        LLENAR_CMB_HORA()
    End Sub

    Private Sub txtPaciente_TextChanged(sender As Object, e As EventArgs) Handles txtPaciente.TextChanged
        'Controles de validacion para que se habilite el boton reservar si se dan todas las condiciones
        If txtPaciente.Text <> "" And cbMedico.SelectedItem IsNot Nothing And dtpFecha.Value.ToShortDateString IsNot Nothing And cbHora.SelectedItem IsNot Nothing Then
            If cbHora.SelectedItem IsNot "LLENO" Then
                bReservar.Enabled = True
            Else
                bReservar.Enabled = False
            End If
        Else
            bReservar.Enabled = False
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        'Control de validacion para que el datetimepicker de fecha no se pueda seleccionar ni sabado ni domingo.
        'Creamos dentro una consulta para ofrecerle al usuario la posibilidad de cambiar automaticamente la fecha al lunes proximo.
        'Si el usurio desea otro dia, debera antes cambiar la fecha para poder seguir con la asignacion del turno.
        Dim FINDE As DateTime = dtpFecha.Value.Date
        LLENAR_CMB_HORA()
        If FINDE.DayOfWeek = DayOfWeek.Saturday OrElse FINDE.DayOfWeek = DayOfWeek.Sunday Then
            If MessageBox.Show("Solo se atiende de Lunes a Viernes." + vbLf + "Desea seleccionar el próximo Lunes?", "Solicitar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If FINDE.DayOfWeek = DayOfWeek.Saturday Then
                    dtpFecha.Value = dtpFecha.Value.AddDays(+2)
                Else
                    dtpFecha.Value = dtpFecha.Value.AddDays(+1)
                End If
            Else
                MessageBox.Show("Deberá cambiar la fecha seleccionada por algun día de lunes a viernes para poder continuar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            e.Cancel = True
        End If
    End Sub
End Class