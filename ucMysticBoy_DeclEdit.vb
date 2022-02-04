Public Class ucMysticBoy_DeclEdit
    ''' <summary>
    ''' ������XML��д�������Ϣ
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
    ''' �ؼ��������Ǽ�������/�������Ϣ
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
    ''' ����XML���ݿ�ʼ�������ڱ��ؼ��е�����
    ''' </summary>
    ''' <remarks>������ԭ������Ϣ!</remarks>
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

        ' �˵����� Windows ���������������ġ�
        InitializeComponent()

        '�� InitializeComponent() ����֮������κγ�ʼ����
        
    End Sub

    Private Sub RaiseChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsEditable.CheckedChanged, _
           cbsType.TextChanged, cbsType.SelectedIndexChanged, txtDefault.TextChanged, txtToolTip.TextChanged, txtFunction.TextChanged
        RaiseEvent Change()
    End Sub
End Class
