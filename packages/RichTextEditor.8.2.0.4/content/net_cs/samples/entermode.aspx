<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		//Editor1.EnterKeyTag = RTEEnterKeyTag.BR;
		string m = Request.QueryString["m"];
		if (m != null && m != "")
		{
			if (m == "p")
			{
				Editor1.EnterKeyTag = RTEEnterKeyTag.P;
			}
			if (m == "br")
			{
				Editor1.EnterKeyTag = RTEEnterKeyTag.BR;
			}
			if (m == "div")
			{
				Editor1.EnterKeyTag = RTEEnterKeyTag.DIV;
			}
			rbl_type.SelectedValue = m;
		}
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("entermode.aspx?m=" + rbl_type.SelectedValue);
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Enter mode</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Enter Mode: Paragraph or LineBreak?</h1>
		<p>
			Rich Text Editor can be configured to define the behaviour of the ENTER KEY. You
			use &lt;p&gt;, &lt;br /&gt; or &lt;div&gt; tags when you press enter. In either
			mode &lt;br&gt; tags can be created by using shift+enter.</p>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Default : p" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="br" Value="br"></asp:ListItem>
					<asp:ListItem Text="div" Value="div"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="officexpsilver"  Text = "Type here" />
		</div>
	</form>
</body>
</html>
