﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings 自动保存功能"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("基本信息")>  _
        Public Property frmmain_tphdr() As String
            Get
                Return CType(Me("frmmain_tphdr"),String)
            End Get
            Set
                Me("frmmain_tphdr") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("导入")>  _
        Public Property frmmain_tpimts() As String
            Get
                Return CType(Me("frmmain_tpimts"),String)
            End Get
            Set
                Me("frmmain_tpimts") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("引用")>  _
        Public Property frmmain_tpref() As String
            Get
                Return CType(Me("frmmain_tpref"),String)
            End Get
            Set
                Me("frmmain_tpref") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("声明")>  _
        Public Property frmmain_tpdecs() As String
            Get
                Return CType(Me("frmmain_tpdecs"),String)
            End Get
            Set
                Me("frmmain_tpdecs") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("代码")>  _
        Public Property frmmain_tpcodes() As String
            Get
                Return CType(Me("frmmain_tpcodes"),String)
            End Get
            Set
                Me("frmmain_tpcodes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("允许将代码段插入到光标处")>  _
        Public Property frmmain_cbsExpansion() As String
            Get
                Return CType(Me("frmmain_cbsExpansion"),String)
            End Get
            Set
                Me("frmmain_cbsExpansion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("允许将此代码段放置在一段选定的代码周围")>  _
        Public Property frmmain_cbsSurroundsWith() As String
            Get
                Return CType(Me("frmmain_cbsSurroundsWith"),String)
            End Get
            Set
                Me("frmmain_cbsSurroundsWith") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("关键词:")>  _
        Public Property frmmain_lblKeyword() As String
            Get
                Return CType(Me("frmmain_lblKeyword"),String)
            End Get
            Set
                Me("frmmain_lblKeyword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("帮助URL:")>  _
        Public Property frmmain_lblHelpUrl() As String
            Get
                Return CType(Me("frmmain_lblHelpUrl"),String)
            End Get
            Set
                Me("frmmain_lblHelpUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("代码段说明:")>  _
        Public Property frmmain_lblCSDesc() As String
            Get
                Return CType(Me("frmmain_lblCSDesc"),String)
            End Get
            Set
                Me("frmmain_lblCSDesc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("作者:")>  _
        Public Property frmmain_lblAuthor() As String
            Get
                Return CType(Me("frmmain_lblAuthor"),String)
            End Get
            Set
                Me("frmmain_lblAuthor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("快捷字符串:")>  _
        Public Property frmmain_lblShortcut() As String
            Get
                Return CType(Me("frmmain_lblShortcut"),String)
            End Get
            Set
                Me("frmmain_lblShortcut") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("标题:")>  _
        Public Property frmmain_lblTitle() As String
            Get
                Return CType(Me("frmmain_lblTitle"),String)
            End Get
            Set
                Me("frmmain_lblTitle") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("代码段放置类型:")>  _
        Public Property frmmain_lblCST() As String
            Get
                Return CType(Me("frmmain_lblCST"),String)
            End Get
            Set
                Me("frmmain_lblCST") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("关键词")>  _
        Public Property frmmain_tsmiTxtAddKeyword() As String
            Get
                Return CType(Me("frmmain_tsmiTxtAddKeyword"),String)
            End Get
            Set
                Me("frmmain_tsmiTxtAddKeyword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("编辑")>  _
        Public Property frmmain_tsmiEditkeyword() As String
            Get
                Return CType(Me("frmmain_tsmiEditkeyword"),String)
            End Get
            Set
                Me("frmmain_tsmiEditkeyword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("编辑")>  _
        Public Property frmmain_tsmiTxtEditKeyword() As String
            Get
                Return CType(Me("frmmain_tsmiTxtEditKeyword"),String)
            End Get
            Set
                Me("frmmain_tsmiTxtEditKeyword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("删除")>  _
        Public Property frmmain_tsmiDelete() As String
            Get
                Return CType(Me("frmmain_tsmiDelete"),String)
            End Get
            Set
                Me("frmmain_tsmiDelete") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("添加")>  _
        Public Property frmmain_tsmiAddkeyword() As String
            Get
                Return CType(Me("frmmain_tsmiAddkeyword"),String)
            End Get
            Set
                Me("frmmain_tsmiAddkeyword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("确定")>  _
        Public Property frmmain_tsmiOK() As String
            Get
                Return CType(Me("frmmain_tsmiOK"),String)
            End Get
            Set
                Me("frmmain_tsmiOK") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("取消")>  _
        Public Property frmmain_tsmiCancle() As String
            Get
                Return CType(Me("frmmain_tsmiCancle"),String)
            End Get
            Set
                Me("frmmain_tsmiCancle") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property frmmain_lblInf1() As String
            Get
                Return CType(Me("frmmain_lblInf1"),String)
            End Get
            Set
                Me("frmmain_lblInf1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Declarations 元素中可能有零个或多个 Literal 元素")>  _
        Public Property frmmain_umbdeLiteral() As String
            Get
                Return CType(Me("frmmain_umbdeLiteral"),String)
            End Get
            Set
                Me("frmmain_umbdeLiteral") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Declarations 元素中可能有零个或多个 Object 元素。")>  _
        Public Property frmmain_umbdeObject() As String
            Get
                Return CType(Me("frmmain_umbdeObject"),String)
            End Get
            Set
                Me("frmmain_umbdeObject") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("定义代码段的可编辑对象(Object)")>  _
        Public Property frmmain_gbsObject() As String
            Get
                Return CType(Me("frmmain_gbsObject"),String)
            End Get
            Set
                Me("frmmain_gbsObject") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("定义代码段的可编辑文本(Literal)")>  _
        Public Property frmmain_gbsLiteral() As String
            Get
                Return CType(Me("frmmain_gbsLiteral"),String)
            End Get
            Set
                Me("frmmain_gbsLiteral") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("文件(&F)")>  _
        Public Property frmmain_tsmiFile() As String
            Get
                Return CType(Me("frmmain_tsmiFile"),String)
            End Get
            Set
                Me("frmmain_tsmiFile") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("新建(&N)")>  _
        Public Property frmmain_tsmiNew() As String
            Get
                Return CType(Me("frmmain_tsmiNew"),String)
            End Get
            Set
                Me("frmmain_tsmiNew") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("打开(&O)...")>  _
        Public Property frmmain_tsmiOpen() As String
            Get
                Return CType(Me("frmmain_tsmiOpen"),String)
            End Get
            Set
                Me("frmmain_tsmiOpen") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("保存(&S)")>  _
        Public Property frmmain_tsmiSave() As String
            Get
                Return CType(Me("frmmain_tsmiSave"),String)
            End Get
            Set
                Me("frmmain_tsmiSave") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("另存为(&A)...")>  _
        Public Property frmmain_tsmiSaveAs() As String
            Get
                Return CType(Me("frmmain_tsmiSaveAs"),String)
            End Get
            Set
                Me("frmmain_tsmiSaveAs") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("退出(&X)")>  _
        Public Property frmmain_tsmiExit() As String
            Get
                Return CType(Me("frmmain_tsmiExit"),String)
            End Get
            Set
                Me("frmmain_tsmiExit") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("视图(&V)")>  _
        Public Property frmmain_tsmiOptional() As String
            Get
                Return CType(Me("frmmain_tsmiOptional"),String)
            End Get
            Set
                Me("frmmain_tsmiOptional") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("基本")>  _
        Public Property frmmain_tsmiConfig() As String
            Get
                Return CType(Me("frmmain_tsmiConfig"),String)
            End Get
            Set
                Me("frmmain_tsmiConfig") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("帮助(&H)")>  _
        Public Property frmmain_tsmiHelp() As String
            Get
                Return CType(Me("frmmain_tsmiHelp"),String)
            End Get
            Set
                Me("frmmain_tsmiHelp") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("关于(&A)...")>  _
        Public Property frmmain_tsmiAbout() As String
            Get
                Return CType(Me("frmmain_tsmiAbout"),String)
            End Get
            Set
                Me("frmmain_tsmiAbout") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("IntelliSense 代码段")>  _
        Public Property frmmain_lblInx() As String
            Get
                Return CType(Me("frmmain_lblInx"),String)
            End Get
            Set
                Me("frmmain_lblInx") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("语言:")>  _
        Public Property frmmain_lbllanguage() As String
            Get
                Return CType(Me("frmmain_lbllanguage"),String)
            End Get
            Set
                Me("frmmain_lbllanguage") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("分隔符:")>  _
        Public Property frmmain_lblspa() As String
            Get
                Return CType(Me("frmmain_lblspa"),String)
            End Get
            Set
                Me("frmmain_lblspa") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("插入方式:")>  _
        Public Property frmmain_lblInsType() As String
            Get
                Return CType(Me("frmmain_lblInsType"),String)
            End Get
            Set
                Me("frmmain_lblInsType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("代码段文件(*.snippet)|*.snippet|Xml 兼容格式文件|*.xml|所有文件(*.*)|*.*")>  _
        Public Property SnippetFileFilter() As String
            Get
                Return CType(Me("SnippetFileFilter"),String)
            End Get
            Set
                Me("SnippetFileFilter") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property FileDlgInitialDirectory() As String
            Get
                Return CType(Me("FileDlgInitialDirectory"),String)
            End Get
            Set
                Me("FileDlgInitialDirectory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("打开代码段文件")>  _
        Public Property frmmain_ofdOpenFile_Title() As String
            Get
                Return CType(Me("frmmain_ofdOpenFile_Title"),String)
            End Get
            Set
                Me("frmmain_ofdOpenFile_Title") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsi=""http://www.w3."& _ 
            "org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <s"& _ 
            "tring>String</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</ArrayOfString>")>  _
        Public Property csDeclObject() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("csDeclObject"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("csDeclObject") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsi=""http://www.w3."& _ 
            "org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <s"& _ 
            "tring>String</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</ArrayOfString>")>  _
        Public Property csDeclLiteral() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("csDeclLiteral"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("csDeclLiteral") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property csAsmUrl() As String
            Get
                Return CType(Me("csAsmUrl"),String)
            End Get
            Set
                Me("csAsmUrl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property csNamespace() As String
            Get
                Return CType(Me("csNamespace"),String)
            End Get
            Set
                Me("csNamespace") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("保存代码段文件")>  _
        Public Property frmmain_sfdsavefile_title() As String
            Get
                Return CType(Me("frmmain_sfdsavefile_title"),String)
            End Get
            Set
                Me("frmmain_sfdsavefile_title") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property frmmain_location() As Global.System.Drawing.Point
            Get
                Return CType(Me("frmmain_location"),Global.System.Drawing.Point)
            End Get
            Set
                Me("frmmain_location") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("工具(&T)")>  _
        Public Property frmmmain_tmsitools() As String
            Get
                Return CType(Me("frmmmain_tmsitools"),String)
            End Get
            Set
                Me("frmmmain_tmsitools") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("规则检查(&C)")>  _
        Public Property frmmain_tsmicheckrule() As String
            Get
                Return CType(Me("frmmain_tsmicheckrule"),String)
            End Get
            Set
                Me("frmmain_tsmicheckrule") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("写入检查(&W)")>  _
        Public Property frmmain_tsmiLearn() As String
            Get
                Return CType(Me("frmmain_tsmiLearn"),String)
            End Get
            Set
                Me("frmmain_tsmiLearn") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property csSaveCheck() As Boolean
            Get
                Return CType(Me("csSaveCheck"),Boolean)
            End Get
            Set
                Me("csSaveCheck") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.CodeSnippetEditor.My.MySettings
            Get
                Return Global.CodeSnippetEditor.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
