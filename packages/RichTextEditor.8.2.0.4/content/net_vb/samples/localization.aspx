<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)

		Dim lang As String = Request.QueryString("language")
		If Not lang = "" Then
			Editor1.Language = lang
			RadioList.SelectedValue = lang
		End If
	End Sub

	Private Sub culture_Changed(ByVal sender As [Object], ByVal e As EventArgs)
		Response.Redirect("localization.aspx?language=" + RadioList.SelectedValue)
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Localization</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Built-in localization for French, Spanish, and German ...</h1>
		<p>
			RichTextEditor auto-detects Client Browser's culture setting to decide what language
			to use. If developers need server side control, we also provide API to override
			the setting acquired from client browsers(shown in example below).</p>
		<p>
			<asp:RadioButtonList Style="border: #c0c0c0 1px solid; background-color: #f5f5f5;
				width:770px" ID="RadioList" runat="server" AutoPostBack="True" RepeatLayout="Table"
				RepeatColumns="6" CellPadding="2" CellSpacing="2" RepeatDirection="Horizontal"
				OnSelectedIndexChanged="culture_Changed">
				<asp:ListItem Value="en">English </asp:ListItem>
				<asp:ListItem Value="fr-FR">French</asp:ListItem>
				<asp:ListItem Value="de-de">German</asp:ListItem>
				<asp:ListItem Value="nl-NL">Dutch</asp:ListItem>
				<asp:ListItem Value="es-ES">Spanish</asp:ListItem>
				<asp:ListItem Value="it-IT">Italian</asp:ListItem>
				<asp:ListItem Value="nb-NO">Norwegian</asp:ListItem>
				<asp:ListItem Value="ru-RU">Russian</asp:ListItem>
				<asp:ListItem Value="ja-JP">Japanese</asp:ListItem>
				<asp:ListItem Value="zh-cn">Chinese</asp:ListItem>
				<asp:ListItem Value="sv-SE">Swedish</asp:ListItem>
				<asp:ListItem Value="pt-BR">Portuguese</asp:ListItem>
				<asp:ListItem Value="da">Danish</asp:ListItem>
				<asp:ListItem Value="he-IL">Hebrew</asp:ListItem>
				<asp:ListItem Value="ar">Arabic</asp:ListItem>
				<asp:ListItem Value="cs">CZech</asp:ListItem>
				<asp:ListItem Value="tr-TR">Turkey</asp:ListItem>
				<asp:ListItem Value="vi">Vietnam</asp:ListItem>
				<asp:ListItem Value="th">Thai</asp:ListItem>
				<asp:ListItem Value="ko-KR">Korean</asp:ListItem>
				<asp:ListItem Value="" Selected="True">Auto Detect</asp:ListItem>
			</asp:RadioButtonList>
		</p>
		<p>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Skin="office2010blue2" Text = "Type here" />
		</p>
	</form>
</body>
</html>
