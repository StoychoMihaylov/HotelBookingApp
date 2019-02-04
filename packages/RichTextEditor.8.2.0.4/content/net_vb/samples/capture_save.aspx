<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Capture event</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	<script type="text/javascript">
		var editor;
		function RichTextEditor_OnLoad(rteeditor) {
			editor = rteeditor;
			editor.AttachEvent("ExecUICommand", CaptureSaveEvent);
		}
		function CaptureSaveEvent(rteeditor, info) {
			if (!rteeditor) return;
			if (!info || !info.Arguments || !info.Arguments[1] || info.Arguments[1]!="Save") return;
			var c = rteeditor.GetText();
			alert("Save event has been captured : " + c);
		}
	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Capturing save event</h1>
		<p>
			RichTextEditor allows you capture the click event of each button of the editor toolbar.
			In this example, it shows how to capture the "Save" event.
		</p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Text="Type here"/>
		</div>
	</form>
</body>
</html>
