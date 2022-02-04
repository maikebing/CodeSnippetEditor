Imports System.Xml


<Microsoft.VisualBasic.ComClass()> Public Class CodeSnippet

    Dim xDoc As New XmlDocument
    Dim xCdSnpt As XmlElement
    Dim xHeader As XmlElement
    Dim xhKeys As XmlElement
    Dim xSnippet As XmlElement


    Public Property Author() As String
        Get
            Return GetHeadersItem("Author")
        End Get
        Set(ByVal value As String)
            SetHeadersItem("Author", value)
        End Set
    End Property

    Public Property Description() As String
        Get
            Return GetHeadersItem("Description")
        End Get
        Set(ByVal value As String)
            SetHeadersItem("Description", value)
        End Set
    End Property

    Private pTitle As String
    Public Property Title() As String
        Get
            Return GetHeadersItem("Title")
        End Get
        Set(ByVal value As String)
            SetHeadersItem("Title", value)

        End Set
    End Property


    Public Property Shortcut() As String
        Get
            Return GetHeadersItem("Shortcut")
        End Get
        Set(ByVal value As String)
            SetHeadersItem("Shortcut", value)

        End Set
    End Property


    Public Property HelpUrl() As String
        Get
            Return GetHeadersItem("HelpUrl")
        End Get
        Set(ByVal value As String)
            SetHeadersItem("HelpUrl", value)
        End Set
    End Property
    Private Sub SetHeadersItem(ByVal Name As String, ByVal Value As String)
        SetXmlEmt(xHeader, Name).InnerText = Value
    End Sub
    Private Function GetHeadersItem(ByVal Name As String) As String
        Return GetXmlEmtVal(xHeader, Name)
    End Function

    ''' <summary>
    ''' 添加关键词
    ''' </summary>
    ''' <param name="Keyword ">关键词值</param>
    ''' <remarks>不检查是不是存在,直接添加</remarks>
    Public Function AddKeyword(ByVal Keyword As String) As Boolean
        Dim xItem As XmlElement
        Dim xKey As XmlElement
        Try
            xItem = SetXmlEmt(xHeader, "Keywords")
            xKey = SetXmlEmt(xItem, "Keyword")
            xKey.InnerText = Keyword
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 删除关键词
    ''' </summary>
    ''' <param name="Keyword">要删除的关键词</param>
    ''' <remarks></remarks>
    Public Function RemoveKeyword(ByVal Keyword As String) As Boolean
        Dim xItem As XmlElement
        Dim xItm As XmlElement
        Try
            xItem = SetXmlEmt(xHeader, "Keywords")
            For Each xItm In xItem.ChildNodes
                If xItm.InnerText.Contains(Keyword) Then
                    xItem.RemoveChild(xItm) '为了删除重复关键词,在这里不返回,继续列举.
                    '直到删除完这个关键词的重复项.
                End If
            Next
            '废弃代码
            'If InStr(xItem.InnerXml, "Keyword") > 0 Then
            '    If InStr(xItem.InnerText, Keyword) > 0 Then
            '        xItem.InnerXml = Replace(xItem.InnerXml, "<Keyword>" & Keyword & "</Keyword>)", "")
            '    End If
            'End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 添加或修改关键词
    ''' </summary>
    ''' <param name="OldKeyword">旧的关键词</param>
    ''' <param name="NewKeyword">用来替换的关键词</param>
    ''' <remarks>如果旧管家词不在,则添加.如果在,则替换.如果NewKeyword为Nothing则添加OldKeyword</remarks>
    Public Function EditKeyword(ByVal OldKeyword As String, ByVal NewKeyword As String) As Boolean
        Dim xItem As XmlElement
        Dim xKey As XmlElement
        Try
            xItem = SetXmlEmt(xHeader, "Keywords")
            If InStr(xItem.InnerXml, "Keyword") > 0 Then
                If InStr(xItem.InnerText, OldKeyword) > 0 Then
                    xItem.InnerXml = Replace(xItem.InnerXml, OldKeyword, NewKeyword)
                Else
                    xKey = SetXmlEmt(xItem, "Keyword")
                    xKey.InnerText = IIf(IsNothing(NewKeyword), OldKeyword, NewKeyword)
                End If
            End If
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Function GetKeywords() As String()
        Dim xItem As XmlElement
        Dim xKey As XmlElement
        Dim xst As String = ""
        Try
            xItem = SetXmlEmt(xHeader, "Keywords")
            For Each xKey In xItem
                xst = xst & IIf(xst.Length > 0, ",", "") & xKey.InnerText
            Next
        Catch ex As Exception
        End Try
        Return xst.Split(",")
    End Function


    ''' <summary>
    ''' 片段的枚举类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SnippetType
        ''' <summary>
        '''许将代码段插入到光标处 
        ''' </summary>
        ''' <remarks></remarks>
        Expansion = 1
        ''' <summary>
        ''' 允许将此代码段放置在一段选定的代码周围
        ''' </summary>
        ''' <remarks></remarks>
        SurroundsWith = 2
        ''' <summary>
        ''' 指定在 Visual C# 重构过程中使用此代码段。不能在自定义代码段中使用 Refactoring
        ''' </summary>
        ''' <remarks></remarks>
        Refactoring = 4
    End Enum



    ''' <summary>
    ''' 设置片断的类型.
    ''' </summary>
    ''' <param name="tpType"></param>
    ''' <remarks></remarks>
    Public Function SetSnippetType(ByVal tpType As SnippetType) As Boolean
        Dim xItem As XmlElement
        Dim xSt As XmlElement
        Dim ESR As String = ""
        On Error GoTo errH
        xItem = SetXmlEmt(xHeader, "SnippetTypes")
        Select Case tpType
            Case SnippetType.Expansion
                ESR = "e"
            Case SnippetType.Refactoring
                ESR = "r"
            Case SnippetType.SurroundsWith
                ESR = "s"
            Case SnippetType.Expansion Or SnippetType.Refactoring
                ESR = "er"
            Case SnippetType.Expansion Or SnippetType.SurroundsWith
                ESR = "es"
            Case SnippetType.Refactoring Or SnippetType.SurroundsWith
                ESR = "rs"
            Case SnippetType.Expansion Or SnippetType.Refactoring Or SnippetType.SurroundsWith
                ESR = "ers"
        End Select
        xItem.InnerXml = "" '清除旧值,重新设置选项
        If InStr(ESR, "e") Then
            xSt = AddNd("SnippetType", xItem)
            xSt.InnerText = "Expansion"
        End If
        If InStr(ESR, "r") Then
            xSt = AddNd("SnippetType", xItem)
            xSt.InnerText = "Refactoring"
        End If
        If InStr(ESR, "s") Then
            xSt = AddNd("SnippetType", xItem)
            xSt.InnerText = "SurroundsWith"
        End If
        Return True
errH:
        Return False
    End Function

    Public Function GetSnippetType() As SnippetType
        Dim xItem As XmlElement
        Dim xSt As XmlElement
        Dim ESR As String = ""
        Try
            xItem = SetXmlEmt(xHeader, "SnippetTypes")
            For Each xSt In xItem
                ESR = ESR & "," & xSt.InnerText
            Next
            ESR.ToLower()
        Catch ex As Exception

        End Try
        Return IIf(ESR.Contains("surroundswith"), SnippetType.SurroundsWith, 0) _
               Or IIf(ESR.Contains("refactoring"), SnippetType.Refactoring, 0) _
               Or IIf(ESR.Contains("expansion"), SnippetType.Expansion, 0)
    End Function

    ''' <summary>
    ''' 在Owner 中按照给出的子元素名称,在子元素中查找xPath的值等于xValue的元素
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="xSubItem">a</param>
    ''' <param name="xPath">格式:b/c </param>
    ''' <param name="xValue">格式:v</param>
    ''' <returns>返回一个元素</returns>
    ''' <remarks>descendant::book[author/last-name='Austen']
    ''' 参考文章: ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.chs/CPref19/html/M_System_Xml_XmlNode_SelectSingleNode_1_16219e3a.htm
    ''' </remarks>
    ''' 
    Private Function SelXmlEmt(ByVal Owner As XmlElement, ByVal xSubItem As String, ByVal xPath As String, ByVal xValue As String) As XmlElement
        Try
            'Dim im As XmlElement
            'im = Owner.ParentNode.SelectSingleNode("descendant::Imports[Import/Namespace]")
            Return Owner.SelectSingleNode("descendant::" & xSubItem & "[" & xPath & "='" & xValue & "']")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' 在 Owner 中按照a.b.c.e 路径的格式选择e元素
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="emtPath">格式为 a.b.c.d </param>
    ''' <returns>返回一个元素</returns>
    ''' <remarks></remarks>
    Private Function SelXmlEmt(ByVal Owner As XmlElement, ByVal emtPath As String) As XmlElement
        Dim cStrs As String()
        Dim Key As String
        Dim chNode As XmlNode = Owner
        cStrs = emtPath.Split(".".ToCharArray)
        For Each Key In cStrs
            chNode = chNode.SelectSingleNode("descendant::" & Key)
        Next
        Return chNode
    End Function


    Public Function AddImport(ByVal cNamespace As String) As Boolean
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Dim NamSp As XmlElement
        Try
            Imps = SetXmlEmt(xSnippet, "Imports")
            imp = AddNd("Import", Imps)
            NamSp = AddNd("Namespace", imp)
            NamSp.InnerText = cNamespace
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function GetImports() As String()
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Dim ips As String = ""
        Try
            Imps = SetXmlEmt(xSnippet, "Imports")
            For Each imp In Imps
                Try
                    ips = ips & IIf(ips.Length > 0, ",", "") & imp.Item("Namespace").InnerText
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        Return ips.Split(",")
    End Function


    Public Function RemoveImport(ByVal cNamespace) As Boolean
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Try
            Imps = SetXmlEmt(xSnippet, "Imports")
            If Imps.HasChildNodes = False Then
                Return False
            End If
            For Each imp In Imps.ChildNodes()
                If imp.HasChildNodes = True Then
                    If imp.InnerText.Contains(cNamespace) Then
                        Imps.RemoveChild(imp)
                        Return True
                    End If
                End If
            Next imp
            Return False
            '废弃代码 Imps.InnerXml = Replace(Imps.InnerXml, "<Import>" & cNamespace & "</Import>)", "")
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' 添加引用的程序集或URL。
    ''' </summary>
    ''' <param name="cAssemblyOrUrl" >程序集或URL,URL请以http:开头</param>
    ''' <returns>添加成功返回真</returns>
    ''' <remarks></remarks>
    Public Function AddReference(ByVal cAssemblyOrUrl As String) As Boolean
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Dim NamSp As XmlElement
        Try
            Imps = SetXmlEmt(xSnippet, "References")
            imp = AddNd("Reference", Imps)
            If Left(cAssemblyOrUrl.Trim, 7).ToLower = "http://" Then
                NamSp = AddNd("Url", imp)
            Else
                NamSp = AddNd("Assembly", imp)
            End If
            NamSp.InnerText = cAssemblyOrUrl
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetReference() As String()
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Dim crus As String = ""
        Dim tm As String = ""
        Try
            Imps = SetXmlEmt(xSnippet, "References")
            For Each imp In Imps
                Try
                    Try
                        If Not IsNothing(imp.Item("Assembly")) Then
                            tm = imp.Item("Assembly").InnerText
                            crus = crus & IIf(crus.Length > 0, ",", "") & tm
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(imp.Item("Url")) Then
                            tm = imp.Item("Url").InnerText
                            crus = crus & IIf(crus.Length > 0, ",", "") & tm
                        End If
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        Return crus.Split(",")
    End Function



    Public Function RemoveReference(ByVal cAssemblyOrUrl As String) As Boolean
        Dim Imps As XmlElement
        Dim imp As XmlElement
        Try
            Imps = SetXmlEmt(xSnippet, "References")
            If Imps.HasChildNodes = False Then
                Return False
            End If
            For Each imp In Imps.ChildNodes()
                If imp.HasChildNodes = True Then
                    If imp.InnerText.Contains(">" & cAssemblyOrUrl & "</") Then
                        Imps.RemoveChild(imp)
                        Return True
                    End If
                End If
            Next imp
            Return False
        Catch ex As Exception
            Return False
        End Try
        '废弃代码' Imps.InnerXml = Replace(Imps.InnerXml, "<Reference><Assembly>" & cAssembly & "</Assembly><Url>" & cUrl & "</Url></Reference>", "")
    End Function


    ''' <summary>
    ''' 添加文本
    ''' </summary>
    ''' <param name="xID">标识该文本的字符串</param>
    ''' <param name="xType">文本类型</param>
    ''' <param name="xFunction">指定当对象在 Visual Studio 中获得焦点时要执行的函数</param>
    ''' <param name="xDefault">默认值</param>
    ''' <param name="xToolTip">提示信息</param>
    ''' <param name="Editable"> 指定在代码段插入后是否可以编辑对象。此属性的默认值为 true。</param>
    ''' <returns>如果成功返回真</returns>
    ''' <remarks>Literal 元素用于标识完全包含在代码段中的代码片段替换，
    ''' 不过这些代码片段在插入到代码中后，可能需要进行自定义。
    ''' 例如，字符串、数值和一些变量名都应声明为文本。</remarks>
    Public Function AddLiteral(ByVal xID As String, ByVal xType As String, _
                                ByVal xDefault As String, _
                                   ByVal xToolTip As String, _
                                 Optional ByVal xFunction As String = Nothing, _
                                Optional ByVal Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Dim xItm As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            XLit = AddNd("Literal", xDec)
            If Editable = False Then
                XLit.SetAttribute("Editable", Editable.ToString.ToLower)
            End If
            xItm = AddNd("ID", XLit) : xItm.InnerText = xID
            If xType <> "" Then
                xItm = AddNd("Type", XLit) : xItm.InnerText = xType
            End If
            xItm = AddNd("Default", XLit) : xItm.InnerText = xDefault
            If Not IsNothing(xFunction) Then
                xItm = AddNd("Function", XLit) : xItm.InnerText = xFunction
            End If
            xItm = AddNd("ToolTip", XLit) : xItm.InnerText = xToolTip
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 添加对象
    ''' </summary>
    ''' <param name="xID">识别对象的字符串</param>
    ''' <param name="xType">对象类型</param>
    ''' <param name="xFunction">指定当对象在 Visual Studio 中获得焦点时要执行的函数</param>
    ''' <param name="xDefault">默认值</param>
    ''' <param name="xToolTip">提示字符串</param>
    ''' <returns>添加成功返回真</returns>
    ''' <param name="Editable"> 指定在代码段插入后是否可以编辑对象。此属性的默认值为 true。</param>
    ''' <remarks>Object 元素用于标识代码段需要的但很有可能要在代码段外部定义的项。
    ''' 例如，Windows 窗体控件、ASP.NET 控件、对象实例和类型实例都应声明为对象。
    ''' 对象声明要求指定类型，这一操作可通过 Type 元素完成。</remarks>
    Public Function AddObject(ByVal xID As String, ByVal xType As String, _
                                 ByVal xDefault As String, _
                                  ByVal xToolTip As String, _
                                 Optional ByVal xFunction As String = Nothing, _
                                Optional ByVal Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Dim xItm As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            XLit = AddNd("Object", xDec)
            If Editable <> True Then
                XLit.SetAttribute("Editable", Editable.ToString.ToLower)
            End If
            xItm = AddNd("ID", XLit) : xItm.InnerText = xID
            xItm = AddNd("Type", XLit) : xItm.InnerText = xType
            If IsNothing(xFunction) = False Then
                xItm = AddNd("Function", XLit) : xItm.InnerText = xFunction
            End If
            xItm = AddNd("ToolTip", XLit) : xItm.InnerText = xToolTip
            xItm = AddNd("Default", XLit) : xItm.InnerText = xDefault
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 编辑Literal
    ''' </summary>
    ''' <param name="xID">用来识别Literal的字符串</param>
    ''' <param name="xType">类型</param>
    ''' <param name="xFunction">指定当对象在 Visual Studio 中获得焦点时要执行的函数</param>
    ''' <param name="xDefault">默认文本</param>
    ''' <param name="xToolTip">提示文本</param>
    ''' <param name="Editable"> 指定在代码段插入后是否可以编辑对象。此属性的默认值为 true。</param>
    ''' <returns>编辑成功则返回真值</returns>
    ''' <remarks></remarks>
    Public Function EditLiteral(ByVal xID As String, Optional ByVal xType As String = Nothing, _
                                Optional ByVal xDefault As String = Nothing, _
                                 Optional ByVal xToolTip As String = Nothing, _
                                 Optional ByVal xFunction As String = Nothing, _
                                Optional ByVal Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.HasChildNodes = True Then
                    If XLit.Item("ID").InnerText = xID And XLit.Name = "Literal" Then
                        If Editable <> True Then
                            XLit.SetAttribute("Editable", Editable.ToString.ToLower)
                        End If
                        If xType <> Nothing Then
                            SetXmlEmt(XLit, "Type", xType)
                        End If
                        If xFunction <> Nothing Then
                            SetXmlEmt(XLit, "Function", xFunction)
                        End If
                        If xToolTip <> Nothing Then
                            SetXmlEmt(XLit, "ToolTip", xToolTip)
                        End If
                        If xDefault <> Nothing Then
                            SetXmlEmt(XLit, "Default", xDefault)
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 读取文字内容.
    ''' </summary>
    ''' <param name="xID"></param>
    ''' <param name="xType"></param>
    ''' <param name="xDefault"></param>
    ''' <param name="xFunction"></param>
    ''' <param name="xToolTip"></param>
    ''' <param name="Editable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadLiteral(ByVal xID As String, Optional ByRef xType As String = Nothing, _
                                Optional ByRef xDefault As String = Nothing, _
                                 Optional ByRef xToolTip As String = Nothing, _
                                 Optional ByRef xFunction As String = Nothing, _
                                Optional ByRef Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.HasChildNodes = True Then
                    If XLit.Item("ID").InnerText = xID And XLit.Name = "Literal" Then
                        xType = GetXmlEmtVal(XLit, "Type")
                        xFunction = GetXmlEmtVal(XLit, "Function")
                        xDefault = GetXmlEmtVal(XLit, "Default")
                        xToolTip = GetXmlEmtVal(XLit, "ToolTip")
                        Editable = IIf(XLit.GetAttribute("Editable").ToLower = "false", False, True)
                        Return True
                    End If
                End If
            Next XLit
            Return False
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 提取文字列表
    ''' </summary>
    ''' <returns>返回字符串数组</returns>
    ''' <remarks></remarks>
    Public Function GetLiterals() As String()
        Dim Obj As String = ""
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.Name = "Literal" Then
                    If XLit.HasChildNodes = True Then
                        Obj = Obj & IIf(Obj.Length > 0, ",", "") & GetXmlEmtVal(XLit, "ID")
                    End If
                End If
            Next XLit
        Catch

        End Try
        Return Obj.Split(",")
    End Function

    ''' <summary>
    ''' 编辑对象
    ''' </summary>
    ''' <param name="xID">对象ID</param>
    ''' <param name="xType">对象类型</param>
    ''' <param name="xFunction">指定当对象在 Visual Studio 中获得焦点时要执行的函数</param>
    ''' <param name="xDefault">默认值</param>
    ''' <param name="xToolTip">提示信息</param>
    ''' <param name="Editable"> 指定在代码段插入后是否可以编辑对象。此属性的默认值为 true。</param>
    ''' <returns>如果编辑成功则返回真</returns>
    ''' <remarks></remarks>
    Public Function EditObject(ByVal xID As String, Optional ByVal xType As String = Nothing, _
                                Optional ByVal xDefault As String = Nothing, _
                                 Optional ByVal xToolTip As String = Nothing, _
                                 Optional ByVal xFunction As String = Nothing, _
                                Optional ByVal Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.HasChildNodes = True Then
                    If XLit.Item("ID").InnerText = xID And XLit.Name = "Object" Then
                        If Editable <> True Then
                            XLit.SetAttribute("Editable", Editable.ToString.ToLower)
                        End If
                        If xType <> Nothing Then
                            SetXmlEmt(XLit, "Type", xType)
                        End If
                        If xFunction <> Nothing Then
                            SetXmlEmt(XLit, "Function", xFunction)
                        End If
                        If xToolTip <> Nothing Then
                            SetXmlEmt(XLit, "ToolTip", xToolTip)
                        End If
                        If xDefault <> Nothing Then
                            SetXmlEmt(XLit, "Default", xDefault)
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ReadObject(ByVal xID As String, Optional ByRef xType As String = Nothing, _
                                Optional ByRef xDefault As String = Nothing, _
                                 Optional ByRef xToolTip As String = Nothing, _
                                 Optional ByRef xFunction As String = Nothing, _
                                Optional ByRef Editable As Boolean = True) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            xType = ""
            xDefault = ""
            xToolTip = ""
            xFunction = ""
            Editable = True
            For Each XLit In xDec.ChildNodes
                If XLit.HasChildNodes = True Then

                    If XLit.Item("ID").InnerText = xID And XLit.Name = "Object" Then
                        xType = GetXmlEmtVal(XLit, "Type")
                        xFunction = GetXmlEmtVal(XLit, "Function")
                        xDefault = GetXmlEmtVal(XLit, "Default")
                        xToolTip = GetXmlEmtVal(XLit, "ToolTip")
                        Editable = IIf(XLit.GetAttribute("Editable").ToLower = "false", False, True)
                        Return True
                    End If
                End If
            Next XLit
            Return False
        Catch
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 读取对象列表
    ''' </summary>
    ''' <returns>返回字符串数组</returns>
    ''' <remarks></remarks>
    Public Function GetObjects() As String()
        Dim Obj As String = ""
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try
            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.Name = "Object" Then
                    If XLit.HasChildNodes = True Then
                        Obj = Obj & IIf(Obj.Length > 0, ",", "") & GetXmlEmtVal(XLit, "ID")
                    End If
                End If
            Next XLit
        Catch

        End Try
        Return Obj.Split(",")
    End Function
    ''' <summary>
    ''' 删除Literal 
    ''' </summary>
    ''' <param name="xID">标识Literal的字符串</param>
    ''' <returns>如果删除成功则返回真</returns>
    ''' <remarks></remarks>
    Public Function RemoveLiteral(ByVal xID As String) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try

            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.Name = "Literal" Then
                    If XLit.HasChildNodes = True Then
                        If XLit.InnerText.Contains(xID) Then
                            xDec.RemoveChild(XLit)
                        End If
                    End If
                End If
            Next XLit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 删除代码对象!
    ''' </summary>
    ''' <param name="xID">用来识别对象.</param>
    ''' <returns>如果删除成功则返回真</returns>
    ''' <remarks></remarks>
    Public Function RemoveObject(ByVal xID As String) As Boolean
        Dim xDec As XmlElement
        Dim XLit As XmlElement
        Try

            xDec = SetXmlEmt(xSnippet, "Declarations")
            For Each XLit In xDec.ChildNodes
                If XLit.Name = "Object" Then
                    If XLit.HasChildNodes = True Then
                        If XLit.InnerText.Contains(xID) Then
                            xDec.RemoveChild(XLit)
                        End If
                    End If
                End If
            Next XLit
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ''' <summary>
    ''' 指定代码段的语言。可用的值有 VB、CSharp、VJSharp 或 XML。有关更多信息，请参见下表中的“Language 属性”部分。
    ''' </summary>
    ''' <remarks></remarks>
    Enum Language
        VB
        CSharp
        VJSharp
        XML
    End Enum
    ''' <summary>
    ''' 指定代码段所包含的代码类型，并据此指定可以插入代码段的位置。可用的值有 method body、method decl、type decl、page、file 和 any。有关更多信息，请参见下表中的“Kind 属性”部分。
    ''' </summary>
    ''' <remarks></remarks>
    Enum Kind
        MethodBody
        MethodDecl
        TypeDecl
        Page
        File
        Any
    End Enum

    ''' <summary>
    ''' 编辑代码段
    ''' </summary>
    ''' <param name="xLanguage">指定语言</param>
    ''' <param name="xCodeText">代码内容</param>
    ''' <param name="xDelimiter">分隔符号,默认为$,如果指定对象或文字,应该用它来括起来,例如: $File$</param>
    ''' <param name="xKind">指定代码段所包含的代码类型，并据此指定可以插入代码段的位置。可用的值有 method body、method decl、type decl、page、file 和 any。有关更多信息，请参见下表中的“Kind 属性”部分。</param>
    ''' <returns>如果编辑成功则返回真</returns>
    ''' <remarks></remarks>
    Public Function EditCode( _
                                ByVal xLanguage As Language, _
                                ByVal xCodeText As String, _
                                Optional ByVal xDelimiter As String = "$", _
                                Optional ByVal xKind As Kind = Nothing) As Boolean
        Dim xCode As XmlElement
        On Error GoTo errH
        xCode = SetXmlEmt(xSnippet, "Code")
        xCode.SetAttribute("Language", [Enum].GetName(GetType(Language), xLanguage))
        If xDelimiter <> "$" Then
            xCode.SetAttribute("Delimiter", xDelimiter)
        End If
        If Not IsNothing(xKind) Then
            Dim cKind As String
            Select Case xKind
                Case Kind.MethodBody
                    cKind = "method body"
                Case Kind.MethodDecl
                    cKind = "method decl"
                Case Kind.TypeDecl
                    cKind = "type decl"
                Case Else
                    cKind = [Enum].GetName(GetType(Kind), xKind).ToLower
            End Select
            xCode.SetAttribute("Kind", cKind)
        End If
        xCode.InnerXml = "<![CDATA[" & xCodeText & "]]>"
        Return True
errH:
        Return False
    End Function
    Public Function ReadCode( _
                                    ByRef xLanguage As Language, _
                                    ByRef xCodeText As String, _
                                    Optional ByRef xDelimiter As String = "$", _
                                    Optional ByRef xKind As Kind = Nothing, Optional ByRef xcKind As String = "") As Boolean
        Dim xCode As XmlElement
        On Error GoTo errH
        xCode = SetXmlEmt(xSnippet, "Code")
        Dim cTm As String
        cTm = xCode.GetAttribute("Language")
        xcKind = cTm
        Select Case cTm.ToLower
            Case "vb"
                xLanguage = Language.VB
            Case "csharp"
                xLanguage = Language.CSharp
            Case "vjsharp"
                xLanguage = Language.VJSharp
            Case "xml"
                xLanguage = Language.XML
        End Select
        xDelimiter = xCode.GetAttribute("Delimiter")
        xDelimiter = IIf(xDelimiter.Length = 0, "$", xDelimiter)
        cTm = xCode.GetAttribute("Kind")
        xcKind = cTm
        Select Case cTm.ToLower
            Case "method body"
                xKind = Kind.MethodBody
            Case "method decl"
                xKind = Kind.MethodDecl
            Case "type decl"
                xKind = Kind.MethodDecl
            Case "page"
                xKind = Kind.Page
            Case "file"
                xKind = Kind.File
            Case "any"
                xKind = Kind.Any
        End Select
        xCodeText = xCode.InnerText
        Return True
errH:
        Return False
    End Function

    Public Sub New()
        Dim xPI As XmlProcessingInstruction
        Dim xCmt As XmlComment
        Dim xEmt As XmlElement
        Try
            xPI = xDoc.CreateProcessingInstruction("xml", "version='1.0' encoding='UTF-8'")
            xDoc.AppendChild(xPI)
            xCmt = xDoc.CreateComment("CoderHelper_CodeSnippet 操作类 MysticBoy 完成!")
            xDoc.AppendChild(xCmt)
            xEmt = xDoc.CreateElement("CodeSnippets", "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")
            xCdSnpt = AddNd("CodeSnippet", xDoc.AppendChild(xEmt))
            xCdSnpt.SetAttribute("Format", "1.0.0")
            xHeader = AddNd("Header", xCdSnpt)
            xSnippet = AddNd("Snippet", xCdSnpt)
            XmlSnippetModify()
        Catch ex As Exception
        End Try

        'Debug.Print(xDoc.InnerXml)
    End Sub
    Public Sub New(ByVal XmlFile As String)
        xDoc.Load(XmlFile)
        xCdSnpt = SetXmlEmt(xDoc.DocumentElement, "CodeSnippet")
        xHeader = SetXmlEmt(xCdSnpt, "Header")
        xSnippet = SetXmlEmt(xCdSnpt, "Snippet")
    End Sub

    Private Function AddNd(ByVal Name As String, ByVal Owner As XmlElement) As XmlElement
        Return Owner.AppendChild(xDoc.CreateElement(Name)) ' '1 ',  "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet"))
    End Function

    Private Function SetXmlEmt(ByVal Owner As XmlElement, ByVal Name As String) As XmlElement
        Dim xEmt As XmlElement
        If IsNothing(Owner.Item(Name)) Then
            xEmt = AddNd(Name, Owner)
        Else
            xEmt = Owner.Item(Name)
        End If
        Return xEmt
    End Function

    Private Sub SetXmlEmt(ByVal Owner As XmlElement, ByVal xSubItemName As String, ByVal xValue As String)
        Dim xEmt As XmlElement
        If IsNothing(Owner.Item(xSubItemName)) Then
            xEmt = AddNd(xSubItemName, Owner)
        Else
            xEmt = Owner.Item(xSubItemName)
        End If
        xEmt.InnerText = xValue
    End Sub

    Private Function GetXmlEmtVal(ByVal Owner As XmlElement, ByVal xItemName As String) As String

        If IsNothing(Owner.Item(xItemName)) Then
            Return ""
        Else
            Return Owner.Item(xItemName).InnerText
        End If
    End Function

    ''' <summary>
    ''' 把内容保存到文本字符串中
    ''' </summary>
    ''' <param name="txtText"></param>
    ''' <remarks></remarks>
    Public Sub Save(ByVal txtText As Object)
        XmlSnippetModify()
        txtText = xDoc.OuterXml
    End Sub

    Public Function GetXmlText() As String
        XmlSnippetModify()
        Return xDoc.OuterXml
    End Function
    Public Sub SetXmlText(ByVal txtText As String)
        xDoc.LoadXml(txtText)
    End Sub
    Public Function GetXmlEmtText(ByVal xPath As String) As String
        Dim xemt As XmlElement
        XmlSnippetModify()
        xemt = SelXmlEmt(xDoc.DocumentElement, xPath)
        Return (xemt.InnerXml)
    End Function
    Public Sub SetXmlEmtText(ByVal xPath As String, ByVal txtText As String)
        Dim xemt As XmlElement
        xemt = SelXmlEmt(xDoc.DocumentElement, xPath)
        xemt.InnerXml = txtText
    End Sub

    ''' <summary>
    ''' 从文本中加载代码段XML
    ''' </summary>
    ''' <param name="txtText">文本类型</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal txtText As Object)
        xDoc.LoadXml(txtText)
    End Sub
    ''' <summary>
    ''' 从一个代码段文件中加载代码段
    ''' </summary>
    ''' <param name="XmlFileFullName">文件的具体路径</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal XmlFileFullName As String)
        xDoc.Load(XmlFileFullName)
        xCdSnpt = SetXmlEmt(xDoc.DocumentElement, "CodeSnippet")
        xHeader = SetXmlEmt(xCdSnpt, "Header")
        xSnippet = SetXmlEmt(xCdSnpt, "Snippet")
    End Sub
    ''' <summary>
    ''' 保存导指定路径和名称的文件中
    ''' </summary>
    ''' <param name="XmlFileFullName"></param>
    ''' <remarks></remarks>
    Public Sub Save(ByVal XmlFileFullName As String)
        XmlSnippetModify()
        xDoc.Save(XmlFileFullName)
    End Sub
    Public Sub Load(ByVal inStream As System.IO.Stream)
        xDoc.Load(inStream)
    End Sub
    Public Sub Save(ByVal outStream As System.IO.Stream)
        XmlSnippetModify()
        xDoc.Save(outStream)

    End Sub
    Public Sub Load(ByVal xTextReader As System.IO.TextReader)
        xDoc.Load(xTextReader)
    End Sub
    Public Sub Save(ByVal xTextWriter As System.IO.TextWriter)
        XmlSnippetModify()
        xDoc.Save(xTextWriter)
    End Sub
    Public Sub Save(ByVal xXmlWriter As XmlWriter)
        XmlSnippetModify()
        xDoc.Save(xXmlWriter)
    End Sub
    Public Sub XmlSnippetModify()
        Try
            xDoc.InnerXml = Replace(xDoc.InnerXml, "xmlns=""""", "")
            '避免该属性造成的ＶＳ无法识别
        Catch ex As Exception
        End Try
    End Sub

End Class