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
            Default Toolbar Config</h1>
        <p>
            This example simply shows the default toolbar config.
        </p>
        <RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Text="Type here" />
    </form>
</body>
</html>

