<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Edit full html</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Edit full html page</h1>
    <p>
        This example demonstrates you can use RichTextEditor to edit full html page.
    </p>
    <div>
        @Html.Raw(ViewBag.Editor)
        <br />
        <button id="btn_sumbit" type="submit">
            Submit</button>
    </div>
    <br />
    <div>
        <h3>
            Result html code:</h3>
        @ViewBag._content
    </div>
    @Code Html.EndForm()End Code
</body>
</html>
