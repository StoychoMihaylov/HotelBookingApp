<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		AddHandler Editor1.UploadImage, AddressOf Editor1_UploadImage
	End Sub

	Sub Editor1_UploadImage(ByVal sender As Object, ByVal args As UploadImageEventArgs)
		Dim text As String = Request("txt_watermark")
		Dim bitmap As New System.Drawing.Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
		Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bitmap)
		Dim style As System.Drawing.FontStyle = System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline
		Dim font As New System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 26, style)
		Dim size As System.Drawing.SizeF = g.MeasureString(text, font)
		g.DrawString(text, font, System.Drawing.Brushes.DarkGreen, bitmap.Width - size.Width, bitmap.Height - size.Height)
		

		Dim watermark As RTE.ConfigWatermark = New ConfigWatermark()
		watermark.XAlign = "right"
		watermark.YAlign = "bottom"
		watermark.XOffset = -10
		watermark.YOffset = -10
		watermark.MinWidth = 450
		watermark.MinHeight = 300
		watermark.Image = bitmap

		args.Watermarks.Clear()
		args.Watermarks.Add(watermark)
		args.DrawWatermarks = True
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Watermark</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
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
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
		</div>
	</form>
</body>
</html>
