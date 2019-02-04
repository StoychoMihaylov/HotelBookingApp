<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		Editor1.Text = "Please select text and click bold button";
		Editor1.ToolbarItems = "{bold}";
		string mode = Request.QueryString["m"];
		if (mode != null && mode != "")
		{
			if (mode == "b")
				Editor1.SetConfig("format_bold", "<b>");
			else if (mode == "span")
				Editor1.SetConfig("format_bold", "<span style='font-weight:bold'>");
			rbl_type.SelectedValue = mode;
		}
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("format_bold.aspx?m=" + rbl_type.SelectedValue);
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Formatting bold button</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	<script type="text/javascript">
		var editor;
		function RichTextEditor_OnLoad(rteeditor) {
			editor = rteeditor;
			editor.AttachEvent("TextChanged", ShowHtml);
		}
		function ShowHtml() {
			if (!editor)			return;
			var c = editor.GetText();
			if(!c) {
				document.getElementById("result").innerHTML = ""; 
				return;
			}
			document.getElementById("result").innerHTML = c.replace(/</g,"&lt;");
		}
	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Formatting bold button</h1>
		<p>
			RichTextEditor enables you to override and define you own custom format tags. By
			default, when you use the Bold button on the toolbar, RichTextEditor inserts a set
			of &lt;strong&gt;tags to format the selected text. The &lt;strong&gt; tags are the
			current standard for marking text as bold. If you prefer to use the &lt;b&gt;tags
			or CSS "font-weight" property instead, you can change the editor configuration to
			change the behavior of bold button.
		</p>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Default: &amp;lt;strong&amp;gt;" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="&amp;lt;b&amp;gt;" Value="b"></asp:ListItem>
					<asp:ListItem Text="&amp;lt;span style='font-weight:bold'&amp;gt;" Value="span"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
		</div>
		<br />
		<div>
			<h3>
				Result html code:</h3>
			<div id="result">
			</div>
		</div>
	</form>
</body>
</html>
