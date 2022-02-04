

<System.Runtime.InteropServices.ComVisible(False)> Public Class frmMain
    Dim xCS As New CodeSnippet
    Public Saved As Boolean = True
    Public FileName As String = ""
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If Me.lstNamespace.Items.Contains(Me.umblstNamespace.ListBox.SelectedItem) = False Then
                Me.lstNamespace.Items.Add(Me.umblstNamespace.ListBox.SelectedItem)
                Saved = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            Me.lstNamespace.Items.Remove(Me.lstNamespace.SelectedItem)
            Saved = False
        Catch
        End Try
    End Sub

    Private Sub tsmiOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiOpen.Click
        If Me.ofdOpenFile.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                Me.XLoad(Me.ofdOpenFile.FileName)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub XLoad(ByVal txtText As Object)
        Me.SetState("�����ı�����...")
        Me.xCS.Load(txtText)
        Me.UpDate()
    End Sub

    Public Sub XLoad(ByVal xFileName As String)
        Me.SetState("�����ļ�...")
        Me.xCS.Load(xFileName)
        Me.UpDate()
        Me.FileName = xFileName
        Saved = True
    End Sub
    Public Sub XSave(ByVal xFileName As String)

        Me.SetXcs()
        SetState("����д���ļ�...")
        Me.xCS.Save(xFileName)
        Me.Saved = True
        Me.FileName = xFileName
        SetState("")
    End Sub
    Public Sub XSave(ByRef txtText As Object)
        Me.SetXcs() '�ڲ����ز�������
        SetState("����д�뵽�ı�...")
        txtText = Me.xCS.GetXmlText
        SetState("")
    End Sub
    Public Function XSave() As String
        Me.SetXcs() ' '�ڲ����ز�������
        SetState("���ڷ��ص�������...")
        SetState("")
        Return Me.xCS.GetXmlText
    End Function


    ''' <summary>
    ''' �Ѵ����ϵ��������л���XML������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetXcs()
        '���û�����Ϣ����

        SetState("���ڴ��������Ϣ...", 5)
        With Me.xCS
            .Author = Me.txtAuthor.Text
            .Description = Me.txtCSDesc.Text
            .HelpUrl = Me.txtHelpUrl.Text
            .Shortcut = Me.txtShortcut.Text
            .Title = Me.txtTitle.Text
            SetState(10)
            Dim ctmp As String = ""
            For Each ctmp In .GetKeywords
                .RemoveKeyword(ctmp)
            Next
            SetState(20)
            For Each ctmp In Me.umblstKeyword.ListBox.Items
                If ctmp.Trim <> "" Then
                    .AddKeyword(ctmp)
                End If
            Next
            .SetSnippetType(IIf(Me.cbsExpansion.Checked = True, CodeSnippet.SnippetType.Expansion, 0) _
                        Or IIf(Me.cbsSurroundsWith.Checked = True, CodeSnippet.SnippetType.SurroundsWith, 0))


            '���ô��벿��
            SetState("���ڴ�����벿��...", 35)
            Dim xl As CodeSnippet.Language
            Select Case Me.cmbLanguage.Text.ToLower.Trim
                Case "vb"
                    xl = CodeSnippet.Language.VB
                Case "csharp" 'CSharp 
                    xl = CodeSnippet.Language.CSharp
                Case "vbsharp"
                    xl = CodeSnippet.Language.VJSharp
                Case "xml"
                    xl = CodeSnippet.Language.XML
            End Select
            Dim xk As CodeSnippet.Kind
            Select Case Me.cmbInsType.Text.ToLower.Trim
                Case "method body"
                    xk = CodeSnippet.Kind.MethodBody
                Case "method decl"
                    xk = CodeSnippet.Kind.MethodDecl
                Case "type decl"
                    xk = CodeSnippet.Kind.TypeDecl
                Case "any"
                    xk = CodeSnippet.Kind.Any
                Case "page"
                    xk = CodeSnippet.Kind.Page
                Case "file"
                    xk = CodeSnippet.Kind.File
            End Select
            SetState(40)
            .EditCode(xl, Me.txtCode.Text, IIf(Me.txtSpa.Text.Trim = "", "$", Me.txtSpa.Text), xk)

            '��������ѡ�
            SetState("���ڴ���������������...", 55)
            Me.umbdeObject.SaveLastItem()
            SetState(60)
            Me.umbdeLiteral.SaveLastItem()

            '���õ���
            SetState("���ڴ��������ֿռ��б�...", 65)
            Dim tm1 As String = ""
            For Each tm1 In .GetImports
                .RemoveImport(tm1)
            Next
            SetState(70)
            For Each tm1 In Me.lstNamespace.Items
                If tm1.Trim <> "" Then '��ֹ�ո�
                    .AddImport(tm1)
                End If
            Next

            '��������
            SetState("���ڴ������õĳ����б�...", 85)
            Dim xNmsp As String = ""
            Dim xNSs() As String = {""}
            Dim xxn() As String = {""}
            xxn = .GetReference
            SetState(90)
            For Each xNmsp In xxn
                If Me.lstAsmUrl.Items.Contains(xNmsp) = True Then
                    Me.lstAsmUrl.Items.Remove(xNmsp)
                Else
                    .RemoveReference(xNmsp)
                End If
            Next
            SetState(95)
            For Each xNmsp In Me.lstAsmUrl.Items
                If xNmsp.Trim <> "" Then
                    Try
                        .AddReference(xNmsp)
                    Catch ex As Exception
                    End Try
                End If
            Next
            '�����ǰӦ�����ֿռ� �������б���,���б���ɾ��.���������б���,��XML��ɾ��
            '���,�������б��е����ֿռ�Ӧ�����¼ӵ�,��ӵ�XML��,���Ϸ�������Ҫ������ǰ��Ĵ���
            '��ǰ����������������.
        End With
        SetState(100)
        SetState("�������")
    End Sub

    Public Overloads Sub UpDate()
        On Error Resume Next
        SetState("���ڼ��ػ�����Ϣ...", 5)
        '���ػ�����Ϣ����,Header
        Me.txtAuthor.Text = Me.xCS.Author
        Me.txtCSDesc.Text = Me.xCS.Description
        Me.txtHelpUrl.Text = Me.xCS.HelpUrl
        Me.txtShortcut.Text = Me.xCS.Shortcut
        SetState(10)
        Me.txtTitle.Text = Me.xCS.Title
        Me.umblstKeyword.ListBox.Items.Clear()
        Me.umblstKeyword.ListBox.Items.AddRange(Me.xCS.GetKeywords)
        SetState(15)
        Me.cbsExpansion.Checked = (Me.xCS.GetSnippetType Xor CodeSnippet.SnippetType.Refactoring Xor CodeSnippet.SnippetType.SurroundsWith) = CodeSnippet.SnippetType.Expansion
        Me.cbsSurroundsWith.Checked = (Me.xCS.GetSnippetType Xor CodeSnippet.SnippetType.Expansion Xor CodeSnippet.SnippetType.Refactoring) = CodeSnippet.SnippetType.SurroundsWith
        SetState("���ڼ��ش��벿��...", 20)
        '���ش���ѡ�
        Dim xl As CodeSnippet.Language
        Dim xct As String = ""
        Dim xd As String = ""
        Dim xk As String = ""
        Me.xCS.ReadCode(xl, xct, xd, xcKind:=xk)
        SetState(25)
        Me.cmbLanguage.Text = xl.ToString
        Me.txtCode.Text = xct
        Me.txtSpa.Text = xd
        Me.cmbInsType.Text = xk

        '��������ѡ�����
        SetState("��ʼ���ش������������...", 30)
        Me.umbdeObject.xCS = Me.xCS
        Me.umbdeObject.UpdateMe()
        SetState(40)
        Me.umbdeLiteral.xCS = Me.xCS
        Me.umbdeLiteral.UpdateMe()

        '���ص���ѡ�����
        SetState("��ʼ���ص�������ֿռ��б�", 50)
        Me.lstNamespace.Items.Clear()
        Me.lstNamespace.Items.AddRange(Me.xCS.GetImports)
        SetState(55)
        Dim xtmp As String = ""
        Dim xxp As String = ""
        For Each xtmp In Me.lstNamespace.Items
            If (My.Settings.csNamespace & ",").Contains(xtmp & ",") = False And Trim(xtmp) <> "" Then
                xxp = xxp & IIf(xxp.Length > 0, ",", "") & xtmp
            End If
        Next
        SetState(70)
        My.Settings.csNamespace = xxp & IIf(xxp.Length > 0, IIf(My.Settings.csNamespace.Length > 0, ",", ""), "") & My.Settings.csNamespace
        Me.umblstNamespace.ListBox.Items.Clear()
        Me.umblstNamespace.ListBox.Items.AddRange(My.Settings.csNamespace.Split(","))
        '��������ѡ�����

        SetState("��ʼ�������õĳ�����Ϣ", 75)
        Me.lstAsmUrl.Items.Clear()
        Me.lstAsmUrl.Items.AddRange(Me.xCS.GetReference)
        xtmp = ""
        xxp = ""
        SetState(80)
        For Each xtmp In Me.lstAsmUrl.Items
            If (My.Settings.csAsmUrl & ",").Contains(xtmp & ",") = False And xtmp.Trim <> "" Then
                xxp = xxp & IIf(xxp.Length > 0, ",", "") & xtmp
            End If
        Next
        SetState(95)
        My.Settings.csAsmUrl = xxp & IIf(xxp.Length > 0, IIf(My.Settings.csAsmUrl.Length > 0, ",", ""), "") & My.Settings.csAsmUrl
        Me.umblstAsmUrl.ListBox.Items.Clear()
        Me.umblstAsmUrl.ListBox.Items.AddRange(My.Settings.csAsmUrl.Split(","))
        SetState(100)
        SetState("�������!", 0)
    End Sub

    Private Sub SetState(ByVal txt As String)
        Me.tsslblState.Text = txt
        ' My.Application.DoEvents()
    End Sub

    Private Sub SetState(ByVal lng As Long)
        If lng > 100 Or lng < 0 Then
            lng = 0
        End If
        Me.tspbState.Value = lng
        ' My.Application.DoEvents()
    End Sub
    Private Sub SetState(ByVal txt As String, ByVal lng As Long)
        Me.tsslblState.Text = txt
        If lng > 100 Or lng < 0 Then
            lng = 0
        End If
        Me.tspbState.Value = lng
        'My.Application.DoEvents()
    End Sub

    Public Sub New()

        ' �˵����� Windows ���������������ġ�
        InitializeComponent()

        ' �� InitializeComponent() ����֮������κγ�ʼ����
        Me.umbdeObject.xCS = Me.xCS
        Me.umbdeLiteral.xCS = Me.xCS
    End Sub

    Private Sub tsmiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiSave.Click
        If Me.tmsiLearn.Checked = True Then
            If Me.CheckItOK(1) = False Then
                SetState("����ǰ���еĹ�����û��ͨ��!Ŀǰû�б���!")
                Exit Sub
            End If
        End If
        Try
            If FileName <> "" Then
                Me.XSave(FileName)
            Else
                tsmiSaveAs_Click(sender, e)
            End If
            Saved = True
        Catch ex As Exception
            tsmiSaveAs_Click(sender, e)
        End Try
        SetState(0)
    End Sub

    Public Sub Save()
        If Me.tmsiLearn.Checked = True Then
            If Me.CheckItOK(1) = False Then
                SetState("����ǰ���еĹ�����û��ͨ��!Ŀǰû�б���!")
                Exit Sub
            End If
        End If
        Try
            If FileName <> "" Then
                Me.XSave(FileName)
            Else
                tsmiSaveAs_Click(Nothing, Nothing)
            End If
            Saved = True
        Catch ex As Exception
            tsmiSaveAs_Click(Nothing, Nothing)
        End Try
        SetState(0)
    End Sub


    Private Sub tsmiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiNew.Click
        Me.xCS = New CodeSnippet
        Me.UpDate()
        Me.Saved = True
        SetState("����", 0)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub tsmiSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiSaveAs.Click
        Me.SetXcs()
        If Me.sfdSaveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Me.xCS.Save(Me.sfdSaveFile.FileName)
                FileName = Me.sfdSaveFile.FileName
                Saved = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
        SetState(0)
    End Sub

    Private Sub tsmiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiExit.Click
        If Saved = True Then
            My.Settings.Save()
            Me.Visible = False
        Else
            Select Case MsgBox("��ǰ���༭���ļ�û�б���!Ҫ������", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Me.Save()
                Case MsgBoxResult.No
                    My.Settings.Save()
                    Me.Visible = False
                Case MsgBoxResult.Cancel
                    '��ִ���κβ���
            End Select
        End If
    End Sub
    Private Sub theTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitle.TextChanged, txtShortcut.TextChanged, _
               txtHelpUrl.TextChanged, txtAuthor.TextChanged, txtCode.TextChanged, cmbInsType.SelectedIndexChanged, txtSpa.TextChanged, _
               cmbLanguage.SelectedIndexChanged
        Saved = False
    End Sub
    Private Sub umblstKeywordChange(ByVal Item As String) Handles umblstKeyword.DelItem, umblstKeyword.AddedItem
        Saved = False
    End Sub

    Private Sub umbdeChange() Handles umbdeObject.Change, umbdeLiteral.Change
        Saved = False
    End Sub

    Private Sub btnAsmUrlRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsmUrlRemove.Click
        Try
            Me.lstAsmUrl.Items.Remove(Me.lstAsmUrl.SelectedItem)
            Saved = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAsmUrlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsmUrlAdd.Click
        Try
            If Me.lstAsmUrl.Items.Contains(Me.umblstAsmUrl.ListBox.SelectedItem) = False Then
                Me.lstAsmUrl.Items.Add(Me.umblstAsmUrl.ListBox.SelectedItem)
                Saved = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsmiAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAbout.Click
        Me.tcCSE.SelectedTab = Me.tpabout
    End Sub

    Private Sub tsmiRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRef.Click
        Me.tcCSE.SelectedTab = Me.tpref
    End Sub

    Private Sub tsmiImps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiImps.Click
        Me.tcCSE.SelectedTab = Me.tpimts
    End Sub

    Private Sub tmsiDescl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsiDescl.Click
        Me.tcCSE.SelectedTab = Me.tpdecs
    End Sub

    Private Sub tsmiCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCodes.Click
        Me.tcCSE.SelectedTab = Me.tpcode
    End Sub

    Private Sub tsmiHdr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiHdr.Click
        Me.tcCSE.SelectedTab = Me.tphdr
    End Sub

    Private Sub wbAbout_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbAbout.DocumentCompleted
        If wbAbout.Document.Title.ToLower <> "chcse" Then
            Try
                wbAbout.Document.Write(My.Resources.hpAbout)
            Catch ex As Exception
            End Try
        End If
        Me.wbAbout.Visible = True
    End Sub


    Private Sub tcCSE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcCSE.SelectedIndexChanged
        'http://chcse.mysticboy.com.cn

        If tcCSE.SelectedTab.Name = Me.tpabout.Name Then
            Me.wbAbout.Visible = False
            wbAbout.Navigate("http://chcse.mysticboy.com.cn")
        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            'RegExt()
        Catch ex As Exception
        End Try
        Try
            If My.Settings.frmmain_location.X = 0 And My.Settings.frmmain_location.Y = 0 Then
                Me.Location = New Point(My.Computer.Screen.WorkingArea.Width / 2 - Me.Width / 2, My.Computer.Screen.WorkingArea.Height / 2 - Me.Height / 2)
            Else
                Me.Location = My.Settings.frmmain_location

            End If
        Catch ex As Exception
        End Try
        'Try
        '    If My.Application.CommandLineArgs.Count >= 1 Then
        '        If My.Computer.FileSystem.FileExists(My.Application.CommandLineArgs(0)) = True Then
        '            Me.XLoad(My.Application.CommandLineArgs(0))
        '        Else
        '            MsgBox("������Ч!" & My.Application.CommandLineArgs(0))
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub frmMain_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Try
            My.Settings.frmmain_location = Me.Location
        Catch ex As Exception
        End Try
    End Sub


    'Private Function GetUserInf(ByRef kNamev As String, ByRef kPass As String, ByRef kType As Short) As String
    '    On Error Resume Next 'still here just as a precaution
    '    Dim cTable(512) As Short 'character map
    '    Dim nKeys(16) As Short 'xor keys used for pArray(x) xor nkeys(x)
    '    Dim s0(512) As Short 'swap-box data used to map character table
    '    Dim nArray(16) As Short 'name array data
    '    Dim pArray(16) As Short 'password array data
    '    Dim n As Short 'for next loop counter
    '    Dim nPtr As Short 'name pointer (used for counting)
    '    Dim cPtr As Short 'character pointer (used for counting)
    '    Dim cFlip As Boolean 'character flip (used to flip between numeric and alpha)
    '    Dim sIni As Short 'holds s-box values
    '    Dim temp As Short 'holds s-box values
    '    Dim rtn As Short 'holds generated key values used agains chr map
    '    Dim gKey As String 'generated key as string
    '    Dim nLen As Short 'number of chr's in name
    '    Dim pLen As Short 'number of chr's in password
    '    Dim kPtr As Short 'key pointer
    '    Dim sPtr As Short 'space pointer (used in hex key)
    '    Dim nOffset As Short 'name offset
    '    Dim pOffset As Short 'password offset
    '    Dim tOffset As Short 'total offset
    '    Dim KeySize As Short 'the size of the key to make

    '    Const nXor As Short = 18 'name xor value
    '    Const pXor As Short = 25 'password xor value
    '    Const cLw As Short = 65 'character lower limit 65 = A ** do not change **
    '    Const nLw As Short = 48 'number lower limit 48 = 0 ** do not change **
    '    Const sOffset As Short = 0 'character map offset
    '    Dim VarType_Renamed As String
    '    Dim kName As String
    '    Dim AryCtl As Short
    '    'Dim AryCtrl As System.Windows.Forms.Control

    '    kName = kNamev


    '    nLen = Len(kName)
    '    pLen = Len(kPass)

    '    nKeys(1) = 46
    '    nKeys(2) = 89
    '    nKeys(3) = 142
    '    nKeys(4) = 63
    '    nKeys(5) = 231
    '    nKeys(6) = 32
    '    nKeys(7) = 129
    '    nKeys(8) = 51
    '    nKeys(9) = 28
    '    nKeys(10) = 97
    '    nKeys(11) = 248
    '    nKeys(12) = 41
    '    nKeys(13) = 136
    '    nKeys(14) = 53
    '    nKeys(15) = 78
    '    nKeys(16) = 164

    '    sIni = 0

    '    'set s boxes
    '    For n = 0 To 512
    '        s0(n) = n
    '    Next n

    '    For n = 0 To 512
    '        sIni = (sOffset + sIni + n) Mod 256
    '        temp = s0(n)
    '        s0(n) = s0(sIni)
    '        s0(sIni) = temp
    '    Next n

    '    If kType = 1 Then '(numeric)

    '        nPtr = 0
    '        KeySize = 16
    '        gKey = New String(" ", 16)

    '        For n = 0 To 512
    '            cTable(s0(n)) = (nLw + (nPtr))
    '            nPtr = nPtr + 1
    '            If nPtr = 10 Then nPtr = 0
    '        Next n



    '    ElseIf kType = 2 Then  '(alphanumeric)

    '        nPtr = 0
    '        cPtr = 0
    '        KeySize = 16
    '        gKey = New String(" ", 16)

    '        cFlip = False
    '        For n = 0 To 512
    '            If cFlip Then
    '                cTable(s0(n)) = (nLw + nPtr)
    '                nPtr = nPtr + 1
    '                If nPtr = 10 Then nPtr = 0
    '                cFlip = False
    '            Else
    '                cTable(s0(n)) = (cLw + cPtr)
    '                cPtr = cPtr + 1
    '                If cPtr = 26 Then cPtr = 0
    '                cFlip = True
    '            End If
    '        Next n



    '    Else '(hex)

    '        KeySize = 8
    '        gKey = New String(" ", 19)

    '    End If

    '    kPtr = 1

    '    For n = 1 To nLen 'name
    '        nArray(kPtr) = nArray(kPtr) + Asc(Mid(kName, n, 1)) Xor nXor
    '        nOffset = nOffset + nArray(kPtr)
    '        kPtr = kPtr + 1
    '        If kPtr = 9 Then kPtr = 1
    '    Next n

    '    For n = 1 To pLen 'password
    '        pArray(kPtr) = pArray(kPtr) + Asc(Mid(kPass, n, 1)) Xor pXor
    '        pOffset = pOffset + pArray(kPtr)
    '        kPtr = kPtr + 1
    '        If kPtr = 9 Then kPtr = 1
    '    Next n

    '    tOffset = (nOffset + pOffset) Mod 512

    '    kPtr = 1
    '    sPtr = 1
    '    For n = 1 To KeySize
    '        pArray(n) = pArray(n) Xor nKeys(n)
    '        rtn = System.Math.Abs(((nArray(n) Xor pArray(n)) Mod 512) - tOffset)

    '        If kType = 3 Then 'hex key
    '            If rtn < 16 Then
    '                Mid(gKey, kPtr, 2) = "0" & Hex(rtn)
    '            Else
    '                Mid(gKey, kPtr, 2) = Hex(rtn)
    '            End If
    '            If sPtr = 2 And kPtr < 18 Then
    '                kPtr = kPtr + 1
    '                Mid(gKey, kPtr + 1, 1) = "-"
    '            End If
    '            kPtr = kPtr + 2
    '            sPtr = sPtr + 1
    '            If sPtr = 3 Then sPtr = 1
    '        Else 'numeric - alphanumeric key
    '            Mid(gKey, n, 1) = Chr(cTable(rtn))
    '        End If
    '    Next
    '    Return gKey
    'End Function

    Private Sub tsmiCheckRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiCheckRule.Click
        CheckItOK(1)
    End Sub

    Public Function CheckItOK(Optional ByVal level As Long = 0) As Boolean
        SetState("���ڼ�������Ϣ����", 5)
        Dim tm As String = ""
        If Me.txtTitle.Text.Trim.Length = 0 Then
            MsgBox("����������Ϊ��", MsgBoxStyle.Information)
            Me.tcCSE.SelectTab(Me.tphdr)
            Me.txtTitle.Show()
            SetState("", 0)
            Return False
        End If
        If Me.txtShortcut.Text.Trim.Length = 0 Then
            MsgBox("����ַ�������Ϊ��!", MsgBoxStyle.Information)
            Me.tcCSE.SelectTab(Me.tphdr)
            Me.txtShortcut.Show()
            SetState("", 0)
            Return False
        End If
        If Me.cmbLanguage.Text.Trim.Length = 0 Then
            MsgBox("�����Ǳ���ѡ���,��ѡ������ʺ�����������!", MsgBoxStyle.Information)
            Me.tcCSE.SelectTab(Me.tphdr)
            Me.cmbLanguage.Show()
            SetState("", 0)
            Return False
        End If
        If Me.txtCode.Text.Trim.Length = 0 Then
            MsgBox("��û�б�д�κδ����,����д����!", MsgBoxStyle.Information)
            Me.tcCSE.SelectTab(Me.tpcode)
            Me.txtCode.Show()
            SetState("", 0)
            Return False
        End If

        If level = 1 Then
            SetState("�������������", 40)
            For Each tm In Me.umbdeLiteral.umblstIDS.ListBox.Items
                If Me.txtCode.Text.ToLower.Contains(Me.txtSpa.Text & tm.Trim.ToLower & Me.txtSpa.Text) = False Then
                    MsgBox("�ڴ������Ҫʹ�õ��������� '" & tm & "' û��ʹ��!����ɾ��", MsgBoxStyle.Information, "������")
                    With Me.umbdeLiteral.umblstIDS.ListBox
                        .SelectedItem = tm
                    End With
                    Me.tcCSE.SelectTab(Me.tpdecs)
                    SetState("", 0)
                    Return False
                End If
            Next
            SetState(60)
            For Each tm In Me.umbdeObject.umblstIDS.ListBox.Items
                If Me.txtCode.Text.ToLower.Contains(Me.txtSpa.Text & tm.Trim.ToLower & Me.txtSpa.Text) = False Then
                    MsgBox("�ڴ������Ҫʹ�õĶ������� '" & tm & "' û��ʹ��!����ɾ��", MsgBoxStyle.Information, "������")
                    With Me.umbdeObject.umblstIDS.ListBox
                        .SelectedItem = tm
                    End With
                    Me.tcCSE.SelectTab(Me.tpdecs)
                    SetState("", 0)
                    Return False
                End If
            Next
            SetState(70)
            If (UBound(Me.txtCode.Text.Split(Me.txtSpa.Text)) Mod 2) = 1 Then
                MsgBox("�ڴ��봰���зָ�����'" & Me.txtSpa.Text & "'�����!", MsgBoxStyle.Information)
                Me.tcCSE.SelectTab(Me.tpcode)
                Me.txtCode.Show()
                SetState("", 0)
                Return False
            Else
                Dim n As Long
                Dim cnt As Boolean
                Dim arys As String() = Me.txtCode.Text.Split(Me.txtSpa.Text)
                SetState(90)
                For n = 1 To UBound(arys) Step 2
                    Try
                        cnt = Me.umbdeObject.umblstIDS.ListBox.Items.Contains(arys(n)) _
                          Or Me.umbdeLiteral.umblstIDS.ListBox.Items.Contains(arys(n))
                        '���Сд�ǲ���Ҳ�������
                    Catch ex As Exception
                    End Try


                    If cnt = False Then
                        MsgBox("���ڴ����ж����'" & arys(n) & "'û���ڶ����б��л������б�������!" & vbCrLf & _
                               "ע��:�ô��ļ�����ִ�Сд,�������Сд�Ƿ�ƥ��!", MsgBoxStyle.Information)
                        Me.tcCSE.SelectTab(Me.tpcode)
                        Me.txtCode.Show()
                        Try
                            Dim sts As String = Me.txtSpa.Text & arys(n) & Me.txtSpa.Text
                            Me.txtCode.Select(InStr(Me.txtCode.Text, sts), sts.Length)
                        Catch ex As Exception
                        End Try
                        SetState("", 0)
                        Return False
                    End If
                Next
            End If
        End If
        SetState("���������", 100)
        SetState(0)
        Return True
    End Function

    Private Sub tmsiLearn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmsiLearn.Click
        Me.tmsiLearn.Checked = Not Me.tmsiLearn.Checked
    End Sub



    Public Function RegExt() As Boolean
        Dim cmd As String = """" & My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.Length = 3, "", "\") & My.Application.Info.AssemblyName & ".exe"" ""%1"""
        Dim hk As String = "HKEY_CLASSES_ROOT\Applications\" & My.Application.Info.AssemblyName & ".exe" & "\shell\open\command\"
        Dim lc As String = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.snippet"
        Dim name As String = My.Application.Info.AssemblyName & ".exe"
        If My.Computer.Registry.GetValue(hk, "", "") <> cmd Then
            My.Computer.Registry.ClassesRoot.CreateSubKey("Applications\" & name & "\shell\open\command\", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            My.Computer.Registry.SetValue(hk, "", cmd)
            If My.Computer.Registry.GetValue(lc, "Application", "") <> name Then
                My.Computer.Registry.SetValue(lc, "Application", name)
            End If
        End If
    End Function

End Class

<Microsoft.VisualBasic.ComClass()> Public Class Connect
    Dim CSE As New frmMain
    Public Sub SetCodeText(ByVal txtCode As String)
        CSE.txtCode.Text = txtCode
    End Sub
    Public Function GetSinppetXmlPath() As String
        Return CSE.FileName
    End Function

    Public Sub Show()
        CSE.Show()
    End Sub
    Public Sub Show(ByVal txtText As Object)
        CSE.Show()
        CSE.XLoad(txtText)
    End Sub
    Public Sub Show(ByVal xFileName As String)
        CSE.Show()
        CSE.XLoad(xFileName)
    End Sub
    Public Sub Close()
        CSE.Close()
    End Sub
    Public Sub Close(ByVal xFileName As String)
        CSE.XSave(xFileName)
        CSE.Close()
    End Sub
    Public Sub Close(ByRef txtText As Object)
        CSE.XSave(txtText)
        CSE.Close()
    End Sub
    ''' <summary>
    ''' ���õ�ǰѡ�
    ''' </summary>
    ''' <param name="tpName">tphdr,tpcode,tpdesc,tpimts,tpref,tpabout</param>
    ''' <remarks></remarks>
    Public Sub SetTabPage(ByVal tpName As String)
        Try
            CSE.tcCSE.SelectTab(tpName)
        Catch ex As Exception
        End Try
    End Sub

End Class