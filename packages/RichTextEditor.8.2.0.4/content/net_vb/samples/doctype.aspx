<%@ Page Language="VB" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(e As EventArgs)
		MyBase.OnInit(e)
		Dim m As String = Request.QueryString("m")
		Editor1.DesignDocType = RTEDesignDocType.[Default]
		If Not m="" Then
			If m = "HTML4" Then
				Editor1.DesignDocType = RTEDesignDocType.HTML4
			End If
			If m = "HTML5" Then
				Editor1.DesignDocType = RTEDesignDocType.HTML5
			End If
			If m = "XHTML" Then
				Editor1.DesignDocType = RTEDesignDocType.XHTML
			End If
			rbl_type.SelectedValue = m
		End If
	End Sub

	Private Sub rbl_type_change(sender As Object, e As EventArgs)
		Response.Redirect("doctype.aspx?m=" + rbl_type.SelectedValue)
	End Sub
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - DesignDocType</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
	<h1>
		Design DocType</h1>
	<p>
		</p>
	<div>
		<div>
			<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
				AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
				<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
				<asp:ListItem Text="HTML4" Value="HTML4"></asp:ListItem>
				<asp:ListItem Text="HTML5" Value="HTML5"></asp:ListItem>
				<asp:ListItem Text="XHTML" Value="XHTML"></asp:ListItem>
			</asp:RadioButtonList>
		</div>
		<br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="officexpsilver"  Text = "Type here" />
	</div>
	</form>
</body>
</html>
