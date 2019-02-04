<%@ Page Language="c#" %>
<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);

		Editor1.Text = "<div style='color:red;'><strong>1. Easy for developers</strong></div>";
		Editor2.Text = "<div style='color:darkgreen;'><strong>2. Seamless Integration with Web Forms</strong></div>";
	}

	private void btn_sumbit_click(object sender, EventArgs e)
	{
		lit_result.Text = "<div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/>" + Editor1.Text +
			"<br/><div style='font-size:16px;font-weight:bold;'>RichTextEditor 1:</div><br/>" + Editor2.Text;
	}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Multiple editors</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
        <h1>
            Multiple Editors in one page</h1>
        <p>
            This example shows how to setup multiple editors on the same page.
        </p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="smartblue" Toolbar="forum" Width="755px"
				Height="200px" />
			<br />
			<RTE:Editor runat="server" ID="Editor2" Skin="smartsilver" Toolbar="forum" Width="755px"
				Height="200px" />
			<br />
			<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
		</div>
		<br />
		<div>
			<div>
				<asp:Literal ID="lit_result" runat="server"></asp:Literal>
			</div>
		</div>
	</form>
</body>
</html>
