<%@ Page Language="c#" %>

<%@ Register TagPrefix="RTE" Namespace="RTE" Assembly="RichTextEditor" %>

<script runat="server">
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);

		string skin = Request.QueryString["skin"];
		if (skin == null || skin == "")
			skin = "office2007blue";
		Editor1.Skin = skin;
		string toolbar = Request.QueryString["toolbar"];
		if (toolbar != null && toolbar != "")
			Editor1.Toolbar = toolbar;
	}
	
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>RichTextEditor - Skinning the Editor</title>
	<link rel="stylesheet" href="example.css" type="text/css" />

	<script type="text/javascript">
		var url = location.href.split('#')[0];
		pair = url.split('?');
		var file = pair[0];
		var qs = (pair[1] || "").split('&');

		function geturlparam(name) {
			var ne = name + "=";
			for (var i = 0; i < qs.length; i++) {
				if (qs[i].substring(0, ne.length) == ne) {
					return qs[i].substring(ne.length);
				}
			}
		}
		function changeurlparam(name, value) {
			if (!pair[1]) {
				location.href = file + "?" + name + "=" + value;
				return;
			}
			var ne = name + "=";
			for (var i = 0; i < qs.length; i++) {
				if (qs[i].substring(0, ne.length) == ne) {
					qs[i] = name + "=" + value
					location.href = file + "?" + qs.join('&');
					return;
				}
			}
			qs.push(name + "=" + value);
			location.href = file + "?" + qs.join('&');
		}
		function changeskin(skin) {
			changeurlparam("skin", skin);
		}
		function changetoolbar(toolbar) {
			changeurlparam("toolbar", toolbar);
		}

	</script>

</head>
<body>
	<form id="Form1" method="post" runat="server">
		<h1>
			Skinning the Editor</h1>
		<p>
			Editor skinning is done via CSS. Rich Text Editor provides several built-in skins
			that are ready to use. You can choose from several predefined skins or create your
			own.</p>
		<br />
		<div>
        Skin:
        <select id='selskin' onchange='changeskin(this.value)'>
            <option value=''>select a skin</option>
            <option value='office2007blue'>office2007blue</option>
            <option value='office2007silver'>office2007silver</option>
            <option value='office2007silver2'>office2007silver2</option>
            <option value='office2010blue'>office2010blue</option>
            <option value='office2010blue2'>office2010blue2</option>
            <option value='office2010silver'>office2010silver</option>
            <option value='office2010silver2'>office2010silver2</option>
            <option value='office2010black'>office2010black</option>
            <option value='office2003blue'>office2003blue</option>
            <option value='office2003silver'>office2003silver</option>
            <option value='office2003silver2'>office2003silver2</option>
            <option value='officexpblue'>officexpblue</option>
            <option value='officexpsilver'>officexpsilver</option>
            <option value='smartblue'>smartblue</option>
            <option value='smartsilver'>smartsilver</option>
            <option value='smartgray'>smartgray</option>
            <option value='downlevelhtm'>downlevelhtm</option>
            <option value='downlevelubb'>downlevelubb</option>
        </select>
        &nbsp; &nbsp; Toolbar:
        <select id='seltoolbar' onchange='changetoolbar(this.value)'>
            <option value=''>select a toolbar</option>
            <option value='custom'>custom</option>
            <option value='ribbon'>ribbon</option>
            <option value='full'>full</option>
            <option value='light'>light</option>
            <option value='forum'>forum</option>
            <option value='email'>email</option>
            <option value='minimal'>minimal</option>
            <option value='none'>none</option>
        </select>
    </div>

		<script type="text/javascript">
		document.getElementById("selskin").value = geturlparam("skin") || ""
		document.getElementById("seltoolbar").value = geturlparam("toolbar") || ""
		</script>

		<p>
			<RTE:Editor runat="server" ID="Editor1" ContentCss="example.css" Text="Type here" />
		</p>
	</form>
</body>
</html>
