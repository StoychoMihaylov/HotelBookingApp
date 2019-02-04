<%@ Page Language="VB" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(e As EventArgs)
		MyBase.OnInit(e)
		'Editor1.EnterKeyTag = RTEEnterKeyTag.BR;
		Dim m As String = Request.QueryString("m")
		Dim resizemode As String = "Editor1.ResizeMode = RTEResizeMode.{0};"
		If Not m="" Then
			If m = "auto" Then
				Editor1.ResizeMode = RTEResizeMode.AutoAdjustHeight
				resizemode = String.Format(resizemode, "AutoAdjustHeight")
			End If
			If m = "width" Then
				Editor1.ResizeMode = RTEResizeMode.ResizeWidth
				resizemode = String.Format(resizemode, "ResizeWidth")
			End If
			If m = "height" Then
				Editor1.ResizeMode = RTEResizeMode.ResizeHeight
				resizemode = String.Format(resizemode, "ResizeHeight")
			End If
			If m = "both" Then
				Editor1.ResizeMode = RTEResizeMode.ResizeBoth
				resizemode = String.Format(resizemode, "ResizeBoth")
			End If
			If m = "no" Then
				Editor1.ResizeMode = RTEResizeMode.Disabled
				resizemode = String.Format(resizemode, "Disabled")
			End If
			rbl_type.SelectedValue = m
		Else
			Editor1.ResizeMode = RTEResizeMode.AutoAdjustHeight
			resizemode = String.Format(resizemode, "AutoAdjustHeight")
		End If
		Editor1.Text = "This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text.<br />This is some more test text."
	End Sub

	Private Sub rbl_type_change(ByVal sender As Object, ByVal e As EventArgs)
		Response.Redirect("autoheight.aspx?m=" + rbl_type.SelectedValue)
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Auto adjusting height</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
	<script type="text/javascript">
		var editor;
		function RichTextEditor_OnLoad(rteeditor) {
			editor = rteeditor;
		}
		function GetEditorHTML() {
			if (!editor) return;
			document.getElementById("result").innerHTML = editor.GetText();
		}
	</script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <h1>
            Editor Auto Adjusting Height</h1>
        <p>
            This example demonstrates how to use Editor.ResizeMode to make the Editor change
            its height based on the content. The Editor will now grow and shrink in height to
            match the content inside.
        </p>
        <div>
            <div>
                <asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                    AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
                    <asp:ListItem Text="AutoAdjustHeight" Value="auto" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Width" Value="width"></asp:ListItem>
                    <asp:ListItem Text="Height" Value="height"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="both"></asp:ListItem>
                    <asp:ListItem Text="None" Value="no"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Height="260px" />
            <br />
            <div>
                <button type="button" onclick="GetEditorHTML();">
                    Get Content</button>
            </div>
        </div>
        <br />
        <div>
            <h3>
                Result html:</h3>
            <div id="result">
            </div>
        </div>
    </form>
</body>
</html>
