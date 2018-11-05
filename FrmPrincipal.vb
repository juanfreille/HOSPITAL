Public Class FrmPrincipal

    Private Sub NuevoTurnoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoTurnoToolStripMenuItem.Click
        Dim F1 As New FrmNuevoTurno
        F1.ShowDialog()
    End Sub

    Private Sub VerTurnosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerTurnosToolStripMenuItem.Click
        Dim F2 As New FrmVerTurnos
        F2.ShowDialog()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class
