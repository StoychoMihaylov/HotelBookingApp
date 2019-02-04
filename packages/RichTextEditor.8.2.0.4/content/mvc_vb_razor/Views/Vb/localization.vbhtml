<!DOCTYPE html>
<html>
<head>
    <title>RichTextEditor - Localization</title>
    <link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>
    @Code Html.BeginForm()End Code
    <h1>
        Built-in localization for French, Spanish, and German ...</h1>
    <p>
        RichTextEditor auto-detects Client Browser's culture setting to decide what language
        to use. If developers need server side control, we also provide API to override
        the setting acquired from client browsers(shown in example below).</p>
    <table id="MainContent_RadioList" cellspacing="2" cellpadding="2" style="border: #c0c0c0 1px solid;
        background-color: #f5f5f5; width: 770px">
        <tr>
            <td>
                <input id="MainContent_RadioList_0" type="radio" name="SelectType" value="en" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_0">English</label>
            </td>
            <td>
                <input id="MainContent_RadioList_1" type="radio" name="SelectType" value="fr-FR"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_1">French</label>
            </td>
            <td>
                <input id="MainContent_RadioList_2" type="radio" name="SelectType" value="de-de"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_2">German</label>
            </td>
            <td>
                <input id="MainContent_RadioList_3" type="radio" name="SelectType" value="nl-NL"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_3">Dutch</label>
            </td>
            <td>
                <input id="MainContent_RadioList_4" type="radio" name="SelectType" value="es-ES"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_4">Spanish</label>
            </td>
            <td>
                <input id="MainContent_RadioList_5" type="radio" name="SelectType" value="it-IT"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_5">Italian</label>
            </td>
        </tr>
        <tr>
            <td>
                <input id="MainContent_RadioList_6" type="radio" name="SelectType" value="nb-NO"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_6">Norwegian</label>
            </td>
            <td>
                <input id="MainContent_RadioList_7" type="radio" name="SelectType" value="ru-RU"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_7">Russian</label>
            </td>
            <td>
                <input id="MainContent_RadioList_8" type="radio" name="SelectType" value="ja-JP"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_8">Japanese</label>
            </td>
            <td>
                <input id="MainContent_RadioList_9" type="radio" name="SelectType" value="zh-cn"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_9">Chinese</label>
            </td>
            <td>
                <input id="MainContent_RadioList_10" type="radio" name="SelectType" value="sv-SE"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_10">Swedish</label>
            </td>
            <td>
                <input id="MainContent_RadioList_11" type="radio" name="SelectType" value="pt-BR"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_11">Portuguese</label>
            </td>
        </tr>
        <tr>
            <td>
                <input id="MainContent_RadioList_12" type="radio" name="SelectType" value="da" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_12">Danish</label>
            </td>
            <td>
                <input id="MainContent_RadioList_13" type="radio" name="SelectType" value="he-IL"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_13">Hebrew</label>
            </td>
            <td>
                <input id="MainContent_RadioList_14" type="radio" name="SelectType" value="ar" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_14">Arabic</label>
            </td>
            <td>
                <input id="MainContent_RadioList_15" type="radio" name="SelectType" value="cs" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_15">CZech</label>
            </td>
            <td>
                <input id="MainContent_RadioList_16" type="radio" name="SelectType" value="tr-TR"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_16">Turkey</label>
            </td>
            <td>
                <input id="MainContent_RadioList_17" type="radio" name="SelectType" value="vi" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_17">Vietnam</label>
            </td>
        </tr>
        <tr>
            <td>
                <input id="MainContent_RadioList_18" type="radio" name="SelectType" value="th" onclick="MvcSubmit();" /><label
                    for="MainContent_RadioList_18">Thai</label>
            </td>
            <td>
                <input id="MainContent_RadioList_19" type="radio" name="SelectType" value="ko-KR"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_19">Korean</label>
            </td>
            <td>
                <input id="MainContent_RadioList_20" type="radio" name="SelectType" value="" checked="checked"
                    onclick="MvcSubmit();" /><label for="MainContent_RadioList_20">Auto Detect</label>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var ipts = document.getElementsByName("SelectType");
        var lang = '@ViewBag._mode' || "";
        if (lang) {
            for (var i = 0; i < ipts.length; i++) {
                if (ipts[i].value == lang) {
                    ipts[i].checked = true;
                    break;
                }
            }
        }
        function MvcSubmit() {
            document.getElementById('btn_sumbit').click();
        }
    </script>
    <button id="btn_sumbit" style="display: none;" type="submit">
        Submit</button>
    <p>
        @Html.Raw(ViewBag.Editor)
    </p>
    @Code Html.EndForm()End Code
</body>
</html>
