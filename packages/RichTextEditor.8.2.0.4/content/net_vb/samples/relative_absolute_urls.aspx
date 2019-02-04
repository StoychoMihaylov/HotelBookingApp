<%@ Page Language="VB" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(e As EventArgs)
		MyBase.OnInit(e)
		Editor1.Text = "<div><a href=""some.htm"">This is a relative path</a><br><br><a href=""/some.htm"">This is a Site Root Relative path</a> <br><br><a href=""http://somesite/some.htm"">This is a absolute path.</a><br><br><a href=""#tips"">This is a link to anchor.</a><br><br></div>"
	End Sub

	Private Sub btn_sumbit_click(sender As Object, e As EventArgs)
		lit_result.Text = Editor1.Text.Replace("<", "&lt;")
	End Sub

	Private Sub rbl_type_change(sender As Object, e As EventArgs)
		Dim m As String = rbl_type.SelectedValue
		If m = "abs" Then
			Editor1.URLType = RTEURLType.Absolute
		ElseIf m = "rel" Then
			Editor1.URLType = RTEURLType.SiteRelative
		Else
			Editor1.URLType = RTEURLType.[Default]
		End If
	End Sub
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Relative, Absolute URLs</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
	<h1>
		Relative or Absolute URLs, which do you prefer?</h1>
	<p>
		With RichTextEditor, you have the choice of using either a relative or absolute
		URL.
	</p>
	<div>
		<div>
			<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
				AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
				<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
				<asp:ListItem Text="Absolute URLs" Value="abs"></asp:ListItem>
				<asp:ListItem Text="SiteRelative URLs" Value="rel"></asp:ListItem>
			</asp:RadioButtonList>
		</div>
		<br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="officexpsilver" Toolbar="full" ShowLinkbar="false" />
		<br />
		<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
	</div>
	<br />
	<div>
		<h3>
			Result html code:</h3>
		<div>
			<asp:Literal ID="lit_result" runat="server"></asp:Literal>
		</div>
	</div>
	
	</form>
</body>
</html>
