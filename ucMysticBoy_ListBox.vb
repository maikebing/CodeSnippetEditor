Public Class ucMysticBoy_ListBox
    Public Event SelectedIndexChanged(ByVal ItemText As String)
    Public Event AddedItem(ByVal Item As String)
    Public Event DelItem(ByVal Item As String)

    Private Sub tsmiDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiDelete.Click
        If Not IsNothing(Me.ListBox.SelectedItem) Then
            Try
                Try
                    RaiseEvent DelItem(Me.ListBox.SelectedItem)
                Catch ex As Exception
                End Try
                Me.ListBox.Items.Remove(Me.ListBox.SelectedItem)
                If Me.ListBox.Items.Count = 0 Then
                    Me.tsmiTxtEditKeyword.Enabled = False
                    Me.tsmiEditOK.Enabled = Me.tsmiTxtEditKeyword.Enabled
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub lstKeyword_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox.SelectedIndexChanged
        Try
            Me.tsmiTxtEditKeyword.Enabled = True
            Me.tsmiTxtEditKeyword.Text = Me.ListBox.SelectedItem
        Catch ex As Exception
        End Try
        Try
            RaiseEvent SelectedIndexChanged(Me.ListBox.SelectedItem)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmiOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiOk.Click
        Try
            If Me.ListBox.Items.Contains(Me.tsmiTxtAddKeyword.Text) = False Then
                Me.ListBox.Items.Add(Me.tsmiTxtAddKeyword.Text)
                RaiseEvent AddedItem(Me.tsmiTxtAddKeyword.Text)
                Me.ListBox.SelectedItem = Me.tsmiTxtAddKeyword.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tsmiEditOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiEditOK.Click
        Try
            Me.ListBox.Items.Item(Me.ListBox.SelectedIndex) = Me.tsmiTxtEditKeyword.Text
        Catch ex As Exception

        End Try
    End Sub

    Public Function SelText()
        SelText = ListBox.SelectedItem
    End Function

    'Private newListItems As String()
    'Public Property ListItems() As String()
    '    Get
    '        Dim cItm As String
    '        Dim citms As String = ""
    '        For Each cItm In Me.ListBox.Items
    '            citms = citms & ";"
    '        Next
    '        newListItems = citms.Split(";")
    '        Return newListItems
    '    End Get
    '    Set(ByVal value As String())
    '        Dim citm As String
    '        newListItems = value
    '        Me.ListBox.Items.Clear()
    '        For Each citm In newListItems
    '            Me.ListBox.Items.Add(citm)
    '        Next
    '    End Set
    'End Property

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub lstKeyword_ValueMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox.ValueMemberChanged

    End Sub

    Private Sub cmsKeyword_BeginDrag(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmsKeyword.BeginDrag
        Try
            Me.tsmiTxtEditKeyword.Enabled = Me.ListBox.SelectedItems.Count <> 0
            Me.tsmiEditOK.Enabled = Me.tsmiTxtEditKeyword.Enabled
        Catch ex As Exception
        End Try

    End Sub

    Private Sub tsmiTxtEditKeyword_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsmiTxtEditKeyword.EnabledChanged
        Me.tsmiEditOK.Enabled = Me.tsmiTxtEditKeyword.Enabled
        Me.tsmiDelete.Enabled = Me.tsmiTxtEditKeyword.Enabled
    End Sub
End Class
