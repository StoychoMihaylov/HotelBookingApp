<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		Editor1.AllowScriptCode = True
		Editor1.EditCompleteDocument = True
		Editor1.TagBlackList = ""
		Editor1.Text = "<html><head></head><body><div>Editor full html page</div><br/><br/>" + "<div style='font-weight:bold;'>Editor1.AllowScriptCode = true;<br/>Editor1.EditCompleteDocument = true;<br/>Editor1.TagBlackList = """";</div></body></html>"
	End Sub

	Private Sub btn_sumbit_click(ByVal sender As Object, ByVal e As EventArgs)
		lit_result.Text = Editor1.Text.Replace("<", "&lt;")
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Edit full html</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Edit full html page</h1>
		<p>
			This example demonstrates you can use RichTextEditor to edit full html page from
			&lt;html&gt; to &lt;/html&gt;.
		</p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
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
