<%@ Page Language="c#" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Readonly</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <h1>
            Readonly support</h1>
        <p>
            This example shows you can set ReadOnly property to true if you would like to display
            read-only content of Editor in some situations.
        </p>
        <RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" ReadOnly="True" Text="This is a readonly editor." />
    </form>
</body>
</html>
