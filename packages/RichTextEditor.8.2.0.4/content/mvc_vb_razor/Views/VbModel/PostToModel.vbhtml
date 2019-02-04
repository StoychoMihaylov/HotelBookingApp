@ModelType rtedemo.Controllers.MyModel
    
<!DOCTYPE html>
<html>
<head>
	<title>RichTextEditor - Auto adjusting height</title>
	<link rel="stylesheet" href="/Content/example.css" type="text/css" />
</head>
<body>

	@Code Using Html.BeginForm() End Code

		<h1>Post To Model </h1>
	 
	 @Code If Context.Request.HttpMethod = "POST" Then End Code
	 
		<h3>You posted this value : </h3>
		<div>Title:</div>
		<div>@Model.Title</div>
	 
		<div>Message:</div>
		<div>@Model.Message</div>
	 @Code End If End Code
		<p>
			@Html.ValidationSummary("Invalid input.")
		</p>

		<table border="1" cellspacing="0" cellpadding="5" style="border-collapse: collapse;">
			<tr>
				<td></td>
				<td>Form</td>
			</tr>
			<tr>
				<td>Title @Html.ValidationMessageFor(Function(m) m.Title)</td>
				<td>@Html.TextBoxFor(Function(m) m.Title, New With {.style = "width:500px;"})</td>
			</tr>
			<tr>
				<td>Message @Html.ValidationMessageFor(Function(m) m.Message)</td>
				<td>@Html.Raw(ViewBag.Editor)</td>
			</tr>
			<tr>
				<td>Accept</td>
				<td>@Html.CheckBoxFor(Function(m) m.Accept)
					@Html.LabelFor(Function(m) m.Accept)
					@Html.ValidationMessageFor(Function(m) m.Accept)
				</td>
			</tr>
			<tr>
				<td></td>
				<td>
					<input class="submit" type="submit" value="Submit It" /></td>
			</tr>
		</table>	 
    @Code End Using End Code

</body>
</html>
