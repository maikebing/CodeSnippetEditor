<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMysticBoy_ListBox
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
        Me.components = New System.ComponentModel.Container
        Me.cmsKeyword = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiAddKeyWord = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiTxtAddKeyword = New System.Windows.Forms.ToolStripTextBox
        Me.tsmiOk = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiCancle = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiEditKeyword = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiTxtEditKeyword = New System.Windows.Forms.ToolStripTextBox
        Me.tsmiEditOK = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiEditCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiLine1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmiDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ListBox = New System.Windows.Forms.ListBox
        Me.cmsKeyword.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsKeyword
        '
        Me.cmsKeyword.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAddKeyWord, Me.tsmiEditKeyword, Me.tsmiLine1, Me.tsmiDelete})
        Me.cmsKeyword.Name = "cmsKeyword"
        Me.cmsKeyword.Size = New System.Drawing.Size(95, 76)
        Me.cmsKeyword.Tag = "该菜单的文本绑定于配置文件中"
        '
        'tsmiAddKeyWord
        '
        Me.tsmiAddKeyWord.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiTxtAddKeyword, Me.tsmiOk, Me.tsmiCancle})
        Me.tsmiAddKeyWord.Name = "tsmiAddKeyWord"
        Me.tsmiAddKeyWord.Size = New System.Drawing.Size(94, 22)
        Me.tsmiAddKeyWord.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiAddkeyword
        '
        'tsmiTxtAddKeyword
        '
        Me.tsmiTxtAddKeyword.Name = "tsmiTxtAddKeyword"
        Me.tsmiTxtAddKeyword.Size = New System.Drawing.Size(100, 21)
        Me.tsmiTxtAddKeyword.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiTxtAddKeyword
        '
        'tsmiOk
        '
        Me.tsmiOk.Name = "tsmiOk"
        Me.tsmiOk.Size = New System.Drawing.Size(160, 22)
        Me.tsmiOk.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiOK
        '
        'tsmiCancle
        '
        Me.tsmiCancle.Name = "tsmiCancle"
        Me.tsmiCancle.Size = New System.Drawing.Size(160, 22)
        Me.tsmiCancle.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiCancle
        '
        'tsmiEditKeyword
        '
        Me.tsmiEditKeyword.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiTxtEditKeyword, Me.tsmiEditOK, Me.tsmiEditCancel})
        Me.tsmiEditKeyword.Name = "tsmiEditKeyword"
        Me.tsmiEditKeyword.Size = New System.Drawing.Size(94, 22)
        Me.tsmiEditKeyword.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiEditkeyword
        Me.tsmiEditKeyword.Visible = False
        '
        'tsmiTxtEditKeyword
        '
        Me.tsmiTxtEditKeyword.Enabled = False
        Me.tsmiTxtEditKeyword.Name = "tsmiTxtEditKeyword"
        Me.tsmiTxtEditKeyword.Size = New System.Drawing.Size(152, 21)
        Me.tsmiTxtEditKeyword.Text = "无"
        '
        'tsmiEditOK
        '
        Me.tsmiEditOK.Enabled = False
        Me.tsmiEditOK.Name = "tsmiEditOK"
        Me.tsmiEditOK.Size = New System.Drawing.Size(212, 22)
        Me.tsmiEditOK.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiOK
        '
        'tsmiEditCancel
        '
        Me.tsmiEditCancel.Name = "tsmiEditCancel"
        Me.tsmiEditCancel.Size = New System.Drawing.Size(212, 22)
        Me.tsmiEditCancel.Text = Global.CodeSnippetEditor.My.MySettings.Default.frmmain_tsmiCancle
        '
        'tsmiLine1
        '
        Me.tsmiLine1.Name = "tsmiLine1"
        Me.tsmiLine1.Size = New System.Drawing.Size(91, 6)
        '
        'tsmiDelete
        '
        Me.tsmiDelete.Name = "tsmiDelete"
        Me.tsmiDelete.Size = New System.Drawing.Size(94, 22)
        Me.tsmiDelete.Text = "删除"
        '
        'ListBox
        '
        Me.ListBox.ContextMenuStrip = Me.cmsKeyword
        Me.ListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.HorizontalScrollbar = True
        Me.ListBox.ItemHeight = 12
        Me.ListBox.Location = New System.Drawing.Point(0, 0)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(262, 232)
        Me.ListBox.Sorted = True
        Me.ListBox.TabIndex = 13
        '
        'ucMysticBoy_ListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListBox)
        Me.Name = "ucMysticBoy_ListBox"
        Me.Size = New System.Drawing.Size(262, 232)
        Me.cmsKeyword.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmsKeyword As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiAddKeyWord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiTxtAddKeyword As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsmiOk As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCancle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditKeyword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiTxtEditKeyword As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsmiEditOK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEditCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiLine1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox As System.Windows.Forms.ListBox

End Class
