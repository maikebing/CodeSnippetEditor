Public Class ucMysticBoy_DeclEdit
    ''' <summary>
    ''' 决定向XML中写入何种信息
    ''' </summary>
    ''' <remarks></remarks>
    Enum deDecl
        dLiteral
        dObject
    End Enum
    Public Event Change()

    Public xCS As CodeSnippet


    Private newDeclType As deDecl
    ''' <summary>
    ''' 控件的内容是加载文字/对象的信息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeclType() As deDecl
        Get
            Return newDeclType
        End Get
        Set(ByVal value As deDecl)
            newDeclType = value
        End Set
    End Property

    Private Sub umblstIDS_AddedItem(ByVal Item As String) Handles umblstIDS.AddedItem
        Try
            Select Case Me.DeclType
                Case deDecl.dLiteral
                    xCS.AddLiteral(Item, "", "", "")
                Case deDecl.dObject
                    xCS.AddObject(Item, "", "", "")
            End Select
            RaiseEvent Change()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub umblstIDS_DelItem(ByVal Item As String) Handles umblstIDS.DelItem
        Try
            Select Case Me.DeclType
                Case deDecl.dLiteral
                    xCS.RemoveLiteral(Item)
                Case deDecl.dObject
                    xCS.RemoveObject(Item)
            End Select
            RaiseEvent Change()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveLastItem()
        umblstIDS_SelectedIndexChanged(Nothing)

    End Sub
    Private Sub umblstIDS_SelectedIndexChanged(ByVal ItemText As String) Handles umblstIDS.SelectedIndexChanged
        Static OldItem As String
        If (IsNothing(OldItem) Or OldItem = "") = False Then
            Select Case Me.DeclType
                Case deDecl.dLiteral
                    xCS.EditLiteral(OldItem, Me.cbsType.Text, Me.txtDefault.Text, _
                     Me.txtToolTip.Text, Me.txtFunction.Text, Me.cbsEditable.Checked)
                Case deDecl.dObject
                    xCS.EditObject(OldItem, Me.cbsType.Text, Me.txtDefault.Text, _
                    Me.txtToolTip.Text, Me.txtFunction.Text, Me.cbsEditable.Checked)
            End Select
        End If

        OldItem = ItemText
        If (IsNothing(ItemText) Or ItemText = "") = False Then
            Me.lblIDName.Text = ItemText
            Select Case Me.DeclType
                Case deDecl.dLiteral
                    Dim ct = "", dt = "", ttt = "", ft = ""
                    Dim eb As Boolean
                    xCS.ReadLiteral(ItemText, ct, dt, ttt, ft, eb)
                    Me.cbsType.Text = ct
                    If Me.cbsType.Items.Contains(ct) = False Then
                        Me.cbsType.Items.Add(ct)
                    End If
                    If My.Settings.csDeclLiteral.Contains(ct) = False Then
                        My.Settings.csDeclLiteral.Add(ct)
                    End If
                    Me.txtDefault.Text = dt : Me.txtToolTip.Text = ttt
                    Me.txtFunction.Text = ft
                    Me.cbsEditable.Checked = eb
                Case deDecl.dObject
                    Dim ct = "", dt = "", ttt = "", ft = ""
                    Dim eb As Boolean
                    xCS.ReadObject(ItemText, ct, dt, ttt, ft, eb)
                    Me.cbsType.Text = ct : Me.txtDefault.Text = dt : Me.txtToolTip.Text = ttt
                    If Me.cbsType.Items.Contains(ct) = False Then
                        Me.cbsType.Items.Add(ct)
                    End If
                    If My.Settings.csDeclObject.Contains(ct) = False Then
                        My.Settings.csDeclObject.Add(ct)
                    End If
                    Me.txtFunction.Text = ft
                    Me.cbsEditable.Checked = eb
            End Select
        End If
       
    End Sub
    

    ''' <summary>
    ''' 按照XML内容开始加载属于本控件中的内容
    ''' </summary>
    ''' <remarks>不保存原来的信息!</remarks>
    Public Sub UpdateMe()
        Dim ids As String() = {""}
        Me.umblstIDS.ListBox.Items.Clear()
        Select Case Me.DeclType
            Case deDecl.dLiteral
                ids = xCS.GetLiterals()
            Case deDecl.dObject
                ids = xCS.GetObjects
        End Select
        Dim xid As String
        For Each xid In ids
            If xid <> "" Then
                Me.umblstIDS.ListBox.Items.Add(xid)
            End If
        Next
        Me.txtFunction.Text = ""
        Me.txtToolTip.Text = ""
        Me.txtDefault.Text = ""
        Me.lblIDName.Text = "(None)"
        Me.cbsType.Text = ""
        Me.cbsEditable.Checked = True
        Me.cbsType.Items.Clear()
        Dim cts As String = ""
        For Each cts In IIf(Me.DeclType = deDecl.dLiteral, My.Settings.csDeclLiteral, My.Settings.csDeclObject)
            Me.cbsType.Items.Add(cts)
        Next
        If Me.umblstIDS.ListBox.Items.Count > 0 Then
            Me.umblstIDS.ListBox.SelectedIndex = 0
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化。
        
    End Sub

    Private Sub RaiseChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsEditable.CheckedChanged, _
           cbsType.TextChanged, cbsType.SelectedIndexChanged, txtDefault.TextChanged, txtToolTip.TextChanged, txtFunction.TextChanged
        RaiseEvent Change()
    End Sub
End Class
