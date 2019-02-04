<%@ Page Language="VB" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	Private selecttype As String = ""
	Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		selecttype = Request("SelectType")
		Dim _store As String = ""
		Dim file As RTE.ConfigFile
		Dim storages As RTE.ConfigSecurity()
		Editor1.RenderSupportAjax = False
		Select Case selecttype
			Case "Administrators"
				Editor1.SecurityPolicyFile = "admin.config"
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/>"
				Exit Select
			Case "Members"
				Editor1.SecurityPolicyFile = "default.config"
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/>"
				Exit Select
			Case "Guest"
				Editor1.SecurityPolicyFile = "guest.config"
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/>"
				Exit Select
			Case "John"
				Editor1.SecurityPolicyFile = "admin.config"
				file = Editor1.LoadConfigFile()
				storages = file.GetItems("Gallery", False, True)
				_store = storages(0).StoragePath + "/John"
				Editor1.SetSecurity("Gallery", "*", "StoragePath", _store)
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/> Gallery:" + _store
				Exit Select
			Case "Mary"
				Editor1.SecurityPolicyFile = "default.config"
				file = Editor1.LoadConfigFile()
				storages = file.GetItems("Gallery", False, True)
				_store = storages(0).StoragePath + "/Mary"
				Editor1.SetSecurity("Gallery", "*", "StoragePath", _store)
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/> Gallery:" + _store
				Exit Select
			Case "Tim"
				Editor1.SecurityPolicyFile = "default.config"
				file = Editor1.LoadConfigFile()
				storages = file.GetItems("Gallery", False, True)
				_store = storages(0).StoragePath + "/Tim"
				Editor1.SetSecurity("Gallery", "*", "StoragePath", _store)
				lit_sec.Text = "Policy file:" + Editor1.SecurityPolicyFile + "<br/> Gallery:" + _store
				Exit Select
		End Select
	End Sub
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Programmatic Security</title>
	<link rel="stylesheet" href="example.css" type="text/css" />
</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Personalization and Programmatic Security Example</h1>
		<p>
			RichTextEditor allows developers to assign a pre-defined set of permissions&nbsp;by&nbsp;group&nbsp;or
			individual. This prevents a normal user to access the administration functionality.
			The details of permissions are specified by an XML security policy file. Each level
			maps to a specific file. The default mappings:
		</p>
		<ul>
			<li>admin maps to admin.config</li>
			<li>default maps to default.config</li>
			<li>guest maps to guest.config</li>
		</ul>
		<p>
			You can customize and extend each policy file by editing the XML security policy
			file. You can also create your own policy files that define arbitrary permission
			sets. <span class="parent" child="Security">Comparison of the sample security policy
				file</span>
		</p>
		<table>
			<tbody>
				<tr>
					<td>
						<table id="RadioList" bgcolor="#f5f5f5" border="0" style="width: 400px; border: #c0c0c0 1px solid;">
							<tbody>
								<tr>
									<td>
										<input id="RadioList_0" type="radio" name="SelectType" value="Administrators" onclick="window.Form1.submit();" /><label
											for="RadioList_0">
											Administrators</label>
									</td>
									<td>
										<input id="RadioList_1" type="radio" name="SelectType" value="Members" onclick="window.Form1.submit();" /><label
											for="RadioList_1">
											Members</label>
									</td>
									<td>
										<input id="RadioList_2" type="radio" name="SelectType" value="Guest" onclick="window.Form1.submit();" /><label
											for="RadioList_2">
											Guest</label>
									</td>
								</tr>
								<tr>
									<td>
										<input id="RadioList_3" type="radio" name="SelectType" value="John" onclick="window.Form1.submit();" /><label
											for="RadioList_3">
											John (admin)</label>
									</td>
									<td>
										<input id="RadioList_4" type="radio" name="SelectType" value="Mary" onclick="window.Form1.submit();" /><label
											for="RadioList_4">
											Mary (sales)</label>
									</td>
									<td>
										<input id="RadioList_5" type="radio" name="SelectType" value="Tim" onclick="window.Form1.submit();" /><label
											for="RadioList_5">
											Tim (financial)</label>
									</td>
								</tr>
							</tbody>
						</table>

						<script type="text/javascript">
						var ipts = document.getElementsByName("SelectType");
						var lang = '<%=selecttype %>' || "";
						if (lang) {
							new function () {
								for (var i = 0; i < ipts.length; i++) {
									if (ipts[i].value == lang) {
										ipts[i].checked = true;
										return;
									}
								}
							} ();
						}
						</script>

					</td>
					<td width="10">
					</td>
					<td style="color: red">
						<asp:Literal ID="lit_sec" runat="server"></asp:Literal>
					</td>
				</tr>
			</tbody>
		</table>
		<br />
		<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Width="755" Height="420px" />
	</form>
</body>
</html>
