<%@ Page Language="c#" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		string m = Request.QueryString["m"];
		if (m!=null&&m!="")
		{
			if (m == "Disabled")
			{
				Editor1.PasteMode = RTEPasteMode.Disabled;
			}
			if (m == "Paste")
			{
				Editor1.PasteMode = RTEPasteMode.Paste;
			}
			if (m == "PasteText")
			{
				Editor1.PasteMode = RTEPasteMode.PasteText;
			}
			if (m == "PasteWord")
			{
				Editor1.PasteMode = RTEPasteMode.PasteWord;
			}
			if (m == "ConfirmWord")
			{
				Editor1.PasteMode = RTEPasteMode.ConfirmWord;
			}
			rbl_type.SelectedValue = m;
		}
		else
			Editor1.PasteMode = RTEPasteMode.Default;
	}

	private void rbl_type_change(object sender, EventArgs e)
	{
		Response.Redirect("onpaste.aspx?m=" + rbl_type.SelectedValue);
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RichTextEditor - Cleaning pasted content</title>
    <link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <h1>
        Cleaning pasted content</h1>
    <p>
        By default, RichTextEditor will automatically detect/clean the dirty pasted content.
        You have full control over how contributors paste content into the Editor. For example,
        you can disable the paste function, force pasting as plain text or prompt the user
        about cleaning up the content when pasting from MS Word.
    </p>
	<div>
		<div>
			<asp:RadioButtonList ID="rbl_type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
				AutoPostBack="true" OnSelectedIndexChanged="rbl_type_change">
				<asp:ListItem Text="Default" Value="" Selected="True"></asp:ListItem>
				<asp:ListItem Text="Disabled" Value="Disabled"></asp:ListItem>
				<asp:ListItem Text="Paste" Value="Paste"></asp:ListItem>
				<asp:ListItem Text="PasteText" Value="PasteText"></asp:ListItem>
				<asp:ListItem Text="PasteWord" Value="PasteWord"></asp:ListItem>
				<asp:ListItem Text="ConfirmWord" Value="ConfirmWord"></asp:ListItem>
			</asp:RadioButtonList>
		</div>
		<br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css"  />
	</div>
    </form>
</body>
</html>

