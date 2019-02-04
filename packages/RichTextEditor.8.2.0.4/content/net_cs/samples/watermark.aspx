<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		Editor1.UploadImage += new UploadImageEventHandler(Editor1_UploadImage);
	}

	void Editor1_UploadImage(object sender, UploadImageEventArgs args)
	{
		string text = Request["txt_watermark"];
		System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(400, 200, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
		{
			System.Drawing.FontStyle style = System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline;
			System.Drawing.Font font = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 26, style);
			System.Drawing.SizeF size = g.MeasureString(text, font);
			g.DrawString(text, font, System.Drawing.Brushes.DarkGreen, bitmap.Width - size.Width, bitmap.Height - size.Height);
		}

		RTE.ConfigWatermark watermark = new ConfigWatermark();
		watermark.XAlign = "right";
		watermark.YAlign = "bottom";
		watermark.XOffset = -10;
		watermark.YOffset = -10;
		watermark.MinWidth = 450;
		watermark.MinHeight = 300;
		watermark.Image = bitmap;

		args.Watermarks.Clear();
		args.Watermarks.Add(watermark);
		args.DrawWatermarks = true;
	}
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
