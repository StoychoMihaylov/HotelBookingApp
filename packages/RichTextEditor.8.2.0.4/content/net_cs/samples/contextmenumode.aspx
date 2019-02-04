<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		string m = Request.QueryString["m"];
		Editor1.ContextMenuMode = RTEContextMenuMode.Default;
		if (m != null && m != "")
		{
			if (m == "Minimal")
			{
				Editor1.ContextMenuMode = RTEContextMenuMode.Minimal;
			}
			if (m == "Simple")
			{
				Editor1.ContextMenuMode = RTEContextMenuMode.Simple;
			}
			rbl_type.SelectedValue = m;
		}
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("contextmenumode.aspx?m=" + rbl_type.SelectedValue);
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - ContextMenu mode</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Context menu customization</h1>
		<p>
			RichTextEditor is a context sensitive application, it is aware of it's context and
			acts accordingly. There are many ways to control the context menu behaviors within
			RichTextEditor:
		</p>
		<div>
			<div>
				<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
					AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
					<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
					<asp:ListItem Text="Simple" Value="Simple"></asp:ListItem>
					<asp:ListItem Text="Minimal " Value="Minimal"></asp:ListItem>
				</asp:RadioButtonList>
			</div>
			<br />
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
		</div>
	</form>
</body>
</html>
