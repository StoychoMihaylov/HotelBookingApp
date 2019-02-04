<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Display the Ruler</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Use rulers for guidance</h1>
		<p>
			In RichTextEditor, you can use rulers guide your page layout in Design view. Rulers
			appear across the top and down the left side of the editing window.
		</p>
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css"  ShowRulers="True" Skin="office2010blue2" Text = "Type here"/>
	</form>
</body>
</html>
