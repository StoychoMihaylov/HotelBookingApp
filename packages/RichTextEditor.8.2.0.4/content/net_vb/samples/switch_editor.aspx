<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Public Sub ToggleEditor(ByVal sender As Object, ByVal e As EventArgs)
		If textbox1.Visible Then
			textbox1.Visible = False
			Editor1.Visible = True
			Editor1.Text = textbox1.Text.Replace("\n", "<br>")
		Else
			textbox1.Visible = True
			Editor1.Visible = False
			textbox1.Text = Editor1.PlainTextWithLinefeeds
		End If
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Plain Text Switcher</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Plain Text Switcher</h1>
		<p>
			This example demonstrates how to toggle from a plain text field to the Rich Text
			Editor with a simple button click.</p>
		<asp:Button ID="Button1" OnClick="ToggleEditor" runat="server" Text="Toggle Editor">
		</asp:Button><br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Width="750px" Height="360px" Visible="false" />
		<asp:TextBox ID="textbox1" runat="server" TextMode="MultiLine" Height="360px" Width="750px">
This is some more test text.
This is some more test text.
This is some more test text.
This is some more test text.
This is some more test text.
This is some more test text.
		</asp:TextBox>
	</form>
</body>
</html>
