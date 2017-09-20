Imports ComunicazioneFattureEmesseRicevute.Common
Imports ComunicazioneFattureEmesseRicevute.FattureEmesse
Imports ComunicazioneFattureEmesseRicevute.Validators
Imports Janus.Windows.GridEX

Public Class Form1
    Public ds As New List(Of IdFiscaleIVA)
    Public c As New ComunicazioneFattureEmesseRicevute.ComunicazioneFattureEmesseRicevute
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cc = New CessionarioCommittente()
        cc.Validator = New CessionarioCommittenteDTEValidator
        cc.IdentificativiFiscali.CodiceFiscale = "d"
        cc.IdentificativiFiscali.IdFiscaleIVA.IdPaese = "a"
        c.FattureEmesse.CessionarioCommittente.Add(cc)
        GridEX1.DataSource = c.FattureEmesse.CessionarioCommittente
        GridEX1.RetrieveStructure()

        Dim t As GridEXTable = GridEX1.RootTable

        'IdentificativiFiscali
        Dim codiceFiscale As GridEXColumn = t.Columns("IdentificativiFiscali")
        codiceFiscale.DataMember = "IdentificativiFiscali.CodiceFiscale"
        codiceFiscale.Caption = "Codice Fiscale"
        codiceFiscale.EditType = EditType.TextBox

        Dim idPaese As GridEXColumn = NewGridExColumn("IdentificativiFiscali.IdFiscaleIVA.IdPaese", "Paese")
        Dim idCodice As GridEXColumn = NewGridExColumn("IdentificativiFiscali.IdFiscaleIVA.IdCodice", "Partita IVA")
        GridEX1.RowHeaders = InheritableBoolean.True

        t.CellLayoutMode = CellLayoutMode.UseColumnSets
        t.ColumnSetRowCount = 1
        'GridEX1.RowHeaderContent=
        'GridEX1.CellSelectionMode = CellSelectionMode.EntireRow
        'idPaese.[Da
        GridEX1.RootTable.Columns.Add(idPaese)
        GridEX1.RootTable.Columns.Add(idCodice)
        'GridEX1.RootTable.
        Dim s As GridEXColumnSet = GridEX1.RootTable.ColumnSets.Add()
        s.Visible = True
        s.ColumnCount = 3
        s.Add(idPaese, 0, 0)
        s.Add(idCodice, 0, 1)
        s.Add(codiceFiscale, 0, 2)

    End Sub
    Private Function NewGridExColumn(dataMember As String, caption As String, Optional type As ColumnType = ColumnType.Text, Optional editType As EditType = EditType.TextBox, Optional alignment As TextAlignment = TextAlignment.Near) As GridEXColumn
        Dim c As New GridEXColumn(dataMember, type, editType) With {
                .Caption = caption,
                .TextAlignment = alignment,
                .HeaderAlignment = TextAlignment.Center
            }
        If alignment = Janus.Windows.GridEX.TextAlignment.Far Then
            c.FormatString = "n2"
        End If
        If editType = EditType.CalendarCombo Then
            c.FormatString = "dd/MM/yyyy"
        End If
        Return c

    End Function

End Class
