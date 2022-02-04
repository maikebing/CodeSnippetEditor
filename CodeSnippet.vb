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
    ''' ��ӹؼ���
    ''' </summary>
    ''' <param name="Keyword ">�ؼ���ֵ</param>
    ''' <remarks>������ǲ��Ǵ���,ֱ�����</remarks>
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
    ''' ɾ���ؼ���
    ''' </summary>
    ''' <param name="Keyword">Ҫɾ���Ĺؼ���</param>
    ''' <remarks></remarks>
    Public Function RemoveKeyword(ByVal Keyword As String) As Boolean
        Dim xItem As XmlElement
        Dim xItm As XmlElement
        Try
            xItem = SetXmlEmt(xHeader, "Keywords")
            For Each xItm In xItem.ChildNodes
                If xItm.InnerText.Contains(Keyword) Then
                    xItem.RemoveChild(xItm) 'Ϊ��ɾ���ظ��ؼ���,�����ﲻ����,�����о�.
                    'ֱ��ɾ��������ؼ��ʵ��ظ���.
                End If
            Next
            '��������
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
    ''' ��ӻ��޸Ĺؼ���
    ''' </summary>
    ''' <param name="OldKeyword">�ɵĹؼ���</param>
    ''' <param name="NewKeyword">�����滻�Ĺؼ���</param>
    ''' <remarks>����ɹܼҴʲ���,�����.�����,���滻.���NewKeywordΪNothing�����OldKeyword</remarks>
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
    ''' Ƭ�ε�ö������
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SnippetType
        ''' <summary>
        '''������β��뵽��괦 
        ''' </summary>
        ''' <remarks></remarks>
        Expansion = 1
        ''' <summary>
        ''' �����˴���η�����һ��ѡ���Ĵ�����Χ
        ''' </summary>
        ''' <remarks></remarks>
        SurroundsWith = 2
        ''' <summary>
        ''' ָ���� Visual C# �ع�������ʹ�ô˴���Ρ��������Զ���������ʹ�� Refactoring
        ''' </summary>
        ''' <remarks></remarks>
        Refactoring = 4
    End Enum



    ''' <summary>
    ''' ����Ƭ�ϵ�����.
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
        xItem.InnerXml = "" '�����ֵ,��������ѡ��
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
    ''' ��Owner �а��ո�������Ԫ������,����Ԫ���в���xPath��ֵ����xValue��Ԫ��
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="xSubItem">a</param>
    ''' <param name="xPath">��ʽ:b/c </param>
    ''' <param name="xValue">��ʽ:v</param>
    ''' <returns>����һ��Ԫ��</returns>
    ''' <remarks>descendant::book[author/last-name='Austen']
    ''' �ο�����: ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.chs/CPref19/html/M_System_Xml_XmlNode_SelectSingleNode_1_16219e3a.htm
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
    ''' �� Owner �а���a.b.c.e ·���ĸ�ʽѡ��eԪ��
    ''' </summary>
    ''' <param name="Owner"></param>
    ''' <param name="emtPath">��ʽΪ a.b.c.d </param>
    ''' <returns>����һ��Ԫ��</returns>
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
            '�������� Imps.InnerXml = Replace(Imps.InnerXml, "<Import>" & cNamespace & "</Import>)", "")
        Catch ex As Exception
            Return False
        End Try

    End Function
    ''' <summary>
    ''' ������õĳ��򼯻�URL��
    ''' </summary>
    ''' <param name="cAssemblyOrUrl" >���򼯻�URL,URL����http:��ͷ</param>
    ''' <returns>��ӳɹ�������</returns>
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
        '��������' Imps.InnerXml = Replace(Imps.InnerXml, "<Reference><Assembly>" & cAssembly & "</Assembly><Url>" & cUrl & "</Url></Reference>", "")
    End Function


    ''' <summary>
    ''' ����ı�
    ''' </summary>
    ''' <param name="xID">��ʶ���ı����ַ���</param>
    ''' <param name="xType">�ı�����</param>
    ''' <param name="xFunction">ָ���������� Visual Studio �л�ý���ʱҪִ�еĺ���</param>
    ''' <param name="xDefault">Ĭ��ֵ</param>
    ''' <param name="xToolTip">��ʾ��Ϣ</param>
    ''' <param name="Editable"> ָ���ڴ���β�����Ƿ���Ա༭���󡣴����Ե�Ĭ��ֵΪ true��</param>
    ''' <returns>����ɹ�������</returns>
    ''' <remarks>Literal Ԫ�����ڱ�ʶ��ȫ�����ڴ�����еĴ���Ƭ���滻��
    ''' ������Щ����Ƭ���ڲ��뵽�����к󣬿�����Ҫ�����Զ��塣
    ''' ���磬�ַ�������ֵ��һЩ��������Ӧ����Ϊ�ı���</remarks>
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
    ''' ��Ӷ���
    ''' </summary>
    ''' <param name="xID">ʶ�������ַ���</param>
    ''' <param name="xType">��������</param>
    ''' <param name="xFunction">ָ���������� Visual Studio �л�ý���ʱҪִ�еĺ���</param>
    ''' <param name="xDefault">Ĭ��ֵ</param>
    ''' <param name="xToolTip">��ʾ�ַ���</param>
    ''' <returns>��ӳɹ�������</returns>
    ''' <param name="Editable"> ָ���ڴ���β�����Ƿ���Ա༭���󡣴����Ե�Ĭ��ֵΪ true��</param>
    ''' <remarks>Object Ԫ�����ڱ�ʶ�������Ҫ�ĵ����п���Ҫ�ڴ�����ⲿ������
    ''' ���磬Windows ����ؼ���ASP.NET �ؼ�������ʵ��������ʵ����Ӧ����Ϊ����
    ''' ��������Ҫ��ָ�����ͣ���һ������ͨ�� Type Ԫ����ɡ�</remarks>
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
    ''' �༭Literal
    ''' </summary>
    ''' <param name="xID">����ʶ��Literal���ַ���</param>
    ''' <param name="xType">����</param>
    ''' <param name="xFunction">ָ���������� Visual Studio �л�ý���ʱҪִ�еĺ���</param>
    ''' <param name="xDefault">Ĭ���ı�</param>
    ''' <param name="xToolTip">��ʾ�ı�</param>
    ''' <param name="Editable"> ָ���ڴ���β�����Ƿ���Ա༭���󡣴����Ե�Ĭ��ֵΪ true��</param>
    ''' <returns>�༭�ɹ��򷵻���ֵ</returns>
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
    ''' ��ȡ��������.
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
    ''' ��ȡ�����б�
    ''' </summary>
    ''' <returns>�����ַ�������</returns>
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
    ''' �༭����
    ''' </summary>
    ''' <param name="xID">����ID</param>
    ''' <param name="xType">��������</param>
    ''' <param name="xFunction">ָ���������� Visual Studio �л�ý���ʱҪִ�еĺ���</param>
    ''' <param name="xDefault">Ĭ��ֵ</param>
    ''' <param name="xToolTip">��ʾ��Ϣ</param>
    ''' <param name="Editable"> ָ���ڴ���β�����Ƿ���Ա༭���󡣴����Ե�Ĭ��ֵΪ true��</param>
    ''' <returns>����༭�ɹ��򷵻���</returns>
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
    ''' ��ȡ�����б�
    ''' </summary>
    ''' <returns>�����ַ�������</returns>
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
    ''' ɾ��Literal 
    ''' </summary>
    ''' <param name="xID">��ʶLiteral���ַ���</param>
    ''' <returns>���ɾ���ɹ��򷵻���</returns>
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
    ''' ɾ���������!
    ''' </summary>
    ''' <param name="xID">����ʶ�����.</param>
    ''' <returns>���ɾ���ɹ��򷵻���</returns>
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
    ''' ָ������ε����ԡ����õ�ֵ�� VB��CSharp��VJSharp �� XML���йظ�����Ϣ����μ��±��еġ�Language ���ԡ����֡�
    ''' </summary>
    ''' <remarks></remarks>
    Enum Language
        VB
        CSharp
        VJSharp
        XML
    End Enum
    ''' <summary>
    ''' ָ��������������Ĵ������ͣ����ݴ�ָ�����Բ������ε�λ�á����õ�ֵ�� method body��method decl��type decl��page��file �� any���йظ�����Ϣ����μ��±��еġ�Kind ���ԡ����֡�
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
    ''' �༭�����
    ''' </summary>
    ''' <param name="xLanguage">ָ������</param>
    ''' <param name="xCodeText">��������</param>
    ''' <param name="xDelimiter">�ָ�����,Ĭ��Ϊ$,���ָ�����������,Ӧ��������������,����: $File$</param>
    ''' <param name="xKind">ָ��������������Ĵ������ͣ����ݴ�ָ�����Բ������ε�λ�á����õ�ֵ�� method body��method decl��type decl��page��file �� any���йظ�����Ϣ����μ��±��еġ�Kind ���ԡ����֡�</param>
    ''' <returns>����༭�ɹ��򷵻���</returns>
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
            xCmt = xDoc.CreateComment("CoderHelper_CodeSnippet ������ MysticBoy ���!")
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
    ''' �����ݱ��浽�ı��ַ�����
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
    ''' ���ı��м��ش����XML
    ''' </summary>
    ''' <param name="txtText">�ı�����</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal txtText As Object)
        xDoc.LoadXml(txtText)
    End Sub
    ''' <summary>
    ''' ��һ��������ļ��м��ش����
    ''' </summary>
    ''' <param name="XmlFileFullName">�ļ��ľ���·��</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal XmlFileFullName As String)
        xDoc.Load(XmlFileFullName)
        xCdSnpt = SetXmlEmt(xDoc.DocumentElement, "CodeSnippet")
        xHeader = SetXmlEmt(xCdSnpt, "Header")
        xSnippet = SetXmlEmt(xCdSnpt, "Snippet")
    End Sub
    ''' <summary>
    ''' ���浼ָ��·�������Ƶ��ļ���
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
            '�����������ɵģ֣��޷�ʶ��
        Catch ex As Exception
        End Try
    End Sub

End Class