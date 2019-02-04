<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Custom content css</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Custom content css</h1>
    <p>
        This example demonstrates how to apply custom css file(s) to editor contents. Multiple
        css files are supported.
    </p>
    <div>
        <div>
            <span id="MainContent_rbl_type">
                <input id="MainContent_rbl_type_0" type="radio" name="SelectType" value="" checked="checked"
                    onclick="MvcSubmit();" /><label for="MainContent_rbl_type_0">forecolor.css</label>
                <input id="MainContent_rbl_type_1" type="radio" name="SelectType" value="/Content/backgroundimage.css"
                    onclick="MvcSubmit();" /><label for="MainContent_rbl_type_1">backgroundimage.css</label>
                <input id="MainContent_rbl_type_2" type="radio" name="SelectType" value="/Content/backgroundimage.css,/Content/forecolor.css"
                    onclick="MvcSubmit();" /><label for="MainContent_rbl_type_2">forecolor.css + backgroundimage.css</label></span>
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
                function MvcSubmit() {
                    document.getElementById('btn_sumbit').click();
                }
            </script>
            <button id="btn_sumbit" style="display: none;" type="submit">
                Submit</button>
        </div>
        <br />
        @Html.Raw(ViewBag.Editor)
    </div>
    @Code Html.EndForm()End Code
</body>
</html>
