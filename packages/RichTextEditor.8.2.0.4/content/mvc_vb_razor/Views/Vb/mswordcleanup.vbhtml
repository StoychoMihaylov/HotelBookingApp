<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Ms word clean up</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    <script type="text/javascript">
        function RichTextEditor_OnPasteFilter(editor, evt) {
            var html = evt.Arguments[0];
            var cmd = evt.Arguments[1];
            //filter html here
            evt.ReturnValue = "<div style='color:blue;'>[-- RichTextEditor has filtered your pasted code --]</div><div style='color:blue;'>{</div>" + html + "<div style='color:blue;'>}</div>";
        }
    </script>
    <h1>
        Ms word clean up</h1>
    <p>
        By default, ms-word markup pasted into the editor will be parsed and cleaned up.
        By customizing office HTML filter, you can define which types of markup tags are
        removed. Feel free to copy/paste from msword and then switch to HtmlView (using
        the Html tab in the editor).</p>
    <div>
        <br />
        @Html.Raw(ViewBag.Editor)
    </div>
</body>
</html>
