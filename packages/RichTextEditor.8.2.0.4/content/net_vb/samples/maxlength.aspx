<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		Dim m As String = Request.QueryString("m")
		If Not m = "" Then
			If m = "html" Then
                Editor1.MaxHTMLLength = 100
			End If
			If m = "text" Then
                Editor1.MaxTextLength = 100
			End If
			rbl_type.SelectedValue = m
		End If
	End Sub

	Private Sub btn_sumbit_click(ByVal sender As Object, ByVal e As EventArgs)
		lit_result.Text = Editor1.Text.Replace("<", "&lt;")
	End Sub

	Private Sub rbl_type_change(ByVal sender As Object, ByVal e As EventArgs)
		Response.Redirect("maxlength.aspx?m=" + rbl_type.SelectedValue)
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Rich Text Editor: Setting the max length</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Use MaxHTMLLength or MaxTextLength to Protect Your Database</h1>
		<p>
			We often use a database backend such as <a target="_blank" href="http://www.microsoft.com/sql/">
				SQL Server</a> to store data. In such databases, you have to specify the length
			of any textual field when a table is designed. If you tried to insert a record whose
			text length is greater than allowed by your table, an error will be reported.
			<br />
			<br />
			To prevent this type of error from occurring, developers can use <strong>MaxHTMLLength</strong>
			or <strong>MaxTextLength</strong> in the RichTextEditor to limit the length of the
			user's input.
		</p>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Non-limit" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="MaxHTMLLength : 100" Value="html"></asp:ListItem>
					<asp:ListItem Text="MaxTextLength : 100" Value="text"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
			<br />
			<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
		</div>
		<br />
		<div>
			<h3>
				Result html:</h3>
			<div id="result">
				<asp:Literal ID="lit_result" runat="server"></asp:Literal>
			</div>
		</div>
	</form>
</body>
</html>
