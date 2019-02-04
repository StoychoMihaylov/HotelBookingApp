Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.WebControls
Imports RTE

Namespace Controllers
    Public Class MyModel
        Private _title As String
        Private _message As String
        Private _accept As Boolean

        <System.ComponentModel.DataAnnotations.Required(ErrorMessage:="*")> _
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(value As String)
                _title = value
            End Set
        End Property

        <System.ComponentModel.DataAnnotations.Required(ErrorMessage:="*")> _
        Public Property Message() As String
            Get
                Return _message
            End Get
            Set(value As String)
                _message = value
            End Set
        End Property

        <System.ComponentModel.DataAnnotations.RegularExpression("True", ErrorMessage:="You must accept it.")> _
        <System.ComponentModel.DataAnnotations.Display(Name:="I accept it.")> _
        Public Property Accept() As Boolean
            Get
                Return _accept
            End Get
            Set(value As Boolean)
                _accept = value
            End Set
        End Property
    End Class

    <ValidateInput(False)> _
    Public Class VbModelController
        Inherits System.Web.Mvc.Controller

        'this is a custom function that create and initialize the editor
        Protected Function PrepairEditor(propertyName As String, oninit As Action(Of Editor)) As Editor
            Dim editor As New Editor(System.Web.HttpContext.Current, propertyName)

			editor.ClientFolder = "/richtexteditor/"
			editor.ContentCss = "/Content/example.css"
            'editor.ClientFolder = "/Content/richtexteditor/";
            'editor.ClientFolder = "/Scripts/richtexteditor/";

            'editor.Text = "Type here";

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
            PrepairEditor("Message",
                Sub(editor As Editor)

                End Sub)
            Return New EmptyResult()
        End Function

        <ValidateInput(False)> _
        Public Function PostToModel() As ActionResult
            'set editor properties here
            PrepairEditor("Message",
                Sub(editor As Editor)

                End Sub)
            Return View(New MyModel())
        End Function

        <HttpPost> _
        <ValidateInput(False)> _
        Public Function PostToModel(model As MyModel) As ActionResult
            PrepairEditor("Message",
                Sub(editor As Editor)
                    'set editor properties here
                End Sub)

            'check the editor data here
            If ModelState.IsValid Then
                'TODO , save the data to DB , and redirect to result page..
            End If

            Return View(model)
        End Function

    End Class
End Namespace
