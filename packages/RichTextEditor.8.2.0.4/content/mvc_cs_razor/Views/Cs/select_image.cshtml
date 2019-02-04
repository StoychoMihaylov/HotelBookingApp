<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Editor as image selector</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    <script type="text/javascript">
        var editor;
        var showed = false;

        function RichTextEditor_OnLoader(loader) {
            var config = loader._config;
            config.showtoolbar = false;
            config.showtoolbar_code = false;
            config.showbottombar = false;
            config.preloadplugins = "";
            var div = document.getElementById(config.containerid);
            div.style.display = "none";
        }
        function ShowEditorGallery() {
            showed = true;
            if (editor) {
                editor.ExecUICommand(null, "InsertGallery");
            }
        }

        function RichTextEditor_OnLoad(argeditor) {
            editor = argeditor;
            if (showed)
                ShowEditorGallery()
        }

        function RichTextEditor_OnTextChanged() {
            if (!showed) return;
            showed = false;
            var img = editor.GetPointNode();
            if (img && img.GetNameLower() == "img") {
                var src = img.GetAttribute("src");
                OnGetImageUrl(src);
            }
            editor.SetText("");
        }
        function OnGetImageUrl(src) {
            document.getElementById("result").innerHTML = "You selected : " + src;
        }
    </script>
    <h1>
        Use RichTextEditor as image selector</h1>
    <p>
    </p>
    <div style="display: none;">
        @Html.Raw(ViewBag.Editor)
    </div>
    <br />
    <div>
        <button type="button" onclick="ShowEditorGallery();return false;">
            Select Image</button>
    </div>
    <br />
    <div id="result">
    </div>
</body>
</html>
