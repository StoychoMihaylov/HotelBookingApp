<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Editor inside jQuery tabs</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

	<style type="text/css">
		#wrapper
		{
			width: 800px;
		}
		ul.tabs
		{
			width: 800px;
			margin: 0;
			padding: 0;
		}
		ul.tabs li
		{
			display: block;
			float: left;
			padding: 0 5px;
		}
		ul.tabs li a
		{
			display: block;
			float: left;
			padding: 5px;
			font-size: 0.8em;
			background-color: #e0e0e0;
			color: #666;
			text-decoration: none;
		}
		.selected
		{
			font-weight: bold;
		}
		.tab-content
		{
			clear: both;
			border: 1px solid #ddd;
			padding: 10px;
		}
	</style>

	<script type="text/javascript">
		$(document).ready(function () {
			$('.tabs a').click(function () {
				switch_tabs($(this));
			});

			switch_tabs($('.defaulttab'));
		});

		function switch_tabs(obj) {
			$('.tab-content').hide();
			$('.tabs a').removeClass("selected");
			var id = obj.attr("rel");
			$('#' + id).show();
			obj.addClass("selected");
		}
		var editors = [];
		function RichTextEditor_OnLoad(rteeditor) {
			editors.push(rteeditor);
		}

		function GetEditorHTML(num) {
			var editor;
			for (var i = 0; i < editors.length; i++) {
				if (editors[i]._config.skin_div.id.indexOf(num) >= 0) {
					editor = editors[i];
					break;
				}
			}
			$("#result").html(editor.GetText());
		}
	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Editor inside jQuery tabs</h1>
		<p>
			This example demonstrates how to render an Editor inside of jQuery tabs.
		</p>
		<div id="wrapper">
			<ul class="tabs">
				<li><a href="#" class="defaulttab" rel="tabs1">Tab #1</a></li>
				<li><a href="#" rel="tabs2">Tab #2</a></li>
				<li><a href="#" rel="tabs3">Tab #3</a></li>
			</ul>
			<div class="tab-content" id="tabs1">
				<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="office2003silver" Toolbar="email" Width="720px"
					Height="300px" Text="Tab #1 content" />
				<div>
					<button type="button" onclick="GetEditorHTML('1');">
						Get Content</button></div>
			</div>
			<div class="tab-content" id="tabs2">
				<RTE:Editor runat="server" ID="Editor2" Skin="office2003blue" Toolbar="email" Width="720px"
					Height="300px" Text="Tab #2 content" />
				<div>
					<button type="button" onclick="GetEditorHTML('2');">
						Get Content</button></div>
			</div>
			<div class="tab-content" id="tabs3">
				<RTE:Editor runat="server" ID="Editor3" Skin="office2010blue2" Toolbar="email" Width="720px"
					Height="300px" Text="Tab #3 content" />
				<div>
					<button type="button" onclick="GetEditorHTML('3');">
						Get Content</button></div>
			</div>
		</div>
		<br />
		<div>
			<h3>
				Result html:</h3>
			<div id="result">
			</div>
		</div>
	</form>
</body>
</html>
