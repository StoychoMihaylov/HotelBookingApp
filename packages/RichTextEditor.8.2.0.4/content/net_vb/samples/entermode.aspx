<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		'Editor1.EnterKeyTag = RTEEnterKeyTag.BR;
		Dim m As String = Request.QueryString("m")
		If Not m = "" Then
			If m = "p" Then
				Editor1.EnterKeyTag = RTEEnterKeyTag.P
			End If
			If m = "br" Then
				Editor1.EnterKeyTag = RTEEnterKeyTag.BR
			End If
			If m = "div" Then
				Editor1.EnterKeyTag = RTEEnterKeyTag.DIV
			End If
			rbl_type.Text = m
		End If
	End Sub

	Private Sub rbl_type_change(ByVal sender As Object, ByVal e As EventArgs)
		Response.Redirect("entermode.aspx?m=" + rbl_type.Text)
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Enter mode</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Enter Mode: Paragraph or LineBreak?</h1>
		<p>
			Rich Text Editor can be configured to define the behaviour of the ENTER KEY. You
			use &lt;p&gt;, &lt;br /&gt; or &lt;div&gt; tags when you press enter. In either
			mode &lt;br&gt; tags can be created by using shift+enter.</p>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Default : p" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="br" Value="br"></asp:ListItem>
					<asp:ListItem Text="div" Value="div"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="officexpsilver"  Text = "Type here" />
		</div>
	</form>
</body>
</html>
