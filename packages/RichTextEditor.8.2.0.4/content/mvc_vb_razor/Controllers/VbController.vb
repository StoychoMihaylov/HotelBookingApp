Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.WebControls
Imports RTE


Namespace Controllers
    <ValidateInput(False)> _
    Public Class VbController
        Inherits System.Web.Mvc.Controller

        'this is a custom function that create and initialize the editor
        Function PrepairEditor(oninit As Action(Of Editor)) As Editor
            Dim editor As Editor = New Editor(System.Web.HttpContext.Current, "editor")
			editor.ClientFolder = "/richtexteditor/"
			editor.ContentCss = "/Content/example.css"
            'editor.ClientFolder = "/Content/richtexteditor/"
            'editor.ClientFolder = "/Scripts/richtexteditor/"
            editor.Text = "Type here"
            editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler")

            If oninit <> Nothing Then
                oninit(editor)
            End If

            'try to handle the upload/ajax requests
            Dim isajax As Boolean = editor.MvcInit()

            If isajax Then
                Return editor
            End If

            'load the form data if any
            If Me.Request.HttpMethod = "POST" Then
                Dim formdata As String = Me.Request.Form(editor.Name)
                If formdata <> Nothing Then
                    editor.LoadFormData(formdata)
                End If
            End If
            'render the editor to ViewBag.Editor
            ViewBag.Editor = editor.MvcGetString()
            Return editor
        End Function

        'this action is specified by editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");
        'it will handle the editor dialogs Upload/Ajax requests
        <ValidateInput(False)> _
        Function EditorAjaxHandler() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return New EmptyResult()
        End Function

        Function toolbar_editor() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        Function autoheight() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.LoadFormData("This is some more test text.<br />This is some more test text.<br />This is some more test text.<br /" & _
                        ">This is some more test text.<br />This is some more test text.<br />This is some more test text.<br" & _
                        " />This is some more test text.")
                    Dim m As String = "auto"
                    If (Request.QueryString.Count <> 0) Then
                        m = Request.QueryString("mode").ToString
                    End If
                    If Not String.IsNullOrEmpty(m) Then
                        If (m = "auto") Then
                            editor.ResizeMode = RTEResizeMode.AutoAdjustHeight
                        End If
                        If (m = "width") Then
                            editor.ResizeMode = RTEResizeMode.ResizeWidth
                        End If
                        If (m = "height") Then
                            editor.ResizeMode = RTEResizeMode.ResizeHeight
                        End If
                        If (m = "both") Then
                            editor.ResizeMode = RTEResizeMode.ResizeBoth
                        End If
                        If (m = "no") Then
                            editor.ResizeMode = RTEResizeMode.Disabled
                        End If
                    Else
                        editor.ResizeMode = RTEResizeMode.AutoAdjustHeight
                    End If

                    ViewBag.mode = m
                End Sub)
            Return View()
        End Function

        Function contextmenumode() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function contextmenumode(ByVal m As String) As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    m = Request.Form("SelectType")
                    editor.ContextMenuMode = RTEContextMenuMode.Default
                    If Not String.IsNullOrEmpty(m) Then
                        If (m = "Minimal") Then
                            editor.ContextMenuMode = RTEContextMenuMode.Minimal
                        End If
                        If (m = "Simple") Then
                            editor.ContextMenuMode = RTEContextMenuMode.Simple
                        End If
                        ViewBag._mode = m
                    End If
                End Sub)
            Return View()
        End Function

        Function custom_buttons() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.ToolbarItems = "{bold,italic,underlinemenu}{forecolor,backcolor,fontname,fontsize}{justifyleft,justifycenter,justifyr" & _
                    "ight,justifyfull}{insertorderedlist,insertunorderedlist,outdent,indent}{insertlink,insertimage,inser" & _
                    "tblockquote,syntaxhighlighter}{unlink,removeformat}//{mybutton1}"
                End Sub)
            Return View()
        End Function

        Function custom_buttons2() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)
                   editor.ToolbarItems = "{bold,italic,underlinemenu}{forecolor,backcolor,fontname,fontsize}{justifyleft,justifycenter,justifyr" & _
                   "ight,justifyfull}{insertorderedlist,insertunorderedlist,outdent,indent}{insertlink,insertimage,inser" & _
                   "tblockquote,syntaxhighlighter}{unlink,removeformat}//{mydialog1}"
               End Sub)
            Return View()
        End Function

        Function custom_css() As ActionResult
			PrepairEditor(
			   Sub(editor As Editor)
				   editor.ContentCss = "/Content/example.css,/Content/forecolor.css"
			   End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function custom_css(ByVal m As String) As ActionResult
			PrepairEditor(
			   Sub(editor As Editor)
				   m = Request.Form("SelectType")
				   If Not String.IsNullOrEmpty(m) Then
					   editor.ContentCss = "/Content/example.css," + m
					   ViewBag._mode = m
				   Else
					   editor.ContentCss = "/Content/example.css,/Content/forecolor.css"
				   End If
			   End Sub)
            Return View()
        End Function

        Function dialog_editor() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)

               End Sub)
            Return View()
        End Function

        Function doctype() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)

               End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function doctype(ByVal m As String) As ActionResult
            PrepairEditor(
              Sub(editor As Editor)
                  m = Request.Form("SelectType")
                  editor.DesignDocType = RTEDesignDocType.Default
                  If Not String.IsNullOrEmpty(m) Then
                      If (m = "HTML4") Then
                          editor.DesignDocType = RTEDesignDocType.HTML4
                      End If
                      If (m = "HTML5") Then
                          editor.DesignDocType = RTEDesignDocType.HTML5
                      End If
                      If (m = "XHTML") Then
                          editor.DesignDocType = RTEDesignDocType.XHTML
                      End If
                      ViewBag._mode = m
                  End If
              End Sub)
            Return View()
        End Function

        Function entermode() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function entermode(ByVal m As String) As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    m = Request.Form("SelectType")
                    If Not String.IsNullOrEmpty(m) Then
                        If (m = "p") Then
                            editor.EnterKeyTag = RTEEnterKeyTag.P
                        End If
                        If (m = "br") Then
                            editor.EnterKeyTag = RTEEnterKeyTag.BR
                        End If
                        If (m = "div") Then
                            editor.EnterKeyTag = RTEEnterKeyTag.DIV
                        End If
                        ViewBag._mode = m
                    End If
                End Sub)
            Return View()
        End Function

        Function filter_html() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)

               End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function filter_html(ByVal m As String) As ActionResult
            PrepairEditor(
              Sub(editor As Editor)
                  m = Request.Form("SelectType")
                  If Not String.IsNullOrEmpty(m) Then
                      If (m = "no") Then
                          editor.TagBlackList = "*"
                      End If
                      If (m = "white") Then
                          editor.TagWhiteList = "embed"
                      End If
                      If (m = "black") Then
                          editor.TagBlackList = "div"
                      End If
                      If (m = "full") Then
                          editor.AllowScriptCode = True
                          editor.EditCompleteDocument = True
                          editor.TagBlackList = ""
                      End If
                      ViewBag._mode = m
                  End If
              End Sub)
            Return View()
        End Function

        Function fullpage_editor() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)
                   editor.AllowScriptCode = True
                   editor.EditCompleteDocument = True
                   editor.TagBlackList = ""
                   editor.Text = ("<html><head></head><body><div>Editor full html page</div><br/><br/>" + "<div style='font-weight:bold;'>Editor1.AllowScriptCode = true;<br/>Editor1.EditCompleteDocument = tru" & _
                   "e;<br/>Editor1.TagBlackList = \""\"";</div></body></html>")
               End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function fullpage_editor(ByVal m As String) As ActionResult
            PrepairEditor(
               Sub(editor As Editor)
                   editor.AllowScriptCode = True
                   editor.EditCompleteDocument = True
                   editor.TagBlackList = ""
                   Dim c As String = Request.Form("editor")
                   If Not String.IsNullOrEmpty(c) Then
                       ViewBag._content = editor.Text
                   End If
               End Sub)
            Return View()
        End Function

        Function javascript_api() As ActionResult
            PrepairEditor(
               Sub(editor As Editor)
                   editor.Width = Unit.Pixel(600)
                   editor.Height = Unit.Pixel(300)
                   editor.Skin = "smartgray"
                   editor.Toolbar = "minimal"
               End Sub)
            Return View()
        End Function

        Function jquery_tabs() As ActionResult
            Dim Editor1 As Editor = PrepairEditor(
               Sub(editor As Editor)
                   editor.ID = "Editor1"
                   editor.Name = "Editor1"
                   editor.Width = Unit.Pixel(600)
                   editor.Height = Unit.Pixel(300)
                   editor.Skin = "office2003blue"
                   editor.Toolbar = "email"
                   editor.LoadFormData("Tab # 1 content")
               End Sub)
            Dim Editor2 As Editor = PrepairEditor(
                   Sub(editor As Editor)
                       editor.ID = "Editor2"
                       editor.Name = "Editor2"
                       editor.Width = Unit.Pixel(640)
                       editor.Height = Unit.Pixel(300)
                       editor.Skin = "smartblue"
                       editor.Toolbar = "email"
                       editor.LoadFormData("Tab # 2 content")
                   End Sub)
            Dim Editor3 As Editor = PrepairEditor(
                       Sub(editor As Editor)
                           editor.ID = "Editor3"
                           editor.Name = "Editor3"
                           editor.Width = Unit.Pixel(600)
                           editor.Height = Unit.Pixel(300)
                           editor.Skin = "officexpsilver"
                           editor.Toolbar = "email"
                           editor.LoadFormData("Tab # 3 content")
                       End Sub)
            ViewBag.Editor1 = Editor1.MvcGetString
            ViewBag.Editor2 = Editor2.MvcGetString
            ViewBag.Editor3 = Editor3.MvcGetString
            Return View()
        End Function

        Function localization() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function localization(ByVal m As String) As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 m = Request.Form("SelectType")
                 If Not String.IsNullOrEmpty(m) Then
                     editor.Language = m
                     ViewBag._mode = m
                 End If
             End Sub)
            Return View()
        End Function

        Function maxlength() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function maxlength(ByVal m As String) As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 m = Request.Form("SelectType")
                 If Not String.IsNullOrEmpty(m) Then
                     If (m = "html") Then
                         editor.MaxHTMLLength = 100
                     End If
                     If (m = "text") Then
                         editor.MaxTextLength = 100
                     End If
                     ViewBag._mode = m
                 End If
             End Sub)
            Return View()
        End Function

        Function mswordcleanup() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            Return View()
        End Function

        Function multi_editor() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)
                  editor.Width = Unit.Pixel(500)
                  editor.Height = Unit.Pixel(300)
                  editor.Skin = "smartsilver"
                  editor.Toolbar = "forum"
              End Sub)
            Return View()
        End Function

        Function multiple_editors() As ActionResult
            Dim Editor1 As Editor = PrepairEditor(
             Sub(editor As Editor)
                 editor.ID = "Editor1"
                 editor.Name = "Editor1"
                 editor.Width = Unit.Pixel(750)
                 editor.Height = Unit.Pixel(300)
                 editor.Skin = "smartblue"
                 editor.Toolbar = "forum"
                 editor.LoadFormData("<div style='color:red;'><strong>1. Easy for developers</strong></div>")
             End Sub)
            Dim Editor2 As Editor = PrepairEditor(
              Sub(editor As Editor)
                  editor.ID = "Editor2"
                  editor.Name = "Editor2"
                  editor.Width = Unit.Pixel(750)
                  editor.Height = Unit.Pixel(300)
                  editor.Skin = "smartsilver"
                  editor.Toolbar = "forum"
                  editor.LoadFormData("<div style='color:darkgreen;'><strong>2. Seamless Integration with Web Forms</strong></div>")
              End Sub)

            ViewBag.Editor1 = Editor1.MvcGetString
            ViewBag.Editor2 = Editor2.MvcGetString

            If Request.HttpMethod = "POST" Then
                ViewBag._content = "<div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/>" & Editor1.Text & _
                         "<br/><div style='font-size:16px;font-weight:bold;'>RichTextEditor 2:</div><br/>" & Editor2.Text
            End If

            Return View()
        End Function

        '<HttpPost(), _
        ' ValidateInput(False)> _
        'Function multiple_editors(ByVal m As String) As ActionResult
        '    Dim Editor1 As Editor = PrepairEditor(
        '      Sub(editor As Editor)
        '          editor.ID = "Editor1"
        '          editor.Name = "Editor1"
        '          editor.Width = Unit.Pixel(750)
        '          editor.Height = Unit.Pixel(300)
        '          editor.Skin = "smartblue"
        '          editor.Toolbar = "forum"
        '          editor.LoadFormData("<div style='color:red;'><strong>1. Easy for developers</strong></div>")
        '      End Sub)
        '    Dim Editor2 As Editor = PrepairEditor(
        '      Sub(editor As Editor)
        '          editor.ID = "Editor2"
        '          editor.Name = "Editor2"
        '          editor.Width = Unit.Pixel(750)
        '          editor.Height = Unit.Pixel(300)
        '          editor.Skin = "smartsilver"
        '          editor.Toolbar = "forum"
        '          editor.LoadFormData("<div style='color:darkgreen;'><strong>2. Seamless Integration with Web Forms</strong></div>")
        '      End Sub)

        '    ViewBag.Editor1 = Editor1.MvcGetString
        '    ViewBag.Editor2 = Editor2.MvcGetString

        '    If Request.HttpMethod = "POST" Then
        '        ViewBag._content = "<div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/>" & Editor1.Text & _
        '                 "<br/><div style='font-size:16px;font-weight:bold;'>RichTextEditor 2:</div><br/>" & Editor2.Text
        '    End If

        '    Return View()
        'End Function

        Function noneditable_contents() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            Return View()
        End Function

        Function onpaste() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)
                  editor.PasteMode = RTEPasteMode.Default
              End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function onpaste(ByVal m As String) As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 m = Request.Form("SelectType")
                 If Not String.IsNullOrEmpty(m) Then
                     If (m = "Disabled") Then
                         editor.PasteMode = RTEPasteMode.Disabled
                     End If
                     If (m = "Paste") Then
                         editor.PasteMode = RTEPasteMode.Paste
                     End If
                     If (m = "PasteText") Then
                         editor.PasteMode = RTEPasteMode.PasteText
                     End If
                     If (m = "PasteWord") Then
                         editor.PasteMode = RTEPasteMode.PasteWord
                     End If
                     If (m = "ConfirmWord") Then
                         editor.PasteMode = RTEPasteMode.ConfirmWord
                     End If
                     ViewBag._mode = m
                 Else
                     editor.PasteMode = RTEPasteMode.Default
                 End If
             End Sub)
            Return View()
        End Function

        Function plaintext() As ActionResult
            PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function plaintext(ByVal m As String) As ActionResult
            Dim Editor1 As Editor = PrepairEditor(
              Sub(editor As Editor)

              End Sub)
            ViewBag._content = Editor1.PlainText
            Return View()
        End Function

        Function readonly_editor() As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 editor.Text = "This is a readonly editor."
                 editor.ReadOnly = True
             End Sub)
            Return View()
        End Function

        Function relative_absolute_urls() As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 Dim _text As String = "<div> <a href='some.htm'>This is a relative path</a><br /><br /><a href='/some.htm'>This is a Site Root Relative path</a><br /><br /><a href='http://somesite/some.htm'>This is a absolute path.</a><br /><br /><a href='#tips'>This is a link to anchor.</a><br /></div>"
                 editor.LoadFormData(_text)
             End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function relative_absolute_urls(ByVal m As String) As ActionResult
            PrepairEditor(
            Sub(editor As Editor)
                editor.Height = Unit.Pixel(420)
                Dim mode As String = Request.Form("SelectType")
                If Not String.IsNullOrEmpty(mode) Then
                    ViewBag._mode = mode
                    If (mode = "abs") Then
                        editor.URLType = RTEURLType.Absolute
                    ElseIf (mode = "rel") Then
                        editor.URLType = RTEURLType.SiteRelative
                    Else
                        editor.URLType = RTEURLType.Default
                    End If
                End If
            End Sub)
            Return View()
        End Function

        Function security() As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 'need to point another url to apply the security policy
                 editor.AjaxPostbackUrl = Url.Action("security")
             End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function security(ByVal m As String) As ActionResult
            PrepairEditor(
            Sub(editor As Editor)
                'need to point another url to apply the security policy
                editor.AjaxPostbackUrl = Url.Action("security")
                Dim selecttype As String = ""
                Dim _secstr As String = ""
                selecttype = Request.Form("SelectType")
                ViewBag._selecttype = selecttype
                Dim _store As String = ""
                Dim file As RTE.ConfigFile
                Dim storages() As RTE.ConfigSecurity
                editor.RenderSupportAjax = False
                Select Case (selecttype)
                    Case "Administrators"
                        editor.SecurityPolicyFile = "admin.config"
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + "<br/>"))
                    Case "Members"
                        editor.SecurityPolicyFile = "default.config"
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + "<br/>"))
                    Case "Guest"
                        editor.SecurityPolicyFile = "guest.config"
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + "<br/>"))
                    Case "John"
                        editor.SecurityPolicyFile = "admin.config"
                        file = editor.LoadConfigFile
                        storages = file.GetItems("Gallery", False, True)
                        _store = (storages(0).StoragePath + "/John")
                        editor.SetSecurity("Gallery", "*", "StoragePath", _store)
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + ("<br/> Gallery:" + _store)))
                    Case "Mary"
                        editor.SecurityPolicyFile = "default.config"
                        file = editor.LoadConfigFile
                        storages = file.GetItems("Gallery", False, True)
                        _store = (storages(0).StoragePath + "/Mary")
                        editor.SetSecurity("Gallery", "*", "StoragePath", _store)
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + ("<br/> Gallery:" + _store)))
                    Case "Tim"
                        editor.SecurityPolicyFile = "default.config"
                        file = editor.LoadConfigFile
                        storages = file.GetItems("Gallery", False, True)
                        _store = (storages(0).StoragePath + "/Tim")
                        editor.SetSecurity("Gallery", "*", "StoragePath", _store)
                        _secstr = ("Policy file:" _
                                    + (editor.SecurityPolicyFile + ("<br/> Gallery:" + _store)))
                End Select
                ViewBag._secstr = _secstr
            End Sub)
            Return View()
        End Function

        Function showrulers() As ActionResult
            PrepairEditor(
             Sub(editor As Editor)
                 editor.ShowRulers = True
             End Sub)
            Return View()
        End Function

        Function skinning_editor() As ActionResult
            PrepairEditor(
            Sub(editor As Editor)
                editor.Text = "Type here"
                Dim skin As String = Request.QueryString("skin")
                If (Request.UserAgent.IndexOf("Mobile") >= 0) Then
                    skin = "phonesilver"
                End If
                If String.IsNullOrEmpty(skin) Then
                    skin = "office2007blue"
                End If
                editor.Skin = skin
                Dim toolbar As String = Request.QueryString("toolbar")
                If Not String.IsNullOrEmpty(toolbar) Then
                    editor.Toolbar = toolbar
                End If
                Dim itemlist() As String = New String() {"", "{fullscreen,undo,redo,find}{insertlink,unlink}{insertlinemenu,justifymenu,insertorderedlist,insertuno" & _
                        "rderedlist,outdent,indent,insertblockquote}{inserttable,insertgallery,insertimage}{inserttemplate,in" & _
                        "sertdocument,insertmedia,insertyoutube,html5,googlemap}{help}/[paragraphs,styles][fontname,fontsize]" & _
                        "{bold,italic,underlinemenu}{forecolor,backcolor}{superscript,subscript,changecase}{removeformat}{for" & _
                        "matpainter}", "{save,new,print,spellcheck}{paste,pastetext,pasteword}{cut,copy,delete,find}{undo,redo}{inserttable,i" & _
                        "nsertgallery,insertimage}{inserttemplate,insertdocument,insertmedia,syntaxhighlighter,insertyoutube," & _
                        "html5,googlemap}/[fontname,fontsize]{bold,italic,underlinemenu}{forecolor,backcolor}{superscript,sub" & _
                        "script,changecase}{removeformat,cleancode,selectall}{formatpainter}{insertlink,unlink,insertanchor,i" & _
                        "nsertimagemap,insertdate,insertchars,virtualkeyboard}/[paragraphs,styles]{justifymenu,lineheight,ltr" & _
                        ",rtl,insertlinemenu}{insertorderedlist,insertunorderedlist,outdent,indent,insertblockquote}{insertfo" & _
                        "rm,insertbox,insertlayer,insertfieldset,fullscreen,toggleborder,pageproperties,help}", "<@COMMON,ribbonpaste,pastetext,pasteword,{save,new,print,spellcheck}{cut,copy,delete,find}{undo,redo|" & _
                        "formatpainter}><@FORMAT,[fontname,fontsize]{bold,italic,underlinemenu|forecolor,backcolor}{superscri" & _
                        "pt,subscript,changecase|removeformat,cleancode,selectall}><@PARAGRAPHS,[paragraphs,styles]{justifyme" & _
                        "nu,lineheight,ltr,rtl,insertlinemenu}{insertorderedlist,insertunorderedlist,outdent,indent,insertblo" & _
                        "ckquote}><@INSERT,ribbontable,insertgallery,insertimage,{insertform,insertbox,insertlayer,insertfiel" & _
                        "dset,fullscreen,toggleborder,pageproperties,help}{insertlink,unlink,insertanchor,insertimagemap,inse" & _
                        "rtdate,insertchars,virtualkeyboard}{inserttemplate,insertdocument,insertmedia,syntaxhighlighter,inse" & _
                        "rtyoutube,html5,googlemap}>"}
                Dim index As Integer
                If Integer.TryParse(Request.QueryString("itemlist"), index) Then
                    If ((index >= 0) _
                                AndAlso (index < itemlist.Length)) Then
                        editor.ToolbarItems = itemlist(index)
                    End If
                End If
            End Sub)
            Return View()
        End Function

        Function table_support() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        Function bbcode(ByVal m As String) As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function bbcode() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    ViewBag.BBCode = editor.BBCode
                End Sub)
            Return View()
        End Function

        Function watermark() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.AjaxPostbackUrl = Url.Action("watermark")
                    If (Request.HttpMethod = "POST") Then
                        AddHandler editor.UploadImage, AddressOf Me.Editor1_UploadImage
                    End If
                End Sub)
            Return View()
        End Function

        'Function watermark_handler() As ActionResult
        '    PrepairEditor(
        '        Sub(editor As Editor)
        '            AddHandler editor.UploadImage, AddressOf Me.Editor1_UploadImage
        '        End Sub)
        '    Return View()
        'End Function

        Sub Editor1_UploadImage(ByVal sender As Object, ByVal args As UploadImageEventArgs)
            Dim text As String = Request("txt_watermark")
            Dim bitmap As New System.Drawing.Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
                Dim style As System.Drawing.FontStyle = System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline
                Dim font As New System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 26, style)
                Dim size As System.Drawing.SizeF = g.MeasureString(text, font)
                g.DrawString(text, font, System.Drawing.Brushes.DarkGreen, bitmap.Width - size.Width, bitmap.Height - size.Height)
            End Using

            Dim watermark As RTE.ConfigWatermark = New ConfigWatermark()
            watermark.XAlign = "right"
            watermark.YAlign = "bottom"
            watermark.XOffset = -10
            watermark.YOffset = -10
            watermark.MinWidth = 450
            watermark.MinHeight = 300
            watermark.Image = bitmap

            args.Watermarks.Clear()
            args.Watermarks.Add(watermark)
            args.DrawWatermarks = True
        End Sub

        <ValidateInput(False)> _
        Function showlinkbar() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.Text = "<a href='http://cutesoft.net' target='_blank'>This is a test link</a>"
                End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function showlinkbar(ByVal m As String) As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    m = Request.Form("SelectType")
                    If Not String.IsNullOrEmpty(m) Then
                        If (m = "yes") Then
                            editor.ShowLinkbar = True
                        End If
                        If (m = "no") Then
                            editor.ShowLinkbar = False
                        End If
                        ViewBag._mode = m
                    End If
                    editor.Text = "<a href='http://cutesoft.net' target='_blank'>This is a test link</a>"
                End Sub)
            Return View()
        End Function

        Function format_bold() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.ToolbarItems = "{bold}"
                    editor.Text = "Please select text and click bold button"
                End Sub)
            Return View()
        End Function

        <HttpPost(), _
         ValidateInput(False)> _
        Function format_bold(ByVal m As String) As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.Text = "Please select text and click bold button"
                    editor.ToolbarItems = "{bold}"
                    m = Request.Form("SelectType")
                    If Not String.IsNullOrEmpty(m) Then
                        If (m = "b") Then
                            editor.SetConfig("format_bold", "<b>")
                        ElseIf (m = "span") Then
                            editor.SetConfig("format_bold", "<span style='font-weight:bold'>")
                        End If
                        ViewBag._mode = m
                    End If
                End Sub)
            Return View()
        End Function

        Function capture_save() As ActionResult
            PrepairEditor(
                 Sub(editor As Editor)

                 End Sub)
            Return View()
        End Function

        Function populate_menu() As ActionResult
            PrepairEditor(
                 Sub(editor As Editor)
                     'add content css
                     editor.ContentCss = "/Content/dynamicstyles.css"
                     'set font name, font size list by servercode
                     'Editor1.SetConfig("fontnamelist", "Arial,Microsoft YaHei,Verdana");
                     'Editor1.SetConfig("fontsizelist","9px,13px,16px,20px,24px,32px");
                     editor.ToolbarItems = "{styles,fontname,fontsize}{mydropdownlink,mydropdowncodesnippet}"
                 End Sub)
            Return View()
        End Function

        Function select_image() As ActionResult
            PrepairEditor(
                 Sub(editor As Editor)

                 End Sub)
            Return View()
        End Function

        Function select_file() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        Function simple_editor() As ActionResult
            Dim Editor1 As Editor = PrepairEditor(
                Sub(editor As Editor)
                    editor.ID = "Editor1"
                    editor.Name = "Editor1"
                    editor.Height = Unit.Pixel(200)
                    editor.Text = "Type here"
                    editor.Skin = "officexpsilver"
                    editor.Toolbar = "minimal"
                End Sub)
            Dim Editor2 As Editor = PrepairEditor(
                Sub(editor As Editor)
                    editor.ID = "Editor2"
                    editor.Name = "Editor2"
                    editor.Height = Unit.Pixel(200)
                    editor.Text = "Type here"
                    editor.Skin = "officexpblue"
                    editor.Toolbar = "email"
                End Sub)
            Dim Editor3 As Editor = PrepairEditor(
                Sub(editor As Editor)
                    editor.ID = "Editor3"
                    editor.Name = "Editor3"
                    editor.Height = Unit.Pixel(200)
                    editor.Text = "Type here"
                    editor.Skin = "office2003silver2"
                    editor.Toolbar = "forum"
                End Sub)
            Dim Editor4 As Editor = PrepairEditor(
                Sub(editor As Editor)
                    editor.ID = "Editor4"
                    editor.Name = "Editor4"
                    editor.Height = Unit.Pixel(200)
                    editor.Text = "Type here"
                    editor.Skin = "office2003blue"
                    editor.Toolbar = "light"
                End Sub)

            ViewBag.Editor1 = Editor1.MvcGetString
            ViewBag.Editor2 = Editor2.MvcGetString
            ViewBag.Editor3 = Editor3.MvcGetString
            ViewBag.Editor4 = Editor4.MvcGetString
            Return View()
        End Function

        Function switch_editor() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)
                    editor.Width = Unit.Pixel(750)
                    editor.Height = Unit.Pixel(360)
                End Sub)
            Return View()
        End Function

        Function output_xhtml() As ActionResult
            PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            Return View()
        End Function

        <HttpPost()> _
        Function output_xhtml(ByVal m As String) As ActionResult
            Dim Editor1 As Editor = PrepairEditor(
                Sub(editor As Editor)

                End Sub)
            ViewBag._content = Editor1.XHTML
            Return View()
        End Function

    End Class
End Namespace
