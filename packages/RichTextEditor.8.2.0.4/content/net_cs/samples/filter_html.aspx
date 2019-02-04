<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		string m = Request.QueryString["m"];
		if (m != null && m != "")
		{
			if (m == "no")
			{
				Editor1.TagBlackList = "*";
			}
			if (m == "white")
			{
				Editor1.TagWhiteList = "embed";
			}
			if (m == "black")
			{
				Editor1.TagBlackList = "div";
			}
			if (m == "full")
			{
				Editor1.AllowScriptCode = true;
				Editor1.EditCompleteDocument = true;
				Editor1.TagBlackList = "";
			}

			rbl_type.SelectedValue = m;
		}
	}

	private void btn_sumbit_click(object sender, EventArgs e)
	{
		lit_result.Text = HttpUtility.HtmlEncode(Editor1.Text);
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("filter_html.aspx?m=" + rbl_type.SelectedValue);
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Filtering HTML code</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			How to Filtering HTML code in Rich Text Editor?</h1>
		<p>
			The new Filtering HTML code functionality in Rich Text Editor 8 allows you to accept
			HTML input from your users, filter it to make sure it contains only an allowed set
			of tags, attributes and values and then display it without leaving yourself open
			to XSS holes.</p>
		<p>
			The possible options are:</p>
		<ul>
			<li>TagWhiteList - Allows you set a list of html tags that will not be removed from
				content sources. </li>
			<li>TagBlackList - Allows you set a list of html tags that will be removed from content
				sources. </li>
			<li>AttrWhiteList - Allows you set a list of html attributes that will not be removed
				from content sources. </li>
			<li>AttrBlackList - Allows you set a list of html attributes that will be removed from
				content sources. </li>
			<li>StyleWhiteList - Allows you set a list of style attributes that will not be removed
				from content sources. </li>
			<li>StyleBlackList - Allows you set a list of style attributes that will be removed
				from content sources.</li>
			<li>No HTML - All the HTML code will be filtered.</li>
			<li>Full HTML - The filtering is disabled. Usually this option can be used for for trusted
				users.</li>
		</ul>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="Black list : div" Value="black"></asp:ListItem>
					<asp:ListItem Text="White list : embed" Value="white"></asp:ListItem>
					<asp:ListItem Text="No html" Value="no"></asp:ListItem>
					<asp:ListItem Text="Full html" Value="full"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
			<br />
			<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
		</div>
		<br />
		<div>
			<h3>
				Result html code:</h3>
			<div>
				<asp:Literal ID="lit_result" runat="server"></asp:Literal>
			</div>
		</div>
	</form>
</body>
</html>
