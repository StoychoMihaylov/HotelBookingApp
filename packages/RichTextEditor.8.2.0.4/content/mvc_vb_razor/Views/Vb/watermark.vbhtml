<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Watermark</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    <h1>
        Adding watermark(text or image) to uploaded images</h1>
    <p>
        When you upload images to your website, you might want to add a watermark to the
        image before you save it or display it on a page. People often use watermarks to
        add copyright information to an image or to advertise their business name. RichTextEditor
        has the built-in function which allows you watermark images when uploading using
        ASP.NET code.
    </p>
    <p>
        This example also shows how to use Editor.UploadImage Event to execute custom actions
        when an image is uploaded successfully.
    </p>
    <div>
        <div>
            Watermark Text :
            <input name="txt_watermark" type="text" value="RichTextEditor" style="width: 160px;" />
        </div>
        <br />
        @Html.Raw(ViewBag.Editor)
    </div>
</body>
</html>
