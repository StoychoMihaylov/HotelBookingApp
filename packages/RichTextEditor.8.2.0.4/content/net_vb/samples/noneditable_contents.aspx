<%@ Page Language="VB" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(e As EventArgs)
		MyBase.OnInit(e)
		Editor1.Text = "<p>First paragraph <b>editable</b>.</p><p contenteditable='false'>Second paragraph is read-only.</p><p>Third paragraph with <span contenteditable='false'> non-editable content</span>.</p>"
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - NonEditable contents</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <h1>
            NonEditable contents</h1>
        <p>
            This example displays how areas within an editor instance can be disabled from editing
            by specifying the standard-compliant contenteditable attribute on the element.
        </p>
        <p>
            <RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
        </p>
    </form>
</body>
</html>
