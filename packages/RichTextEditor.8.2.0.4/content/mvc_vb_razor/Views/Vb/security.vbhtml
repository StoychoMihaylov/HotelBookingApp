<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Programmatic Security</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Personalization and Programmatic Security Example</h1>
    <p>
        RichTextEditor allows developers to assign a pre-defined set of permissions&nbsp;by&nbsp;group&nbsp;or
        individual. This prevents a normal user to access the administration functionality.
        The details of permissions are specified by an XML security policy file. Each level
        maps to a specific file. The default mappings:
    </p>
    <ul>
        <li><strong>admin</strong>—maps to admin.config</li>
        <li><strong>default</strong>—maps to default.config</li>
        <li><strong>guest</strong>—maps to guest.config</li>
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
                                    <input id="RadioList_0" type="radio" name="SelectType" value="Administrators" onclick="MvcSubmit();" /><label
                                        for="RadioList_0">
                                        Administrators</label>
                                </td>
                                <td>
                                    <input id="RadioList_1" type="radio" name="SelectType" value="Members" onclick="MvcSubmit();" /><label
                                        for="RadioList_1">
                                        Members</label>
                                </td>
                                <td>
                                    <input id="RadioList_2" type="radio" name="SelectType" value="Guest" onclick="MvcSubmit();" /><label
                                        for="RadioList_2">
                                        Guest</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="RadioList_3" type="radio" name="SelectType" value="John" onclick="MvcSubmit();" /><label
                                        for="RadioList_3">
                                        John (admin)</label>
                                </td>
                                <td>
                                    <input id="RadioList_4" type="radio" name="SelectType" value="Mary" onclick="MvcSubmit();" /><label
                                        for="RadioList_4">
                                        Mary (sales)</label>
                                </td>
                                <td>
                                    <input id="RadioList_5" type="radio" name="SelectType" value="Tim" onclick="MvcSubmit();" /><label
                                        for="RadioList_5">
                                        Tim (financial)</label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <script type="text/javascript">
                        var ipts = document.getElementsByName("SelectType");
                        var lang = '@ViewBag._selecttype' || "";
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
                        function MvcSubmit() {
                            document.getElementById('btn_sumbit').click();
                        }
                    </script>
                    <button id="btn_sumbit" style="display: none;" type="submit">
                        Submit</button>
                </td>
                <td width="10">
                </td>
                <td style="color: red">
                    @Html.Raw(ViewBag._secstr)
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    @Html.Raw(ViewBag.Editor)
    @Code Html.EndForm()End Code
</body>
</html>
