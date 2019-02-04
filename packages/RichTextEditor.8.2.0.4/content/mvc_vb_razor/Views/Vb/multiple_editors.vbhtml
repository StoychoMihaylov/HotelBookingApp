<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Multiple editors</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Multiple Editors in one page</h1>
    <p>
        This example shows how to setup multiple editors on the same page.
    </p>
    <div>
        @Html.Raw(ViewBag.Editor1)
        <br />
        @Html.Raw(ViewBag.Editor2)
        <br />
        <button type="submit">
            submit</button>
    </div>
    <br />
    <div>
        @Html.Raw(ViewBag._content)
    </div>
    @Code Html.EndForm()End Code
</body>
</html>
