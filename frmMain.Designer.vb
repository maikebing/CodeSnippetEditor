<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tcCSE = New System.Windows.Forms.TabControl
        Me.tphdr = New System.Windows.Forms.TabPage
        Me.umblstKeyword = New CodeSnippetEditor.ucMysticBoy_ListBox
        Me.cbsSurroundsWith = New System.Windows.Forms.CheckBox
        Me.cbsExpansion = New System.Windows.Forms.CheckBox
        Me.lblCST = New System.Windows.Forms.Label
        Me.lblKeyword = New System.Windows.Forms.Label
        Me.lblHelpUrl = New System.Windows.Forms.Label
        Me.lblCSDesc = New System.Windows.Forms.Label
        Me.lblAuthor = New System.Windows.Forms.Label
        Me.lblShortcut = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtAuthor = New System.Windows.Forms.TextBox
        Me.txtHelpUrl = New System.Windows.Forms.TextBox
        Me.txtCSDesc = New System.Windows.Forms.TextBox
        Me.txtShortcut = New System.Windows.Forms.TextBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.tpcode = New System.Windows.Forms.TabPage
        Me.lblInX = New System.Windows.Forms.Label
        Me.cmbLanguage = New System.Windows.Forms.ComboBox
        Me.cmbInsType = New System.Windows.Forms.ComboBox
        Me.txtSpa = New System.Windows.Forms.TextBox
        Me.lblInsType = New System.Windows.Forms.Label
        Me.lblSpa = New System.Windows.Forms.Label
        Me.lblLanguage = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.tpdecs = New System.Windows.Forms.TabPage
        Me.gbsLiteral = New System.Windows.Forms.GroupBox
        Me.umbdeLiteral = New CodeSnippetEditor.ucMysticBoy_DeclEdit
        Me.gbsObject = New System.Windows.Forms.GroupBox
        Me.umbdeObject = New CodeSnippetEditor.ucMysticBoy_DeclEdit
        Me.tpimts = New System.Windows.Forms.TabPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.umblstNamespace = New CodeSnippetEditor.ucMysticBoy_ListBox
        Me.lstNamespace = New System.Windows.Forms.ListBox
        Me.tpref = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnAsmUrlAdd = New System.Windows.Forms.Button
        Me.btnAsmUrlRemove = New System.Windows.Forms.Button
        Me.lblAsmurl = New System.Windows.Forms.Label
        Me.lblAsmlist = New System.Windows.Forms.Label
        Me.lstAsmUrl = New System.Windows.Forms.ListBox
        Me.umblstAsmUrl = New CodeSnippetEditor.ucMysticBoy_ListBox
        Me.tpabout = New System.Windows.Forms.TabPage
        Me.wbAbout = New System.Windows.Forms.WebBrowser
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblVer = New System.Windows.Forms.Label
        Me.lblMysticBoy = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tpMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.msMain = New System.Windows.Forms.MenuStrip
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiNew = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiLineFile1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiSave = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiLineFile2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiOptional = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHdr = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiCodes = New System.Windows.Forms.ToolStripMenuItem
        Me.tmsiDescl = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiImps = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiRef = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiTool = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiCheckRule = New System.Windows.Forms.ToolStripMenuItem
        Me.tmsiLearn = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.ssMain = New System.Windows.Forms.StatusStrip
        Me.tsslblState = New System.Windows.Forms.ToolStripStatusLabel
        Me.tspbState = New System.Windows.Forms.ToolStripProgressBar
        Me.ofdOpenFile = New System.Windows.Forms.OpenFileDialog
        Me.sfdSaveFile = New System.Windows.Forms.SaveFileDialog
        Me.tcCSE.SuspendLayout()
        Me.tphdr.SuspendLayout()
        Me.tpcode.SuspendLayout()
        Me.tpdecs.SuspendLayout()
        Me.gbsLiteral.SuspendLayout()
        Me.gbsObject.SuspendLayout()
        Me.tpimts.SuspendLayout()
        Me.tpref.SuspendLayout()
        Me.tpabout.SuspendLayout()
        Me.msMain.SuspendLayout()
        Me.ssMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCSE
        '
        Me.tcCSE.Controls.Add(Me.tphdr)
        Me.tcCSE.Controls.Add(Me.tpcode)
        Me.tcCSE.Controls.Add(Me.tpdecs)
        Me.tcCSE.Controls.Add(Me.tpimts)
        Me.tcCSE.Controls.Add(Me.tpref)
        Me.tcCSE.Controls.Add(Me.tpabout)
        resources.ApplyResources(Me.tcCSE, "tcCSE")
        Me.tcCSE.Name = "tcCSE"
        Me.tcCSE.SelectedIndex = 0
        '
        'tphdr
        '
        Me.tphdr.Controls.Add(Me.umblstKeyword)
        Me.tphdr.Controls.Add(Me.cbsSurroundsWith)
        Me.tphdr.Controls.Add(Me.cbsExpansion)
        Me.tphdr.Controls.Add(Me.lblCST)
        Me.tphdr.Controls.Add(Me.lblKeyword)
        Me.tphdr.Controls.Add(Me.lblHelpUrl)
        Me.tphdr.Controls.Add(Me.lblCSDesc)
        Me.tphdr.Controls.Add(Me.lblAuthor)
        Me.tphdr.Controls.Add(Me.lblShortcut)
        Me.tphdr.Controls.Add(Me.lblTitle)
        Me.tphdr.Controls.Add(Me.txtAuthor)
        Me.tphdr.Controls.Add(Me.txtHelpUrl)
        Me.tphdr.Controls.Add(Me.txtCSDesc)
        Me.tphdr.Controls.Add(Me.txtShortcut)
        Me.tphdr.Controls.Add(Me.txtTitle)
        Me.tphdr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_tphdr", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tphdr, "tphdr")
        Me.tphdr.Name = "tphdr"
        Me.tphdr.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tphdr
        Me.tphdr.UseVisualStyleBackColor = True
        '
        'umblstKeyword
        '
        resources.ApplyResources(Me.umblstKeyword, "umblstKeyword")
        Me.umblstKeyword.Name = "umblstKeyword"
        '
        'cbsSurroundsWith
        '
        Me.cbsSurroundsWith.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_cbsSurroundsWith", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.cbsSurroundsWith, "cbsSurroundsWith")
        Me.cbsSurroundsWith.Name = "cbsSurroundsWith"
        Me.cbsSurroundsWith.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_cbsSurroundsWith
        Me.tpMain.SetToolTip(Me.cbsSurroundsWith, resources.GetString("cbsSurroundsWith.ToolTip"))
        Me.cbsSurroundsWith.UseCompatibleTextRendering = True
        Me.cbsSurroundsWith.UseVisualStyleBackColor = True
        '
        'cbsExpansion
        '
        Me.cbsExpansion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_cbsExpansion", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.cbsExpansion, "cbsExpansion")
        Me.cbsExpansion.Name = "cbsExpansion"
        Me.cbsExpansion.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_cbsExpansion
        Me.tpMain.SetToolTip(Me.cbsExpansion, resources.GetString("cbsExpansion.ToolTip"))
        Me.cbsExpansion.UseVisualStyleBackColor = True
        '
        'lblCST
        '
        resources.ApplyResources(Me.lblCST, "lblCST")
        Me.lblCST.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblCST", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblCST.Name = "lblCST"
        Me.lblCST.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblCST
        '
        'lblKeyword
        '
        resources.ApplyResources(Me.lblKeyword, "lblKeyword")
        Me.lblKeyword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblKeyword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblKeyword.Name = "lblKeyword"
        Me.lblKeyword.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblKeyword
        '
        'lblHelpUrl
        '
        resources.ApplyResources(Me.lblHelpUrl, "lblHelpUrl")
        Me.lblHelpUrl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblHelpUrl", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblHelpUrl.Name = "lblHelpUrl"
        Me.lblHelpUrl.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblHelpUrl
        '
        'lblCSDesc
        '
        resources.ApplyResources(Me.lblCSDesc, "lblCSDesc")
        Me.lblCSDesc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblCSDesc", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblCSDesc.Name = "lblCSDesc"
        Me.lblCSDesc.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblCSDesc
        '
        'lblAuthor
        '
        resources.ApplyResources(Me.lblAuthor, "lblAuthor")
        Me.lblAuthor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblAuthor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblAuthor
        '
        'lblShortcut
        '
        resources.ApplyResources(Me.lblShortcut, "lblShortcut")
        Me.lblShortcut.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblShortcut", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblShortcut.Name = "lblShortcut"
        Me.lblShortcut.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblShortcut
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
        Me.lblTitle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblTitle", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblTitle
        '
        'txtAuthor
        '
        resources.ApplyResources(Me.txtAuthor, "txtAuthor")
        Me.txtAuthor.Name = "txtAuthor"
        '
        'txtHelpUrl
        '
        resources.ApplyResources(Me.txtHelpUrl, "txtHelpUrl")
        Me.txtHelpUrl.Name = "txtHelpUrl"
        '
        'txtCSDesc
        '
        resources.ApplyResources(Me.txtCSDesc, "txtCSDesc")
        Me.txtCSDesc.Name = "txtCSDesc"
        '
        'txtShortcut
        '
        resources.ApplyResources(Me.txtShortcut, "txtShortcut")
        Me.txtShortcut.Name = "txtShortcut"
        '
        'txtTitle
        '
        resources.ApplyResources(Me.txtTitle, "txtTitle")
        Me.txtTitle.Name = "txtTitle"
        '
        'tpcode
        '
        Me.tpcode.Controls.Add(Me.lblInX)
        Me.tpcode.Controls.Add(Me.cmbLanguage)
        Me.tpcode.Controls.Add(Me.cmbInsType)
        Me.tpcode.Controls.Add(Me.txtSpa)
        Me.tpcode.Controls.Add(Me.lblInsType)
        Me.tpcode.Controls.Add(Me.lblSpa)
        Me.tpcode.Controls.Add(Me.lblLanguage)
        Me.tpcode.Controls.Add(Me.txtCode)
        Me.tpcode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_tpcodes", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tpcode, "tpcode")
        Me.tpcode.Name = "tpcode"
        Me.tpcode.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpcodes
        Me.tpcode.UseVisualStyleBackColor = True
        '
        'lblInX
        '
        resources.ApplyResources(Me.lblInX, "lblInX")
        Me.lblInX.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblInx", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblInX.Name = "lblInX"
        Me.lblInX.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblInx
        '
        'cmbLanguage
        '
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.Items.AddRange(New Object() {resources.GetString("cmbLanguage.Items"), resources.GetString("cmbLanguage.Items1"), resources.GetString("cmbLanguage.Items2"), resources.GetString("cmbLanguage.Items3")})
        resources.ApplyResources(Me.cmbLanguage, "cmbLanguage")
        Me.cmbLanguage.Name = "cmbLanguage"
        '
        'cmbInsType
        '
        Me.cmbInsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInsType.FormattingEnabled = True
        Me.cmbInsType.Items.AddRange(New Object() {resources.GetString("cmbInsType.Items"), resources.GetString("cmbInsType.Items1"), resources.GetString("cmbInsType.Items2"), resources.GetString("cmbInsType.Items3"), resources.GetString("cmbInsType.Items4"), resources.GetString("cmbInsType.Items5")})
        resources.ApplyResources(Me.cmbInsType, "cmbInsType")
        Me.cmbInsType.Name = "cmbInsType"
        '
        'txtSpa
        '
        resources.ApplyResources(Me.txtSpa, "txtSpa")
        Me.txtSpa.Name = "txtSpa"
        '
        'lblInsType
        '
        resources.ApplyResources(Me.lblInsType, "lblInsType")
        Me.lblInsType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblInsType", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblInsType.Name = "lblInsType"
        Me.lblInsType.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblInsType
        '
        'lblSpa
        '
        resources.ApplyResources(Me.lblSpa, "lblSpa")
        Me.lblSpa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lblspa", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblSpa.Name = "lblSpa"
        Me.lblSpa.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lblspa
        '
        'lblLanguage
        '
        resources.ApplyResources(Me.lblLanguage, "lblLanguage")
        Me.lblLanguage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_lbllanguage", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_lbllanguage
        '
        'txtCode
        '
        resources.ApplyResources(Me.txtCode, "txtCode")
        Me.txtCode.Name = "txtCode"
        Me.tpMain.SetToolTip(Me.txtCode, resources.GetString("txtCode.ToolTip"))
        '
        'tpdecs
        '
        Me.tpdecs.Controls.Add(Me.gbsLiteral)
        Me.tpdecs.Controls.Add(Me.gbsObject)
        Me.tpdecs.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_tpdecs", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tpdecs, "tpdecs")
        Me.tpdecs.Name = "tpdecs"
        Me.tpdecs.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpdecs
        Me.tpdecs.UseVisualStyleBackColor = True
        '
        'gbsLiteral
        '
        Me.gbsLiteral.Controls.Add(Me.umbdeLiteral)
        Me.gbsLiteral.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_gbsLiteral", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.gbsLiteral, "gbsLiteral")
        Me.gbsLiteral.Name = "gbsLiteral"
        Me.gbsLiteral.TabStop = False
        Me.gbsLiteral.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_gbsLiteral
        '
        'umbdeLiteral
        '
        resources.ApplyResources(Me.umbdeLiteral, "umbdeLiteral")
        Me.umbdeLiteral.DeclType = CodeSnippetEditor.ucMysticBoy_DeclEdit.deDecl.dLiteral
        Me.umbdeLiteral.Name = "umbdeLiteral"
        '
        'gbsObject
        '
        Me.gbsObject.Controls.Add(Me.umbdeObject)
        Me.gbsObject.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_gbsObject", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.gbsObject, "gbsObject")
        Me.gbsObject.Name = "gbsObject"
        Me.gbsObject.TabStop = False
        Me.gbsObject.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_gbsObject
        '
        'umbdeObject
        '
        resources.ApplyResources(Me.umbdeObject, "umbdeObject")
        Me.umbdeObject.DeclType = CodeSnippetEditor.ucMysticBoy_DeclEdit.deDecl.dObject
        Me.umbdeObject.Name = "umbdeObject"
        '
        'tpimts
        '
        Me.tpimts.Controls.Add(Me.Label6)
        Me.tpimts.Controls.Add(Me.Label3)
        Me.tpimts.Controls.Add(Me.Label2)
        Me.tpimts.Controls.Add(Me.btnAdd)
        Me.tpimts.Controls.Add(Me.Label1)
        Me.tpimts.Controls.Add(Me.btnRemove)
        Me.tpimts.Controls.Add(Me.umblstNamespace)
        Me.tpimts.Controls.Add(Me.lstNamespace)
        Me.tpimts.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_tpimts", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tpimts, "tpimts")
        Me.tpimts.Name = "tpimts"
        Me.tpimts.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpimts
        Me.tpimts.UseVisualStyleBackColor = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'umblstNamespace
        '
        resources.ApplyResources(Me.umblstNamespace, "umblstNamespace")
        Me.umblstNamespace.Name = "umblstNamespace"
        '
        'lstNamespace
        '
        Me.lstNamespace.FormattingEnabled = True
        resources.ApplyResources(Me.lstNamespace, "lstNamespace")
        Me.lstNamespace.Name = "lstNamespace"
        '
        'tpref
        '
        Me.tpref.Controls.Add(Me.Label5)
        Me.tpref.Controls.Add(Me.Label4)
        Me.tpref.Controls.Add(Me.btnAsmUrlAdd)
        Me.tpref.Controls.Add(Me.btnAsmUrlRemove)
        Me.tpref.Controls.Add(Me.lblAsmurl)
        Me.tpref.Controls.Add(Me.lblAsmlist)
        Me.tpref.Controls.Add(Me.lstAsmUrl)
        Me.tpref.Controls.Add(Me.umblstAsmUrl)
        Me.tpref.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CodeSnippetEditor.My.MySettings.Default, "frmmain_tpref", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.tpref, "tpref")
        Me.tpref.Name = "tpref"
        Me.tpref.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpref
        Me.tpref.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'btnAsmUrlAdd
        '
        resources.ApplyResources(Me.btnAsmUrlAdd, "btnAsmUrlAdd")
        Me.btnAsmUrlAdd.Name = "btnAsmUrlAdd"
        Me.btnAsmUrlAdd.UseVisualStyleBackColor = True
        '
        'btnAsmUrlRemove
        '
        resources.ApplyResources(Me.btnAsmUrlRemove, "btnAsmUrlRemove")
        Me.btnAsmUrlRemove.Name = "btnAsmUrlRemove"
        Me.btnAsmUrlRemove.UseVisualStyleBackColor = True
        '
        'lblAsmurl
        '
        resources.ApplyResources(Me.lblAsmurl, "lblAsmurl")
        Me.lblAsmurl.Name = "lblAsmurl"
        '
        'lblAsmlist
        '
        resources.ApplyResources(Me.lblAsmlist, "lblAsmlist")
        Me.lblAsmlist.Name = "lblAsmlist"
        '
        'lstAsmUrl
        '
        Me.lstAsmUrl.FormattingEnabled = True
        resources.ApplyResources(Me.lstAsmUrl, "lstAsmUrl")
        Me.lstAsmUrl.Name = "lstAsmUrl"
        '
        'umblstAsmUrl
        '
        resources.ApplyResources(Me.umblstAsmUrl, "umblstAsmUrl")
        Me.umblstAsmUrl.Name = "umblstAsmUrl"
        Me.tpMain.SetToolTip(Me.umblstAsmUrl, resources.GetString("umblstAsmUrl.ToolTip"))
        '
        'tpabout
        '
        Me.tpabout.Controls.Add(Me.wbAbout)
        Me.tpabout.Controls.Add(Me.Label8)
        Me.tpabout.Controls.Add(Me.lblVer)
        Me.tpabout.Controls.Add(Me.lblMysticBoy)
        Me.tpabout.Controls.Add(Me.Label7)
        resources.ApplyResources(Me.tpabout, "tpabout")
        Me.tpabout.Name = "tpabout"
        Me.tpabout.UseVisualStyleBackColor = True
        '
        'wbAbout
        '
        Me.wbAbout.AllowWebBrowserDrop = False
        Me.wbAbout.IsWebBrowserContextMenuEnabled = False
        resources.ApplyResources(Me.wbAbout, "wbAbout")
        Me.wbAbout.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbAbout.Name = "wbAbout"
        Me.wbAbout.ScrollBarsEnabled = False
        Me.wbAbout.Url = New System.Uri("", System.UriKind.Relative)
        Me.wbAbout.WebBrowserShortcutsEnabled = False
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'lblVer
        '
        resources.ApplyResources(Me.lblVer, "lblVer")
        Me.lblVer.Name = "lblVer"
        '
        'lblMysticBoy
        '
        resources.ApplyResources(Me.lblMysticBoy, "lblMysticBoy")
        Me.lblMysticBoy.ForeColor = System.Drawing.Color.Navy
        Me.lblMysticBoy.Name = "lblMysticBoy"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Name = "Label7"
        '
        'msMain
        '
        resources.ApplyResources(Me.msMain, "msMain")
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile, Me.tsmiOptional, Me.tsmiTool, Me.tsmiHelp})
        Me.msMain.Name = "msMain"
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNew, Me.tsmiOpen, Me.tsmiLineFile1, Me.tsmiSave, Me.tsmiSaveAs, Me.tsmiLineFile2, Me.tsmiExit})
        Me.tsmiFile.Name = "tsmiFile"
        resources.ApplyResources(Me.tsmiFile, "tsmiFile")
        Me.tsmiFile.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiFile
        '
        'tsmiNew
        '
        Me.tsmiNew.Image = Global.CodeSnippetEditor.My.Resources.Resources._NEW
        resources.ApplyResources(Me.tsmiNew, "tsmiNew")
        Me.tsmiNew.Name = "tsmiNew"
        Me.tsmiNew.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiNew
        '
        'tsmiOpen
        '
        Me.tsmiOpen.Image = Global.CodeSnippetEditor.My.Resources.Resources.OPEN
        resources.ApplyResources(Me.tsmiOpen, "tsmiOpen")
        Me.tsmiOpen.Name = "tsmiOpen"
        Me.tsmiOpen.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiOpen
        '
        'tsmiLineFile1
        '
        Me.tsmiLineFile1.Name = "tsmiLineFile1"
        resources.ApplyResources(Me.tsmiLineFile1, "tsmiLineFile1")
        '
        'tsmiSave
        '
        Me.tsmiSave.Image = Global.CodeSnippetEditor.My.Resources.Resources.SAVE
        resources.ApplyResources(Me.tsmiSave, "tsmiSave")
        Me.tsmiSave.Name = "tsmiSave"
        Me.tsmiSave.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiSave
        '
        'tsmiSaveAs
        '
        Me.tsmiSaveAs.Name = "tsmiSaveAs"
        resources.ApplyResources(Me.tsmiSaveAs, "tsmiSaveAs")
        Me.tsmiSaveAs.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiSaveAs
        '
        'tsmiLineFile2
        '
        Me.tsmiLineFile2.Name = "tsmiLineFile2"
        resources.ApplyResources(Me.tsmiLineFile2, "tsmiLineFile2")
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        resources.ApplyResources(Me.tsmiExit, "tsmiExit")
        Me.tsmiExit.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiExit
        '
        'tsmiOptional
        '
        Me.tsmiOptional.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHdr, Me.tsmiCodes, Me.tmsiDescl, Me.tsmiImps, Me.tsmiRef})
        Me.tsmiOptional.Name = "tsmiOptional"
        resources.ApplyResources(Me.tsmiOptional, "tsmiOptional")
        Me.tsmiOptional.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiOptional
        '
        'tsmiHdr
        '
        Me.tsmiHdr.Name = "tsmiHdr"
        resources.ApplyResources(Me.tsmiHdr, "tsmiHdr")
        Me.tsmiHdr.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiConfig
        '
        'tsmiCodes
        '
        Me.tsmiCodes.Name = "tsmiCodes"
        resources.ApplyResources(Me.tsmiCodes, "tsmiCodes")
        Me.tsmiCodes.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpcodes
        '
        'tmsiDescl
        '
        Me.tmsiDescl.Name = "tmsiDescl"
        resources.ApplyResources(Me.tmsiDescl, "tmsiDescl")
        Me.tmsiDescl.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpdecs
        '
        'tsmiImps
        '
        Me.tsmiImps.Name = "tsmiImps"
        resources.ApplyResources(Me.tsmiImps, "tsmiImps")
        Me.tsmiImps.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpimts
        '
        'tsmiRef
        '
        Me.tsmiRef.Name = "tsmiRef"
        resources.ApplyResources(Me.tsmiRef, "tsmiRef")
        Me.tsmiRef.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tpref
        '
        'tsmiTool
        '
        Me.tsmiTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCheckRule, Me.tmsiLearn})
        Me.tsmiTool.Name = "tsmiTool"
        resources.ApplyResources(Me.tsmiTool, "tsmiTool")
        Me.tsmiTool.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmmain_tmsitools
        '
        'tsmiCheckRule
        '
        Me.tsmiCheckRule.Image = Global.CodeSnippetEditor.My.Resources.Resources.SPELLING
        resources.ApplyResources(Me.tsmiCheckRule, "tsmiCheckRule")
        Me.tsmiCheckRule.Name = "tsmiCheckRule"
        Me.tsmiCheckRule.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmicheckrule
        '
        'tmsiLearn
        '
        Me.tmsiLearn.Checked = Global.CodeSnippetEditor.My.MySettings.Default.csSaveCheck
        Me.tmsiLearn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tmsiLearn.Name = "tmsiLearn"
        resources.ApplyResources(Me.tmsiLearn, "tmsiLearn")
        Me.tmsiLearn.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiLearn
        '
        'tsmiHelp
        '
        Me.tsmiHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAbout})
        Me.tsmiHelp.Name = "tsmiHelp"
        resources.ApplyResources(Me.tsmiHelp, "tsmiHelp")
        Me.tsmiHelp.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiHelp
        '
        'tsmiAbout
        '
        Me.tsmiAbout.Image = Global.CodeSnippetEditor.My.Resources.Resources.ces
        resources.ApplyResources(Me.tsmiAbout, "tsmiAbout")
        Me.tsmiAbout.Name = "tsmiAbout"
        Me.tsmiAbout.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiAbout
        '
        'ssMain
        '
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslblState, Me.tspbState})
        resources.ApplyResources(Me.ssMain, "ssMain")
        Me.ssMain.Name = "ssMain"
        '
        'tsslblState
        '
        resources.ApplyResources(Me.tsslblState, "tsslblState")
        Me.tsslblState.Name = "tsslblState"
        Me.tsslblState.Spring = True
        '
        'tspbState
        '
        Me.tspbState.Name = "tspbState"
        resources.ApplyResources(Me.tspbState, "tspbState")
        '
        'ofdOpenFile
        '
        Me.ofdOpenFile.DefaultExt = "snippet"
        Me.ofdOpenFile.Filter = Global.CodeSnippetEditor.My.MySettings.Default.SnippetFileFilter
        Me.ofdOpenFile.InitialDirectory = Global.CodeSnippetEditor.My.MySettings.Default.FileDlgInitialDirectory
        Me.ofdOpenFile.Title = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_ofdOpenFile_Title
        '
        'sfdSaveFile
        '
        Me.sfdSaveFile.DefaultExt = "snippet"
        Me.sfdSaveFile.Filter = Global.CodeSnippetEditor.My.MySettings.Default.SnippetFileFilter
        Me.sfdSaveFile.InitialDirectory = Global.CodeSnippetEditor.My.MySettings.Default.FileDlgInitialDirectory
        Me.sfdSaveFile.Title = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_sfdsavefile_title
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.tcCSE)
        Me.Controls.Add(Me.msMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.msMain
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.tcCSE.ResumeLayout(False)
        Me.tphdr.ResumeLayout(False)
        Me.tphdr.PerformLayout()
        Me.tpcode.ResumeLayout(False)
        Me.tpcode.PerformLayout()
        Me.tpdecs.ResumeLayout(False)
        Me.gbsLiteral.ResumeLayout(False)
        Me.gbsObject.ResumeLayout(False)
        Me.tpimts.ResumeLayout(False)
        Me.tpimts.PerformLayout()
        Me.tpref.ResumeLayout(False)
        Me.tpref.PerformLayout()
        Me.tpabout.ResumeLayout(False)
        Me.tpabout.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcCSE As System.Windows.Forms.TabControl
    Friend WithEvents tphdr As System.Windows.Forms.TabPage
    Friend WithEvents tpimts As System.Windows.Forms.TabPage
    Friend WithEvents tpref As System.Windows.Forms.TabPage
    Friend WithEvents tpdecs As System.Windows.Forms.TabPage
    Friend WithEvents tpcode As System.Windows.Forms.TabPage
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtShortcut As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents txtHelpUrl As System.Windows.Forms.TextBox
    Friend WithEvents txtCSDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblShortcut As System.Windows.Forms.Label
    Friend WithEvents lblAuthor As System.Windows.Forms.Label
    Friend WithEvents lblCSDesc As System.Windows.Forms.Label
    Friend WithEvents lblHelpUrl As System.Windows.Forms.Label
    Friend WithEvents lblCST As System.Windows.Forms.Label
    Friend WithEvents lblKeyword As System.Windows.Forms.Label
    Friend WithEvents cbsExpansion As System.Windows.Forms.CheckBox
    Friend WithEvents tpMain As System.Windows.Forms.ToolTip
    Friend WithEvents cbsSurroundsWith As System.Windows.Forms.CheckBox
    Friend WithEvents lstNamespace As System.Windows.Forms.ListBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents umblstNamespace As CodeSnippetEditor.ucMysticBoy_ListBox
    Friend WithEvents umblstKeyword As CodeSnippetEditor.ucMysticBoy_ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstAsmUrl As System.Windows.Forms.ListBox
    Friend WithEvents umblstAsmUrl As CodeSnippetEditor.ucMysticBoy_ListBox
    Friend WithEvents lblAsmlist As System.Windows.Forms.Label
    Friend WithEvents lblAsmurl As System.Windows.Forms.Label
    Friend WithEvents btnAsmUrlAdd As System.Windows.Forms.Button
    Friend WithEvents btnAsmUrlRemove As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents cmbInsType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSpa As System.Windows.Forms.TextBox
    Friend WithEvents lblInsType As System.Windows.Forms.Label
    Friend WithEvents lblSpa As System.Windows.Forms.Label
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblInX As System.Windows.Forms.Label
    Friend WithEvents gbsObject As System.Windows.Forms.GroupBox
    Friend WithEvents umbdeObject As CodeSnippetEditor.ucMysticBoy_DeclEdit
    Friend WithEvents gbsLiteral As System.Windows.Forms.GroupBox
    Friend WithEvents umbdeLiteral As CodeSnippetEditor.ucMysticBoy_DeclEdit
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLineFile1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLineFile2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiOptional As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHdr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofdOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslblState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbState As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents sfdSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tpabout As System.Windows.Forms.TabPage
    Friend WithEvents tsmiCodes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsiDescl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiImps As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRef As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMysticBoy As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents wbAbout As System.Windows.Forms.WebBrowser
    Friend WithEvents tsmiTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCheckRule As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsiLearn As System.Windows.Forms.ToolStripMenuItem

End Class
