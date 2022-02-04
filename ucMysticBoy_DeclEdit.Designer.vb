<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMysticBoy_DeclEdit
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMysticBoy_DeclEdit))
        Me.lblIDName = New System.Windows.Forms.Label
        Me.cbsType = New System.Windows.Forms.ComboBox
        Me.txtDefault = New System.Windows.Forms.TextBox
        Me.txtToolTip = New System.Windows.Forms.TextBox
        Me.txtFunction = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.lbldefault = New System.Windows.Forms.Label
        Me.lblToolTip = New System.Windows.Forms.Label
        Me.lblfunction = New System.Windows.Forms.Label
        Me.cbsEditable = New System.Windows.Forms.CheckBox
        Me.umblstIDS = New CodeSnippetEditor.ucMysticBoy_ListBox
        Me.SuspendLayout()
        '
        'lblIDName
        '
        resources.ApplyResources(Me.lblIDName, "lblIDName")
        Me.lblIDName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIDName.Name = "lblIDName"
        '
        'cbsType
        '
        Me.cbsType.FormattingEnabled = True
        resources.ApplyResources(Me.cbsType, "cbsType")
        Me.cbsType.Name = "cbsType"
        Me.cbsType.Sorted = True
        '
        'txtDefault
        '
        resources.ApplyResources(Me.txtDefault, "txtDefault")
        Me.txtDefault.Name = "txtDefault"
        '
        'txtToolTip
        '
        resources.ApplyResources(Me.txtToolTip, "txtToolTip")
        Me.txtToolTip.Name = "txtToolTip"
        '
        'txtFunction
        '
        resources.ApplyResources(Me.txtFunction, "txtFunction")
        Me.txtFunction.Name = "txtFunction"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblType
        '
        resources.ApplyResources(Me.lblType, "lblType")
        Me.lblType.Name = "lblType"
        '
        'lbldefault
        '
        resources.ApplyResources(Me.lbldefault, "lbldefault")
        Me.lbldefault.Name = "lbldefault"
        '
        'lblToolTip
        '
        resources.ApplyResources(Me.lblToolTip, "lblToolTip")
        Me.lblToolTip.Name = "lblToolTip"
        '
        'lblfunction
        '
        resources.ApplyResources(Me.lblfunction, "lblfunction")
        Me.lblfunction.Name = "lblfunction"
        '
        'cbsEditable
        '
        resources.ApplyResources(Me.cbsEditable, "cbsEditable")
        Me.cbsEditable.Checked = True
        Me.cbsEditable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbsEditable.Name = "cbsEditable"
        Me.cbsEditable.UseVisualStyleBackColor = True
        '
        'umblstIDS
        '
        resources.ApplyResources(Me.umblstIDS, "umblstIDS")
        Me.umblstIDS.Name = "umblstIDS"
        '
        'ucMysticBoy_DeclEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbsEditable)
        Me.Controls.Add(Me.lblfunction)
        Me.Controls.Add(Me.lblToolTip)
        Me.Controls.Add(Me.lbldefault)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFunction)
        Me.Controls.Add(Me.txtToolTip)
        Me.Controls.Add(Me.txtDefault)
        Me.Controls.Add(Me.cbsType)
        Me.Controls.Add(Me.lblIDName)
        Me.Controls.Add(Me.umblstIDS)
        Me.DoubleBuffered = True
        Me.Name = "ucMysticBoy_DeclEdit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents umblstIDS As CodeSnippetEditor.ucMysticBoy_ListBox
    Friend WithEvents lblIDName As System.Windows.Forms.Label
    Friend WithEvents cbsType As System.Windows.Forms.ComboBox
    Friend WithEvents txtDefault As System.Windows.Forms.TextBox
    Friend WithEvents txtToolTip As System.Windows.Forms.TextBox
    Friend WithEvents txtFunction As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lbldefault As System.Windows.Forms.Label
    Friend WithEvents lblToolTip As System.Windows.Forms.Label
    Friend WithEvents lblfunction As System.Windows.Forms.Label
    Friend WithEvents cbsEditable As System.Windows.Forms.CheckBox

End Class
