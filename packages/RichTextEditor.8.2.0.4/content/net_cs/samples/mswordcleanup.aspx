<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Ms word clean up</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	<script type="text/javascript">
		function RichTextEditor_OnPasteFilter(editor, evt) {
			var html = evt.Arguments[0];
			var cmd = evt.Arguments[1];
			//filter html here
			evt.ReturnValue = "<div style='color:blue;'>[-- RichTextEditor has filtered your pasted code --]</div><div style='color:blue;'>{</div>" + html + "<div style='color:blue;'>}</div>";
		}
	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Ms word clean up</h1>
		<p>
			By default, ms-word markup pasted into the editor will be parsed and cleaned up.
			By customizing office HTML filter, you can define which types of markup tags are
			removed. Feel free to copy/paste from msword and then switch to HtmlView (using
			the Html tab in the editor).</p>
		<div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
		</div>
	</form>
</body>
</html>
