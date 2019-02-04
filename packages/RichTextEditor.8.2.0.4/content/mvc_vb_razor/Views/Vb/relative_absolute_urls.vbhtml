﻿<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Relative, Absolute URLs</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Relative or Absolute URLs, which do you prefer?</h1>
    <p>
        With RichTextEditor, you have the choice of using either a relative or absolute
        URL.
    </p>
    <div>
        <div>
            <span id="MainContent_rbl_type">
                <input id="MainContent_rbl_type_0" type="radio" name="SelectType" value="default"
                    checked="checked" onclick="document.getElementById('btn_sumbit').click();" /><label
                        for="MainContent_rbl_type_0">Default</label>
                <input id="MainContent_rbl_type_1" type="radio" name="SelectType" value="abs" onclick="document.getElementById('btn_sumbit').click();" /><label
                    for="MainContent_rbl_type_1">Absolute URLs</label>
                <input id="MainContent_rbl_type_2" type="radio" name="SelectType" value="rel" onclick="document.getElementById('btn_sumbit').click();" /><label
                    for="MainContent_rbl_type_2">SiteRelative URLs</label></span>
            <script type="text/javascript">
                var ipts = document.getElementsByName("SelectType");
                var mode = '@ViewBag._mode' || "";
                if (mode) {
                    for (var i = 0; i < ipts.length; i++) {
                        if (ipts[i].value == mode) {
                            ipts[i].checked = true;
                            break;
                        }
                    }
                }
            </script>
            <button id="btn_sumbit" style="display: none;" type="submit">
                Submit</button>
        </div>
        <br />
        @Html.Raw(ViewBag.Editor)
        <br />
    </div>
    @Code Html.EndForm()End Code
</body>
</html>
