<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Enter mode</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Enter Mode: Paragraph or LineBreak?</h1>
    <p>
        Rich Text Editor can be configured to define the behaviour of the ENTER KEY. You
        use &lt;p&gt;, &lt;br /&gt; or &lt;div&gt; tags when you press enter. In either
        mode &lt;br&gt; tags can be created by using shift+enter.</p>
    <div>
        <div>
            <span id="MainContent_rbl_type">
                <input id="MainContent_rbl_type_0" type="radio" name="SelectType" value="" checked="checked"
                    onclick="MvcSubmit();" /><label for="MainContent_rbl_type_0">Default : p</label>
                <input id="MainContent_rbl_type_1" type="radio" name="SelectType" value="br" onclick="MvcSubmit();" /><label
                    for="MainContent_rbl_type_1">br</label>
                <input id="MainContent_rbl_type_2" type="radio" name="SelectType" value="div" onclick="MvcSubmit();" /><label
                    for="MainContent_rbl_type_2">div</label></span>
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
