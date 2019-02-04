<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
        Editor1.Text = "<table cellspacing=""4"" cellpadding=""4"" border=""0""><tr><td><p><img src=""http://www.richtexteditor.com/uploads/j0262681.jpg"" alt="""" /></p></td> <td> <p>When your algorithmic and programming skills have reached a level which you cannot improve any further, refining your team strategy will give you that extra edge you need to reach the top. We practiced programming contests with different team members and strategies for many years, and saw a lot of other teams do so too.</p></td></tr> <tr> <td> <p> <img src=""http://www.richtexteditor.com/uploads/PH02366J.jpg"" alt="""" /></p></td> <td> <p>From this we developed a theory about how an optimal team should behave during a contest. However, a refined strategy is not a must: The World Champions of 1995, Freiburg University, were a rookie team, and the winners of the 1994 Northwestern European Contest, Warsaw University, met only two weeks before that contest.</p></td></tr></table>"
	End Sub

	Private Sub btn_sumbit_click(ByVal sender As Object, ByVal e As EventArgs)
        textbox1.Text = Editor1.Text
        textbox2.Text = Editor1.PlainText
        textbox3.Text = Editor1.PlainTextWithLinefeeds
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Extract plain text</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Extracting Plain Text</h1>
		<p>
			This sample demonstrates retrieving the RichTextEditor HTML content in the plain
			text format. If you want to store the document text in a database which is searchable,
			you can use the output of this property to create an HTML-free copy for indexing.
		</p>
		<div>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" />
			<br />
			<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_sumbit_click" />
		</div>
		<br />
		<h3>HTML:</h3>
		<asp:textbox id="textbox1" runat="server" TextMode="MultiLine" Height="120" Width="760px"></asp:textbox>
		<br />
		<h3>PlainText:</h3>
		<asp:textbox id="textbox2" runat="server" TextMode="MultiLine" Height="120" Width="760px"></asp:textbox>
		<br />
		<h3>PlainText with line feeds:</h3>
		<asp:textbox id="textbox3" runat="server" TextMode="MultiLine" Height="120" Width="760px"></asp:textbox>
		
	</form>
</body>
</html>
