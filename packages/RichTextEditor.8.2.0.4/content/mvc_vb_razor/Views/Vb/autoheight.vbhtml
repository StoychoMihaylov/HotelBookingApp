<!DOCTYPE html>

<html>
<head>
    <title>RichTextEditor - Auto adjusting height</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
     <script type="text/javascript">
         var editor;
         var link = '/Vb/autoheight/';
         function RichTextEditor_OnLoad(rteeditor) {
             editor = rteeditor;
         }
         function GetEditorHTML() {
             if (!editor) return;
             document.getElementById("result").innerHTML = editor.GetText();
         }

         function ChangeType() {
             var m = document.getElementById("rbl_type").value;
             window.location = link + "?mode=" + m;
         }

         window.onload = function () {
             document.getElementById("rbl_type").value = '@ViewBag.mode' || 'auto';
         }
    </script>
    <h1>
        Editor Auto Adjusting Height</h1>
    <p>
        This example demonstrates how to use Editor.ResizeMode to make the Editor change
        its height based on the content. The Editor will now grow and shrink in height to
        match the content inside.
    </p>
    <div>
        <div>
            <select id="rbl_type" onchange="ChangeType();">
                <option value="auto" selected="selected">AutoAdjustHeight</option>
                <option value="width">Width</option>
                <option value="height">Height</option>
                <option value="both">Both</option>
                <option value="no">None</option>
            </select>
        </div>
        <br />
        @Html.Raw(ViewBag.Editor)
        <br />
        <div>
            <button type="button" onclick="GetEditorHTML();">
                Get Content</button>
        </div>
    </div>
    <br />
    <div>
        <h3>
            Result html:</h3>
        <div id="result">
        </div>
    </div>
</body>
</html>
