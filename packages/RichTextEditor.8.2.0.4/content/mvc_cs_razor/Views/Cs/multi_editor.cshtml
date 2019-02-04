<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - One editor, multiple area</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
    <style type="text/css">
        .content
        {
            border: 1px solid #cccccc;
            padding: 5px;
            line-height: 22px;
            width: 300px;
        }
    </style>
</head>
<body>
    <script type="text/javascript">
        var editor;
        var diveditor;
        var divcontent;
        function RichTextEditor_OnLoad(rteeditor) {
            editor = rteeditor;
            diveditor = document.getElementById("div_editor");
        }

        function GetEditorHTML() {
            if (!editor || !divcontent)
                return;
            diveditor.style.display = "none";
            divcontent.innerHTML = editor.GetText();
        }

        function EditMe(_div) {
            divcontent = _div;
            editor.SetText(_div.innerHTML);
            var t = _div.offsetTop;
            var l = _div.offsetLeft;
            diveditor.style.display = "";
            diveditor.style.zIndex = "9";
            diveditor.style.left = l + "px";
            diveditor.style.top = t + "px";
        }
    </script>
    <h1>
        One Editor, Multiple Edit Areas</h1>
    <p>
        This example demonstrates how to have one Editor instance control different editable
        areas on a page. Double click any of the areas below to edit it's content. Then
        click the collapse button in the toolbar to remove the editor.
        <br />
    </p>
    <br />
    <div style="position: relative;">
        <div class="content" ondblclick="EditMe(this);">
            #1. Double click me to edit the contents</div>
        <br />
        <div class="content" ondblclick="EditMe(this);">
            #2. Double click me to edit the contents</div>
        <br />
        <div class="content" ondblclick="EditMe(this);">
            #3. Double click me to edit the contents</div>
        <br />
        <div class="content" ondblclick="EditMe(this);">
            #4. Double click me to edit the contents</div>
        <div id="div_editor" style="display: none; position: absolute; background: white;
            left: 0px; top: 0px; border: 1px solid gray;">
            @Html.Raw(ViewBag.Editor)
            <button type="button" onclick="GetEditorHTML();">
                Submit</button>
        </div>
    </div>
</body>
</html>
