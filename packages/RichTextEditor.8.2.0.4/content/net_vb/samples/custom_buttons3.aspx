<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)

		Editor1.ToolbarItems = "{bold,italic,underlinemenu}{forecolor,backcolor,fontname,fontsize}{justifyleft,justifycenter,justifyright,justifyfull}{insertorderedlist,insertunorderedlist,outdent,indent}{insertlink,insertimage,insertblockquote,syntaxhighlighter}{unlink,removeformat}//{mypanel1}"
	End Sub

	Private Sub btn_sumbit_click(ByVal sender As Object, ByVal e As EventArgs)
		If TypeOf sender Is Button Then
			Dim link As Button = DirectCast(sender, Button)
			Editor1.Text += "<hr />" + link.Text + " clicked"
		End If
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Custom buttons</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
	<style>
	.serverbtn
	{
		height:20px;
	}
	</style>

	<script type="text/javascript">
		var loader;
		var editor;
		

		function RichTextEditor_OnCoreLoad(rteloader) {
			loader = rteloader;

			var config = loader._config;
			var toolbar = config._toolbartemplate || config.toolbar;

			var panel1 = "item_" + toolbar + "_" + config.skin + "_" + config.color + "_mypanel1";
			var define1 = jsml.class_define(panel1, "htmlcontrol");
			define1.constructor(function () {
				this["htmlcontrol_constructor"]();
				this.set_dock("left");
				var custdiv = document.getElementById("div_custom");
				this._content.appendChild(custdiv);
				custdiv.style.display="";
			});
			
		}

		function RichTextEditor_OnLoad(rteeditor) {
			editor = rteeditor;
		}

	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Adding custom buttons (server)</h1>
		<p>
			The Rich Text Editor allows you extend the functions of the editor. You can create
			new custom buttons and add them to the editor's toolbar list.
		</p>
		<div id="div_custom" style="display: none;">
			<asp:Button ID="Button1" Text="server button1" runat="server" CssClass="serverbtn"
				OnClick="btn_sumbit_click" />
			<asp:Button ID="Button2" Text="server button2" runat="server" CssClass="serverbtn"
				OnClick="btn_sumbit_click" />
		</div>
		<p>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
		</p>
	</form>
</body>
</html>
