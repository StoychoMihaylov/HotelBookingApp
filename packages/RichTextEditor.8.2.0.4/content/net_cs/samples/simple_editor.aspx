<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Default Toolbar Config</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Simple Configuration example</h1>
		<p>
			This example shows the simple Configuration of editor.
		</p>
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Height="200px" Skin="officexpsilver" Toolbar="minimal" Text="Type here"/>
		<br />
		<RTE:Editor runat="server" ID="Editor2" ContentCss="example.css" Height="200px" Skin="officexpblue" Toolbar="email" />
	</form>
</body>
</html>
