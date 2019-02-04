<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		//add content css
		Editor1.ContentCss = "../samples/dynamicstyles.css";
		//set font name, font size list by servercode
		//Editor1.SetConfig("fontnamelist", "Arial,Microsoft YaHei,Verdana");
		//Editor1.SetConfig("fontsizelist","9px,13px,16px,20px,24px,32px");

		Editor1.ToolbarItems = "{styles,fontname,fontsize}{mydropdownlink,mydropdowncodesnippet}";
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Populate menus</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	<script type="text/javascript">
		var editor;
		function RichTextEditor_OnLoader(loader) {
			var config = loader._config;
			// add links
			if (!config.linkurlarray) config.linkurlarray = [];
			config.linkurlarray.push("../samples/sharelinks.xml");
			config.linkurlarray.push("../samples/sharelinks2.xml");

			// add templates(snippets)
			if (!config.templateurlarray) config.templateurlarray = [];
			config.templateurlarray.push("../samples/sharetemplates.xml");

			//set font name, font size list by javascript code
			config.fontnamelist = "Arial,Microsoft YaHei";
			config.fontsizelist = "9px,13px,16px,20px,24px,32px";

			loader.oncoreload = function () {
				var toolbar = config._toolbartemplate || config.toolbar;
				var btnname = "item_" + toolbar + "_" + config.skin + "_" + config.color + "_mydropdownlink";
				var basetype = "image_" + config.skin + "_" + config.color;

				var define = jsml.class_define(btnname, basetype);
				define.constructor(function () {
					this[basetype + "_constructor"]();
					this.set_imagename("link");
					this.set_tooltip("My dropdown link");
				});
				define.attach("click", function () {
					if (!editor) return; 
					editor.ExecShowXmlFloatbox(this._element, "insertlink_dropdown.xml");
				});

				var btnname = "item_" + toolbar + "_" + config.skin + "_" + config.color + "_mydropdowncodesnippet";
				var define = jsml.class_define(btnname, basetype);
				define.constructor(function () {
					this[basetype + "_constructor"]();
					this.set_imagename("template");
					this.set_tooltip("My dropdown template");
				});
				define.attach("click", function () {
					if (!editor) return;
					editor.ExecShowXmlFloatbox(this._element, "inserttemplate_dropdown.xml");
				});
			}
		}

		function RichTextEditor_OnLoad(rteeditor) {
			editor = rteeditor;
		}
	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Dynamically populate the dropdown menu</h1>
		<p>
			By default, RichTextEditor displays several predefined set of data in its dropdown
			menus(code snippet, internal links, font name, font size, and styles). You can easily
			modify the default sets by editing the static configuration files(staticlinks.xml,staticstyles.xml,statictemplates.xml).
			You can also dynamically populate the drop down menus.
		</p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Text="Type here" />
		</div>
	</form>
</body>
</html>
