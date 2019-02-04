<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		Editor1.Text = @"<table cellspacing=""4"" cellpadding=""4"" border=""0""><tr><td><p><img src=""http://www.richtexteditor.com/uploads/j0262681.jpg"" alt="""" /></p></td> <td> <p>When your algorithmic and programming skills have reached a level which you cannot improve any further, refining your team strategy will give you that extra edge you need to reach the top. We practiced programming contests with different team members and strategies for many years, and saw a lot of other teams do so too.</p></td></tr> <tr> <td> <p> <img src=""http://www.richtexteditor.com/uploads/PH02366J.jpg"" alt="""" /></p></td> <td> <p>From this we developed a theory about how an optimal team should behave during a contest. However, a refined strategy is not a must: The World Champions of 1995, Freiburg University, were a rookie team, and the winners of the 1994 Northwestern European Contest, Warsaw University, met only two weeks before that contest.</p></td></tr></table>";
	}

	private void btn_sumbit_click(object sender, EventArgs e)
	{
        textbox1.Text = Editor1.XHTML;
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - XHTML Output</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Support output well-formed HTML and XHTML</h1>
		<p>
			This example show you RichTextEditor supports output well-formed XHTML. Your choice
			of XHTML 1.0 or HTML 4.01 output.
		</p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
			<br />
			<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
		</div>
        <br />
        <h3>
            XHTML:</h3>
        <asp:TextBox ID="textbox1" runat="server" TextMode="MultiLine" Height="220" Width="770px"></asp:TextBox>
    </form>
</body>
</html>
