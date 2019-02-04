<%@ Page Language="c#" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		string m = Request.QueryString["m"];
		if (m!=null&&m!="")
		{
			if (m == "yes")
			{
				Editor1.ShowLinkbar = true;
			}
			if (m == "no")
			{
				Editor1.ShowLinkbar = false;
			}
			rbl_type.SelectedValue = m;
		}
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("showlinkbar.aspx?m=" + rbl_type.SelectedValue);
	}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Show or hide link editing box</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
	<h1>
            Show or hide link editing box</h1>
        <p>
            When a hyperlink is selected, a link editing box will be displayed in the editor.
            You can turn it off by setting this property to "false".
        </p>
	<div>
		<div>
			<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
				AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
				<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
				<asp:ListItem Text="Show Linkbar" Value="yew"></asp:ListItem>
				<asp:ListItem Text="Hide Linkbar" Value="no"></asp:ListItem>
			</asp:RadioButtonList>
		</div>
		<br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css"  />
	</div>
	</form>
</body>
</html>
