<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		Editor1.Text = @"<table cellspacing=""1"" cellpadding=""1"" border=""1"" style=""width: 500px""><caption>Table Support</caption><thead><tr><th>Head1</th><th>Head2</th><th>Head3</th><th>Head4</th></tr></thead><tbody><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td> </tr> <tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td> </tr> <tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td> </tr> <tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></tbody><tfoot><tr><td>Foot1</td><td>Foot2</td><td>Foot3</td><td>Foot4</td></tr></tfoot></table>";
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Powerful table support</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Powerful table support</h1>
		<p>
			The editor provides an extensive set of commands, allowing end-users to create,
			customize, and delete tables and their elements via built-in dialogs or context
			menus. Advanced cell operations including appearance customization, cell merging
			and splitting, &nbsp; &lt;caption&gt;,&lt;summary&gt;,&lt;thead&gt;,&lt;tfoot&gt;,&lt;th&gt;
			tags are also supported.
		</p>
		<p>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="office2010blue2" />
		</p>
		
	</form>
</body>
</html>
